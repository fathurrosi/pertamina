<%@ Page Title="" Language="C#" MasterPageFile="~/Backend.Master" AutoEventWireup="true" CodeBehind="contact-person.aspx.cs" Inherits="Pertamina.CORSEC._2019.Admin.Brand.Merchandise.contact_person"   EnableEventValidation="false" %>

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
        <label class="control-label col-sm-2">Nama</label>
        <div class="col-sm-6">
            <asp:TextBox ID="lblName" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
    </div>

    <div class="form-group">
        <label class="control-label col-sm-2">Telp</label>
        <div class="col-sm-6">
            <asp:TextBox ID="lblTelp" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
    </div>
    
    <div class="form-group">
        <label class="control-label col-sm-2">Email</label>
        <div class="col-sm-6">
            <asp:TextBox ID="lblEmail" runat="server" CssClass="form-control"></asp:TextBox>
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

