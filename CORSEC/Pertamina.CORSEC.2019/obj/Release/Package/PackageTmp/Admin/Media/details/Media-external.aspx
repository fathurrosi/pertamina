<%@ Page Title="" Language="C#" MasterPageFile="~/Backend.Master" AutoEventWireup="true" CodeBehind="Media-external.aspx.cs" Inherits="Pertamina.CORSEC._2019.Admin.Media.details.Media_external" EnableEventValidation="false" %>

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
        <div class="col-sm-12" style="text-align: center">
            <div class="row">
                <asp:ListView ID="listViewExhibition" runat="server">
                    <EmptyDataTemplate>
                        <div class="form-group">
                            <asp:Image ID="imgThumnail" ImageUrl="~/Content/assets/media/users/default.jpg" runat="server" CssClass="imgThumnail img-fluid img-thumbnail img-thumbnail-no-borders rounded-0" alt="image thumnail" />
                        </div>
                    </EmptyDataTemplate>
                    <EmptyItemTemplate>
                        <td runat="server" />
                    </EmptyItemTemplate>
                    <ItemTemplate>
                        <div class="col-md-4">
                            <!--begin:: Widgets/Blog-->
                            <div class="kt-portlet kt-portlet--height-fluid kt-widget19">
                                <div class="kt-portlet__body kt-portlet__body--fit kt-portlet__body--unfill">
                                    <a title="klik untuk edit atau hapus." href='<%# ResolveUrl(string.Format("~/Admin/Media/Details/Media-Add.aspx{0}&pid={1}&id={2}", PrevUrl, Eval("infographic_id"), Eval("id"))) %>' class="kt-widget19__username">
                                        <div class="kt-widget19__pic kt-portlet-fit--top kt-portlet-fit--sides" style="min-height: 200px; min-width: 200px; background-image: url('<%# ConvertUrl(Eval("file_blob"))%>')" title="klik untuk edit atau hapus.">
                                        </div>
                                    </a>
                                </div>
                            </div>
                            <!--end:: Widgets/Blog-->
                        </div>
                    </ItemTemplate>
                </asp:ListView>
            </div>
        </div>
    </div>
    <div class="form-group">
        <div class="col-sm-12">
            <asp:Button ID="btnAdd" runat="server" Text="Tambah Gambar" OnClick="btnAdd_Click" />
        </div>
    </div>

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
