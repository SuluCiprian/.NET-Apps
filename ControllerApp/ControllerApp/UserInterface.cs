using System;
using System.Collections.Generic;
using System.Text;

namespace ControllerApp
{
    class UserInterface
    {
        private bool continueLoop = true;
        
        private void DisplayMenu()
        {
            Console.Clear();
            Console.WriteLine("0. Exit");
            Console.WriteLine("1. Add Student");
            Console.WriteLine("2. Delete Student");
            Console.WriteLine("3. Modify Student");
            Console.WriteLine("4. View Student");
        }

        public void Run()
        {
            continueLoop = true;
            StudentController controller = new StudentController();
            while (continueLoop)
            {
                DisplayMenu();
                ConsoleKeyInfo keyInfo = Console.ReadKey();
                switch(keyInfo.KeyChar)
                {
                    case '0':
                        continueLoop = false;
                        break;
                    case '1':
                        controller.AddStudent();
                        break;
                    case '2':
                        controller.RemoveStudent();
                        break;
                    case '3':
                        controller.Modify();
                        break;
                    case '4':
                        controller.ViewStudents();
                        break;
                }
            }
        }
    }
}
