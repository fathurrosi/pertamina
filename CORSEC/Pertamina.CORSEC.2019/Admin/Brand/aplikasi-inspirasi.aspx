<%@ Page Title="" Language="C#" MasterPageFile="~/Backend.Master" AutoEventWireup="true" CodeBehind="aplikasi-inspirasi.aspx.cs" Inherits="Pertamina.CORSEC._2019.Admin.Brand.aplikasi_inspirasi" EnableEventValidation="false" %>

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


    <asp:Button ID="btnCreate" runat="server" Text="Tambah Detail Aplikasi & Inspirasi" OnClick="btnCreate_Click" />
    <br />
    <br />

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

    <asp:ObjectDataSource ID="obj" TypeName="Pertamina.CORSEC.Dta.tbl_brand_guideline_aplikasi_inspirasi_detailItem" EnablePaging="true" runat="server"
        MaximumRowsParameterName="PageSize"
        StartRowIndexParameterName="PageIndex"
        SelectCountMethod="GetCount"
        SelectMethod="GetPaging">

        <SelectParameters>
            <asp:Parameter Name="PageIndex" Type="Int32" />
            <asp:Parameter Name="PageSize" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>



    <div class="form-group">
        <div class="col-sm-offset-2 col-sm-10">
            <asp:Button ID="btnSave" runat="server" Text="Simpan" OnClick="btnSave_Click" />
        </div>
    </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="script" runat="server">
</asp:Content>
