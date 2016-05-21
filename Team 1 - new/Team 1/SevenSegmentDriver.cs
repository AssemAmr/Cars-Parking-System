using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParkingSecurityDriver
{
    class SevenSegmentDriver
    {
        char [] SegAddressArray = new char[2] {(char)1, (char)2};

        int Mapping(char C)
        {
            int MappedC;
            switch (C)
            {
                case '0':
                    MappedC = Utility.BinaryToChar("11000000");
                    break;
                case '1':
                    MappedC = Utility.BinaryToChar("11111001");
                    break;
                case '2':
                    MappedC = Utility.BinaryToChar("10100100");
                    break;
                case '3':
                    MappedC = Utility.BinaryToChar("10110000");
                    break;
                case '4':
                    MappedC = Utility.BinaryToChar("10011001");
                    break;
                case '5':
                    MappedC = Utility.BinaryToChar("10010010");
                    break;
                case '6':
                    MappedC = Utility.BinaryToChar("10000010");
                    break;
                case '7':
                    MappedC = Utility.BinaryToChar("11111000");
                    break;
                case '8':
                    MappedC = Utility.BinaryToChar("10000000");
                    break;
                case '9':
                    MappedC = Utility.BinaryToChar("10010000");
                    break;
                case 'F':
                    MappedC = Utility.BinaryToChar("10001110");
                    break;
                case 'S':
                    MappedC = Utility.BinaryToChar("10010010");
                    break;
                default:
                    MappedC = Utility.BinaryToChar("11111111");
                    break;
            }

            return MappedC;
        }

        

    
       public void Print(char C, int SegNumber)
        {
            char Address = SegAddressArray[SegNumber];
            char Character = (char)Mapping(C);
            InputOutputDriver.Write(Address, Character);

        }
    }
}
