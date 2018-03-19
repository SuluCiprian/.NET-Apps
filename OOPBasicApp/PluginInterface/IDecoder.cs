using System;
using System.Collections.Generic;
using System.Text;

namespace OOPBasics.Shared
{
    public interface IDecoder
    {
        byte[] Decode(byte[] inputData);
    }
}
