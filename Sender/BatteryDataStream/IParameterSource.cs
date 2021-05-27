namespace BatteryDataStream
{
    public interface IParameterSource
    {
        string LoadParameters(string filePath);
        string GetParameter(int index);
    }
}