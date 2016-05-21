using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParkingSecurityDriver
{
    class KeypadDriver
    {
        InputOutputDriver InOut;
        char num;

        public KeypadDriver()
        {
            InOut = new InputOutputDriver();
        }

        public char GetNumber()
        {
            char x,Mask;
            do
            {
                num = InputOutputDriver.Read((char)5);
                Mask = Utility.BinaryToChar("00010000");
                x = (char)(num & Mask);
            } while (x != Mask);

            while ((InputOutputDriver.Read((char)5) & Mask) != 0) { };

            Mask = Utility.BinaryToChar("00001111");
            num =(char) (num & Mask);
           return mapping(num);
        }

        char mapping(char n)
        {
            char MappedN;
            int ni = (int)n; 
            switch (ni)
            {
                case 0:
                    MappedN = '1';
                    break;
                case 1:
                    MappedN = '2';
                    break;
                case 2:
                    MappedN = '3';
                    break;
                case 3:
                    MappedN = 'A';
                    break;
                case 4:
                    MappedN = '4';
                    break;
                case 5:
                    MappedN = '5';
                    break;
                case 6:
                    MappedN = '6';
                    break;
                case 7:
                    MappedN = 'B';
                    break;
                case 8:
                    MappedN = '7';
                    break;
                case 9:
                    MappedN = '8';
                    break;
                case 10:
                    MappedN = '9';
                    break;
                case 11:
                    MappedN = 'C';
                    break;
                case 12:
                    MappedN = '*';
                    break;
                case 13:
                    MappedN = '0';
                    break;
                case 14:
                    MappedN = '#';
                    break;
                case 15:
                    MappedN = 'D';
                    break;
                default:
                    MappedN = 'X';
                    break;
            }

            return MappedN;
        }

        public bool GetCharacter()
        {
            char x, Mask;
            num = InputOutputDriver.Read((char)5);
            Mask = Utility.BinaryToChar("00010000");
            x = (char)(num & Mask);

            return x == Mask;
        }



    }
}
