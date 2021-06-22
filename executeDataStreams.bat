pushd "%~dp0"

dotnet run --project Sender\Sender\Sender.csproj  | java -jar ./src/Receiver.jar

popd

