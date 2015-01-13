using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeshStudios.Target.Model
{
    public enum Operator
    {
        [Description("=(equals)")]
        Equals,

        [Description("<>(does not equal)")]
        DoesNotEqual,

        [Description(">(is greater than)")]
        IsGreaterThan,

        [Description("<(is less than)")]
        IsLessThan,

        [Description(">=(is greater than or equal to)")]
        IsGreaterThanOrEqualTo,

        [Description("<=(is less than or equal to)")]
        IsLessThanOrEqualTo,

        [Description("(starts with)")]
        StartsWith,

        [Description("(contains)")]
        Contains,

        [Description("(does not contain)")]
        DoesNotContain,

        [Description("(ends with)")]
        EndsWith
    }
}
