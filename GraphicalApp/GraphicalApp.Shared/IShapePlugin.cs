using System;
using System.Collections.Generic;
using System.Text;

namespace GraphicalApp.Shared
{
    public interface IShapePlugin
    {
        string GetName();
        IEnumerable<string> GetRequiredArguments();
        void SetArguments(IDictionary<string, string> args);
        IShape GetShape();
    }
}
