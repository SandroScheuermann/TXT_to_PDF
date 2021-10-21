using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace TXT_to_PDF
{
    public class JsonConfig
    {
        protected const string pathAppConfig = "appsettings.json";

        protected static void Save(JObject newAppConfig)
        {
            File.WriteAllText(pathAppConfig, JsonConvert.SerializeObject(newAppConfig));
        }
        public static JObject AppConfig => JObject.Parse(File.ReadAllText(pathAppConfig));
        public static string In_TXT => AppConfig["In_TXT"].ToString();
        public static string Out_PDF => AppConfig["Out_PDF"].ToString();
    }
}
