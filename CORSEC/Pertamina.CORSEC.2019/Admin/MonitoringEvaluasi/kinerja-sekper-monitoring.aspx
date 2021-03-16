<%@ Page Title="" Language="C#" MasterPageFile="~/Backend.Master" AutoEventWireup="true" CodeBehind="kinerja-sekper-monitoring.aspx.cs" Inherits="Pertamina.CORSEC._2019.Admin.MonitoringEvaluasi.kinerja_sekper_monitoring" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <asp:Button ID="btnCreate" runat="server" Text="Buat Baru" OnClick="btnCreate_Click" />
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

            <asp:TemplateField HeaderText="Laporan" ItemStyle-Width="15%">
                <ItemTemplate>
                    <%# Eval("Title")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Bulan" ItemStyle-Width="10%">
                <ItemTemplate>
                    <%# string.Format("{0} {1}", Pertamina.CORSEC.Business.Utilities.ToMonth((int) Eval("Bulan")), Eval("Tahun"))  %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Periode Laporan" ItemStyle-Width="10%">
                <ItemTemplate>
                    <%# Eval("Priode")%>
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

    <asp:ObjectDataSource ID="obj" TypeName="Pertamina.CORSEC.Dta.tbl_MonitoringEvaluasi_KinerjaItem" EnablePaging="true" runat="server"
        MaximumRowsParameterName="PageSize"
        StartRowIndexParameterName="PageIndex"
        SelectCountMethod="GetCount"
        SelectMethod="GetPaging">

        <SelectParameters>
            <asp:Parameter Name="PageIndex" Type="Int32" />
            <asp:Parameter Name="PageSize" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="script" runat="server">
</asp:Content>
