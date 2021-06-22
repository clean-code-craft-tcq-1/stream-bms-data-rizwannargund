pushd "%~dp0"

dotnet run --project Sender\Sender\Sender.csproj  | java -ea -cp src.main.java.batterystreamreceiver.ReceiverServiceImpl.java

popd

