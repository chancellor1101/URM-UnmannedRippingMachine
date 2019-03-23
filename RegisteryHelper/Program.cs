using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RegisteryHelper
{
    class Program
    {
        static void Main(string[] args)
        {
            bool startupAsShell = Convert.ToBoolean(args[0]);
            string appLocation = args[1];
            RegistryKey localMachine = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, RegistryView.Registry64);
            RegistryKey rkApp = localMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion\Winlogon", true);
            switch (startupAsShell)
            {
                case true:
                    //make it the shell
                    if (!IsStartupItem(appLocation, rkApp))
                        rkApp.SetValue("Shell", appLocation, RegistryValueKind.String);
                    break;
                case false:
                    if (IsStartupItem(appLocation, rkApp))
                        rkApp.SetValue("Shell", "explorer.exe",RegistryValueKind.String); // Revert back to windows
                    break;
            }
            rkApp.Flush();
            rkApp.Close();
        }

        static bool IsStartupItem(string appLocation, RegistryKey registery)
        {
            if (registery.GetValue("Shell").ToString() == appLocation)
                // The value doesn't exist, the application is not set to run at startup
                return true;
            else
                // The value exists, the application is set to run at startup
                return false;
        }
    }
}
