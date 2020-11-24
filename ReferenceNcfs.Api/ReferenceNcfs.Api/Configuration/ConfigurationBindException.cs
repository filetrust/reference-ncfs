using System;
using System.Collections.Generic;
using System.Linq;
using ReferenceNcfs.Api.Configuration.Validation.Errors;

namespace ReferenceNcfs.Api.Configuration
{
    [Serializable]
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