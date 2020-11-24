using System.Collections.Generic;
using ReferenceNcfs.Api.Configuration.Validation.Errors;

namespace ReferenceNcfs.Api.Configuration.Validation
{
    public interface IConfigurationItemValidator
    {
        bool TryParse(string key, string rawValue, List<ConfigurationParserError> validationErrors, out object parsed);
    }
}