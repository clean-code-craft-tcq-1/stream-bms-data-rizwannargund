using System;
using System.IO;
using Xunit;

namespace BatteryDataStream.Test
{
    public class BatteryDataStreamTests
    {
        [Fact]
        public void LoadDataStreaming_FakeCSVParameterSource_ReturnsStubCSV()
        {
            //Arrange
            IParameterSource parameterSource = new FakeCSVParameterSource();
            DataStreaming dataStreaming = new DataStreaming(parameterSource);

            //Assert
            string filePath = Directory.GetParent("../../../../") + @"/BatteryDataStream/Data/Parameters.csv";
            string parameters = dataStreaming.Load(filePath);

            //Assert
            Assert.True(float.TryParse(parameters.Split("\n")[1].Split(',')[0], out float _soc) &&
                float.TryParse(parameters.Split("\n")[1].Split(',')[1], out float _temperature));
        }

        [Fact]
        public void StartDataStreaming_FakeCSVParameterSource_ReturnsStubCSV()
        {
            //Arrange
            IParameterSource parameterSource = new FakeCSVParameterSource();
            DataStreaming dataStreaming = new DataStreaming(parameterSource);

            //Act
            string parameters = dataStreaming.Start(1);

            //Assert
            Assert.True(float.TryParse(parameters.Split("\n")[0].Split(',')[0].Trim('\r'), out float _soc) &&
                float.TryParse(parameters.Split("\n")[0].Split(',')[1].Trim('\r'), out float _temperature));
        }

        [Fact]
        public void StartDataStreaming_NoParam_ReturnsException()
        {
            //Assert
            Assert.Throws<ArgumentNullException>(() => new DataStreaming(null));
        }
    }
}
