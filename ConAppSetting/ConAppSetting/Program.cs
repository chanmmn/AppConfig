
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Xml;

namespace ConAppSetting
{
    class Program
    {
        static void Main(string[] args)
        {
            GetAppSetting("1");
            AddKey();
            GetAppSetting("6");
            //AddXML();

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        public static void GetAppSetting(string value)
        {
            string str = System.Configuration.ConfigurationManager.AppSettings[value];          
            Console.WriteLine(str);
        }

        public static void AddKey()
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings.Add("6", "creditcard/6");
            config.Save(ConfigurationSaveMode.Modified,true);
            config.SaveAs(@"D:\test\other\ConAppSetting\ConAppSetting\App.config", ConfigurationSaveMode.Full);

            ConfigurationManager.RefreshSection("appSettings");
        }

        public static void AddXML()
        {
            var xmlDoc = new XmlDocument();
            xmlDoc.Load(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);

            // create new node <add key="Region" value="Canterbury" />
            var nodeRegion = xmlDoc.CreateElement("add");
            nodeRegion.SetAttribute("key", "Region");
            nodeRegion.SetAttribute("value", "Canterbury");

            xmlDoc.SelectSingleNode("//appSettings").AppendChild(nodeRegion);
            xmlDoc.Save(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);

            ConfigurationManager.RefreshSection("appSettings");
        }

        public static void RefreshSection()
        {
            ConfigurationManager.RefreshSection("appSettings");
            //Properties.Settings.Default.Reload();
            
        }

    }
}
