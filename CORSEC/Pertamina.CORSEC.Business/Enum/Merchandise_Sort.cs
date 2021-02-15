using System.ComponentModel;

namespace Pertamina.CORSEC.Business.Enum
{
    public enum Merchandise_Sort
    {
        [Description("Last Added")]
        LastAdded = 1,
        [Description("Sort A-Z")]
        Sort_A_Z = 2,
        [Description("Sort Z-A")]
        Sort_Z_A = 3
    }

    public enum Mitra_Sort
    {
        [Description("Last Added")]
        LastAdded = 1,
        [Description("Sort A-Z")]
        Sort_A_Z = 2,
        [Description("Sort Z-A")]
        Sort_Z_A = 3
    }
}
