<%@ Page Title="" Language="C#" MasterPageFile="~/Backend.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="Footer.aspx.cs" Inherits="Pertamina.CORSEC._2019.Admin.About.Details.Footer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">

    <div class="form-group">
        <label class="control-label col-sm-2">Kategori</label>
        <div class="col-sm-6">
            <asp:TextBox ID="lblFooter" runat="server" class="form-control"></asp:TextBox>
        </div>
    </div>



    <div class="form-group" runat="server" id="_details">

        <div class="col-sm-6">

            <asp:Button ID="btnCreate" runat="server" Text="Buat Baru" OnClick="btnCreate_Click" />
            <br />
            <br />
            <label class="control-label col-sm-2">Daftar Link</label>
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
                    <asp:TemplateField HeaderText="Text">
                        <ItemTemplate>
                            <%# Eval("footer_text")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Link">
                        <ItemTemplate>
                            <%# Eval("footer_link")%>
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

            <asp:ObjectDataSource ID="obj" TypeName="Pertamina.CORSEC.Dta.tbl_Footer_DetailItem" EnablePaging="true" runat="server"
                MaximumRowsParameterName="PageSize"
                StartRowIndexParameterName="PageIndex"
                SelectCountMethod="GetCount"
                SelectMethod="GetPaging">

                <SelectParameters>
                    <asp:Parameter Name="PageIndex" Type="Int32" />
                    <asp:Parameter Name="PageSize" Type="Int32" />

                    <asp:QueryStringParameter Name="Footer" QueryStringField="id" DefaultValue="0" />
                </SelectParameters>
            </asp:ObjectDataSource>
        </div>
    </div>




    <div class="form-group">
        <label class="control-label col-sm-2"></label>
        <div class="col-sm-6">
            <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
            <asp:Button ID="btnCancel" runat="server" Text="Back" OnClick="btnCancel_Click" />
        </div>
    </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="script" runat="server">
</asp:Content>
