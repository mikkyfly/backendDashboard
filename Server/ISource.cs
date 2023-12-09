namespace Server;

public interface ISource
{
    public delegate void AccountHandler(List<Data> datas);
    public event AccountHandler? Notify;
}