using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pertamina.CORSEC.Business.Enum
{
    public enum DiplomaticIntelegence_Type
    {
        [Description("County Profile")]
        County_Profile = 1,
        [Description("Business Analisys")]
        Business_Analisys = 2

    }
    public enum Monitoring_Type
    {

        [Description("Mingguan")]
        Mingguan = 1,
        [Description("Bulanan")]
        Bulanan = 2,
        [Description("Tahunan")]
        Tahunan = 3
    }

    public enum Kinerja_Monitoring_Type
    {
        [Description("Kinerja Sekper")]
        Kinerja_Sekper = 1,
        [Description("Kinerja Unit/Fungsi")]
        Kinerja_Unit = 2,

    }
}
