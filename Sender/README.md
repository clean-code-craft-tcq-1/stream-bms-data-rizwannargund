# Sender

It has three components

- BatteryDataStream is library which loads the csv data sends to console(Sender)
- BatteryDataStream.Test contians unit test for BatteryDataStream
- Sender is the console application which prints the parameter in comma separated i.e (stateofcharge,temperature)


## BatteryDataStream

- Is a library which loads CSV data from Sender\BatteryDataStream\Data\Parameters.csv and sends to console application.
- CSV file has 15 readings can be edited or increased the readings as required.
- CSVParameterSource.cs sets MaxRows property from number of rows in csv, so when it reaches 14th(nth row) row it start printing again from 1st row.

## BatteryDataStream.Test

- BatteryDataStreamTests.cs which test the parameter with fake data.
- ParameterProviderTests.cs which tests different sources of data.

## Sender

- This is console application which contains .exe file. When user starts running the application it starts printing the parameter as (stateofcharge,temperature).
e.g.
Streaming is started in csv format(stateofcharge,temperature). Press Ctrl+C to end
10,20
12,23
14,26
18,25
..
..
..
Streaming stop event is triggered


#### Note: It starts printing from 1st reading once it reaches last reading from csv. User can stop the printing with Ctrl+C.
