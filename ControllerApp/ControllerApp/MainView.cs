using System;
using System.Collections.Generic;
using System.Text;

namespace ControllerApp
{
    class MainView: View
    {
        private ConsoleMenu consoleMenu;
        private StudentController controller;

        public MainView()
        {
            this.consoleMenu = new ConsoleMenu();
            this.controller = new StudentController();
        }

       

        public override View Execute()
        {
            return this;
        }

        public void AddAction(object sender, object context)
        {
            AddView view = (AddView)Execute();
        }

        public void RunApp()
        {
            consoleMenu.Run();
        }
    }
}
