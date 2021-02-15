<%@ Page Title="" Language="C#" MasterPageFile="~/Backend.Master" AutoEventWireup="true"  EnableEventValidation="false"  CodeBehind="Organisasi.aspx.cs" Inherits="Pertamina.CORSEC._2019.Admin.Organization.Organisasi" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">

    <div class="form-group">
        <asp:Image ID="imgThumnail" ImageUrl="#" runat="server" CssClass="imgThumnail img-fluid img-thumbnail img-thumbnail-no-borders rounded-0" alt="image thumnail" />
    </div>


    <div class="form-group">

        <label class="control-label col-sm-2">
        </label>
        <div class="col-sm-6">
            <asp:FileUpload ID="fuImportImage" runat="server" CssClass="form-control imageUpload" />
            <asp:RegularExpressionValidator ID="regexValidator" runat="server"
                ControlToValidate="fuImportImage"
                ErrorMessage="Only JPEG images are allowed" ForeColor="Red"
                ValidationExpression="(.*\.([Jj][Pp][Gg])|.*\.([Jj][Pp][Ee][Gg])|.*\.([Pp][Nn][Gg])$)">
            </asp:RegularExpressionValidator>
        </div>
    </div>

    <div class="form-group">
        <label class="control-label col-sm-2">Judul</label>
        <div class="col-sm-6">
            <asp:TextBox ID="lblTitle" runat="server" class="form-control"></asp:TextBox>
        </div>
    </div>


    <div class="form-group">
        <label class="control-label col-sm-2">Sub Judul</label>
        <div class="col-sm-6">
            <asp:TextBox ID="lblTitleSub" runat="server" class="form-control"></asp:TextBox>
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
        <label class="control-label col-sm-2">Root</label>
        <div class="col-sm-6">
            <asp:TextBox ID="lblRoot" runat="server" class="form-control"></asp:TextBox>
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
