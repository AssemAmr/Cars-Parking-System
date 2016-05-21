using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParkingSecurityDriver
{
    class Utility
    {
        public static char BinaryToChar(string bin)
        {
            char _res = (char)0;
            char _base = (char)1;
            for(int i = 7; i >=0; i--)
            {
                _res += bin[i] == '1' ? _base : (char)0;
                _base *= (char)2;
            }
            return _res;
        }
    }
}
