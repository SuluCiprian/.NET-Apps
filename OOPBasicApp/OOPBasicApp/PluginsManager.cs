using System;
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
        IEnumerable<IEncoder> plugins;

        public OOPBasics.Shared.IEncoder LoadAssembly(string assemblyPath)
        {
            string assembly = Path.GetFullPath(assemblyPath);
            Assembly ptrAssembly = Assembly.LoadFile(assembly);
            types = ptrAssembly.GetTypes();
            foreach (Type item in types)
            {
                if (!item.IsClass) continue;
                if (item.GetInterfaces().Contains(typeof(OOPBasics.Shared.IEncoder)))
                {
                    return (OOPBasics.Shared.IEncoder)Activator.CreateInstance(item);
                }
            }
            throw new Exception("Invalid DLL, Interface not found!");
        }

        public Type[] GetTypes(string assemblyPath)
        {
            string assembly = Path.GetFullPath(assemblyPath);
            Assembly ptrAssembly = Assembly.LoadFile(assembly);
            types = ptrAssembly.GetTypes();
            return types;
        }

        public OOPBasics.Shared.IEncoder LoadAssemblyByName(Type[] types, string type)
        {
            foreach (Type item in types)
            {
                if (!item.IsClass) continue;
                if (item.GetInterfaces().Contains(typeof(OOPBasics.Shared.IEncoder)) && item.Name.Equals(type))
                {
                    return (OOPBasics.Shared.IEncoder)Activator.CreateInstance(item);
                }
            }
            throw new Exception("Invalid DLL, Interface not found!");
        }

        public IEnumerable<IEncoder> LoadPlugins()
        {
            IEnumerable<string>  pluginFiles = GetPluginFiles();
            foreach (string file in pluginFiles)
            {
                Assembly ptrAssembly = Assembly.LoadFile(file);
                types = ptrAssembly.GetTypes();
                foreach (Type item in types)
                {
                    if (!item.IsClass) continue;
                    if (item.GetInterfaces().Contains(typeof(IEncoder)))
                    {
                        plugins.Append<IEncoder>((IEncoder)Activator.CreateInstance(item));
                    }
                }
            }
            return plugins;
        }

        private IEnumerable<string> GetPluginFiles()
        {
            IEnumerable<string> pluginFiles = null;
            DirectoryInfo d = new DirectoryInfo(@"D:\OOPBasics");
            FileInfo[] files = d.GetFiles("*.dll");
            foreach (FileInfo file in files)
            {
                pluginFiles.Append(file.FullName);
            }
            return pluginFiles;
        }

    }
}
