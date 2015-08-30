using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace revData
{
    public class Command
    {
        public static string MakeCovers(string power, Direction direction)
        {
            string command = "";
            string FrontBack = "<0";
            string Setup = ">";
            string rP, lP = "";

            if (direction == Direction.Forward)
            {
                rP = "R0" + power;
                lP = "L0" + power;
            }
            else if (direction == Direction.Left)
            {
                rP = "R0" + power;
                lP = "L1" + power;
            }
            else if (direction == Direction.Right)
            {
                rP = "R1" + power;
                lP = "L0" + power;
            }
            else if (direction == Direction.Back)
            {
                rP = "R1" + power;
                lP = "L1" + power;
            }
            else
            {
                rP = "R1000";
                lP = "L1000";
            }
            command = FrontBack + rP + lP + Setup;

            return command;
        }        
    }
}
