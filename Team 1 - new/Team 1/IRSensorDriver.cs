using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParkingSecurityDriver
{
    class IRSensorDriver
    {
        private char InData()
        {
            return InputOutputDriver.Read((char)3);
        }

        public int ReadSensors()
        {
            char SensorReading = InData();
            char Mask = Utility.BinaryToChar("00000011");
            SensorReading = (char)(SensorReading & Mask);
            switch (SensorReading)
            {
                case (char)1:
                      return 0; //  Car on the Right Sensor 
                case (char)2:
                      return 1; // Car on the Left Sensor
                default:
                      return 2; // No Car
            }
        }
    }
}
