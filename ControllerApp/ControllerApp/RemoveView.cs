using System;
using System.Collections.Generic;
using System.Text;

namespace ControllerApp
{
    class RemoveView : View
    {
        private StudentController controller;

        public RemoveView(StudentController controller)
        {
            this.controller = controller;
        }

        public override View Execute()
        {
            Student student = new Student();
            Console.WriteLine("Remove student with id: ");
            student.Id = Int32.Parse(Console.ReadLine());

            View retView = controller.RemoveStudent(student);
            return retView;
        }
    }
}
