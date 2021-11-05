using System;
using System.IO;
using System.Linq;
using System.Reflection;
using Autofac;

namespace Tools.Ioc
{
    public static class AutofacSetUp
    {
        public static ContainerBuilder AutoRegisterModules(ContainerBuilder builder)
        {
            var assemblies = Directory.EnumerateFiles(AppDomain.CurrentDomain.BaseDirectory, "*.dll", SearchOption.TopDirectoryOnly)
                                      .Where(filePath => Path.GetFileName(filePath).StartsWith("Sample."))
                                      .Select(Assembly.LoadFrom)
                                      .ToArray();
            builder.RegisterAssemblyModules(assemblies);
            return builder;
        }
    }
}
