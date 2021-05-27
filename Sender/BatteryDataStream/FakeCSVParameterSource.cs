using System;
using System.Collections.Generic;
using System.Text;

namespace BatteryDataStream
{
    public class FakeCSVParameterSource : IParameterSource
    {
        public string GetParameter(int index)
        {
            return "10,20\n15,25";
        }

        public string LoadParameters(string filePath)
        {
            return "stateofcharge,temperature\n10,20\n12,25";
        }
    }
}
