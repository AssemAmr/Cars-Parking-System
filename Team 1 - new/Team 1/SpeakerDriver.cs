using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParkingSecurityDriver
{
    class SpeakerDriver
    {
        
	 public void TurnSpeakerOn()
        {
            InputOutputDriver.Write((char)0,(char) 1); 
        }
     public void TurnSpeakerOff()
        {
            InputOutputDriver.Write((char)0, (char)0);
        }
    }
}



