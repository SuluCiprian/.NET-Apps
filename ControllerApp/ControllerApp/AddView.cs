using System;
using System.Collections.Generic;
using System.Text;

namespace ControllerApp
{
    class AddView
    {
        private StudentController controller;

        public AddView(StudentController controller)
        {
            controller.AddStudent();
        }
    }
}
