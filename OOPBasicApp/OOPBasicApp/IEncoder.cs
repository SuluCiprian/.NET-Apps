using System;
using System.Collections.Generic;
using System.Text;

namespace OOPBasicApp
{
    public interface IEncoder
    {
        byte[] Encode(byte[] inputData);
    }
}
