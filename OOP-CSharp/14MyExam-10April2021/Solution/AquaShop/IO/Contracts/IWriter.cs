namespace AquaShop.IO.Contracts
{
    public interface IWriter
    {
        void WriteLine(string message);

        void Write(string message);
        void Writeline(string message);
    }
}