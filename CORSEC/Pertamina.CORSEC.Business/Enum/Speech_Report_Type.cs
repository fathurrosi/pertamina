

using System.ComponentModel;

namespace Pertamina.CORSEC.Business.Enum
{
    public enum KinerjaSekper
    {
        [Description("Semeter 1")]
        Semester1 = 1,
        [Description("Semeter 2")]
        Semester2 = 2
    }
    public enum Speech_Report_Type
    {
        //tab_Board_Speech.HRef = ResolveUrl(string.Format("~/SpeechReport/presentasi.aspx{0}&tab={1}", PrevUrl, 1));
        //tab_Presentasi_Corporate.HRef = ResolveUrl(string.Format("~/SpeechReport/presentasi.aspx{0}&tab={1}", PrevUrl, 2));
        //tab_Email_Broadcast.HRef = ResolveUrl(string.Format("~/SpeechReport/presentasi.aspx{0}&tab={1}", PrevUrl, 3));
        //tab_Materi_Presentasi.HRef = ResolveUrl(string.Format("~/SpeechReport/presentasi.aspx{0}&tab={1}", PrevUrl, 4));

        [Description("Board Speech")]
        BoardSpeech = 1,
        [Description("Presentasi Corporate")]
        PresentasiCorporate = 2,
        [Description("Email Broadcast")]
        EmailBroadcast = 3,
        [Description("Materi Presentasi")]
        MateriPresentasi = 4

    }

    public enum Infographic_Type
    {
        [Description("Infografis corporate")]
        Infografis_corporate = 1,
        [Description("Pertapedia")]
        Pertapedia = 2,
        [Description("Konten social media")]
        Konten_social_media = 3,
        [Description("Media external")]
        Media_external = 4,
        [Description("Print Ad")]
        Print_Ad = 5,
        [Description("Stock Photo")]
        Stock_Photo = 6,
        TVC = 7


    }

}
