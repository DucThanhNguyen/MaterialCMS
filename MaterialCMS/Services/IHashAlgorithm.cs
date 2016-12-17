using Ninject;

namespace MaterialCMS.Services
{
    public interface IHashAlgorithm
    {
        byte[] GenerateSaltedHash(byte[] plainText, byte[] salt);
        string Type { get; }
    }
}