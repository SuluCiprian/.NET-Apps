using System;
using System.Collections.Generic;
using System.Text;

namespace GraphicalApp
{
    public class ConsoleMenu
    {
        private bool continueLoop = true;
        private List<MenuItem> menuItems = new List<MenuItem>();
        public ConsoleMenu()
        {
            AddItem(new MenuItem { ShortcutChar = '0', Text = "Exit", ItemAction = new MenuItemAction(ExitMenu) });
        }

        public void AddItem(MenuItem item)
        {
            menuItems.Add(item);
        }
        private void DisplayMenu()
        {
            Console.Clear();
            foreach (var item in menuItems)
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
                ConsoleKeyInfo keyInfo = Console.ReadKey();
                foreach (var item in menuItems)
                {
                    if (item.ShortcutChar == keyInfo.KeyChar)
                    {
                        if (item.ItemAction != null)
                        {
                            item.ItemAction(this, item.ContextObject);
                        }
                    }
                }
            }
        }

        private void ExitMenu(object sender, object contextObject)
        {
            continueLoop = false;
        }
    }
}
