<%@ Page Title="" Language="C#" MasterPageFile="~/Backend.Master" AutoEventWireup="true" CodeBehind="Sponsorship.aspx.cs" Inherits="Pertamina.CORSEC._2019.Admin.Brand.Details.Sponsorship"  EnableEventValidation="false" %>

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
                <asp:ListView ID="listViewSponsorship" runat="server">
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
                                    <a title="klik untuk edit atau hapus." href='<%# ResolveUrl(string.Format("~/Admin/Brand/Details/Sponsorship-Add.aspx{0}&pid={1}&id={2}", PrevUrl, Eval("sponsorship_id"), Eval("id"))) %>' class="kt-widget19__username">
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
        <label class="control-label col-sm-2">Lokasi</label>
        <div class="col-sm-6">
            <asp:TextBox ID="lblLokasi" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
    </div>

    <div class="form-group">
        <label class="control-label col-sm-2">Award</label>
        <div class="col-sm-6">
            <asp:TextBox ID="lblAward" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
    </div>

    <div class="form-group">

        <div class="col-sm-6">
            <asp:Button ID="btnAddFile" runat="server" Text="Tambah File Materi & Poster" OnClick="btnAddFile_Click" />
        </div>
    </div>
    <div class="form-group">

        <div class="col-sm-6">
            <asp:GridView ID="grid" runat="server" class="table table-bordered table-striped"
                AutoGenerateColumns="false"
                AllowPaging="true"
                AllowSorting="true"
                OnRowDataBound="grid_RowDataBound">
                <PagerStyle CssClass="bs4-aspnet-pager" />
                <PagerSettings Mode="NumericFirstLast" FirstPageText="First" LastPageText="Last" />
                <Columns>
                    <asp:TemplateField HeaderText="Action" HeaderStyle-Width="70px">
                        <ItemTemplate>
                            <asp:HyperLink ID="hlEdit" runat="server" ToolTip="Edit"><i class="fa fa-edit"></i></asp:HyperLink>
                            <asp:HiddenField ID="hdn" runat="server" Value='<%# Eval("id")%>' />
                            <asp:LinkButton runat="server" ID="lbDel" ToolTip="Delete" OnClick="lb_Click"><i class="far fa-trash-alt" ></i></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Keterangan">
                        <ItemTemplate>
                            <%# Eval("file_desc")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Ukuran File">
                        <ItemTemplate>
                            <%# Eval("file_size")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Dibuat">
                        <ItemTemplate>
                            <%# String.Format("{0:dd MMM yyyy HH:mm:ss}", Eval("created") ) %>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <EmptyDataTemplate>
                    There are currently no items in this table.
                </EmptyDataTemplate>

            </asp:GridView>
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
