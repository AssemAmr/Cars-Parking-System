using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace ParkingSecurityDriver
{
    class InputOutputDriver
    {
        const int dataPortAddress = 888;
        const int statusPortAddress = 889;
        const int controlPortAddress = 890;
        const char unusedDeviceAddress = (char)15;
        [DllImport("inpout32.dll", EntryPoint = "Out32")]
        public static extern void Out32(int adress, int value);

        [DllImport("inpout32.dll", EntryPoint = "Inp32")]
        public static extern int Inp32(int adress);

        private static void OutputDeviceAddress(char deviceAddress)
        {
            Out32(controlPortAddress, deviceAddress ^ 11);
        }

        public static char Read(char deviceAddress)
        {
            OutputDeviceAddress(deviceAddress);
            int _inData = Inp32(statusPortAddress);
            OutputDeviceAddress(unusedDeviceAddress);
            _inData /= 8;
            _inData ^= 16;
            return (char)_inData;
        }

        public static void Write(char deviceAddress, char outData)
        {
            OutputDeviceAddress(deviceAddress);
            Out32(dataPortAddress,outData);
            OutputDeviceAddress(unusedDeviceAddress);
        }

    }
}
