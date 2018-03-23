using System;
using System.Collections.Generic;
using System.Text;

namespace ControllerApp
{
    class StudentController
    {
        private Student model;
        private StudentView view;
        private List<Student> students = new List<Student>();

        //public StudentController(Student model, StudentView view)
        //{
        //    this.model = model;
        //    this.view = view;
        //}

        public void Index(MainView mainView)
        {

             mainView.Execute();
        }

        public void AddStudent()
        {
            view.HandleStudentDetails(model);
            students.Add(model);
        }

        public void RemoveStudent()
        {
            foreach (var student in students)
            {
                if (student.Id == view.GetId("Remove"))
                {
                    students.Remove(student);
                    break;
                }
            }
        }

        public void Modify()
        {
            foreach (var student in students)
            {
                if (student.Id == view.GetId("Modify"))
                {
                    view.HandleStudentDetails(student);
                    break;
                }
            }
        }

        public void ViewStudents()
        {
            view.PrintStudentsDetails(students);
        }


    }
}
