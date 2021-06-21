using System;
using BatteryDataStream;
using System.Threading;
using System.IO;

namespace Sender
{
    class Program
    {
        private static readonly CancellationTokenSource cancellationToken = new CancellationTokenSource();
        private static DataStreaming _batteryDataStream;
        private static string _filePath = Directory.GetParent("../../../../") + @"/Sender/BatteryDataStream/Data/Parameters.csv";
        private static int _counter = 1;
        private static CSVParameterSource _csvParameterSource;

        static void Main(string[] args)
        {
            _csvParameterSource = new CSVParameterSource();
            _batteryDataStream = new DataStreaming(_csvParameterSource);
            _batteryDataStream.Load(_filePath);

            Console.WriteLine("Streaming is started in csv format(stateofcharge,temperature). Press Ctrl+C to end");
            Console.CancelKeyPress += (sender, eventArgs) =>
            {
                Console.WriteLine("Streaming stop event is triggered");
                cancellationToken.Cancel();
                eventArgs.Cancel = true;
            };

            StartStreaming();
        }

        private static void StartStreaming()
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                if (_counter == _csvParameterSource.MaxRows)
                    _counter = 1;
                Console.WriteLine(_batteryDataStream.Start(_counter));
                Thread.Sleep(1000);
                _counter++;
            }
        }
    }
}
