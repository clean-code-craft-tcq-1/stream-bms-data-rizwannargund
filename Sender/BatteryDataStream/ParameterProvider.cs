using System;

namespace BatteryDataStream
{
    public class ParameterProvider
    {
        private IParameterSource parameterSource;

        public ParameterProvider(IParameterSource parameterSource)
        {
            if (parameterSource == null)
                throw new ArgumentNullException("parameterSource cannot be null.");

            this.parameterSource = parameterSource;
        }

        public string LoadParameters(string filePath)
        {
            return parameterSource.LoadParameters(filePath);
        }

        public string GetParameter(int index)
        {
            return parameterSource.GetParameter(index);
        }
    }
}