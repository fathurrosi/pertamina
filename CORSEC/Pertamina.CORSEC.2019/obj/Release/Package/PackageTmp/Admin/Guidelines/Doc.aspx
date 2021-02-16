<%@ Page Title="" Language="C#" MasterPageFile="~/Backend.Master" AutoEventWireup="true" CodeBehind="Doc.aspx.cs" Inherits="Pertamina.CORSEC._2019.Admin.Guidelines.Doc" EnableEventValidation="false"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <asp:Button ID="btnCreate" runat="server" Text="Buat Baru" OnClick="btnCreate_Click" />
    <br />
    <br />
    <asp:DropDownList ID="ddlTipe_Dokumen" runat="server" CssClass="form-control col-4" AutoPostBack="true" OnSelectedIndexChanged="ddlTipe_Dokumen_SelectedIndexChanged"></asp:DropDownList>
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
                    <asp:HiddenField ID="hdnFileID" runat="server" Value='<%# Eval("file_id")%>' />
                    <asp:LinkButton runat="server" ID="lbDel" ToolTip="Delete" OnClick="lb_Click"><i class="far fa-trash-alt" ></i></asp:LinkButton>

                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="No">
                <ItemTemplate>
                    <%# Eval("PAGING_ROW_NUMBER")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="No_Dokumen">
                <ItemTemplate>
                    <%# Eval("No_Dokumen")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Tipe_Dokumen">
                <ItemTemplate>
                    <%# Eval("Tipe_Dokumen")%>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Judul">
                <ItemTemplate>
                    <asp:HyperLink ID="linkFile" runat="server"><%# Eval("Judul")%></asp:HyperLink>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Tahun">
                <ItemTemplate>
                    <%# Eval("Tahun")%>
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

    <asp:ObjectDataSource ID="obj" TypeName="Pertamina.CORSEC.Dta.tbl_Guidelines_DocItem" EnablePaging="true" runat="server"
        MaximumRowsParameterName="PageSize"
        StartRowIndexParameterName="StartRowIndex"
        SelectCountMethod="GetCountByTipeDoucment"
        SelectMethod="GetPagingByTipeDoucment">

        <SelectParameters>
            <asp:Parameter Name="StartRowIndex" Type="Int32" />
            <asp:Parameter Name="PageSize" Type="Int32" />
            <asp:ControlParameter Name="tipeDocument" PropertyName="SelectedValue" Type="String" DefaultValue="Jenis Dokumen" ControlID="ddlTipe_Dokumen" />
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="script" runat="server">
</asp:Content>
