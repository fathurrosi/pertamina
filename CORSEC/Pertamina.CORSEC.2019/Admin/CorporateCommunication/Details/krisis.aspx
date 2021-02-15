<%@ Page Title="" Language="C#" MasterPageFile="~/Backend.Master" AutoEventWireup="true" CodeBehind="krisis.aspx.cs" Inherits="Pertamina.CORSEC._2019.Admin.CorporateCommunication.Details.krisis" EnableEventValidation="false" %>

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
        <label class="control-label col-sm-2">Judul</label>
        <div class="col-sm-6">
            <asp:TextBox ID="txtTitle" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
    </div>
    <div class="form-group">
        <label class="control-label col-sm-2">Isi</label>
        <div class="col-sm-10">
            <textarea class="textarea" runat="server" id="txtContent" placeholder=""
                style="width: 100%; height: 200px; font-size: 14px; line-height: 18px; border: 1px solid #dddddd; padding: 10px;"></textarea>
        </div>
    </div>
    <div class="form-group">
        <label class="control-label col-sm-2">Kategori</label>
        <div class="col-sm-6">
            <asp:DropDownList ID="ddlKategori" AutoPostBack="true" runat="server" class="form-control" OnSelectedIndexChanged="ddlKategori_SelectedIndexChanged"></asp:DropDownList>
        </div>
    </div>

    <div class="form-group">
        <label class="control-label col-sm-2">Sub Kategori</label>
        <div class="col-sm-6">
            <asp:DropDownList ID="ddlSubKategori" runat="server" class="form-control"></asp:DropDownList>
        </div>
    </div>



    <div class="form-group">
        <label class="control-label col-sm-2">Tahun</label>
        <div class="col-sm-2">
            <asp:TextBox ID="txtTahun" runat="server" class="form-control" MaxLength="4"></asp:TextBox>
        </div>
    </div>
    <div class="form-group">
        <label class="control-label col-sm-2">Jenis Dokumen</label>
        <div class="col-sm-6">
            <asp:DropDownList ID="ddlJenisDokumen" runat="server" class="form-control"></asp:DropDownList>
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
    <script>
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

    </script>
</asp:Content>
