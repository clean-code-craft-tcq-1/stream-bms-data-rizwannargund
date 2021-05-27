using System;
using System.IO;

namespace BatteryDataStream
{
    public class CSVParameterSource : IParameterSource
    {
        private string _lines;

        public string LoadParameters(string filePath)
        {
            if (File.Exists(filePath))
            {
                using (var reader = new StreamReader(filePath))
                {
                    _lines = reader.ReadToEnd();
                    return _lines;
                }
            }

            throw new Exception("File not found");
        }

        public string GetParameter(int index)
        {
            if (string.IsNullOrEmpty(_lines))
                throw new Exception("Parameters are not loaded.");

            string[] splitLines = _lines.Split("\n");
            return splitLines[index];
        }
    }
}