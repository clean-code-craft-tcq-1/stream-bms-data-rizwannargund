using System;
using System.IO;

namespace BatteryDataStream
{
    public class CSVParameterSource : IParameterSource
    {
        private string _lines;

        public int MaxRows { get; set; }

        public string LoadParameters(string filePath)
        {
            if (File.Exists(filePath))
            {
                using (var reader = new StreamReader(filePath))
                {
                    _lines = reader.ReadToEnd();
                    MaxRows = _lines.Split("\n").Length - 2;
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