
using System;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceProcess;


namespace WindowsServiceHost
{
    public partial class WindowsServiceHost : ServiceBase
    {
        private ServiceHost _serviceHost = null;
        internal const string CurrentServiceName = "WordsCounterService";
        internal const string CurrentServiceDisplayName = "Words Counter Service";
        internal const string CurrentServiceSource = "WordsCounterServiceSource";
        internal const string CurrentServiceLogName = "WordsCounterServiceLogName";
        internal const string CurrentServiceDescription = "Words Counter calculates number of lines, words snd letters in file.";

        public WindowsServiceHost()
        {
            ServiceName = CurrentServiceName;
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            if (_serviceHost != null) _serviceHost.Close();

            string address_HTTP = "http://localhost:9001/WordsCount";

            Uri[] address_base = { new Uri(address_HTTP)};
            _serviceHost = new ServiceHost(typeof(WcfService.WordsCounter), address_base);

            ServiceMetadataBehavior behavior = new ServiceMetadataBehavior();
            _serviceHost.Description.Behaviors.Add(behavior);

            BasicHttpBinding binding_http = new BasicHttpBinding();
            _serviceHost.AddServiceEndpoint(typeof(WcfService.IWordsCounter), binding_http, address_HTTP);
            _serviceHost.AddServiceEndpoint(typeof(IMetadataExchange), MetadataExchangeBindings.CreateMexHttpBinding(), "mex");

            _serviceHost.Open();
        }

        protected override void OnStop()
        {
            try
            {
                _serviceHost.Close();
            }
            catch (Exception ex)
            {
                //ex.Message
            }
        }
    }
}
