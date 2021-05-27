using System;
using System.IO;
using Xunit;

namespace BatteryDataStream.Test
{
    public class ParameterProviderTests
    {

        string filePath = Directory.GetParent("../../../../") + @"/BatteryDataStream/Data/Parameters.csv";

        [Fact]
        public void LoadCSVParameter_ParameterSource_ReturnsCSV()
        {
            //Arrange
            IParameterSource parameterSource = new CSVParameterSource();
            ParameterProvider parameterProvider = new ParameterProvider(parameterSource);

            //Act
            string parameters = parameterProvider.LoadParameters(filePath);

            //Assert
            Assert.True(float.TryParse(parameters.Split("\n")[1].Split(',')[0], out float _soc) &&
                float.TryParse(parameters.Split("\n")[1].Split(',')[1], out float _temperature));
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
            IParameterSource parameterSource = new CSVParameterSource();
            ParameterProvider parameterProvider = new ParameterProvider(parameterSource);
            parameterProvider.LoadParameters(filePath);

            //Act
            string parameters = parameterProvider.GetParameter(1);

            //Assert
            Assert.True(float.TryParse(parameters.Split("\n")[0].Split(',')[0].Trim('\r'), out float _soc) &&
                float.TryParse(parameters.Split("\n")[0].Split(',')[1].Trim('\r'), out float _temperature));
        }

        [Fact]
        public void GetParameter_NoParametersLoaded_ReturnsException()
        {
            //Arrange
            IParameterSource parameterSource = new CSVParameterSource();
            ParameterProvider parameterProvider = new ParameterProvider(parameterSource);

            //Assert
            Assert.Throws<Exception>(() => parameterProvider.GetParameter(1));
        }

        [Fact]
        public void LoadCSVParameter_EmptyFilePath_ReturnsException()
        {
            //Arrange
            IParameterSource parameterSource = new CSVParameterSource();
            ParameterProvider parameterProvider = new ParameterProvider(parameterSource);

            //Assert
            Assert.Throws<Exception>(() => parameterProvider.LoadParameters(""));
        }
    }
}
