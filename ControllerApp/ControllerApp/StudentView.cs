using System;
using System.Collections.Generic;
using System.Text;

namespace ControllerApp
{
    class StudentView
    {

        public void PrintStudentsDetails(List<Student> students)
        {
            foreach (var student in students)
            {
                Console.WriteLine("\n" + student.Id);
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
                Console.WriteLine("\n Enter parameters: ");
                foreach (var arg in arguments)
                {
                    Console.WriteLine(arg + ": ");
                    parameters[arg] = Console.ReadLine();
                }
                student.SetAttributes(parameters);
            }
        }

        public int GetId(string message)
        {
            Console.WriteLine(message + " student with id: ");
            int id = Int32.Parse(Console.ReadLine());
            return id;
        }
    }
}
