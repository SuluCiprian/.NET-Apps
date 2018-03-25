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

       public void Initialize()
        {
            AddView addView = new AddView(controller);
            RemoveView removeView = new RemoveView(controller);
            ModifyView modifyView = new ModifyView(controller);
            StudentsView studentsView = new StudentsView(controller);

            consoleMenu.AddItem(new MenuItem { ShortcutChar = '1', Text = "Add student", ContextObject = addView, ItemAction = new MenuItemAction(AddAction) });
            consoleMenu.AddItem(new MenuItem { ShortcutChar = '2', Text = "Remove student", ContextObject = removeView, ItemAction = new MenuItemAction(RemoveAction) });
            consoleMenu.AddItem(new MenuItem { ShortcutChar = '3', Text = "Modify student", ContextObject = modifyView, ItemAction = new MenuItemAction(ModifyAction) });
            consoleMenu.AddItem(new MenuItem { ShortcutChar = '4', Text = "View students", ContextObject = studentsView, ItemAction = new MenuItemAction(ViewAction) });

        }

        public override View Execute()
        {
            return this;
        }

        public void AddAction(object sender, object context)
        {
            AddView addView = (AddView)context;
            addView.Execute();
        }

        public void ViewAction(object sender, object context)
        {
            StudentsView studentsView = (StudentsView)context;
            studentsView.Execute();
        }

        public void RemoveAction(object sender, object context)
        {
            RemoveView removeView = (RemoveView)context;
            removeView.Execute();
        }

        public void ModifyAction(object sender, object context)
        {
            ModifyView modifyView = (ModifyView)context;
            modifyView.Execute();
        }

        public void Action(object sender, object context)
        {
            Type type = context.GetType();
           
        }

        public void RunApp()
        {
            consoleMenu.Run();
        }
    }
}
