using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pertamina.CORSEC.Business.Enum
{
    public enum StakeHolderDatabase_Type
    {
        [Description("Non Kategori")]
        None = -1,
        [Description("Legislatif")]
        Legislatif = 3,
        [Description("Pemerintah")]
        Pemerintah = 4,
        [Description("Non Pemerintah")]
        NonPemerintah = 5

    }
}
