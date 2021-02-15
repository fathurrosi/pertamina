using System.ComponentModel;

namespace Pertamina.CORSEC.Business.Enum
{
    public enum TemplateType
    {

        [Description("Brand management (Brand Guideline)")]
        Brand_Guideline = 1,
        [Description("Brand management (Communication Campaign)")]
        Communication_Campaign = 2,
        [Description("Brand management (Merchandise Hub)")]
        Merchandise_hub = 3,
        [Description("Brand management (Exhibition)")]
        Exhibition = 4,
        [Description("Brand management (Sponsorship)")]
        Sponsorship = 5,
        [Description("Mitra Binaan")]
        Mitra_binaan = 6,
        [Description("Media (Infographic)")]
        Infographic = 7,
        [Description("Media (Pojok Kreasi)")]
        Pojok_Kreasi = 8,

        [Description("Profile Corsec (Overview, Visi & Misi)")]
        Overview_Visi_Misi,
        [Description("Profile Corsec (Strategic Partner)")]
        Strategic_Partner,
        [Description("Struktur Organisasi")]
        Struktur_Organisasi,
        [Description("Guidelines & Policy")]
        Guidelines_Policy,

        [Description("Collateral Corporate")]
        Collateral_Corporate,

        [Description("Collateral Corporate (Kalender)")]
        Collateral_Corporate_Kalender,
        [Description("Collateral Corporate (Agenda)")]
        Collateral_Corporate_Agenda,
        [Description("Collateral Corporate (Kartu Ucapan)")]
        Collateral_Corporate_Kartu,

        [Description("Speech & Report (Materi Presentasi)")]
        Materi_Presentasi,
        [Description("Speech & Report(Kinerja Sekper)")]
        Kinerja_Sekper,

        [Description("Strategi Komunikasi Korporat")]
        Strategi_Komunikasi_Korporat,
        [Description("Strategi Pengelolaan Krisis")]
        Strategi_Pengelolaan_Krisis,

        [Description("Strategi Pengelolaan Krisis Detail")]
        Strategi_Pengelolaan_Krisis_Detail,

        [Description("Strategic Stake holder Engagement")]
        Strategic_Stake_holder_Engagement,

        [Description("Diplomatic Intelegence")]
        Diplomatic_Intelegence,

        [Description("Stake Holder Database")]
        Stake_Holder_Database,

        [Description("Strategi Pengelolaan CSR-SMEPP")]
        Strategi_Pengelolaan_CSR_SMEPP,

        [Description("Strategi Pengelolaan CSR-BL")]
        Strategi_Pengelolaan_CSR_BL,

        [Description("Program Kemitraan")]
        Strategi_Program_Kemitraan,


        Desain,
        Infografis,

        [Description("Media Monitoring")]
        Media_Monitoring,

        [Description("Kinerja SEKPER")]
        Kinerja_SEKPER
    }
}
