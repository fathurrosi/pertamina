<%@ Page Title="" Language="C#" MasterPageFile="~/Backend.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="strategic-partner.aspx.cs" Inherits="Pertamina.CORSEC._2019.Admin.ProfilCorsec.strategic_partner" %>

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
        <label class="control-label col-sm-2">Judul Tab</label>
        <div class="col-sm-6">
            <asp:DropDownList ID="ddlTipe" runat="server" CssClass="form-control col-4" AutoPostBack="true" OnSelectedIndexChanged="ddlTipe_SelectedIndexChanged"></asp:DropDownList>
        </div>
    </div>



    <div class="form-group">
        <label class="control-label col-sm-2">Judul Visi</label>
        <div class="col-sm-6">
            <asp:TextBox ID="lblTitle" runat="server" class="form-control"></asp:TextBox>
        </div>
    </div>

    <div class="form-group">
        <label class="control-label col-sm-2">Isi Visi</label>
        <div class="col-sm-10">
            <textarea class="textarea" runat="server" id="lblContent" placeholder=""
                style="width: 100%; height: 200px; font-size: 14px; line-height: 18px; border: 1px solid #dddddd; padding: 10px;"></textarea>
        </div>
    </div>

    <div class="form-group">
        <div class="col-sm-offset-2 col-sm-10">
            <asp:Button ID="btnSave" runat="server" Text="Simpan" OnClick="btnSave_Click" />

        </div>
    </div>


</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="script" runat="server">
    <%-- <script>
        function readURL(input) {
            //alert('test masuk');
            if (input.files && input.files[0]) {
                var reader = new FileReader();
                reader.onload = function (e) {
                    jQuery('.imgThumnail').attr('src', e.target.result);
                }
                reader.readAsDataURL(input.files[0]);
            }
        }

        $(function () {
            $(".imageUpload").change(function (e) {
                readURL(this);
            });

        });

    </script>--%>
</asp:Content>
