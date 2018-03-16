﻿using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Linq;
using System.IO;
using OOPBasics.Shared;

namespace OOPBasicApp
{
    class PluginsManager
    {
        private Type[] types;
        List<IPlugin> plugins = new List<IPlugin>();

        public IEnumerable<IPlugin> Plugins
        {
            get
            {
                return plugins.AsReadOnly();
            }
        }

        public void LoadPlugins()
        {
            IEnumerable<string> pluginFiles = GetPluginFiles();
            foreach (string file in pluginFiles)
            {
                Type pluginIfType = typeof(IPlugin);
                Assembly ptrAssembly = Assembly.LoadFile(file);
                types = ptrAssembly.GetExportedTypes();
                foreach (var item in types)
                {
                    if (!item.IsClass) continue;
                    if (pluginIfType.IsAssignableFrom(item))
                    {
                        plugins.Add((IPlugin)Activator.CreateInstance(item));
                    }
                }
            }
           
        }     
        

        private IEnumerable<string> GetPluginFiles()
        {
            List<string> pluginFiles = new List<string>() ;
            DirectoryInfo d = new DirectoryInfo(@"D:\OOPBasics");
            FileInfo[] files = d.GetFiles("*.dll");
            foreach (FileInfo file in files)
            {
                pluginFiles.Add(file.FullName);
            }
            return pluginFiles;
        }

    }
}