namespace ReferenceNcfs.Api.Configuration
{
    public interface IConfigurationParser
    {
        TConfiguration Parse<TConfiguration>() where TConfiguration : new();
    }
}