using System;
using System.Collections.Generic;
using System.Text;

namespace ControllerApp
{
    class StudentController
    {
        private List<Student> students = new List<Student>();

        public void AddStudent()
        {
            Student student = new Student();
            HandleStudentDetails(student);
            students.Add(student);
        }

        public void RemoveStudent()
        {
            Console.WriteLine("Remove student with id: ");
            int id = Int32.Parse(Console.ReadLine());
            foreach (var student in students)
            {
                if (student.Id == id)
                {
                    students.Remove(student);
                    break;
                }
            }
        }

        public void Modify()
        {
            Console.WriteLine("Modify student with id: ");
            int id = Int32.Parse(Console.ReadLine());
            foreach (var student in students)
            {
                if (student.Id == id)
                {
                    HandleStudentDetails(student);
                    break;
                }
            }
        }

        public void ViewStudents()
        {
            foreach (var student in students)
            {
                Console.WriteLine(student.Id);
                Console.WriteLine(student.FirstName);
                Console.WriteLine(student.LastName);
                Console.WriteLine(student.Group);
                Console.WriteLine("Press any key to continue");
            }
            Console.ReadKey();
        }
        public void HandleStudentDetails(Student student)
        {
            List<string> arguments = (List<string>)student.GetRequiredAttributes();
            if (arguments.Count != 0)
            {
                Dictionary<string, string> parameters = new Dictionary<string, string>();
                Console.WriteLine("Enter parameters: ");
                foreach (var arg in arguments)
                {
                    Console.WriteLine(arg + ": ");
                    parameters[arg] = Console.ReadLine();
                }
                student.SetAttributes(parameters);
            }
        }
    }
}
