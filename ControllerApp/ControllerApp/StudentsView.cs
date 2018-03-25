using System;
using System.Collections.Generic;
using System.Text;

namespace ControllerApp
{
    class StudentsView: View
    {
        private StudentController controller;

        public StudentsView(StudentController controller)
        {
            this.controller = controller;
        }

        public override View Execute()
        {
            View retView = controller.ViewStudents();
            return retView;
        }
    }
}
