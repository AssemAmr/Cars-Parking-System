using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;

namespace ParkingSecurityDriver
{
    class Authentication
    {
        string Pass;
	    public float LT, HT;
        public int N, C;
        KeypadDriver KPD;

        /////////////////////////////////

        public  Authentication()
        {
            KPD = new KeypadDriver();
            Pass = "";
        }

        public void GetPassword()
        {
            Console.WriteLine("Please Enter Password");
            for (int i = 0; i < 4; i++)
            {
                Pass += KPD.GetNumber();
            }
            Console.WriteLine("Your new password is: "+Pass);
        }

        public bool CheckPassword()
        {
            string P = "";
            for (int i = 0; i < 4; i++)
            {
                P += KPD.GetNumber();
            }

            return P == (Pass).ToString();
        }

        public bool CheckCharacter()
        {
            return KPD.GetCharacter();
        }

        void SetSmokeThreshold()
        {
            LT = (float)1.0;
            HT = (float)0.0;
            char LTD0, LTD1, HTD0, HTD1;
            LTD0 = LTD1 = HTD0 = HTD1 = 'A';
            while (LTD1 > '9' || LTD1 < '0')
                LTD1 = KPD.GetNumber();
            while (LTD0 > '9' || LTD0 < '0')
                LTD0 = KPD.GetNumber();
            while (HTD1 > '9' || HTD1 < '0')
                HTD1 = KPD.GetNumber();
            while (HTD0 > '9' || HTD0 < '0')
                HTD0 = KPD.GetNumber();

            LT = (LTD1 - '0') + ((float)LTD0 - '0') / (float)10;
            HT = (HTD1 - '0') + ((float)HTD0 - '0') / (float)10;

            while (LT >= HT)
            {
                Console.WriteLine("Error! LT must be less than HT");
                
                LTD0 = LTD1 = HTD0 = HTD1 = 'A';
                while (LTD1 > '9' || LTD1 < '0')
                    LTD1 = KPD.GetNumber();
                while (LTD0 > '9' || LTD0 < '0')
                    LTD0 = KPD.GetNumber();
                while (HTD1 > '9' || HTD1 < '0')
                    HTD1 = KPD.GetNumber();
                while (HTD0 > '9' || HTD0 < '0')
                    HTD0 = KPD.GetNumber();

                LT = (LTD1 - '0') + ((float)LTD0 - '0') / (float)10;
                HT = (HTD1 - '0') + ((float)HTD0 - '0') / (float)10;
            }
            Console.WriteLine("Your new thresholds are:");
            Console.WriteLine("LT:"+LT);
            Console.WriteLine("HT:"+HT);
        }

        void SetCarThreshold()
        {
            char ND1, ND0, CD0, CD1;

            ND1 = ND0 = CD0 = CD1 = 'A';
            while (ND1 > '9' || ND1 < '0')
                ND1 = KPD.GetNumber();
            while (ND0 > '9' || ND0 < '0')
                ND0 = KPD.GetNumber();
            while (CD1 > '9' || CD1 < '0')
                CD1 = KPD.GetNumber();
            while (CD0 > '9' || CD0 < '0')
                CD0 = KPD.GetNumber();


            N = (ND1 - '0') * 10 + (ND0 - '0');
            C = (CD1 - '0') * 10 + (CD0 - '0');

            if (C > N)
                C = N;

            Console.WriteLine("Your new Max:");
            Console.WriteLine("N:"+N);
            Console.WriteLine("C:" + C);
        }

        public void GetInputs()
        {
            Console.WriteLine("Please Enter Smoke Thresholds");
            SetSmokeThreshold();
            Console.WriteLine("Please Enter Car threshold");
            SetCarThreshold();
        }
    }
}
