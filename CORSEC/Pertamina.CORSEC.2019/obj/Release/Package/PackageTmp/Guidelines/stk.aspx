<%@ Page Title="" Language="C#" MasterPageFile="~/Frontend.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="stk.aspx.cs" Inherits="Pertamina.CORSEC._2019.Guidelines.stk" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">


    <!-- begin:: Content -->
    <div class="kt-content-height">
        <div class="kt-content kt-content--fit-top  kt-grid__item kt-grid__item--fluid kt-grid kt-grid--hor"
            id="kt_content">

            <!-- begin:: Content -->

            <!-- begin:: Hero -->
            <%--  <div class="kt-sc" style="background-image: url('<%: ResolveUrl("~/Content/assets/media/bg/bg-9.jpg") %>')">
                <div class="kt-container ">

                    <div class="kt-sc__bottom">
                        <h3 class="kt-sc__heading kt-heading kt-heading--center kt-heading--xxl kt-heading--medium">Guidelines & Policy
                        </h3>

                    </div>
                </div>
            </div>--%>

            <asp:Literal ID="lblHeader" runat="server"></asp:Literal>
            <!-- end:: Hero -->

            <div class="kt-container">
                <div class="kt-portlet">
                    <div class="kt-portlet__body">
                        <div class="kt-infobox">
                            <div class="kt-infobox__header">
                                <h2 class="kt-infobox__title">
                                    <asp:Label ID="lblTitle" runat="server" Text=""></asp:Label>
                                </h2>
                            </div>
                            <div class="kt-infobox__body">
                                <div class="kt-infobox__section">
                                    <div class="kt-infobox__content text-justify">
                                        <asp:Literal ID="lblIsi" runat="server"></asp:Literal>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div class="kt-container ">

                <!--begin::Portlet-->
                <div class="kt-portlet kt-portlet--last kt-portlet--head-lg kt-portlet--responsive-mobile"
                    id="kt_page_portlet">
                    <div class="kt-portlet__head kt-portlet__head--lg">
                        <div class="kt-portlet__head-label">
                            <h3 class="kt-portlet__head-title">STK <small>filter</small></h3>
                        </div>
                        <div class="kt-portlet__head-toolbar">
                            <div class="btn-group" role="group" aria-label="Button group with nested dropdown">
                                <div class="input-group">
                                    <asp:TextBox ID="txtSearch" runat="server" CssClass="form-control" placeholder="Search keyword..."></asp:TextBox>
                                    <div class="input-group-append">
                                        <asp:LinkButton ID="btnSearch" CssClass="btn btn-secondary" runat="server" OnClick="btnSearch_Click"><i class="fa fa-search"></i></asp:LinkButton>
                                    </div>
                                </div>
                                <div class="col-sm-4">
                                    <asp:DropDownList ID="ddlDocumentType" DataTextField="name" DataValueField="name" CssClass="form-control" runat="server"></asp:DropDownList>
                                </div>
                                <div class="col-sm-3">
                                    <asp:DropDownList ID="ddlYear" DataTextField="Code" DataValueField="Code" CssClass="form-control" runat="server"></asp:DropDownList>
                                </div>

                            </div>
                        </div>
                    </div>
                </div>
                <!--end::Portlet-->

                <!-- start::Pedoman -->
                <div class="kt-portlet kt-portlet--mobile">
                    <div class="kt-portlet__head kt-portlet__head--lg">
                        <div class="kt-portlet__head-label">
                            <h3 class="kt-portlet__head-title">Pedoman
                            </h3>
                        </div>
                    </div>
                    <div class="kt-portlet__body">
                        <div class="kt-section">
                            <div class="kt-section__content">
                                <div class="table-responsive">
                                    <asp:GridView ID="gridPedoman" runat="server" class="table table-bordered table-hover"
                                        AutoGenerateColumns="false"
                                        AllowPaging="true"
                                        AllowSorting="false"
                                        OnRowDataBound="grid_RowDataBound">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="Action" HeaderStyle-Width="70px" Visible="false">
                                                <ItemTemplate>
                                                    <asp:HiddenField ID="hdn" runat="server" Value='<%# Eval("id")%>' />
                                                    <asp:HiddenField ID="hdnFileID" runat="server" Value='<%# Eval("file_id")%>' />
                                                    <asp:HiddenField ID="hdnFileExt" runat="server" Value='<%# Eval("file_ext")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="No" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <div class="t-link kt-font-boldest mt-1"><%# Eval("PAGING_ROW_NUMBER")%></div>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="No Dokumen">
                                                <ItemTemplate>
                                                    <%# Eval("No_Dokumen")%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Tipe Dokumen" Visible="false">
                                                <ItemTemplate>
                                                    <%# Eval("Tipe_Dokumen")%>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Judul">
                                                <ItemTemplate>
                                                    <span class="kt-media kt-media--xs">
                                                        <asp:Image ID="imgFile" runat="server" CssClass="float-left mr-2" />
                                                        <asp:HyperLink ID="linkFile" CssClass="t-link kt-font-boldest mt-1" runat="server" data-skin="dark" data-placement="right"><%# Eval("Judul")%></asp:HyperLink>
                                                    </span>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Tahun">
                                                <ItemTemplate>
                                                    <%# Eval("Tahun")%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>

                                        <EmptyDataTemplate>
                                            There are currently no items in this table.
                                        </EmptyDataTemplate>
                                        <PagerSettings Visible="false" />
                                    </asp:GridView>
                                </div>
                                <div id="pagerPedoman" class="kt-pagination kt-pagination--sm kt-pagination--primary kt-mt-40">
                                    <ul class="kt-pagination__links">
                                        <asp:Repeater ID="rptPagerPedoman" runat="server" OnItemDataBound="rptPager_ItemDataBound">
                                            <ItemTemplate>
                                                <li runat="server" id="li">
                                                    <asp:LinkButton ID="lnkPage" runat="server" CommandName="Pedoman" Text='<%#Eval("Text") %>' CommandArgument='<%# Eval("Value") %>' Enabled='<%# Eval("Enabled") %>' OnClick="Page_Changed"></asp:LinkButton>
                                                </li>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </ul>
                                    <div class="kt-pagination__toolbar">
                                        <asp:DropDownList ID="ddlPageSizePedoman" AutoPostBack="true" runat="server" CssClass="form-control kt-font-primary" Style="width: 60px;" DataTextField="Text" DataValueField="Code" OnSelectedIndexChanged="ddlPageSize_SelectedIndexChanged"></asp:DropDownList>
                                        <span class="pagination__desc">
                                            <asp:Literal ID="lblTotalInfoPedoman" runat="server" Text=""></asp:Literal>
                                            <asp:HiddenField ID="hdnPagePedoman" runat="server" />
                                        </span>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <!-- end::Pedoman -->

                <!-- start::TKO -->
                <div class="kt-portlet kt-portlet--mobile">
                    <div class="kt-portlet__head kt-portlet__head--lg">
                        <div class="kt-portlet__head-label">
                            <h3 class="kt-portlet__head-title">TKO
                            </h3>
                        </div>
                    </div>
                    <div class="kt-portlet__body">
                        <div class="kt-section">
                            <div class="kt-section__content">
                                <div class="table-responsive">
                                    <asp:GridView ID="gridTKO" runat="server" class="table table-bordered table-hover"
                                        AutoGenerateColumns="false"
                                        AllowPaging="true"
                                        AllowSorting="false"
                                        OnRowDataBound="grid_RowDataBound">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="Action" HeaderStyle-Width="70px" Visible="false">
                                                <ItemTemplate>
                                                    <asp:HiddenField ID="hdn" runat="server" Value='<%# Eval("id")%>' />
                                                    <asp:HiddenField ID="hdnFileID" runat="server" Value='<%# Eval("file_id")%>' />
                                                    <asp:HiddenField ID="hdnFileExt" runat="server" Value='<%# Eval("file_ext")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="No" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <div class="t-link kt-font-boldest mt-1"><%# Eval("PAGING_ROW_NUMBER")%></div>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="No Dokumen">
                                                <ItemTemplate>
                                                    <%# Eval("No_Dokumen")%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Tipe Dokumen" Visible="false">
                                                <ItemTemplate>
                                                    <%# Eval("Tipe_Dokumen")%>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Judul">
                                                <ItemTemplate>
                                                    <span class="kt-media kt-media--xs">
                                                        <asp:Image ID="imgFile" runat="server" CssClass="float-left mr-2" />
                                                        <asp:HyperLink ID="linkFile" CssClass="t-link kt-font-boldest mt-1" runat="server" data-skin="dark" data-placement="right"><%# Eval("Judul")%></asp:HyperLink>
                                                    </span>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Tahun">
                                                <ItemTemplate>
                                                    <%# Eval("Tahun")%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <EmptyDataTemplate>
                                            There are currently no items in this table.
                                        </EmptyDataTemplate>
                                        <PagerSettings Visible="false" />
                                    </asp:GridView>
                                </div>
                                <div id="pagerTKO" runat="server" class="kt-pagination kt-pagination--sm kt-pagination--primary kt-mt-40">
                                    <ul class="kt-pagination__links">
                                        <asp:Repeater ID="rptPagerTKO" runat="server" OnItemDataBound="rptPager_ItemDataBound">
                                            <ItemTemplate>
                                                <li runat="server" id="li">
                                                    <asp:LinkButton ID="lnkPage" runat="server" CommandName="TKO" Text='<%#Eval("Text") %>' CommandArgument='<%# Eval("Value") %>' Enabled='<%# Eval("Enabled") %>' OnClick="Page_Changed"></asp:LinkButton>
                                                </li>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </ul>
                                    <div class="kt-pagination__toolbar">
                                        <asp:DropDownList ID="ddlPageSizeTKO" AutoPostBack="true" runat="server" CssClass="form-control kt-font-primary" Style="width: 60px;" DataTextField="Text" DataValueField="Code" OnSelectedIndexChanged="ddlPageSize_SelectedIndexChanged"></asp:DropDownList>
                                        <span class="pagination__desc">
                                            <asp:Literal ID="lblTotalInfoTKO" runat="server" Text=""></asp:Literal>
                                            <asp:HiddenField ID="hdnPageTKO" runat="server" />
                                        </span>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <!-- end::TKO -->


                <!-- start::TKI -->
                <div class="kt-portlet kt-portlet--mobile">
                    <div class="kt-portlet__head kt-portlet__head--lg">
                        <div class="kt-portlet__head-label">
                            <h3 class="kt-portlet__head-title">TKI
                            </h3>
                        </div>
                    </div>
                    <div class="kt-portlet__body">
                        <div class="kt-section">
                            <div class="kt-section__content">
                                <div class="table-responsive">
                                    <asp:GridView ID="gridTKI" runat="server" class="table table-bordered table-hover"
                                        AutoGenerateColumns="false"
                                        AllowPaging="true"
                                        AllowSorting="false"
                                        OnRowDataBound="grid_RowDataBound">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="Action" HeaderStyle-Width="70px" Visible="false">
                                                <ItemTemplate>
                                                    <asp:HiddenField ID="hdn" runat="server" Value='<%# Eval("id")%>' />
                                                    <asp:HiddenField ID="hdnFileID" runat="server" Value='<%# Eval("file_id")%>' />
                                                    <asp:HiddenField ID="hdnFileExt" runat="server" Value='<%# Eval("file_ext")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="No" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <div class="t-link kt-font-boldest mt-1"><%# Eval("PAGING_ROW_NUMBER")%></div>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="No Dokumen">
                                                <ItemTemplate>
                                                    <%# Eval("No_Dokumen")%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Tipe Dokumen" Visible="false">
                                                <ItemTemplate>
                                                    <%# Eval("Tipe_Dokumen")%>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Judul">
                                                <ItemTemplate>
                                                    <span class="kt-media kt-media--xs">
                                                        <asp:Image ID="imgFile" runat="server" CssClass="float-left mr-2" />
                                                        <asp:HyperLink ID="linkFile" CssClass="t-link kt-font-boldest mt-1" runat="server" data-skin="dark" data-placement="right"><%# Eval("Judul")%></asp:HyperLink>
                                                    </span>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Tahun">
                                                <ItemTemplate>
                                                    <%# Eval("Tahun")%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <EmptyDataTemplate>
                                            There are currently no items in this table.
                                        </EmptyDataTemplate>
                                        <PagerSettings Visible="false" />
                                    </asp:GridView>
                                </div>
                                <div id="pagerTKI" runat="server" class="kt-pagination kt-pagination--sm kt-pagination--primary kt-mt-40">
                                    <ul class="kt-pagination__links">
                                        <asp:Repeater ID="rptPagerTKI" runat="server" OnItemDataBound="rptPager_ItemDataBound">
                                            <ItemTemplate>
                                                <li runat="server" id="li">
                                                    <asp:LinkButton ID="lnkPage" runat="server" CommandName="TKI" Text='<%#Eval("Text") %>' CommandArgument='<%# Eval("Value") %>' Enabled='<%# Eval("Enabled") %>' OnClick="Page_Changed"></asp:LinkButton>
                                                </li>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </ul>
                                    <div class="kt-pagination__toolbar">
                                        <asp:DropDownList ID="ddlPageSizeTKI" AutoPostBack="true" runat="server" CssClass="form-control kt-font-primary" Style="width: 60px;" DataTextField="Text" DataValueField="Code" OnSelectedIndexChanged="ddlPageSize_SelectedIndexChanged"></asp:DropDownList>
                                        <span class="pagination__desc">
                                            <asp:Literal ID="lblTotalInfoTKI" runat="server" Text=""></asp:Literal>
                                            <asp:HiddenField ID="hdnPageTKI" runat="server" />
                                        </span>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <!-- end::TKI -->


                <!-- start::Daftar Informasi Dikecualikan -->
                <div class="kt-portlet kt-portlet--mobile">
                    <div class="kt-portlet__head kt-portlet__head--lg">
                        <div class="kt-portlet__head-label">
                            <h3 class="kt-portlet__head-title">Daftar Informasi Dikecualikan
                            </h3>
                        </div>
                    </div>
                    <div class="kt-portlet__body">
                        <div class="kt-section">
                            <div class="kt-section__content">
                                <div class="table-responsive">
                                    <asp:GridView ID="gridDaftarInformasiDikecualikan" runat="server" class="table table-bordered table-hover"
                                        AutoGenerateColumns="false"
                                        AllowPaging="true"
                                        AllowSorting="false"
                                        OnRowDataBound="grid_RowDataBound">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="Action" HeaderStyle-Width="70px" Visible="false">
                                                <ItemTemplate>
                                                    <asp:HiddenField ID="hdn" runat="server" Value='<%# Eval("id")%>' />
                                                    <asp:HiddenField ID="hdnFileID" runat="server" Value='<%# Eval("file_id")%>' />
                                                    <asp:HiddenField ID="hdnFileExt" runat="server" Value='<%# Eval("file_ext")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="No" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <div class="t-link kt-font-boldest mt-1"><%# Eval("PAGING_ROW_NUMBER")%></div>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="No Dokumen">
                                                <ItemTemplate>
                                                    <%# Eval("No_Dokumen")%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Tipe Dokumen" Visible="false">
                                                <ItemTemplate>
                                                    <%# Eval("Tipe_Dokumen")%>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Judul">
                                                <ItemTemplate>
                                                    <span class="kt-media kt-media--xs">
                                                        <asp:Image ID="imgFile" runat="server" CssClass="float-left mr-2" />
                                                        <asp:HyperLink ID="linkFile" CssClass="t-link kt-font-boldest mt-1" runat="server" data-skin="dark" data-placement="right"><%# Eval("Judul")%></asp:HyperLink>
                                                    </span>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Tahun">
                                                <ItemTemplate>
                                                    <%# Eval("Tahun")%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <EmptyDataTemplate>
                                            There are currently no items in this table.
                                        </EmptyDataTemplate>
                                        <PagerSettings Visible="false" />
                                    </asp:GridView>
                                </div>
                                <div id="pagerDaftarInformasiDikecualikan" runat="server" class="kt-pagination kt-pagination--sm kt-pagination--primary kt-mt-40">
                                    <ul class="kt-pagination__links">
                                        <asp:Repeater ID="rptPagerDaftarInformasiDikecualikan" runat="server" OnItemDataBound="rptPager_ItemDataBound">
                                            <ItemTemplate>
                                                <li runat="server" id="li">
                                                    <asp:LinkButton ID="lnkPage" runat="server" CommandName="Daftar Informasi Dikecualikan" Text='<%#Eval("Text") %>' CommandArgument='<%# Eval("Value") %>' Enabled='<%# Eval("Enabled") %>' OnClick="Page_Changed"></asp:LinkButton>
                                                </li>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </ul>
                                    <div class="kt-pagination__toolbar">
                                        <asp:DropDownList ID="ddlPageSizeDaftarInformasiDikecualikan" AutoPostBack="true" runat="server" CssClass="form-control kt-font-primary" Style="width: 60px;" DataTextField="Text" DataValueField="Code" OnSelectedIndexChanged="ddlPageSize_SelectedIndexChanged"></asp:DropDownList>
                                        <span class="pagination__desc">
                                            <asp:Literal ID="lblTotalInfoDaftarInformasiDikecualikan" runat="server" Text=""></asp:Literal>
                                            <asp:HiddenField ID="hdnPageDaftarInformasiDikecualikan" runat="server" />
                                        </span>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <!-- end::Daftar Informasi Dikecualikan -->


                <!-- start::Peraturan Compliance -->
                <div class="kt-portlet kt-portlet--mobile">
                    <div class="kt-portlet__head kt-portlet__head--lg">
                        <div class="kt-portlet__head-label">
                            <h3 class="kt-portlet__head-title">Peraturan Compliance
                            </h3>
                        </div>
                    </div>
                    <div class="kt-portlet__body">
                        <div class="kt-section">
                            <div class="kt-section__content">
                                <div class="table-responsive">
                                    <asp:GridView ID="gridPeraturanCompliance" runat="server" class="table table-bordered table-hover"
                                        AutoGenerateColumns="false"
                                        AllowPaging="true"
                                        AllowSorting="false"
                                        OnRowDataBound="grid_RowDataBound">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="Action" HeaderStyle-Width="70px" Visible="false">
                                                <ItemTemplate>
                                                    <asp:HiddenField ID="hdn" runat="server" Value='<%# Eval("id")%>' />
                                                    <asp:HiddenField ID="hdnFileID" runat="server" Value='<%# Eval("file_id")%>' />
                                                    <asp:HiddenField ID="hdnFileExt" runat="server" Value='<%# Eval("file_ext")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="No" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <div class="t-link kt-font-boldest mt-1"><%# Eval("PAGING_ROW_NUMBER")%></div>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="No Dokumen">
                                                <ItemTemplate>
                                                    <%# Eval("No_Dokumen")%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Tipe Dokumen" Visible="false">
                                                <ItemTemplate>
                                                    <%# Eval("Tipe_Dokumen")%>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Judul">
                                                <ItemTemplate>
                                                    <span class="kt-media kt-media--xs">
                                                        <asp:Image ID="imgFile" runat="server" CssClass="float-left mr-2" />
                                                        <asp:HyperLink ID="linkFile" CssClass="t-link kt-font-boldest mt-1" runat="server" data-skin="dark" data-placement="right"><%# Eval("Judul")%></asp:HyperLink>
                                                    </span>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Tahun">
                                                <ItemTemplate>
                                                    <%# Eval("Tahun")%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <EmptyDataTemplate>
                                            There are currently no items in this table.
                                        </EmptyDataTemplate>
                                        <PagerSettings Visible="false" />
                                    </asp:GridView>
                                </div>
                                <div id="pagerPeraturanCompliance" runat="server" class="kt-pagination kt-pagination--sm kt-pagination--primary kt-mt-40">
                                    <ul class="kt-pagination__links">
                                        <asp:Repeater ID="rptPagerPeraturanCompliance" runat="server" OnItemDataBound="rptPager_ItemDataBound">
                                            <ItemTemplate>
                                                <li runat="server" id="li">
                                                    <asp:LinkButton ID="lnkPage" runat="server" CommandName="Peraturan Compliance" Text='<%#Eval("Text") %>' CommandArgument='<%# Eval("Value") %>' Enabled='<%# Eval("Enabled") %>' OnClick="Page_Changed"></asp:LinkButton>
                                                </li>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </ul>
                                    <div class="kt-pagination__toolbar">
                                        <asp:DropDownList ID="ddlPageSizePeraturanCompliance" AutoPostBack="true" runat="server" CssClass="form-control kt-font-primary" Style="width: 60px;" DataTextField="Text" DataValueField="Code" OnSelectedIndexChanged="ddlPageSize_SelectedIndexChanged"></asp:DropDownList>
                                        <span class="pagination__desc">
                                            <asp:Literal ID="lblTotalInfoPeraturanCompliance" runat="server" Text=""></asp:Literal>
                                            <asp:HiddenField ID="hdnPagePeraturanCompliance" runat="server" />
                                        </span>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <!-- end::Peraturan Compliance -->


            </div>
            <!-- end:: Section -->



            <!-- end:: Content -->
        </div>
    </div>
    <!-- end:: Content -->


</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="script" runat="server">
</asp:Content>
