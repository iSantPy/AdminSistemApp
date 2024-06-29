using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json.Linq;

namespace ControlAguaPotable
{
    public static class DynamicConfig
    {
        private static JObject _config;
        private static readonly string _configPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "dynamicConfig.json");

        static DynamicConfig()
        {
            LoadConfig();
        }

        private static void LoadConfig()
        {
            if (File.Exists(_configPath))
            {
                var json = File.ReadAllText(_configPath);
                _config = JObject.Parse(json);
            }
            else
            {
                _config = new JObject();
            }
        }

        public static decimal GetFloat(string key, decimal defaultValue = 0)
        {
            return _config.ContainsKey(key) ? _config[key].Value<decimal>() : defaultValue;
        }

        public static void SetFloat(string key, decimal value)
        {
            _config[key] = value;
            SaveConfig();
        }

        private static void SaveConfig()
        {
            File.WriteAllText(_configPath, _config.ToString());
        }
    }
}
