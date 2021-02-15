<%@ Page Title="" Language="C#" MasterPageFile="~/Backend.Master" AutoEventWireup="true" EnableEventValidation="false"  CodeBehind="FeaturedArticle.aspx.cs" Inherits="Pertamina.CORSEC._2019.Admin.About.Details.FeaturedArticle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">

    <div class="form-group">
        <label class="control-label col-sm-2">Judul </label>
        <div class="col-sm-6">
            <asp:TextBox ID="lblTitle" runat="server" class="form-control"></asp:TextBox>
        </div>
    </div>

    <div class="form-group">
        <label class="control-label col-sm-2">Isi</label>
        <div class="col-sm-10">
            <textarea class="textarea" runat="server" id="lblContent" placeholder=""
                style="width: 100%; height: 200px; font-size: 14px; line-height: 18px; border: 1px solid #dddddd; padding: 10px;"></textarea>
        </div>
    </div>

    <div class="form-group">
        <label class="control-label col-sm-2">Kode Youtube </label>
        <div class="col-sm-6">
            <asp:TextBox ID="txtYoutubeCode" runat="server" class="form-control"></asp:TextBox>
        </div>
    </div>

    <div class="form-group">
        <div class="col-sm-offset-2 col-sm-10">
            <asp:Button ID="btnSave" runat="server" Text="Simpan" OnClick="btnSave_Click" />

        </div>
    </div>


</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="script" runat="server">
</asp:Content>
