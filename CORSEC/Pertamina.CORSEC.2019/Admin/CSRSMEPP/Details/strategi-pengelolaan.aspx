<%@ Page Title="" Language="C#" MasterPageFile="~/Backend.Master" AutoEventWireup="true" CodeBehind="strategi-pengelolaan.aspx.cs"
    Inherits="Pertamina.CORSEC._2019.Admin.CSRSMEPP.Details.strategi_pengelolaan" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">

    <div class="form-group">
        <label class="control-label col-sm-2">Judul</label>
        <div class="col-sm-6">
            <asp:TextBox ID="txtTitle" runat="server" class="form-control"></asp:TextBox>
        </div>
    </div>

    <div class="form-group">
        <label class="control-label col-sm-2">Isi</label>
        <div class="col-sm-10">
            <textarea class="textarea" runat="server" id="txtContent" placeholder=""
                style="width: 100%; height: 200px; font-size: 14px; line-height: 18px; border: 1px solid #dddddd; padding: 10px;"></textarea>
        </div>
    </div>

    <div class="form-group" runat="server" visible="false">
        <label class="control-label col-sm-2">Tahu</label>
        <div class="col-sm-2">
            <asp:TextBox ID="txtTahun" runat="server" class="form-control"></asp:TextBox>
        </div>
    </div>



    <div class="form-group">
        <label class="control-label col-sm-2">Kategori</label>
        <div class="col-sm-6">
            <asp:DropDownList ID="ddlKateori" runat="server" class="form-control"></asp:DropDownList>
        </div>
    </div>

    <div class="form-group" runat="server" visible="false">
        <label class="control-label col-sm-2">Related Document</label>
        <div class="col-sm-6">
            <asp:DropDownList ID="ddlDocument" runat="server" class="form-control"></asp:DropDownList>
        </div>
    </div>

    <div class="form-group" runat="server" visible="false">
        <label class="control-label col-sm-2">Kategori</label>
        <div class="col-sm-6">
            <asp:DropDownList ID="ddldata_type" runat="server" class="form-control"></asp:DropDownList>
        </div>
    </div>


    <div class="form-group">

        <label class="control-label col-sm-2">
            Pilih File
        </label>
        <div class="col-sm-6">
            <asp:FileUpload ID="fileUpload" runat="server" CssClass="form-control" />
            <asp:RegularExpressionValidator ID="regexValidator" runat="server"
                ControlToValidate="fileUpload" ValidationExpression="^.*\.(doc|DOC|docx|DOCX|pdf|PDF)$"
                ErrorMessage="Only doc or pdf are allowed" ForeColor="Red">
            </asp:RegularExpressionValidator>
            <br />
            <asp:HyperLink ID="fileUploaded" runat="server"></asp:HyperLink>
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
