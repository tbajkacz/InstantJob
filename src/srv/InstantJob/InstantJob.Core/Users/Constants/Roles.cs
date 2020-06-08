using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace InstantJob.Core.Users.Constants
{
    public class Roles
    {
        public const string Mandator = nameof(Mandator);
        public const string Contractor = nameof(Contractor);
        public const string Administrator = nameof(Administrator);

        public static readonly IReadOnlyCollection<string> RolesCollection
            = typeof(Roles).GetFields(BindingFlags.Public | BindingFlags.Static)
                .Where(f => f.IsLiteral && !f.IsInitOnly)
                .Select(f => (string)f.GetRawConstantValue())
                .ToList();
    }
}