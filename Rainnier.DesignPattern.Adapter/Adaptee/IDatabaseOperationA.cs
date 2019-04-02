namespace Rainnier.DesignPattern.Adapter.Adaptee
{
    public interface IDatabaseOperationA
    {
        string GetDatabase();
        void ReadDatabase();
        void WriteDatabase();
    }
}