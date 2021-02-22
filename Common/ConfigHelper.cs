using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace NetCoreMixProject
{
    public class ConfigHelper
    {
        static IConfigurationBuilder _Builder;
        static IConfigurationRoot _Root;

        static IConfigurationBuilder Builder
        {
            get {
                if (_Builder == null)
                {
                    string basePath = Directory.GetCurrentDirectory();
                    _Builder = new ConfigurationBuilder();
                    _Builder.SetBasePath(basePath);
                    _Builder.AddJsonFile("config.json", optional: false, reloadOnChange: true);
                }
                return _Builder;
            }
        }

        static IConfigurationRoot Root
        {
            get
            {
                if (_Root == null)
                {
                    _Root = Builder.Build();
                }
                return _Root;
            }
        }

        public static IConfigurationSection Get(string Key)
        {
            return Root.GetSection(Key);
        }
    }
}
