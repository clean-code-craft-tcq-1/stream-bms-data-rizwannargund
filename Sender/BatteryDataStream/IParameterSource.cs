namespace BatteryDataStream
{
    public interface IParameterSource
    {
        public int MaxRows { get; set; }
        string LoadParameters(string filePath);
        string GetParameter(int index);
    }
}