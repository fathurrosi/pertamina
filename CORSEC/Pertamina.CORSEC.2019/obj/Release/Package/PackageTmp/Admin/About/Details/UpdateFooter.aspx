<%@ Page Title="" Language="C#" MasterPageFile="~/Backend.Master" AutoEventWireup="true" EnableEventValidation="false"  CodeBehind="UpdateFooter.aspx.cs" Inherits="Pertamina.CORSEC._2019.Admin.About.Details.UpdateFooter" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">

    <div class="form-group">
        <label class="control-label col-sm-2">Text</label>
        <div class="col-sm-6">
            <asp:TextBox ID="lblText" runat="server" class="form-control"></asp:TextBox>
        </div>
    </div>
    
    <div class="form-group">
        <label class="control-label col-sm-2">Link</label>
        <div class="col-sm-6">
            <asp:TextBox ID="lblLink" runat="server" class="form-control"></asp:TextBox>
        </div>
    </div>

    

    <div class="form-group">
        <label class="control-label col-sm-2"></label>
        <div class="col-sm-6">
            <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
            <asp:Button ID="btnCancel" runat="server" Text="Back" OnClick="btnCancel_Click" />
        </div>
    </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="script" runat="server">
</asp:Content>
