using System;
using System.IO;
using Xunit;

namespace BatteryDataStream.Test
{
    public class BatteryDataStreamTests
    {
        IParameterSource parameterSource = new FakeCSVParameterSource();
        [Fact]
        public void LoadDataStreaming_FakeCSVParameterSource_ReturnsStubCSV()
        {
            //Arrange
            DataStreaming dataStreaming = new DataStreaming(parameterSource);

            //Assert
            string filePath = Directory.GetParent("../../../../") + @"/BatteryDataStream/Data/Parameters.csv";
            string parameters = dataStreaming.Load(filePath);

            //Assert
            Assert.True(IsFloat(parameters, 1));
        }

        [Fact]
        public void StartDataStreaming_FakeCSVParameterSource_ReturnsStubCSV()
        {
            //Arrange
            DataStreaming dataStreaming = new DataStreaming(parameterSource);

            //Act
            string parameters = dataStreaming.Start(2);

            //Assert
            Assert.True(IsFloat(parameters, 0));
        }

        [Fact]
        public void StartDataStreaming_NoParam_ReturnsException()
        {
            //Assert
            Assert.Throws<ArgumentNullException>(() => new DataStreaming(null));
        }

        private bool IsFloat(string parameters, int index)
        {
            return (float.TryParse(parameters.Split("\n")[index].Split(',')[0].Trim('\r'), out float _soc) &&
                float.TryParse(parameters.Split("\n")[index].Split(',')[1].Trim('\r'), out float _temperature));
        }
    }
}
