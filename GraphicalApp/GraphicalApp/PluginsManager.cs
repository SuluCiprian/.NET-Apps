using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace GraphicalApp
{
    class PluginsManager<T>
    {
        private Type[] types;
        List<T> plugins = new List<T>();
        private string dllPath;
        public PluginsManager()
        {

        }

        public PluginsManager(string dllPath)
        {
            this.dllPath = dllPath;
        }

        public IEnumerable<T> Plugins
        {
            get
            {
                return plugins.AsReadOnly();
            }
        }

        public void LoadPlugins(string path)
        {
            IEnumerable<string> pluginFiles = GetPluginFiles(path);
            foreach (string file in pluginFiles)
            {
                Type pluginIfType = typeof(T);
                Assembly ptrAssembly = Assembly.LoadFile(file);
                types = ptrAssembly.GetExportedTypes();
                foreach (var item in types)
                {
                    if (!item.IsClass) continue;
                    if (pluginIfType.IsAssignableFrom(item))
                    {
                        plugins.Add((T)Activator.CreateInstance(item));
                    }
                }
            }

        }
        private IEnumerable<string> GetPluginFiles(string path)
        {
            List<string> pluginFiles = new List<string>();
            DirectoryInfo d = new DirectoryInfo(path);
            FileInfo[] files = d.GetFiles("*.dll");
            foreach (FileInfo file in files)
            {
                pluginFiles.Add(file.FullName);
            }
            return pluginFiles;
        }

    }
}
