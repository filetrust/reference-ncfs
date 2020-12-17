using System;
using System.Collections.Generic;
using System.Linq;
using ReferenceNcfs.Api.Configuration.Validation.Errors;
using System.Diagnostics.CodeAnalysis;

namespace ReferenceNcfs.Api.Configuration
{
    [Serializable]
    [ExcludeFromCodeCoverage]
    public class ConfigurationBindException : Exception
    {
        public ConfigurationBindException()
        {
            
        }

        public ConfigurationBindException(IEnumerable<ConfigurationParserError> errors)
            : base("Error binding configuration: " + string.Join(Environment.NewLine, errors.Select(error => $"{error.ParamName} - {error.Reason}")))
        {
        }
    }
}