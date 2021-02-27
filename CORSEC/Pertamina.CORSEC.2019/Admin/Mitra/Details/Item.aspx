<%@ Page Title="" Language="C#" MasterPageFile="~/Backend.Master" AutoEventWireup="true" CodeBehind="Item.aspx.cs" Inherits="Pertamina.CORSEC._2019.Admin.Mitra.Details.Item" EnableEventValidation="false" %>

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
            <asp:TextBox ID="lblTitle" runat="server" class="form-control"></asp:TextBox>
        </div>
    </div>

    <div class="form-group">
        <label class="control-label col-sm-2">Kategori</label>
        <div class="col-sm-6">
            <asp:DropDownList ID="ddlCategory" runat="server" class="form-control"></asp:DropDownList>

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
        <label class="control-label col-sm-2">SKU</label>
        <div class="col-sm-6">
            <asp:TextBox ID="lblSKU" runat="server" class="form-control"></asp:TextBox>
        </div>
    </div>


    <div class="form-group">

        <label class="control-label col-sm-2">Estimasi harga</label>
        <div class="col-sm-6">
            <div class="row">
                <div class="col-sm-4">
                    <asp:TextBox ID="lblHargaMulai" runat="server" class="form-control allownumericwithdecimal"></asp:TextBox>
                </div>
                <div class="col-sm-4">
                    <asp:TextBox ID="lblHargaSampai" runat="server" class="form-control allownumericwithdecimal"></asp:TextBox>
                </div>
            </div>
        </div>
    </div>



    <div class="form-group">
        <label class="control-label col-sm-2">Min. Quantity</label>
        <div class="col-sm-6">
            <asp:TextBox ID="lblQuantity" runat="server" class="form-control"></asp:TextBox>
        </div>
    </div>


    <div class="form-group">
        <div class="col-sm-12" style="text-align: center">
            <div class="row">
                <asp:ListView ID="listViewMitra_binaan" runat="server">
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
                                    <a title="klik untuk edit atau hapus." href='<%# ResolveUrl(string.Format("~/Admin/Mitra/Details/Item-Add.aspx{0}&pid={1}&id={2}", PrevUrl, Eval("product_id"), Eval("id"))) %>' class="kt-widget19__username">
                                        <div class="kt-widget19__pic kt-portlet-fit--top kt-portlet-fit--sides" style="min-height: 280px; min-width: 200px; background-image: url('<%# ConvertUrl(Eval("file_blob"))%>')" title="klik untuk edit atau hapus.">
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

        <div class="col-sm-6">
            <asp:GridView ID="grid" runat="server" class="table table-bordered table-striped"
                AutoGenerateColumns="false"
                AllowPaging="true"
                AllowSorting="true"
                OnRowDataBound="grid_RowDataBound">
                <PagerStyle CssClass="bs4-aspnet-pager" />
                <PagerSettings Mode="NumericFirstLast" FirstPageText="First" LastPageText="Last" />
                <Columns>
                    <asp:TemplateField HeaderText="Action" HeaderStyle-Width="50px" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:HyperLink ID="hlEdit" runat="server" ToolTip="Edit" Visible="false"><i class="fa fa-edit" ></i></asp:HyperLink>
                            <asp:HiddenField ID="hdn" runat="server" Value='<%# Eval("id")%>' />
                            <asp:LinkButton runat="server" ID="lbDel" ToolTip="Delete" OnClick="lb_Click"><i class="far fa-trash-alt" ></i></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Produk Lainnya">
                        <ItemTemplate>
                            <%# Eval("Title")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Logo">
                        <ItemTemplate>
                            <asp:Image runat="server" Width="200" ImageUrl='<%# ConvertUrl(Eval("file_blob"))%>'></asp:Image>
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

        <div class="col-sm-6">
            <asp:Button ID="btnAddFile" runat="server" Text="Tambah Produk Terkait" OnClick="btnAddFile_Click" />
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

            $(".allownumericwithdecimal").on("keypress keyup blur", function (event) {
                //this.value = this.value.replace(/[^0-9\.]/g,'');
                $(this).val($(this).val().replace(/[^0-9\.]/g, ''));
                if ((event.which != 46 || $(this).val().indexOf('.') != -1) && (event.which < 48 || event.which > 57)) {
                    event.preventDefault();
                }
            });
        });

    </script>
</asp:Content>
