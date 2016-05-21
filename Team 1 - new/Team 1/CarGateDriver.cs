using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParkingSecurityDriver
{
    class CarGateDriver
    {
        IRSensorDriver IRSensor;
        char RightFlag;
        char LeftFlag;
        int lastReading;
       
	  public CarGateDriver()
        {
            lastReading = -1;
            IRSensor = new IRSensorDriver();
            LeftFlag = (char) 0;
            RightFlag = (char) 0;
        }

       public int UpdateCount(int count)
        {
            int Reading = IRSensor.ReadSensors();
            if (Reading != lastReading)
            {
                if (Reading == 0)
                    if (LeftFlag == 1)
                    {
                        count++;
                        LeftFlag = (char)0;
                    }
                    else
                        RightFlag = (char)1;
                else if (Reading == 1)
                    if (RightFlag == 1)
                    {
                        if(count!=0)count--;
                        RightFlag = (char)0;
                    }
                    else
                        LeftFlag = (char)1;
            }
            lastReading = Reading;
            return count;
        }
    }
}
