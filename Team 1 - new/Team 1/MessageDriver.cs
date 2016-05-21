using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace ParkingSecurityDriver
{
    class MessageDriver  
    {
        SevenSegmentDriver SevenSegment;

        public MessageDriver()
        {
            SevenSegment = new SevenSegmentDriver();
        }

        public void PrintCount(int count)
        {
            if (count == 100)
            {
                SevenSegment.Print('A', 0);
                SevenSegment.Print('A', 1);
            }
            else
            {
                char Q = (char)((count / 10) + '0');
                char R = (char)((count % 10) + '0');
                SevenSegment.Print(Q, 0);
                SevenSegment.Print(R, 1);
            }
        }

        public void PrintFS()
        {
            SevenSegment.Print('F', 0);
            SevenSegment.Print('S', 1);
        }
        public void PrintFF()
        {
            SevenSegment.Print('F', 0);
            SevenSegment.Print('F', 1);
        }
    }
}

