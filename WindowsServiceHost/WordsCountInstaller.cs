using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Linq;
using System.ServiceProcess;
using System.Threading.Tasks;

namespace WindowsServiceHost
{
    [RunInstaller(true)]
    public partial class WordsCountInstaller : System.Configuration.Install.Installer
    {
        private ServiceProcessInstaller _serviceProcessInstaller;
        private ServiceInstaller _serviceInstaller;

        public WordsCountInstaller()
        {
            InitializeComponent();
            _serviceProcessInstaller = new ServiceProcessInstaller();
            _serviceInstaller = new ServiceInstaller();
            _serviceProcessInstaller.Account = ServiceAccount.LocalSystem;
            _serviceProcessInstaller.Password = null;
            _serviceProcessInstaller.Username = null;
            _serviceInstaller.ServiceName = WindowsServiceHost.CurrentServiceName;
            _serviceInstaller.DisplayName = WindowsServiceHost.CurrentServiceDisplayName;
            _serviceInstaller.Description = WindowsServiceHost.CurrentServiceDescription;
            _serviceInstaller.StartType = ServiceStartMode.Automatic;
            Installers.AddRange(new Installer[]
            {
                _serviceProcessInstaller,
                _serviceInstaller
            });
        }
    }
}
