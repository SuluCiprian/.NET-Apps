using System;
using System.Collections.Generic;
using System.Text;

namespace OOPBasicApp
{
    public delegate void MenuItemAction(object sender);
    public class MenuItem
    {
        public char ShortcutChar { get; set; }
        public String Text { get; set; }
        public MenuItemAction ActionToExecute { get; set; }
    }
}
