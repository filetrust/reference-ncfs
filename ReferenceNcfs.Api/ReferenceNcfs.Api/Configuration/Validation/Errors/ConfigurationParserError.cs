﻿using System;

namespace ReferenceNcfs.Api.Configuration.Validation.Errors
{
    public class ConfigurationParserError
    {
        public ConfigurationParserError(string paramName, string reason)
        {
            ParamName = paramName ?? throw new ArgumentNullException(nameof(paramName));
            Reason = reason ?? throw new ArgumentNullException(nameof(reason));
        }

        public string ParamName { get; }

        public string Reason { get; }
    }
}