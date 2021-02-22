﻿using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Autofac;

namespace NetCoreMixProject
{
    public class AutofacModuleRegister : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(GetAssemblyByName("AuditLog.EF"))
           .Where(a => a.Name.EndsWith("Repository"))
           .AsImplementedInterfaces();

            builder.RegisterAssemblyTypes(GetAssemblyByName("AuditLog.Application"))
                .Where(a => a.Name.EndsWith("Service"))
                .AsImplementedInterfaces();

            //注册MVC控制器（注册所有到控制器，控制器注入，就是需要在控制器的构造函数中接收对象）
            builder.RegisterAssemblyTypes(GetAssemblyByName("AuditLogDemo"))
                .Where(a => a.Name.EndsWith("Controller"))
                .AsImplementedInterfaces();
        }

        /// <summary>
        /// 根据程序集名称获取程序集
        /// </summary>
        /// <param name="assemblyName">程序集名称</param>
        public static Assembly GetAssemblyByName(string assemblyName)
        {
            return Assembly.Load(assemblyName);
        }

    }
}
