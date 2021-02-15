<%@ Page Title="" Language="C#" MasterPageFile="~/Backend.Master" AutoEventWireup="true" CodeBehind="Video-Add.aspx.cs" Inherits="Pertamina.CORSEC._2019.Admin.Media.details.Video_Add" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div class="form-group">
        <div class="col-sm-12" style="text-align: center">
            <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
        </div>
    </div>
    <br />

    <div class="form-group">
        <label class="control-label col-sm-2">
            Pilih Video
           
        </label>
        <div class="col-sm-6">
            <asp:FileUpload ID="fuImportImage" ClientIDMode="Static" runat="server" CssClass="form-control imageUpload" />
            <video controls width="500px" id="vid" style="display: none"></video>
            <asp:HiddenField ID="lblDurasi" ClientIDMode="Static" runat="server"></asp:HiddenField>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server"
                ControlToValidate="fuImportImage"
                ErrorMessage="Only (mp4, webm, ogv) file supported" ForeColor="Red"
                ValidationExpression="(.*\.([Oo][Gg][Vv])|.*\.([Mm][Pp][4])|.*\.([Ww][Ee][Bb][Mm])$)">
            </asp:RegularExpressionValidator>
        </div>
    </div>

    <div class="form-group">
        <div class="col-sm-offset-2 col-sm-10">
            <asp:Button ID="btnSave" runat="server" Text="Simpan" OnClick="btnSave_Click" ClientIDMode="Static" />

        </div>
    </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="script" runat="server">
    <script type="text/ecmascript">
        var objectUrl;

        $(document).ready(function () {
            $("#fuImportImage").change(function (e) {
                var file = e.currentTarget.files[0];
                objectUrl = URL.createObjectURL(file);
                $("#vid").prop("src", objectUrl);
                //alert(objectUrl);

            });

            $('#btnSave').click(function () {
                var duration = $("#vid")[0].duration;
                var total_minutes = parseInt(duration / 60, 10);
                var seconds = Math.floor(duration % 60);
                var hours = Math.floor(total_minutes / 60);
                var menutes = total_minutes % 60;
                var duration = hours + ":" + menutes + ":" + seconds;
                if (hours == 0 && menutes == 0 && seconds == 0)
                    duration = "";

                $('#lblDurasi').val(duration);
            });

        });
    </script>

</asp:Content>
