using System;
using System.Collections.Generic;
using System.Text;

namespace ControllerApp
{
    class ModifyView: View
    {
        private StudentController controller;

        public ModifyView(StudentController controller)
        {
            this.controller = controller;
        }

        public override View Execute()
        {
            Student student = new Student();
            Console.WriteLine("Id: ");
            student.FirstName = Console.ReadLine();
            Console.WriteLine("First name: ");
            student.FirstName = Console.ReadLine();
            Console.WriteLine("Last name: ");
            student.LastName = Console.ReadLine();
            Console.WriteLine("Group: ");
            student.Group = Console.ReadLine();
            Console.WriteLine(": ");
            student.FirstName = Console.ReadLine();

            View retView = controller.Modify(student);
            return retView;
        }
    }
}
