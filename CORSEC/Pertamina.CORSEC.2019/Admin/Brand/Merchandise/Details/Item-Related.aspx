<%@ Page Title="" Language="C#" MasterPageFile="~/Backend.Master" AutoEventWireup="true" CodeBehind="Item-Related.aspx.cs" Inherits="Pertamina.CORSEC._2019.Admin.Brand.Merchandise.Details.Item_Related" EnableEventValidation="false" %>

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

        <label class="control-label col-sm-6">
            Pilih Produk terkait lalu tekan tombol Simpan.
        </label>
        <div class="col-sm-6">
            <asp:GridView ID="grid" runat="server" class="table table-bordered table-striped"
                AutoGenerateColumns="false"
                AllowPaging="true"
                AllowSorting="true"
                OnRowDataBound="grid_RowDataBound">
                <PagerStyle CssClass="bs4-aspnet-pager" />
                <PagerSettings Mode="NumericFirstLast" FirstPageText="First" LastPageText="Last" />
                <Columns>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:CheckBox ID="checkbox2" OnCheckedChanged="CheckAll" runat="server" AutoPostBack="True" />
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:CheckBox ID="IDCheckbox" runat="server" />
                            <asp:HiddenField ID="hdn" runat="server" Value='<%# Eval("id")%>' />
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Produk lainnya">
                        <ItemTemplate>
                            <%# Eval("title")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <%--              <asp:TemplateField HeaderText="Logo">
                        <ItemTemplate>
                            <asp:Image runat="server" Width="200" ImageUrl='<%# ConvertUrl(Eval("file_blob"))%>'></asp:Image>
                        </ItemTemplate>
                    </asp:TemplateField>--%>
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
            <asp:Button ID="btnBack" runat="server" Text="Kembali" OnClick="btnBack_Click" />

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
