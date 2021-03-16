<%@ Page Title="" Language="C#" MasterPageFile="~/Frontend.Master" AutoEventWireup="true" CodeBehind="program-csr-bl.aspx.cs" Inherits="Pertamina.CORSEC._2019.CSRSMEPP.program_csr_bl" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
  <style>
  .col-md-12 img {
            border: 0px solid #fff;
            border-radius: 4px;
            padding: 10px;
            width: 150px;
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
            <%--  <div class="kt-sc" style="background-image: url('assets/media/bg/bg-9.jpg')">
                <div class="kt-container ">

                    <div class="kt-sc__bottom">
                        <h3 class="kt-sc__heading kt-heading kt-heading--center kt-heading--xxl kt-heading--medium">Strategi Pengelolaan CSR-BL
                        </h3>

                    </div>
                </div>
            </div>
            <!-- end:: Hero -->


            <!-- begin:: Section -->
            <div class="kt-container ">
                <div class="kt-portlet">
                    <div class="kt-portlet__body">
                        <div class="kt-infobox">
                            <div class="kt-infobox__header">
                                <h2 class="kt-infobox__title">Strategi Pengelolaan CSR-BL</h2>
                            </div>
                            <div class="kt-infobox__body">
                                <div class="kt-infobox__section">
                                    <div class="kt-infobox__content text-justify">
                                        Lorem ipsum dolor sit amet, consectetur adipisicing elit. Temporibus at laboriosam architecto
                          maiores consequuntur pariatur fuga aperiam labore, consectetur ratione ullam, accusamus quos
                          optio quibusdam molestias repellendus! Aut nulla dolores nisi nemo aperiam et quos magni ut
                          officia, nesciunt quia ipsa illo nam quibusdam possimus dignissimos ducimus veritatis quae
                          tempore amet voluptate repellat. Eos sed est numquam nisi hic eveniet quos, rerum culpa ipsa,
                          sunt odit ducimus unde recusandae harum eligendi nihil doloribus, libero error dolore esse
                          impedit quam cum! Molestias, adipisci, reprehenderit. Quasi sequi corporis explicabo
                          perferendis? Minus voluptatum corporis earum saepe, ipsa quo nulla deserunt, sed suscipit
                          sapiente eius facilis nisi necessitatibus. Obcaecati nisi natus, laboriosam quo quibusdam
                          nesciunt numquam blanditiis. Recusandae tenetur odio accusantium quaerat, facere est, atque
                          magni laboriosam repellat, cupiditate voluptatum eligendi eum suscipit doloremque laborum
                          cumque
                          consequuntur optio veniam nobis non ducimus! Voluptatibus laborum numquam fuga laboriosam
                          distinctio explicabo reprehenderit minima saepe dicta tempora!
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>--%>


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

            <!-- end:: Section -->
            <div class="kt-container ">
                <div class="kt-portlet">
                    <div class="kt-portlet__head">
                        <div class="kt-portlet__head-toolbar">
                            <ul class="nav nav-pills nav-fill" role="tablist">
                                <%-- <li class="nav-item">
                                    <a class="nav-link active" data-toggle="tab" href="#kt_portlet_base_demo_2_4_tab_content"
                                        role="tab" aria-selected="false">RKAP
                                    </a>
                                </li>
                                <li class="nav-item">
                                    <a class="nav-link " data-toggle="tab" href="#kt_portlet_base_demo_2_3_tab_content" role="tab"
                                        aria-selected="true">REALISASI
                                    </a>
                                </li>--%>

                                <asp:Literal ID="litTab" runat="server"></asp:Literal>
                            </ul>
                        </div>
                        <div class="kt-portlet__head-toolbar">
                            <h2>CSR</h2>
                        </div>
                    </div>
                    <div class="kt-portlet__body">
                        <div class="tab-content">
                            <div class="tab-pane active">
                                <div class="pull-right mb-3">
                                    <div class="btn-group" role="group" aria-label="Button group with nested dropdown">
                                        <div class="btn-group" role="group">
                                            <asp:Literal ID="litBulan" runat="server"></asp:Literal>
                                            <%--   <button id="btnGroupDrop" type="button" class="btn btn-secondary dropdown-toggle"
                                                data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                                Bulan
                                            </button>
                                            <div class="dropdown-menu" aria-labelledby="btnGroupDrop1" x-placement="bottom-start"
                                                style="position: absolute; will-change: transform; top: 0px; left: 0px; transform: translate3d(0px, 38px, 0px);">
                                                <a class="dropdown-item" href="#">January</a>
                                                <a class="dropdown-item" href="#">February</a>
                                                <a class="dropdown-item" href="#">Maret</a>
                                                <a class="dropdown-item" href="#">April</a>
                                            </div>--%>
                                        </div>
                                        <div class="btn-group" role="group">
                                            <asp:Literal ID="litDocument" runat="server"></asp:Literal>
                                            <%--     <button id="btnGroupDropx" type="button" class="btn btn-secondary dropdown-toggle"
                                                data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                                Related Dokumen
                                            </button>
                                            <div class="dropdown-menu" aria-labelledby="btnGroupDrop1" x-placement="bottom-start"
                                                style="position: absolute; will-change: transform; top: 0px; left: 0px; transform: translate3d(0px, 38px, 0px);">
                                                <a class="dropdown-item" href="#">Doc 1</a>
                                                <a class="dropdown-item" href="#">Doc 2</a>
                                                <a class="dropdown-item" href="#">Doc 3</a>
                                            </div>--%>
                                        </div>
                                    </div>
                                </div>
                                <div class="table-responsive">

                                    <asp:GridView ID="grid" runat="server" class="table table-bordered table-hover"
                                        AutoGenerateColumns="false"
                                        AllowPaging="true"
                                        AllowSorting="false"
                                        OnRowDataBound="grid_RowDataBound" ShowHeader="true" GridLines="None">
                                        <Columns>

                                            <asp:TemplateField HeaderText="No" ItemStyle-Width="4%">
                                                <ItemTemplate>
                                                    <%# Eval("ROW_NUMBER")%>
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

                                    <%--<table class="table table-bordered table-hover">
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
                                    </table>--%>
                                </div>
                            </div>

                            <%--                            <div class="tab-pane" id="kt_portlet_base_demo_2_3_tab_content" role="tabpanel">
                                <div class="pull-right mb-3">
                                    <div class="btn-group" role="group" aria-label="Button group with nested dropdown">
                                        <div class="btn-group" role="group">
                                            <button id="btnGroupDrop1" type="button" class="btn btn-secondary dropdown-toggle"
                                                data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                                Bulan
                                            </button>
                                            <div class="dropdown-menu" aria-labelledby="btnGroupDrop1" x-placement="bottom-start"
                                                style="position: absolute; will-change: transform; top: 0px; left: 0px; transform: translate3d(0px, 38px, 0px);">
                                                <a class="dropdown-item" href="#">January</a>
                                                <a class="dropdown-item" href="#">February</a>
                                                <a class="dropdown-item" href="#">Maret</a>
                                                <a class="dropdown-item" href="#">April</a>
                                            </div>
                                        </div>
                                        <div class="btn-group" role="group">
                                            <button id="btnGroupDrop1" type="button" class="btn btn-secondary dropdown-toggle"
                                                data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                                Related Dokumen
                                            </button>
                                            <div class="dropdown-menu" aria-labelledby="btnGroupDrop1" x-placement="bottom-start"
                                                style="position: absolute; will-change: transform; top: 0px; left: 0px; transform: translate3d(0px, 38px, 0px);">
                                                <a class="dropdown-item" href="#">Doc 1</a>
                                                <a class="dropdown-item" href="#">Doc 2</a>
                                                <a class="dropdown-item" href="#">Doc 3</a>
                                            </div>
                                        </div>
                                    </div>
                                </div>
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
                        <div class="kt-portlet__head-toolbar">
                            <ul class="nav nav-pills nav-fill" role="tablist">
                                <%--<li class="nav-item">
                                    <a class="nav-link active" data-toggle="tab" href="#kt_portlet_base_demo_2_4_tab_content"
                                        role="tab" aria-selected="false">RKAP
                                    </a>
                                </li>
                                <li class="nav-item">
                                    <a class="nav-link " data-toggle="tab" href="#kt_portlet_base_demo_2_3_tab_content" role="tab"
                                        aria-selected="true">REALISASI
                                    </a>
                                </li>--%>
                                <asp:Literal ID="litTab2" runat="server"></asp:Literal>
                            </ul>
                        </div>
                        <div class="kt-portlet__head-toolbar">
                            <h2>BL</h2>
                        </div>
                    </div>
                    <div class="kt-portlet__body">
                        <div class="tab-content">
                            <div class="tab-pane active" id="kt_portlet_base_demo_2_4_tab_content" role="tabpanel">
                                <div class="pull-right mb-3">
                                    <div class="btn-group" role="group" aria-label="Button group with nested dropdown">
                                        <div class="btn-group" role="group">
                                            <%-- <button id="btnGroupDrop1" type="button" class="btn btn-secondary dropdown-toggle"
                                                data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                                Bulan
                                            </button>
                                            <div class="dropdown-menu" aria-labelledby="btnGroupDrop1" x-placement="bottom-start"
                                                style="position: absolute; will-change: transform; top: 0px; left: 0px; transform: translate3d(0px, 38px, 0px);">
                                                <a class="dropdown-item" href="#">January</a>
                                                <a class="dropdown-item" href="#">February</a>
                                                <a class="dropdown-item" href="#">Maret</a>
                                                <a class="dropdown-item" href="#">April</a>
                                            </div>--%>
                                            <asp:Literal ID="litBulan2" runat="server"></asp:Literal>
                                        </div>
                                        <div class="btn-group" role="group">
                                            <%--<button id="btnGroupDrop1" type="button" class="btn btn-secondary dropdown-toggle"
                                                data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                                Related Dokumen
                                            </button>
                                            <div class="dropdown-menu" aria-labelledby="btnGroupDrop1" x-placement="bottom-start"
                                                style="position: absolute; will-change: transform; top: 0px; left: 0px; transform: translate3d(0px, 38px, 0px);">
                                                <a class="dropdown-item" href="#">Doc 1</a>
                                                <a class="dropdown-item" href="#">Doc 2</a>
                                                <a class="dropdown-item" href="#">Doc 3</a>
                                            </div>--%>
                                            <asp:Literal ID="litDocument2" runat="server"></asp:Literal>
                                        </div>
                                    </div>
                                </div>
                                <div class="table-responsive">

                                    <asp:GridView ID="grid2" runat="server" class="table table-bordered table-hover"
                                        AutoGenerateColumns="false"
                                        AllowPaging="true"
                                        AllowSorting="false"
                                        OnRowDataBound="grid_RowDataBound" ShowHeader="true" GridLines="None">
                                        <Columns>

                                            <asp:TemplateField HeaderText="No" ItemStyle-Width="4%">
                                                <ItemTemplate>
                                                    <%# Eval("ROW_NUMBER")%>
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

                                    <%--                                    <table class="table table-bordered table-hover">
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
                                    </table>--%>
                                </div>
                            </div>

                            <%--                            <div class="tab-pane" id="kt_portlet_base_demo_2_3_tab_content" role="tabpanel">
                                <div class="pull-right mb-3">
                                    <div class="btn-group" role="group" aria-label="Button group with nested dropdown">
                                        <div class="btn-group" role="group">
                                            <button id="btnGroupDrop1" type="button" class="btn btn-secondary dropdown-toggle"
                                                data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                                Bulan
                                            </button>
                                            <div class="dropdown-menu" aria-labelledby="btnGroupDrop1" x-placement="bottom-start"
                                                style="position: absolute; will-change: transform; top: 0px; left: 0px; transform: translate3d(0px, 38px, 0px);">
                                                <a class="dropdown-item" href="#">January</a>
                                                <a class="dropdown-item" href="#">February</a>
                                                <a class="dropdown-item" href="#">Maret</a>
                                                <a class="dropdown-item" href="#">April</a>
                                            </div>
                                        </div>
                                        <div class="btn-group" role="group">
                                            <button id="btnGroupDrop1" type="button" class="btn btn-secondary dropdown-toggle"
                                                data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                                Related Dokumen
                                            </button>
                                            <div class="dropdown-menu" aria-labelledby="btnGroupDrop1" x-placement="bottom-start"
                                                style="position: absolute; will-change: transform; top: 0px; left: 0px; transform: translate3d(0px, 38px, 0px);">
                                                <a class="dropdown-item" href="#">Doc 1</a>
                                                <a class="dropdown-item" href="#">Doc 2</a>
                                                <a class="dropdown-item" href="#">Doc 3</a>
                                            </div>
                                        </div>
                                    </div>
                                </div>
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
                        </div>
                        <div id="pager2" class="kt-pagination kt-pagination--sm kt-pagination--primary kt-mt-40">
                            <ul class="kt-pagination__links">
                                <asp:Repeater ID="rptPager2" runat="server" OnItemDataBound="rptPager_ItemDataBound">
                                    <ItemTemplate>
                                        <li runat="server" id="li">
                                            <asp:LinkButton ID="lnkPage" runat="server" CommandName="" Text='<%#Eval("Text") %>' CommandArgument='<%# Eval("Value") %>' Enabled='<%# Eval("Enabled") %>' OnClick="Page_Changed"></asp:LinkButton>
                                        </li>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </ul>
                            <div class="kt-pagination__toolbar">
                                <asp:DropDownList ID="ddlPageSize2" AutoPostBack="true" runat="server" CssClass="form-control kt-font-primary" Style="width: 60px;" DataTextField="Text" DataValueField="Code" OnSelectedIndexChanged="ddlPageSize_SelectedIndexChanged"></asp:DropDownList>
                                <span class="pagination__desc">
                                    <asp:Literal ID="lblTotalInfo2" runat="server" Text=""></asp:Literal>
                                    <asp:HiddenField ID="hdnPage2" runat="server" />
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
