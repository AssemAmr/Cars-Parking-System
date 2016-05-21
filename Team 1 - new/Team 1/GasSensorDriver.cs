using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParkingSecurityDriver
{
    class GasSensorDriver
    {
        ADCDriver ADC;
        public GasSensorDriver()
        {
            ADC = new ADCDriver();
        }
       
	public double readSensor()
        {
            return ADC.readADC();
        }
    }
}
