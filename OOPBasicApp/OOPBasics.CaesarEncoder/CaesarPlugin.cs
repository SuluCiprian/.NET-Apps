﻿using System;
using System.Collections.Generic;
using System.Text;
using OOPBasics.Shared;
using Algorithms;
namespace OOPBasics.CaesarEncoder
{
    public class CaesarPlugin : IPlugin
    {
        private string name = "Caesar";
        List<string> arguments = new List<string>();
        public IEncoder GetEncoder()
        {
            return new Algorithms.CaesarEncoder();
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
