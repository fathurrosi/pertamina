<%@ Page Title="" Language="C#" MasterPageFile="~/Backend.Master" AutoEventWireup="true" CodeBehind="StrukturCorcom.aspx.cs" Inherits="Pertamina.CORSEC._2019.Admin.Organization.Details.StrukturCorcom"  EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">


    <div class="form-group">
        <label class="control-label col-sm-2">Nama Jabatan</label>
        <div class="col-sm-6">
            <asp:DropDownList ID="ddlJabatan" runat="server" class="form-control"></asp:DropDownList>
        </div>
    </div>

    <div class="form-group">
        <label class="control-label col-sm-2">Urutan</label>
        <div class="col-sm-6">
            <asp:TextBox ID="lblUrut" runat="server" class="form-control"></asp:TextBox>
        </div>
    </div>


    <div class="form-group">
        <label class="control-label col-sm-2">Jabatan (Diatasnya)</label>
        <div class="col-sm-6">
            <asp:HiddenField ID="hdnParentID" runat="server" />
            <asp:HiddenField ID="hdnParentJabatanID" runat="server" />
            <asp:TextBox ID="lblRootName" runat="server" class="form-control"  readonly></asp:TextBox>
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
