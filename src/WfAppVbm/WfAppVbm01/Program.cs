using Syncfusion.Windows.Forms;
using Syncfusion.WinForms.Controls;
using System;
using System.Windows.Forms;

namespace WfAppVbm01
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var licenseKey = "MzI5MDA4NkAzMjM1MmUzMDJlMzBGekgvNTNiOXpTQUh3L2NBRTg2djhRZDZIOUh4TE9BdFlCaU9DMS85ZTlRPQ==";
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense(licenseKey);
            SfSkinManager.LoadAssembly(typeof(Office2016Theme).Assembly);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Pages.Setup.CheckSqlServerInstancesDialog());
        }
    }
}
