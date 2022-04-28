using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaredaProject.Project.Others
{
    class TimeConfig
    {
        public static readonly string CONFIG_PATH = Main.GetGeneralLogPath() + "time";
        public static readonly string LOG_START_TIME = "LogStartTime";
        public static readonly string LOG_END_TIME = "LogEndTime";
        public static bool IsConfigRestoreEnable(string dbName)
        {
            return !ReadConfig(dbName, LOG_START_TIME).Equals("Không thể phục hồi");
        }
        public static void ClearConfig(string dbName)
        {
            ClearConfig(dbName, LOG_START_TIME);
            ClearConfig(dbName, LOG_END_TIME);
        }
        public static void DisableConfig(string dbName)
        {
            WriteConfig(dbName, LOG_START_TIME, "Không thể phục hồi");
            WriteConfig(dbName, LOG_END_TIME, "Không thể phục hồi");
        }
        public static void WriteConfig(string dbName, string key, string value)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(CONFIG_PATH);
            string realKey = GenerateKey(dbName, key);
            config.AppSettings.Settings.Remove(realKey);
            config.AppSettings.Settings.Add(realKey, value);
            config.Save(ConfigurationSaveMode.Minimal);
        }
        public static bool ConfigHasKey(string dbName, string key)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(CONFIG_PATH);
            string realKey = GenerateKey(dbName, key);
            foreach (string element in config.AppSettings.Settings.AllKeys)
            {
                if (element.Equals(realKey)) return true;
            }
            return false;
        }
        public static string ReadConfig(string dbName, string key)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(CONFIG_PATH);
            string realKey = GenerateKey(dbName, key);
            string[] keys = config.AppSettings.Settings.AllKeys;
            foreach (string element in keys)
            {
                if (element == realKey)
                    return config.AppSettings.Settings[realKey].Value;
            }
            return string.Empty;
        }
        public static void ClearConfig(string dbName, string key)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(CONFIG_PATH);
            config.AppSettings.Settings.Remove(GenerateKey(dbName, key));
            config.Save(ConfigurationSaveMode.Minimal);
        }
        private static string GenerateKey(string dbName, string key)
        {

            return $"{dbName}_{key}";
        }

        public static void CheckConfigExists()
        {
            if (!File.Exists(CONFIG_PATH))
            {
                File.Create(CONFIG_PATH);
            }
        }
    }
}
