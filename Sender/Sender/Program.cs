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
        private static string _filePath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\..\", @"BatteryDataStream/Data/Parameters.csv"));
        private static int _counter = 1;
        private static CSVParameterSource _csvParameterSource;
        private static int _limitRows = 0;

        static void Main(string[] args)
        {
            _csvParameterSource = new CSVParameterSource();
            _batteryDataStream = new DataStreaming(_csvParameterSource);
            _batteryDataStream.Load(_filePath);
            if (args.Length > 0 && int.TryParse(args[0], out int result))
            {
                _limitRows = result;
            }

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
                ResetCounter();
                Console.WriteLine(_batteryDataStream.Start(_counter));
                Thread.Sleep(500);
                if (_limitRows == _counter)
                    break;
                _counter++;
            }
        }

        private static void ResetCounter()
        {
            if (_counter == _csvParameterSource.MaxRows)
                _counter = 1;
        }
    }
}
