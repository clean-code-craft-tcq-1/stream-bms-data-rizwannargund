using System;
using System.IO;
using Xunit;

namespace BatteryDataStream.Test
{
    public class ParameterProviderTests
    {

        string filePath = Directory.GetParent("../../../../") + @"/BatteryDataStream/Data/Parameters.csv";
        IParameterSource parameterSource = new CSVParameterSource();

        [Fact]
        public void LoadCSVParameter_ParameterSource_ReturnsCSV()
        {
            //Arrange
            ParameterProvider parameterProvider = new ParameterProvider(parameterSource);

            //Act
            string parameters = parameterProvider.LoadParameters(filePath);

            //Assert
            Assert.True(IsFloat(parameters, 1));
        }

        [Fact]
        public void ParameterProvider_NoParam_ReturnsException()
        {
            Assert.Throws<ArgumentNullException>(() => new ParameterProvider(null));
        }

        [Fact]
        public void GetParameter_ParameterSource_ReturnsCSV()
        {
            //Arrange
            ParameterProvider parameterProvider = new ParameterProvider(parameterSource);
            parameterProvider.LoadParameters(filePath);

            //Act
            string parameters = parameterProvider.GetParameter(1);

            //Assert
            Assert.True(IsFloat(parameters, 0));
        }

        [Fact]
        public void GetParameter_NoParametersLoaded_ReturnsException()
        {
            //Arrange
            ParameterProvider parameterProvider = new ParameterProvider(parameterSource);

            //Assert
            Assert.Throws<Exception>(() => parameterProvider.GetParameter(3));
        }

        [Fact]
        public void LoadCSVParameter_EmptyFilePath_ReturnsException()
        {
            //Arrange
            ParameterProvider parameterProvider = new ParameterProvider(parameterSource);

            //Assert
            Assert.Throws<Exception>(() => parameterProvider.LoadParameters(""));
        }

        private bool IsFloat(string parameters, int index)
        {
            return (float.TryParse(parameters.Split("\n")[index].Split(',')[0].Trim('\r'), out float _soc) &&
                float.TryParse(parameters.Split("\n")[index].Split(',')[1].Trim('\r'), out float _temperature));
        }
    }
}
