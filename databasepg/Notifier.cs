namespace databasepg;

public class Notifier
{
    public Action<List<string>> OnMessageReceived = (_) => {};
}