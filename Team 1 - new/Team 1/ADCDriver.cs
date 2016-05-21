using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParkingSecurityDriver
{
    class ADCDriver
    {
        char InData()
        {
            return InputOutputDriver.Read((char)4);
            
        }

        double calcVolt(char digital)
        {
            return (double)(digital * 5) / 31;
        }

	    public double readADC()
        {
            InputOutputDriver.Write((char)6, Utility.BinaryToChar("00000001"));
            System.Threading.Thread.Sleep(50);
            InputOutputDriver.Write((char)6, Utility.BinaryToChar("00000000"));
            System.Threading.Thread.Sleep(50);
            char digital = InData();
            digital &= Utility.BinaryToChar("00011111");
            return calcVolt(digital);
        }
    }
}
