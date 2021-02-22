using log4net;
using log4net.Config;
using log4net.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace NetCoreMixProject.Common
{
    public class LogHelper
    {
        static ILoggerRepository repository;
        static ILog log;
        static LogHelper() {
            repository = LogManager.CreateRepository("NETCoreRepository");
            XmlConfigurator.Configure(repository, new FileInfo("log4net.config"));
            log = LogManager.GetLogger(repository.Name, "NETCorelog4net");
        }

        public static void Debug(object obj)
        {
            log.Debug(obj);
        }

        public static void Debug(object obj ,Exception ex)
        {
            log.Debug(obj ,ex);
        }


        public static void Error(object obj)
        {
            log.Error(obj);
        }

        public static void Error(object obj, Exception ex)
        {
            log.Error(obj, ex);
        }

        public static void Info(object obj)
        {
            log.Info(obj);
        }

        public static void Info(object obj, Exception ex)
        {
            log.Info(obj, ex);
        }
    }
}
