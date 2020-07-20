using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InstantJob.Core.Common.Exceptions
{
    public class ValidationFailedException : Exception
    {
        public IDictionary<string, string[]> Failures { get; }

        public ValidationFailedException()
            : base("Validation did not pass due to one or more failures")
        {
            Failures = new Dictionary<string, string[]>();
        }

        public ValidationFailedException(IEnumerable<ValidationFailure> failures)
            : this()
        {
            foreach (var propertyName in failures.Select(f => f.PropertyName).Distinct())
            {
                Failures.Add(propertyName, failures.Where(x => x.PropertyName == propertyName)
                                                   .Select(x => x.ErrorMessage)
                                                   .ToArray());
            }
        }
    }
}
