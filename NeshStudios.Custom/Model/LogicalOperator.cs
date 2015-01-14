using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeshStudios.Custom.Model
{
    public enum LogicalOperator
    {
        [Description("Where")]
        Where,

        [Description("Where Not")]
        WhereNot,

        [Description("And")]
        And,

        [Description("Or")]
        Or,

        [Description("And Not")]
        AndNot,

        [Description("Or Not")]
        OrNot,
    }
}
