using System;
using System.Diagnostics;
using System.ServiceModel;
using ServiceCenter.UI.Infrastructure.Interfaces;

namespace ServiceCenter.UI.Infrastructure
{
    public abstract class WcfClientBase<T> : IDisposable where T : class
    {
        private readonly ILoginService _loginService;
        private readonly Lazy<ChannelFactory<T>> _lazyFactory;
        private readonly Lazy<T> _lazyChannel;
        protected WcfClientBase(ILoginService loginService)
        {
            _loginService = loginService;
            _lazyFactory = new Lazy<ChannelFactory<T>>(CreateChannelFactory);
            _lazyChannel = new Lazy<T>(CreateChannel);
        }

        protected T Channel => _lazyChannel.Value;
       
        public void Dispose()
        {
            CleanupChannel();
            CleanupChannelFactory();
        }

        private void CleanupChannelFactory()
        {
            if (!_lazyFactory.IsValueCreated) return;
            try
            {
                _lazyFactory.Value.Close();
            }
            catch
            {
                try
                {
                    _lazyFactory.Value.Abort();
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                }
            }
        }

        public void CleanupChannel()
        {
            if (!_lazyChannel.IsValueCreated) return;
            try
            {
                ICommunicationObject co = (ICommunicationObject)Channel;
                co.Close();
            }
            catch
            {
                try
                {
                    ICommunicationObject co = (ICommunicationObject)Channel;
                    co.Abort();
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
            ((IClientChannel)channel).Open();
            return channel;
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
