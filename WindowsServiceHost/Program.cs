using System;
using System.ServiceProcess;
using System.Configuration.Install;
using System.Reflection;
using System.Windows;

namespace WindowsServiceHost
{
    static class Program
    {
        static void Main(string[] args)
        {

            //Thread.Sleep(10000);
            bool isInstalled = false;
            bool serviceStarting = false;
            const string serviceName = WindowsServiceHost.CurrentServiceName;

            ServiceController[] services = ServiceController.GetServices();

            foreach (ServiceController service in services)
            {
                if (!service.ServiceName.Equals(serviceName))
                    continue;
                isInstalled = true;
                if (service.Status == ServiceControllerStatus.StartPending)
                {
                    serviceStarting = true;
                }

                break;
            }

            if (!serviceStarting)
            {
                if (isInstalled)
                {
                    MessageBoxResult dr =
                        MessageBox.Show(string.Format("Do You REALLY Want To Uninstall {0}", serviceName),
                            "Danger", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                    if (dr != MessageBoxResult.Yes)
                        return;
                    SelfInstaller.UninstallMe();
                    MessageBox.Show(string.Format("{0} Successfully Uninstalled", serviceName),
                        "Status", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show(
                        SelfInstaller.InstallMe()
                            ? string.Format("{0} Successfully Installed", serviceName)
                            : string.Format("{0} FAILED To Install", serviceName),
                        "Status", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            else
            {
                var servicesToRun = new ServiceBase[] { new WindowsServiceHost(), };
                ServiceBase.Run(servicesToRun);
            }
        }
    }

    internal static class SelfInstaller
    {
        private static readonly string ExePath = Assembly.GetExecutingAssembly().Location;

        internal static bool InstallMe()
        {
            try
            {
                ManagedInstallerClass.InstallHelper(
                    new[] { ExePath });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }

            return true;
        }

        internal static bool UninstallMe()
        {
            try
            {
                ManagedInstallerClass.InstallHelper(
                    new[] { "/u", ExePath });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }

            return true;
        }
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        /*static void Main()
        {
            /ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            {
                new WindowsServiceHost()
            };
            ServiceBase.Run(ServicesToRun);
        }*/
    }
}
