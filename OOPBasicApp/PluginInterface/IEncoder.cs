using System;
using System.Collections.Generic;
using System.Text;

namespace OOPBasics.Shared
{
    public interface IEncoder
    {
        byte[] Encode(byte[] inputData);
    }
}
