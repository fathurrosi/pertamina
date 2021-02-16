<%@ Page Title="" Language="C#" MasterPageFile="~/Backend.Master" AutoEventWireup="true" CodeBehind="Brand-Guideline.aspx.cs" Inherits="Pertamina.CORSEC._2019.Admin.Brand.Brand_Guideline" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div class="form-group">
        <div class="col-sm-12" style="text-align: center">
            <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
        </div>
    </div>
    <br />
    <div class="row">

        <div class="col-sm-6">
            <div class="form-group">
                <label class="control-label col-sm-6">Nama Logo Korporasi</label>
                <div class="col-sm-6">
                    <asp:TextBox ID="lblNamaLogo" runat="server" class="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <asp:Image ID="imgThumnail" ImageUrl="~/Content/assets/media/users/default.jpg" runat="server" CssClass="imgThumnail img-fluid img-thumbnail img-thumbnail-no-borders rounded-0" alt="image thumnail" />
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
        </div>
        <div class="col-sm-6">
            <div class="form-group">
                <label class="control-label col-sm-6">Nama Logo HUT</label>
                <div class="col-sm-6">
                    <asp:TextBox ID="lblNamaLogoHUT" runat="server" class="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <asp:Image ID="imgThumnailHUT" ImageUrl="~/Content/assets/media/users/default.jpg" runat="server" CssClass="imgThumnailHUT img-fluid img-thumbnail img-thumbnail-no-borders rounded-0" alt="image thumnail" />
            </div>

            <div class="form-group">

                <label class="control-label col-sm-2">
                </label>
                <div class="col-sm-6">
                    <asp:FileUpload ID="fuImportImageHUT" runat="server" CssClass="form-control imageUploadHUT" />
                    <asp:RegularExpressionValidator ID="regexValidatorHUT" runat="server"
                        ControlToValidate="fuImportImageHUT"
                        ErrorMessage="Only JPEG images are allowed" ForeColor="Red"
                        ValidationExpression="(.*\.([Jj][Pp][Gg])|.*\.([Jj][Pp][Ee][Gg])|.*\.([Pp][Nn][Gg])$)">
                    </asp:RegularExpressionValidator>
                </div>
            </div>
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
        function readURL(input, classname) {
            //alert(classname);
            if (input.files && input.files[0]) {
                var reader = new FileReader();
                reader.onload = function (e) {
                    jQuery(classname).attr('src', e.target.result);
                }
                reader.readAsDataURL(input.files[0]);
            }
        }

        $(function () {
            

            $(".imageUpload").change(function (e) {
                readURL(this, '.imgThumnail');
            });


            $(".imageUploadHUT").change(function (e) {

                readURL(this, '.imgThumnailHUT');
            });

        });

    </script>
</asp:Content>
