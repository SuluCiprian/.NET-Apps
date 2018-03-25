using System;
using System.Collections.Generic;
using System.Text;

namespace ControllerApp
{
    class StudentController
    {
        private List<Student> students = new List<Student>();
        private ConsoleMenu consoleMenu;


        //public View Index()
        //{
        //    consoleMenu.AddItem(new MenuItem { ShortcutChar = '1', Text = "Add Student", ContextObject = students, ItemAction = new MenuItemAction(AddStudent) }); ;
        //    return new MainView();
        //}

        public MainView AddStudent(Student student)
        {
            students.Add(student);
            
            return new MainView();
        }

        public View RemoveStudent(Student studentToRemove)
        {
            for (int i = 0; i < students.Count; i++)
            {
                if (students[i] == studentToRemove)
                {
                    students.Remove(studentToRemove);
                    break;
                }
            }
            return new MainView();
        }

        public View Modify(Student studentToModify)
        {
            for (int i = 0; i < students.Count; i++)
            {
                if (students[i] == studentToModify)
                {
                    students[i] = studentToModify;
                    break;
                }
            }
            return new MainView();
        }

        public View ViewStudents()
        {
            foreach (var student in students)
            {
                Console.WriteLine("\n" + student.Id);
                Console.WriteLine(student.FirstName);
                Console.WriteLine(student.LastName);
                Console.WriteLine(student.Group);
            }
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            return new MainView();
        }        

    }
}
