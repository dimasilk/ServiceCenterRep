using System;
using System.Diagnostics;
using System.ServiceModel;
using ServiceCenter.UI.Infrastructure.Interfaces;

namespace ServiceCenter.UI.Infrastructure
{
    public abstract class WcfClientBase<T> : IDisposable where T : class
    {
        private readonly ILoginService _loginService;
        private Lazy<ChannelFactory<T>> _lazyFactory;
        private Lazy<T> _lazyChannel;
        protected WcfClientBase(ILoginService loginService)
        {
            _loginService = loginService;
            Init();
        }

        private void Init()
        {
            _lazyFactory = new Lazy<ChannelFactory<T>>(CreateChannelFactory);
            _lazyChannel = new Lazy<T>(CreateChannel);
        }

        protected T Channel => _lazyChannel.Value;
       
        public void Dispose()
        {
            if (!_lazyChannel.IsValueCreated) return;
            CleanupChannel((ICommunicationObject)_lazyChannel.Value);
            if (!_lazyFactory.IsValueCreated) return;
            CleanupChannelFactory(_lazyFactory.Value);
        }

        private void CleanupChannelFactory(ChannelFactory<T> factory)
        {
            try
            {
                factory.Close();
            }
            catch
            {
                try
                {
                    factory.Abort();
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                }
            }
        }

        public void CleanupChannel(ICommunicationObject channel)
        {
            try
            {
                channel.Close();
            }
            catch
            {
                try
                {
                    channel.Abort();
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                }
            }
        }

        private T CreateChannel()
        {
            var channel = _lazyFactory.Value.CreateChannel();
            try
            {
                ((IClientChannel)channel).Open();
                return channel;
            }
            catch (Exception)
            {
                CleanupChannel((ICommunicationObject)channel);
                CleanupChannelFactory(_lazyFactory.Value);
                Init();
                throw;
            }
        }

        private ChannelFactory<T> CreateChannelFactory()
        {
            var c = new ChannelFactory<T>(typeof(T).Name);
            // ReSharper disable once PossibleNullReferenceException
            c.Credentials.UserName.UserName = _loginService.GetUserName();
            c.Credentials.UserName.Password = _loginService.GetUserPassword();
            return c;
        }
    }
}
