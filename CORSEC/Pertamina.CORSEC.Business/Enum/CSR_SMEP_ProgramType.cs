using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pertamina.CORSEC.Business.Enum
{

    public enum Design_Grafis_Desain_Type
    {
        [Description("Print Ad")]
        Print_Ad = 11,
        [Description("Banner")]
        Banner = 12,

        [Description("Stock Photo")]
        Stock_Photo = 13,
        [Description("TVC")]
        TVC = 14,
        [Description("Lainnya")]
        Lainnya = 15


    }

    public enum CSR_SMEP_ProgramType
    {
        [Description("Kemitraan")]
        Program_Kemitraan = 1,
        [Description("Kolektibilitas PK")]
        Kolektibilitas_PK = 2,
        [Description("Pengelolaan CSR")]
        Pengelolaan_CSR = 3,
        [Description("Pengelolaan BL")]
        Pengelolaan_BL = 4

    }

    public enum CSR_SMEPP_Data_Type
    {
        [Description("RKAP")]
        CSR_RKAP = 1,
        [Description("REALISASI")]
        CSR_REALISASI = 2,
        //[Description("RKAP")]
        //BL_RKAP = 3,
        //[Description("REALISASI")]
        //BL_REALISASI = 4
    }

    public enum Kemitraan_Data_Type
    {
        //[Description("RKAP")]
        //CSR_RKAP = 1,
        //[Description("REALISASI")]
        //CSR_REALISASI = 2,
        [Description("RKAP")]
        RKAP = 5,
        [Description("REALISASI")]
        REALISASI = 6
    }


    public enum BL_SMEPP_Data_Type
    {
        //[Description("RKAP")]
        //CSR_RKAP = 1,
        //[Description("REALISASI")]
        //CSR_REALISASI = 2,
        [Description("RKAP")]
        BL_RKAP = 3,
        [Description("REALISASI")]
        BL_REALISASI = 4
    }


}
