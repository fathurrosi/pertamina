<%@ Page Title="" Language="C#" MasterPageFile="~/Backend.Master" AutoEventWireup="true" CodeBehind="pojok-kreasi.aspx.cs" Inherits="Pertamina.CORSEC._2019.Admin.Media.pojok_kreasi" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">

    <div class="form-group">
        <div class="col-sm-12">
            <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
        </div>
    </div>
    <div class="form-group">
        <label class="control-label col-sm-2">Pilih Kategori</label>
        <div class="col-sm-6">
            <asp:DropDownList ID="ddldata_type" runat="server" class="form-control" AutoPostBack="true"></asp:DropDownList>
        </div>
    </div>
    <div class="form-group">
        <div class="col-sm-6">
            <asp:Button ID="btnCreate" runat="server" Text="Buat Baru" OnClick="btnCreate_Click" />
        </div>
    </div>

    <asp:GridView ID="grid" DataSourceID="obj" runat="server" class="table table-bordered table-striped"
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
                    <asp:HiddenField ID="hdn_infographic_type" runat="server" Value='<%# Eval("infographic_type")%>' />
                    <asp:LinkButton runat="server" ID="lbDel" ToolTip="Delete" OnClick="lb_Click"><i class="far fa-trash-alt" ></i></asp:LinkButton>

                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Judul">
                <ItemTemplate>
                    <%# Eval("Title")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Isi">
                <ItemTemplate>
                    <%# Eval("body")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Gambar">
                <ItemTemplate>
                    <asp:Image ID="imgThumnail" Width="100px" ImageUrl='<%# ConvertUrl(Eval("img_blob"))%>' runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Dibuat">
                <ItemTemplate>
                    <%# String.Format("{0:dd MMM yyyy HH:mm:ss}", Eval("created") ) %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Diubah">
                <ItemTemplate>
                    <%# String.Format("{0:dd MMM yyyy HH:mm:ss}", Eval("updated") ) %>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>

        <EmptyDataTemplate>
            There are currently no items in this table.
        </EmptyDataTemplate>

    </asp:GridView>

    <asp:ObjectDataSource ID="obj" TypeName="Pertamina.CORSEC.Dta.tbl_MediaItem" EnablePaging="true" runat="server"
        MaximumRowsParameterName="PageSize"
        StartRowIndexParameterName="PageIndex"
        SelectCountMethod="GetCount"
        SelectMethod="GetPaging">

        <SelectParameters>
            <asp:Parameter Name="PageIndex" Type="Int32" />
            <asp:Parameter Name="PageSize" Type="Int32" />
            <%-- <asp:Parameter Name="infographic_type" Type="Int32" DefaultValue="2" />--%>
            <asp:ControlParameter ControlID="ddldata_type" Name="infographic_type" Type="Int32" DefaultValue="0" PropertyName="SelectedValue" />
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="script" runat="server">
</asp:Content>
