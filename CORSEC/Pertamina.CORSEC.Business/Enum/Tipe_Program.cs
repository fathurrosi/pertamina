
using System.ComponentModel;

namespace Pertamina.CORSEC.Business.Enum
{
    public enum Tipe_Program
    {
        [Description("Corporate Communication")]
        Corporate_Communication = 15,
        [Description("Stakeholder Relation")]
        Stakeholder_Relation = 16,

        [Description("CSR Smepp")]
        CSR_Smepp = 17,
        [Description("BOD Support")]
        BOD_Support = 18,
        [Description("Planning Governance")]
        Planning_Governance = 19
    }
}
