﻿using System.Collections.Generic;
using System.Linq;
using ReferenceNcfs.Api.Configuration.Validation;
using ReferenceNcfs.Api.Configuration.Validation.Errors;

namespace ReferenceNcfs.Api.Configuration
{
    public class StringValidator
        : IConfigurationItemValidator
    {
        private readonly int _minLengthInclusive;

        public StringValidator(int? minLengthInclusive = null)
        {
            _minLengthInclusive = minLengthInclusive.GetValueOrDefault(int.MinValue);
        }

        public bool TryParse(string key, string rawValue, List<ConfigurationParserError> validationErrors, out object parsed)
        {
            var thisItemsErrors = new List<ConfigurationParserError>();

            var length = rawValue?.Length ?? 0;

            if (length < _minLengthInclusive)
                thisItemsErrors.Add(new ConfigurationParserError(key, $"Value must be at least {_minLengthInclusive} characters. Got {rawValue?.Length}"));

            validationErrors.AddRange(thisItemsErrors);

            parsed = rawValue;
            return !thisItemsErrors.Any();
        }
    }
}