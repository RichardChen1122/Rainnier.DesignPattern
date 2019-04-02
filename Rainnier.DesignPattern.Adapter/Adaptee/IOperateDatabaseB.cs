namespace Rainnier.DesignPattern.Adapter.Adaptee
{
    public interface IOperateDatabaseB
    {
        string DatabaseGet();
        void DatabaseRead();
        void DatabaseWrite();
    }
}