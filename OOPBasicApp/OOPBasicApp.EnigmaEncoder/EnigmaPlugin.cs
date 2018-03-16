using System;
using System.Collections.Generic;
using System.Text;
using OOPBasics.Shared;

namespace OOPBasics.EnigmaEncoder
{
    class EnigmaPlugin : IPlugin
    {
        private string name;
        private byte startRange;
        private byte endRange;
        private byte randomValue;
        private List<string> arguments = new List<string>();

        public EnigmaPlugin()
        {
            arguments.Add("startRange");
            arguments.Add("endRange");
            arguments.Add("randomValue");
        }
        public IEncoder GetEncoder()
        {
            return new Algorithms.EnigmaEncoder(startRange, endRange, randomValue);
        }

        public string GetName()
        {
            return name;
        }

        public IEnumerable<string> GetRequiredArguments()
        {
            return arguments;
        }

        public void SetArguments(IDictionary<string, string> args)
        {
            startRange = Byte.Parse(args["startRange"]);
            endRange = Byte.Parse(args["endRange"]);
            randomValue = Byte.Parse(args["randomValue"]);
        }
    }
}
