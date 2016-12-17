namespace MaterialCMS.Services
{
    public interface IHashAlgorithmProvider
    {
        IHashAlgorithm GetHashAlgorithm(string type);
    }
}