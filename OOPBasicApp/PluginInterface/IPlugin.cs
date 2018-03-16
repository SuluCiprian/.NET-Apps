﻿using System;
using System.Collections.Generic;
using System.Text;

namespace OOPBasics.Shared
{
    public interface IPlugin
    {
        string GetName();
        IEnumerable<string> GetRequiredArguments();
        void SetArguments(IDictionary<string, string> args);
        IEncoder GetEncoder();
    }
}
