using System;
using System.Collections.Generic;
using System.Text;
using OOPBasics.Shared;

namespace OOPBasics.CaesarDecoder
{
    public class CaesarDecoderPlugin : IDecoderPlugin
    {
        private string name = "Caesar Decoder";
        List<string> arguments = new List<string>();

        public IDecoder GetDecoder()
        {
            return new CaesarDecoder();
        }

        public IEncoder GetEncoder()
        {
            throw new NotImplementedException();
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
            
        }
    }
}
