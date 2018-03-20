using System;
using System.Collections.Generic;
using System.Text;
using OOPBasics.Shared;

namespace OOPBasicApp
{
    class BinaryDecoder
    {
        private IDecoder decoder;

        public BinaryDecoder(IDecoder decoder)
        {
            this.decoder = decoder;
        }

        public string Decode(byte[] byteArray)
        {
            byte[] decodedData = decoder.Decode(byteArray);
            string retVal = System.Text.Encoding.UTF8.GetString(decodedData);

            return retVal;
        }
    }
}
