<%@ Page Title="" Language="C#" MasterPageFile="~/Frontend.Master" AutoEventWireup="true" CodeBehind="kinerja-sekper-monitoring.aspx.cs" Inherits="Pertamina.CORSEC._2019.MonitoringEvaluasi.kinerja_sekper_monitoring" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">

    <!-- begin:: Content -->
    <div class="kt-content-height">
        <div class="kt-content  kt-content--fit-top  kt-grid__item kt-grid__item--fluid kt-grid kt-grid--hor"
            id="kt_content">

            <!-- begin:: Content -->

            <asp:Literal ID="lblHeader" runat="server"></asp:Literal>
            <div class="kt-container">
                <div class="kt-portlet">
                    <div class="kt-portlet__body">
                        <div class="kt-infobox">
                            <div class="kt-infobox__header">
                                <h2 class="kt-infobox__title">
                                    <asp:Label ID="lblTitle" runat="server" Text=""></asp:Label></h2>
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

            <!-- end:: Section -->
            <div class="kt-container ">
                <div class="kt-portlet">
                    <div class="kt-portlet__head">
                        <div class="kt-portlet__head-toolbar">
                            <ul class="nav nav-pills nav-fill" role="tablist">
                                <%--<li class="nav-item">
                                    <a class="nav-link active" data-toggle="tab" href="#kt_portlet_base_demo_2_4_tab_content"
                                        role="tab" aria-selected="false">Kinerja Sekper
                                    </a>
                                </li>
                                <li class="nav-item">
                                    <a class="nav-link " data-toggle="tab" href="#kt_portlet_base_demo_2_3_tab_content" role="tab"
                                        aria-selected="true">Kinerja Unit/Fungsi
                                    </a>
                                </li>--%>
                                <asp:Literal ID="litTab" runat="server"></asp:Literal>
                            </ul>
                        </div>
                    </div>
                    <div class="kt-portlet__body">
                        <div class="tab-content">

                            <div class="tab-pane active" id="kt_portlet_base_demo_2_4_tab_content" role="tabpanel">

                                <%--<div class="pull-right mb-3">
                                    <div class="btn-group" role="group" aria-label="Button group with nested dropdown">
                                        <div class="btn-group" role="group">                                            
                                            <asp:TextBox ID="txtMonth" runat="server" TextMode="Month" class="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>--%>

                                <div class="table-responsive">
                                    <asp:GridView ID="grid" runat="server" class="table table-bordered table-hover"
                                        AutoGenerateColumns="false"
                                        AllowPaging="true"
                                        AllowSorting="false"
                                        OnRowDataBound="grid_RowDataBound" ShowHeader="true" GridLines="None">
                                        <Columns>
                                            <asp:TemplateField HeaderText="No" ItemStyle-Width="4%">
                                                <ItemTemplate>
                                                    <%# Eval("PAGING_ROW_NUMBER")%>
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

                                         <%--   <asp:TemplateField HeaderText="Action" ItemStyle-Width="5%">
                                                <ItemTemplate>
                                                    <a href="#" class="btn-label-brand btn btn-sm btn-bold">Lihat</a>
                                                </ItemTemplate>
                                            </asp:TemplateField>--%>
                                        </Columns>
                                        <EmptyDataTemplate>
                                            There are currently no items in this table.
                                        </EmptyDataTemplate>
                                        <PagerSettings Visible="false" />
                                    </asp:GridView>
                                </div>

                                <%-- <div class="tab-pane active" id="kt_portlet_base_demo_2_4_tab_content" role="tabpanel">
                                <div class="pull-right mb-3">
                                    <div class="btn-group" role="group" aria-label="Button group with nested dropdown">
                                        <div class="btn-group" role="group">
                                            <input class="form-control" type="month" value="2011-08" id="example-month-input">
                                        </div>
                                    </div>
                                </div>
                                <div class="table-responsive">
                                    <table class="table table-bordered table-hover">
                                        <thead>
                                            <tr class="text-center">
                                                <th width="4%">No</th>
                                                <th>Laporan</th>
                                                <th>Bulan</th>
                                                <th>Periode Laporan</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <tr>
                                                <th scope="row">1</th>
                                                <td>Loream Ipsum</td>
                                                <td>Bulan</td>
                                                <td>Triwulan</td>
                                            </tr>
                                            <tr>
                                                <th scope="row">2</th>
                                                <td>Loream Ipsum</td>
                                                <td>Bulan</td>
                                                <td>Triwulan</td>
                                            </tr>
                                            <tr>
                                                <th scope="row">3</th>
                                                <td>Loream Ipsum</td>
                                                <td>Bulan</td>
                                                <td>Triwulan</td>
                                            </tr>
                                            <tr>
                                                <th scope="row">4</th>
                                                <td>Loream Ipsum</td>
                                                <td>Bulan</td>
                                                <td>Triwulan</td>
                                            </tr>
                                            <tr>
                                                <th scope="row">5</th>
                                                <td>Loream Ipsum</td>
                                                <td>Bulan</td>
                                                <td>Triwulan</td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </div>
                            </div>
                            <div class="tab-pane" id="kt_portlet_base_demo_2_3_tab_content" role="tabpanel">
                                <div class="pull-right mb-3">
                                    <div class="btn-group" role="group" aria-label="Button group with nested dropdown">
                                        <div class="btn-group" role="group">
                                            <input class="form-control" type="month" value="2011-08" id="example-month-input">
                                        </div>
                                    </div>
                                </div>
                                <div class="table-responsive">
                                    <table class="table table-bordered table-hover">
                                        <thead>
                                             <tr class="text-center">
                                                <th width="4%">No</th>
                                                <th>Laporan</th>
                                                <th>Bulan</th>
                                                <th>Periode Laporan</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <tr>
                                                <th scope="row">1</th>
                                                <td>Loream Ipsum</td>
                                                <td>Bulan</td>
                                                <td>Triwulan</td>
                                            </tr>
                                            <tr>
                                                <th scope="row">2</th>
                                                <td>Loream Ipsum</td>
                                                <td>Bulan</td>
                                                <td>Triwulan</td>
                                            </tr>
                                            <tr>
                                                <th scope="row">3</th>
                                                <td>Loream Ipsum</td>
                                                <td>Bulan</td>
                                                <td>Triwulan</td>
                                            </tr>
                                            <tr>
                                                <th scope="row">4</th>
                                                <td>Loream Ipsum</td>
                                                <td>Bulan</td>
                                                <td>Triwulan</td>
                                            </tr>
                                            <tr>
                                                <th scope="row">5</th>
                                                <td>Loream Ipsum</td>
                                                <td>Bulan</td>
                                                <td>Triwulan</td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </div>
                            </div>--%>
                            </div>


                            <div id="pager" class="kt-pagination kt-pagination--sm kt-pagination--primary kt-mt-40">
                                <ul class="kt-pagination__links">
                                    <asp:Repeater ID="rptPager" runat="server" OnItemDataBound="rptPager_ItemDataBound">
                                        <ItemTemplate>
                                            <li runat="server" id="li">
                                                <asp:LinkButton ID="lnkPage" runat="server" CommandName="" Text='<%#Eval("Text") %>' CommandArgument='<%# Eval("Value") %>' Enabled='<%# Eval("Enabled") %>' OnClick="Page_Changed"></asp:LinkButton>
                                            </li>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </ul>
                                <div class="kt-pagination__toolbar">
                                    <asp:DropDownList ID="ddlPageSize" AutoPostBack="true" runat="server" CssClass="form-control kt-font-primary" Style="width: 60px;" DataTextField="Text" DataValueField="Code" OnSelectedIndexChanged="ddlPageSize_SelectedIndexChanged"></asp:DropDownList>
                                    <span class="pagination__desc">
                                        <asp:Literal ID="lblTotalInfo" runat="server" Text=""></asp:Literal>
                                        <asp:HiddenField ID="hdnPage" runat="server" />
                                    </span>
                                </div>
                            </div>

                            <%--                        <div class="kt-pagination kt-pagination--sm kt-pagination--primary kt-mt-40">
                            <ul class="kt-pagination__links">
                                <li class="kt-pagination__link--first">
                                    <a href="#"><i class="fa fa-angle-double-left kt-font-primary"></i></a>
                                </li>
                                <li class="kt-pagination__link--next">
                                    <a href="#"><i class="fa fa-angle-left kt-font-primary"></i></a>
                                </li>
                                <li>
                                    <a href="#">...</a>
                                </li>
                                <li>
                                    <a href="#">29</a>
                                </li>
                                <li class="kt-pagination__link--active">
                                    <a href="#">30</a>
                                </li>
                                <li>
                                    <a href="#">31</a>
                                </li>
                                <li>
                                    <a href="#">32</a>
                                </li>
                                <li>
                                    <a href="#">33</a>
                                </li>
                                <li>
                                    <a href="#">34</a>
                                </li>
                                <li>
                                    <a href="#">...</a>
                                </li>
                                <li class="kt-pagination__link--prev">
                                    <a href="#"><i class="fa fa-angle-right kt-font-primary"></i></a>
                                </li>
                                <li class="kt-pagination__link--last">
                                    <a href="#"><i class="fa fa-angle-double-right kt-font-primary"></i></a>
                                </li>
                            </ul>
                            <div class="kt-pagination__toolbar">
                                <select class="form-control kt-font-primary" style="width: 60px;">
                                    <option value="10">10</option>
                                    <option value="20">20</option>
                                    <option value="30">30</option>
                                    <option value="50">50</option>
                                    <option value="100">100</option>
                                </select>
                                <span class="pagination__desc">Displaying 10 of 230 records
                                </span>
                            </div>
                        </div>--%>
                        </div>
                    </div>
                </div>
                <div class="kt-container ">
                    <div class="kt-portlet">
                        <div class="kt-portlet__head">
                            <div class="kt-portlet__head-label">
                                <h3 class="kt-portlet__head-title">Risk Management
                                </h3>
                            </div>
                        </div>
                        <div class="kt-portlet__body">
                            <div class="kt-widget4">
                                <div class="kt-widget4__item p-2">
                                    <a href="#" class="kt-widget4__title kt-widget4__title--light">Documents v6 has been arrived!
                                    </a>
                                    <span class="kt-widget3__number kt-font-info">
                                        <a href="#" class="btn-label-brand btn btn-sm btn-bold">Lihat</a>
                                    </span>
                                </div>
                                <div class="kt-widget4__item p-2">
                                    <a href="#" class="kt-widget4__title kt-widget4__title--light">Documents community meet-up 2019 in Rome.
                                    </a>
                                    <span class="kt-widget3__number kt-font-info">
                                        <a href="#" class="btn-label-brand btn btn-sm btn-bold">Lihat</a>
                                    </span>
                                </div>
                                <div class="kt-widget4__item p-2">
                                    <a href="#" class="kt-widget4__title kt-widget4__title--light">Documents Angular 8 version will be landing soon...
                                    </a>
                                    <span class="kt-widget3__number kt-font-info">
                                        <a href="#" class="btn-label-brand btn btn-sm btn-bold">Lihat</a>
                                    </span>
                                </div>
                                <div class="kt-widget4__item p-2">
                                    <a href="#" class="kt-widget4__title kt-widget4__title--light">ale! Purchase Documents at 70% off for limited time
                                    </a>
                                    <span class="kt-widget3__number kt-font-info">
                                        <a href="#" class="btn-label-brand btn btn-sm btn-bold">Lihat</a>
                                    </span>
                                </div>
                                <div class="kt-widget4__item p-2">
                                    <a href="#" class="kt-widget4__title kt-widget4__title--light">Documents VueJS version is in progress. Stay tuned!
                                    </a>
                                    <span class="kt-widget3__number kt-font-info">
                                        <a href="#" class="btn-label-brand btn btn-sm btn-bold">Lihat</a>
                                    </span>
                                </div>
                                <div class="kt-widget4__item p-2">
                                    <a href="#" class="kt-widget4__title kt-widget4__title--light">Black Friday! Purchase Documents at ever lowest 90% off for limited time
                                    </a>
                                    <span class="kt-widget3__number kt-font-info">
                                        <a href="#" class="btn-label-brand btn btn-sm btn-bold">Lihat</a>
                                    </span>
                                </div>
                                <div class="kt-widget4__item p-2">
                                    <a href="#" class="kt-widget4__title kt-widget4__title--light">Documents React version is in progress.
                                    </a>
                                    <span class="kt-widget3__number kt-font-info">
                                        <a href="#" class="btn-label-brand btn btn-sm btn-bold">Lihat</a>
                                    </span>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="kt-container ">
                    <div class="kt-portlet">
                        <div class="kt-portlet__head">
                            <div class="kt-portlet__head-label">
                                <h3 class="kt-portlet__head-title">Corporate Integrated
                                </h3>
                            </div>
                        </div>
                        <div class="kt-portlet__body">
                            <div class="kt-widget4">
                                <div class="kt-widget4__item p-2">
                                    <a href="#" class="kt-widget4__title kt-widget4__title--light">Documents v6 has been arrived!
                                    </a>
                                    <span class="kt-widget3__number kt-font-info">
                                        <a href="#" class="btn-label-brand btn btn-sm btn-bold">Lihat</a>
                                    </span>
                                </div>
                                <div class="kt-widget4__item p-2">
                                    <a href="#" class="kt-widget4__title kt-widget4__title--light">Documents community meet-up 2019 in Rome.
                                    </a>
                                    <span class="kt-widget3__number kt-font-info">
                                        <a href="#" class="btn-label-brand btn btn-sm btn-bold">Lihat</a>
                                    </span>
                                </div>
                                <div class="kt-widget4__item p-2">
                                    <a href="#" class="kt-widget4__title kt-widget4__title--light">Documents Angular 8 version will be landing soon...
                                    </a>
                                    <span class="kt-widget3__number kt-font-info">
                                        <a href="#" class="btn-label-brand btn btn-sm btn-bold">Lihat</a>
                                    </span>
                                </div>
                                <div class="kt-widget4__item p-2">
                                    <a href="#" class="kt-widget4__title kt-widget4__title--light">ale! Purchase Documents at 70% off for limited time
                                    </a>
                                    <span class="kt-widget3__number kt-font-info">
                                        <a href="#" class="btn-label-brand btn btn-sm btn-bold">Lihat</a>
                                    </span>
                                </div>
                                <div class="kt-widget4__item p-2">
                                    <a href="#" class="kt-widget4__title kt-widget4__title--light">Documents VueJS version is in progress. Stay tuned!
                                    </a>
                                    <span class="kt-widget3__number kt-font-info">
                                        <a href="#" class="btn-label-brand btn btn-sm btn-bold">Lihat</a>
                                    </span>
                                </div>
                                <div class="kt-widget4__item p-2">
                                    <a href="#" class="kt-widget4__title kt-widget4__title--light">Black Friday! Purchase Documents at ever lowest 90% off for limited time
                                    </a>
                                    <span class="kt-widget3__number kt-font-info">
                                        <a href="#" class="btn-label-brand btn btn-sm btn-bold">Lihat</a>
                                    </span>
                                </div>
                                <div class="kt-widget4__item p-2">
                                    <a href="#" class="kt-widget4__title kt-widget4__title--light">Documents React version is in progress.
                                    </a>
                                    <span class="kt-widget3__number kt-font-info">
                                        <a href="#" class="btn-label-brand btn btn-sm btn-bold">Lihat</a>
                                    </span>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <!-- end:: Content -->
            </div>
        </div>
        <!-- end:: Content -->
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="script" runat="server">
</asp:Content>
