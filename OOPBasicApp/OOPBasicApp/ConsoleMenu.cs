using System;
using System.Collections.Generic;
using System.Text;

namespace OOPBasicApp
{
    public class ConsoleMenu
    {
        private List<MenuItem> items = new List<MenuItem>();
        private bool continueLoop = true;

        public ConsoleMenu()
        {
            AddItem(new MenuItem { ShortcutChar = '0', Text = "Exit", ActionToExecute = new MenuItemAction(ExitMenu) });
        }

        public void AddItem(MenuItem item)
        {
            items.Add(item);
        }
        private void DisplayMenu()
        {
            Console.Clear();
            foreach (var item in items)
            {
                Console.WriteLine("{0}. {1}", item.ShortcutChar, item.Text);
            }
        }
        public void Run()
        {
            continueLoop = true;
            while (continueLoop)
            {
                DisplayMenu();
                ConsoleKeyInfo key = Console.ReadKey();
                foreach (var item in items)
                {
                    if (item.ShortcutChar == key.KeyChar)
                    {
                        if (item.ActionToExecute != null)
                        {
                            item.ActionToExecute(this);
                        }
                    }
                }
            }
        }

        private void ExitMenu(object sender)
        {
            continueLoop = false;
        }

    }
}
