<%@ Page Title="" Language="C#" MasterPageFile="~/Backend.Master" AutoEventWireup="true" CodeBehind="TVC.aspx.cs" Inherits="Pertamina.CORSEC._2019.Admin.DesignGrafis.details.TVC" EnableEventValidation="false" %>

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
            <asp:TextBox ID="lblTitle" runat="server" CssClass="form-control"></asp:TextBox>
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
        <label class="control-label col-sm-2">
        </label>
        <div class="col-sm-6">
            <asp:Image ID="imgThumnail" ImageUrl="~/Content/assets/media/users/default.jpg" runat="server" CssClass="imgThumnail img-fluid img-thumbnail img-thumbnail-no-borders rounded-0" alt="image thumnail" />
        </div>
    </div>
    <div class="form-group">

        <label class="control-label col-sm-2">
            Pilih Tampilan awal
        </label>
        <div class="col-sm-6">
            <asp:FileUpload ID="fuImportImage" runat="server" CssClass="form-control imageUpload" />
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
                ControlToValidate="fuImportImage"
                ErrorMessage="Only JPEG, PNG images are allowed" ForeColor="Red"
                ValidationExpression="(.*\.([Jj][Pp][Gg])|.*\.([Jj][Pp][Ee][Gg])|.*\.([Pp][Nn][Gg])$)">
            </asp:RegularExpressionValidator>
        </div>
    </div>

    <div class="form-group" id="videoContainter" runat="server">
        <label class="control-label col-sm-2">
        </label>
        <div class="col-sm-6">
            <asp:Literal ID="lblVideo" runat="server"></asp:Literal>
        </div>

    </div>
    <div class="form-group">
        <div class="col-sm-12">
            <asp:Button ID="btnAdd" runat="server" Text="Tambah Video" OnClick="btnAdd_Click" />
            <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click" />
        </div>
    </div>

    <div class="form-group">
        <label class="control-label col-sm-2">Tahun</label>
        <div class="col-sm-2">
            <asp:TextBox ID="lblTahun" runat="server" CssClass="form-control year" ClientIDMode="Static"></asp:TextBox>
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

            $(".year").datepicker({
                format: "yyyy",
                viewMode: "years",
                minViewMode: "years"
            });
        });


    </script>
</asp:Content>
