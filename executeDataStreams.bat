pushd "%~dp0"

dotnet run --project Sender\Sender\Sender.csproj 20 | java -jar ./src/Receiver.jar 

popd

