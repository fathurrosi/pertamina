<%@ Page Title="" Language="C#" MasterPageFile="~/Frontend.Master" AutoEventWireup="true" CodeBehind="stake-holder-database.aspx.cs" Inherits="Pertamina.CORSEC._2019.StakeHolderManagement.stake_holder_database" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .table-borderless tr td {
            padding: 0px !important;
            border-top: none !important;
            border-bottom-width: 1px;
            border-bottom-style: solid;
            border-bottom-color: #ebedf2;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">

    <!-- begin:: Content -->
    <div class="kt-content-height">
        <div class="kt-content  kt-content--fit-top  kt-grid__item kt-grid__item--fluid kt-grid kt-grid--hor"
            id="kt_content">

            <!-- begin:: Content -->

            <!-- begin:: Hero -->
            <%--   <div class="kt-sc" style="background-image: url('assets/media/bg/bg-9.jpg')">
              <div class="kt-container ">

                <div class="kt-sc__bottom">
                  <h3 class="kt-sc__heading kt-heading kt-heading--center kt-heading--xxl kt-heading--medium">
                    Strategic Stake holder Engagement
                  </h3>

                </div>
              </div>
            </div>--%>
            <!-- end:: Hero -->


            <asp:Literal ID="lblHeader" runat="server"></asp:Literal>


            <!-- begin:: Section -->
            <div class="kt-container ">
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



            <div class="kt-container">
                <div class="kt-portlet">
                    <div class="kt-portlet__body">
                        <div class="kt-widget4">

                            <asp:GridView ID="gridUncategorized" runat="server" class="table table-borderless"
                                AutoGenerateColumns="false"
                                AllowPaging="true"
                                AllowSorting="false"
                                OnRowDataBound="grid_RowDataBound" ShowHeader="false" GridLines="None">
                                <Columns>
                                    <asp:TemplateField HeaderText="Judul">
                                        <ItemTemplate>
                                            <asp:HiddenField ID="hdnFileID" runat="server" Value='<%# Eval("id")%>' />
                                            <asp:HiddenField ID="hdnFileExt" runat="server" Value='<%# Eval("file_ext")%>' />
                                            <div class="kt-widget4__item p-2">
                                                <asp:Image ID="imgFile" runat="server" CssClass="float-left mr-2" alt=" image" ImageUrl="~/Content/assets/media/files/jpg.svg" Visible="false" />
                                                <asp:HyperLink ID="linkFile" CssClass="kt-widget4__title kt-widget4__title--light" runat="server"><%# Eval("Title")%></asp:HyperLink>
                                                <span class="kt-widget3__number kt-font-info">
                                                    <a href="#" class="btn-label-brand btn btn-sm btn-bold">Lihat</a>

                                                </span>
                                            </div>

                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <EmptyDataTemplate>
                                    There are currently no items in this table.
                                </EmptyDataTemplate>
                                <PagerSettings Visible="false" />
                            </asp:GridView>
                            <%--                    <div class="kt-widget4__item p-2">
                      <a href="#" class="kt-widget4__title kt-widget4__title--light">
                        Documents v6 has been arrived!
                      </a>
                      <span class="kt-widget3__number kt-font-info">
                        <a href="#" class="btn-label-brand btn btn-sm btn-bold">Lihat</a>
                      </span>
                    </div>
                    <div class="kt-widget4__item p-2">
                      <a href="#" class="kt-widget4__title kt-widget4__title--light">
                        Documents community meet-up 2019 in Rome.
                      </a>
                      <span class="kt-widget3__number kt-font-info">
                        <a href="#" class="btn-label-brand btn btn-sm btn-bold">Lihat</a>
                      </span>
                    </div>
                    <div class="kt-widget4__item p-2">
                      <a href="#" class="kt-widget4__title kt-widget4__title--light">
                        Documents Angular 8 version will be landing soon...
                      </a>
                      <span class="kt-widget3__number kt-font-info">
                        <a href="#" class="btn-label-brand btn btn-sm btn-bold">Lihat</a>
                      </span>
                    </div>
                    <div class="kt-widget4__item p-2">
                      <a href="#" class="kt-widget4__title kt-widget4__title--light">
                        ale! Purchase Documents at 70% off for limited time
                      </a>
                      <span class="kt-widget3__number kt-font-info">
                        <a href="#" class="btn-label-brand btn btn-sm btn-bold">Lihat</a>
                      </span>
                    </div>
                    <div class="kt-widget4__item p-2">
                      <a href="#" class="kt-widget4__title kt-widget4__title--light">
                        Documents VueJS version is in progress. Stay tuned!
                      </a>
                      <span class="kt-widget3__number kt-font-info">
                        <a href="#" class="btn-label-brand btn btn-sm btn-bold">Lihat</a>
                      </span>
                    </div>
                    <div class="kt-widget4__item p-2">
                      <a href="#" class="kt-widget4__title kt-widget4__title--light">
                        Black Friday! Purchase Documents at ever lowest 90% off for limited time
                      </a>
                      <span class="kt-widget3__number kt-font-info">
                        <a href="#" class="btn-label-brand btn btn-sm btn-bold">Lihat</a>
                      </span>
                    </div>
                    <div class="kt-widget4__item p-2">
                      <a href="#" class="kt-widget4__title kt-widget4__title--light">
                        Documents React version is in progress.
                      </a>
                      <span class="kt-widget3__number kt-font-info">
                        <a href="#" class="btn-label-brand btn btn-sm btn-bold">Lihat</a>
                      </span>
                    </div>--%>
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
                                        role="tab"
                                        aria-selected="false">County Profile
                                    </a>
                                </li>
                                <li class="nav-item">
                                    <a class="nav-link " data-toggle="tab" href="#kt_portlet_base_demo_2_3_tab_content"
                                        role="tab" aria-selected="true">Business Analisys
                                    </a>
                                </li>--%>
                                <asp:Literal ID="litTab" runat="server"></asp:Literal>
                            </ul>
                        </div>
                        <div class="kt-portlet__head-toolbar">
                            <div class="btn-group ml-1" role="group" aria-label="Button group with nested dropdown">
                                <div class="btn-group" role="group">
                                    <asp:Literal ID="litCountry" runat="server"></asp:Literal>
                                    <%-- <button id="btnGroupDrop1" type="button" class="btn btn-secondary dropdown-toggle"
                                        data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                        Country
                                    </button>
                                    <div class="dropdown-menu" aria-labelledby="btnGroupDrop1">
                                        <a class="dropdown-item" href="#">Indonesia</a>
                                        <a class="dropdown-item" href="#">Singapore</a>
                                        <a class="dropdown-item" href="#">Malaysia</a>
                                        <a class="dropdown-item" href="#">Thailand</a>
                                    </div>
                                    --%>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="kt-portlet__body">
                        <div class="tab-content">
                            <%--  <div class="tab-pane active" id="kt_portlet_base_demo_2_4_tab_content" role="tabpanel">
                                <div class="table-responsive">
                                    <table class="table table-bordered table-hover">
                                        <thead>
                                            <tr class="text-center">
                                                <th width="4%">No</th>
                                                <th width="15%">Loream Ipsum</th>
                                                <th width="10%">Tahun</th>
                                                <th>Judul</th>
                                                <th width="5%"></th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <tr>
                                                <th class="text-center" scope="row">1</th>
                                                <td>Loream Ipsum</td>
                                                <td class="text-center">2020</td>
                                                <td>
                                                    <span class="kt-media kt-media--xs">
                                                        <img src="assets/media/files/pdf.svg" class="float-left mr-2" alt=" image">
                                                        <a href="#" class="mt-1">Loream Ipsum Loream Ipsum Loream Ipsum
                                                        </a>
                                                    </span>
                                                </td>
                                                <td><a href="#" class="btn-label-brand btn btn-sm btn-bold">Lihat</a></td>
                                            </tr>
                                            <tr>
                                                <th class="text-center" scope="row">2</th>
                                                <td>Loream Ipsum</td>
                                                <td class="text-center">2019</td>
                                                <td>
                                                    <span class="kt-media kt-media--xs">
                                                        <img src="assets/media/files/pdf.svg" class="float-left mr-2" alt=" image">
                                                        <a href="#" class="mt-1">Loream Ipsum Loream Ipsum Loream Ipsum
                                                        </a>
                                                    </span>
                                                </td>
                                                <td><a href="#" class="btn-label-brand btn btn-sm btn-bold">Lihat</a></td>
                                            </tr>
                                            <tr>
                                                <th class="text-center" scope="row">3</th>
                                                <td>Loream Ipsum</td>
                                                <td class="text-center">2018</td>
                                                <td>
                                                    <span class="kt-media kt-media--xs">
                                                        <img src="assets/media/files/doc.svg" class="float-left mr-2" alt=" image">
                                                        <a href="#" class="mt-1">Loream Ipsum Loream Ipsum Loream Ipsum
                                                        </a>
                                                    </span>
                                                </td>
                                                <td><a href="#" class="btn-label-brand btn btn-sm btn-bold">Lihat</a></td>
                                            </tr>
                                            <tr>
                                                <th class="text-center" scope="row">4</th>
                                                <td>Loream Ipsum</td>
                                                <td class="text-center">2018</td>
                                                <td>
                                                    <span class="kt-media kt-media--xs">
                                                        <img src="assets/media/files/doc.svg" class="float-left mr-2" alt=" image">
                                                        <a href="#" class="mt-1">Loream Ipsum Loream Ipsum Loream Ipsum
                                                        </a>
                                                    </span>
                                                </td>
                                                <td><a href="#" class="btn-label-brand btn btn-sm btn-bold">Lihat</a></td>
                                            </tr>
                                            <tr>
                                                <th class="text-center" scope="row">5</th>
                                                <td>Loream Ipsum</td>
                                                <td class="text-center">2018</td>
                                                <td>
                                                    <span class="kt-media kt-media--xs">
                                                        <img src="assets/media/files/doc.svg" class="float-left mr-2" alt=" image">
                                                        <a href="#" class="mt-1">Loream Ipsum Loream Ipsum Loream Ipsum
                                                        </a>
                                                    </span>
                                                </td>
                                                <td><a href="#" class="btn-label-brand btn btn-sm btn-bold">Lihat</a></td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </div>
                            </div>--%>

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
                                    <asp:TemplateField HeaderText="Konten" ItemStyle-Width="15%">
                                        <ItemTemplate>
                                            <%# Eval("body")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Tahun" ItemStyle-Width="10%">
                                        <ItemTemplate>
                                            <%# Eval("year")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Judul">
                                        <ItemTemplate>
                                            <asp:HiddenField ID="hdnFileID" runat="server" Value='<%# Eval("id")%>' />
                                            <asp:HiddenField ID="hdnFileExt" runat="server" Value='<%# Eval("file_ext")%>' />
                                            <span class="kt-media kt-media--xs">
                                                <asp:Image ID="imgFile" runat="server" CssClass="float-left mr-2" alt=" image" ImageUrl="~/Content/assets/media/files/jpg.svg" />
                                                <asp:HyperLink ID="linkFile" CssClass="mt-1" runat="server"><%# Eval("Title")%></asp:HyperLink>
                                            </span>

                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Action" ItemStyle-Width="5%">
                                        <ItemTemplate>
                                            <a href="#" class="btn-label-brand btn btn-sm btn-bold">Lihat</a>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <EmptyDataTemplate>
                                    There are currently no items in this table.
                                </EmptyDataTemplate>
                                <PagerSettings Visible="false" />
                            </asp:GridView>

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
            <!-- end:: Content -->
        </div>
    </div>
    <!-- end:: Content -->
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="script" runat="server">
</asp:Content>
