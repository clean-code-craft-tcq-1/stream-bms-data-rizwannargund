using System;

namespace BatteryDataStream
{
    public class DataStreaming
    {
        private ParameterProvider _parameterProvider = null;

        public DataStreaming(IParameterSource parameterSource)
        {
            if (parameterSource == null)
                throw new ArgumentNullException("parameterSource cannot be null");

            _parameterProvider = new ParameterProvider(parameterSource);
            
        }

        public string Load(string filePath)
        {
            return _parameterProvider.LoadParameters(filePath);
        }

        public string Start(int index)
        {
            return _parameterProvider.GetParameter(index);
        }

    }
}