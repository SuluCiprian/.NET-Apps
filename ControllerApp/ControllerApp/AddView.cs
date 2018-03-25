﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ControllerApp
{
    class AddView: View
    {
        private StudentController controller;
        private ConsoleMenu consoleMenu;

        public AddView(StudentController controller)
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

           

            View retView = controller.AddStudent(student);
            return retView;
        }

        public void AddAction(object sender, object context)
        {
            AddView view = (AddView)Execute();
        }
    }
}