using System.Diagnostics.CodeAnalysis;

namespace ReferenceNcfs.Api.Configuration
{
    [ExcludeFromCodeCoverage]
    public class TransactionEventApiConfiguration : ITransactionEventApiConfiguration
    {
        public string TransactionStoreConnectionStringCsv { get; set; }
        public string ShareName { get; set; }
    }
}