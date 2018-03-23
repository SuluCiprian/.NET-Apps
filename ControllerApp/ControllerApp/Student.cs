using System;
using System.Collections.Generic;
using System.Text;

namespace ControllerApp
{
    public class Student
    {
        public int Id { get; set; }        
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Group { get; set; }

        //public List<Student> Students
        //{
        //    get
        //    {
        //        return students;
        //    }
        //}

        //public IEnumerable<string> GetRequiredAttributes()
        //{
        //    return attributes;
        //}

        //public void SetAttributes(IDictionary<string, string> attrib)
        //{
        //    id = Int32.Parse(attrib["id"]);
        //    firstName = attrib["firstName"];
        //    lastName = attrib["lastName"];
        //    group = attrib["group"];
        //}
    }
}
