using System;
using System.Collections.Generic;
using System.Text;

namespace ControllerApp
{
    public class Student
    {
        private int id;
        private string firstName;
        private string lastName;
        private string group;
        private List<string> attributes = new List<string>();

        public Student()
        {
            attributes.Add("id");
            attributes.Add("firstName");
            attributes.Add("lastName");
            attributes.Add("group");
        }

        public int Id
        {
            get
            {
                return id;
            }
            
        }
        public string FirstName
        {
            get
            {
                return firstName;
            }
            
        }

        public string LastName
        {
            get
            {
                return lastName;
            }
            
        }

        public string Group
        {
            get
            {
                return group;
            }
          
        }
        public IEnumerable<string> GetRequiredAttributes()
        {
            return attributes;
        }

        public void SetAttributes(IDictionary<string, string> attrib)
        {
            id = Int32.Parse(attrib["id"]);
            firstName = attrib["firstName"];
            lastName = attrib["lastName"];
            group = attrib["group"];
        }
    }
}
