namespace ReferenceNcfs.Api.Configuration
{
    public interface ITransactionEventApiConfiguration
    {
        string TransactionStoreConnectionStringCsv { get; }
        string ShareName { get; }
    }
}