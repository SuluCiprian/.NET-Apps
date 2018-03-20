using System;
using System.Collections.Generic;
using System.Text;
using OOPBasics.Shared;

namespace OOPBasicApp
{
    public class AppManager
    {
        private PluginsManager<IPlugin> encoderPlugins;
        private PluginsManager<IDecoderPlugin> decoderPlugins;
        private String dllPath = @"D:\OOPBasics";
        ConsoleMenu menu = new ConsoleMenu();

        public AppManager()
        {
            encoderPlugins = new PluginsManager<IPlugin>(dllPath);
            decoderPlugins = new PluginsManager<IDecoderPlugin>(dllPath);
        }

        public void Initialize()
        {
            menu.AddItem(new MenuItem { ShortcutChar = '1', Text = "Test", ActionToExecute = new MenuItemAction(DoTest) });
        }

        public void RunApp()
        {
            menu.Run();
        }

        private void DoTest(object sender)
        {
            Console.WriteLine("This is a test");
            Console.ReadLine();
        }



    }
}
