using System;
using System.Diagnostics;
using System.ServiceModel;
using System.Threading.Tasks;
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

        protected Task<T> AsyncChannel
        {
            get { return _lazyChannel.IsValueCreated ? Task.FromResult(Channel) : Task<T>.Factory.StartNew(() => Channel); }
        }

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
                var communicationObject = (IClientChannel)channel;
                communicationObject.Faulted += CommunicationObject_Faulted;
                communicationObject.Open();
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

        private void CommunicationObject_Faulted(object sender, EventArgs e)
        {
            var communicationObject = (IClientChannel)sender;
            communicationObject.Faulted -= CommunicationObject_Faulted;
            CleanupChannel(communicationObject);
            CleanupChannelFactory(_lazyFactory.Value);
            Init();
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
