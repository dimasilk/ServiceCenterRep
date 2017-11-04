using System;
using System.Diagnostics;
using System.ServiceModel;

namespace ServiceCenter.UI.Infrastructure
{
    public abstract class WcfClientBase<T> : IDisposable where T : class
    {
        protected WcfClientBase(ChannelFactory<T> channelFactory)
        {
            this._channelFactory = channelFactory;
            if (_channelFactory == null) throw new InvalidOperationException("Unable to create channel factory");
            Open();
        } 
        protected T Channel;
        private readonly ChannelFactory<T> _channelFactory;
       // [Dependency]
       // public ChannelFactory<T> ChannelFactory { set { _channelFactory = value; } }

        public void Dispose()
        {
            CleanupChannel();
            CleanupChannelFactory();
        }

        private void CleanupChannelFactory()
        {
            try
            {
                _channelFactory.Close();
            }
            catch
            {
                try
                {
                    _channelFactory.Abort();
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                }
            }
        }

        public void CleanupChannel()
        {
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

        private void Open()
        {
            if (Channel != null) return;
            _channelFactory.Credentials.UserName.UserName = "123";
            _channelFactory.Credentials.UserName.Password = "123";
            Channel = _channelFactory.CreateChannel();
            ((IClientChannel)Channel).Open();
        }
    }
}
