namespace ReferenceNcfs.Api.Configuration
{
    public class TransactionEventApiConfiguration : ITransactionEventApiConfiguration
    {
        public string TransactionStoreConnectionStringCsv { get; set; }
        public string ShareName { get; set; }
    }
}