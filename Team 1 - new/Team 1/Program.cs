using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;

namespace ParkingSecurityDriver
{
    class Program
    {
        static void Main(string[] args)
        {
            MessageDriver Msg = new MessageDriver();
            SpeakerDriver Speaker = new SpeakerDriver();
            CarGateDriver CarGate = new CarGateDriver();
            GasSensorDriver GasSensor = new GasSensorDriver();
            Authentication Auth = new Authentication();
            int Count = 0;
            int tempCount = 0;
            int currentLevel = 0;
            int Level1Alarm = 0;
            float gas;

            Speaker.TurnSpeakerOff();
            Msg.PrintCount(0);

            

            Auth.GetPassword();
            Auth.GetInputs();

            while (true)
            {
                gas = (float)GasSensor.readSensor();
                if (gas < Auth.LT)            // Level 0 Logic
                {
                    Speaker.TurnSpeakerOff();
                    if (Count == Auth.N)
                        Msg.PrintFF();
                    else
                        Msg.PrintCount(Count);


                    tempCount = CarGate.UpdateCount(Count);
                    if (tempCount > Auth.N) Count = Auth.N;
                    else Count=tempCount;
                    currentLevel = 0;
                }

                else if (gas < Auth.HT)     // Level 1 logic
                {
                    Msg.PrintFS();
                    if (Count > Auth.C && currentLevel != 1)
                        Level1Alarm = 1;

                    if (Count <= Auth.C) Level1Alarm = 0;

                    if (Auth.CheckCharacter())
                    {
                        if (Auth.CheckPassword())
                        {
                            Level1Alarm = 0;
                            if (Count == 0) break;
                        }
                    }

                    if (Level1Alarm == 1)
                        Speaker.TurnSpeakerOn();
                    else
                        Speaker.TurnSpeakerOff();


                    tempCount = CarGate.UpdateCount(Count);
                    if (tempCount < Count) Count = tempCount;

                    currentLevel = 1;
                }

                else                                        // Level 2 logic
                {
                    Speaker.TurnSpeakerOn();
                    Msg.PrintFS();


                    tempCount = CarGate.UpdateCount(Count);
                    if (tempCount < Count) Count = tempCount;

                    currentLevel = 2;
                }

                if (Count == 0 && Auth.CheckCharacter())
                {
                    if (Auth.CheckPassword())
                        break;
                }
            }
            Speaker.TurnSpeakerOff();
            Msg.PrintCount(100);
        }
    }
}
