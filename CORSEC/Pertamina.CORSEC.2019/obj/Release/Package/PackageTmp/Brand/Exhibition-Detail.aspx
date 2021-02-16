<%@ Page Title="" Language="C#" MasterPageFile="~/Frontend.Master" AutoEventWireup="true" CodeBehind="Exhibition-Detail.aspx.cs" Inherits="Pertamina.CORSEC._2019.Brand.Exhibition_Detail" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">

    <!-- begin:: Content -->
    <div class="kt-content-height">
        <div class="kt-content kt-content--fit-top  kt-grid__item kt-grid__item--fluid kt-grid kt-grid--hor"
            id="kt_content">

            <!-- begin:: Content -->

            <!-- begin:: Hero -->
            <%--     <div class="kt-sc" style="background-image: url('/Content/assets/media/bg/bg-9.jpg')">
                <div class="kt-container ">

                    <div class="kt-sc__bottom">
                        <h3 class="kt-sc__heading kt-heading kt-heading--center kt-heading--xxl kt-heading--medium">Exhibition
                        </h3>
                    </div>
                </div>
            </div>--%>

            <asp:Literal ID="lblHeader" runat="server"></asp:Literal>
            <!-- end:: Hero -->

            <div class="kt-container mt-2">
                <div class="kt-portlet">
                    <div class="kt-portlet__body">
                        <div class="kt-portlet__content">
                            <div class="row">
                                <div class="col-md-6">
                                    <ul id="glasscase" class="gc-start">
                                        <asp:Literal ID="lblImages" runat="server"></asp:Literal>
                                    </ul>
                                </div>
                                <div class="col-md-6">
                                    <div class="kt-portlet kt-portlet--bordered">
                                        <div class="kt-portlet__head">
                                            <div class="kt-portlet__head-label">
                                                <h3 class="kt-portlet__head-title">

                                                    <asp:Label ID="lblTitle" runat="server" Text=""></asp:Label>
                                                </h3>
                                            </div>
                                        </div>
                                        <div class="kt-portlet__body kt-scroll scroll-desc-product-2" data-scroll="true">
                                            <div class="row mt-0 mb-0">
                                                <label class="col-3">Loakasi</label>
                                                <div class="col-9">
                                                    :
                                <asp:Label ID="lblLokasi" runat="server" Text=""></asp:Label>
                                                </div>
                                            </div>
                                            <div class="row mt-0 mb-0">
                                                <label class="col-3">Tanggal</label>
                                                <div class="col-9">
                                                    :
                                <asp:Label ID="lblTanggal" runat="server" Text=""></asp:Label>
                                                </div>
                                            </div>
                                            <div class="row mt-0 mb-0">
                                                <label class="col-3">Award</label>
                                                <div class="col-9">
                                                    :
                                <asp:Label ID="lblAward" runat="server" Text=""></asp:Label>
                                                </div>
                                            </div>
                                            <p class="mt-4 mb-0 text-justify">
                                                <asp:Literal ID="lblIsi" runat="server"></asp:Literal>
                                            </p>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <h2 class="mt-3 mb-4">Materi & Poster</h2>
                            <%--   <div class="kt-widget4">
                                <div class="kt-widget4__item p-2">
                                    <img class="kt-mr-10" src="/Content/assets/media/files/pdf.svg" height="26" alt="">
                                    <a href="#" class="kt-widget4__title kt-widget4__title--light">Documents v6 has been arrived!
                                    </a>
                                    <small class="kt-widget4__number fsize-11 kt-mr-20">PDF - 23mb</small>
                                    <span class="kt-widget3__number kt-font-info">
                                        <a href="#" class="btn-label-brand btn btn-sm btn-bold">Download</a>
                                    </span>
                                </div>
                                <div class="kt-widget4__item p-2">
                                    <img class="kt-mr-10" src="/Content/assets/media/files/doc.svg" height="26" alt="">
                                    <a href="#" class="kt-widget4__title kt-widget4__title--light">Documents community meet-up 2019 in Rome.
                                    </a>
                                    <small class="kt-widget4__number fsize-11 kt-mr-20">PDF - 23mb</small>
                                    <span class="kt-widget3__number kt-font-info">
                                        <a href="#" class="btn-label-brand btn btn-sm btn-bold">Download</a>
                                    </span>
                                </div>
                                <div class="kt-widget4__item p-2">
                                    <img class="kt-mr-10" src="/Content/assets/media/files/jpg.svg" height="26" alt="">
                                    <a href="#" class="kt-widget4__title kt-widget4__title--light">Documents Angular 8 version will be landing soon...
                                    </a>
                                    <small class="kt-widget4__number fsize-11 kt-mr-20">PDF - 23mb</small>
                                    <span class="kt-widget3__number kt-font-info">
                                        <a href="#" class="btn-label-brand btn btn-sm btn-bold">Download</a>
                                    </span>
                                </div>
                                <div class="kt-widget4__item p-2">
                                    <img class="kt-mr-10" src="/Content/assets/media/files/doc.svg" height="26" alt="">
                                    <a href="#" class="kt-widget4__title kt-widget4__title--light">ale! Purchase Documents at 70% off for limited time
                                    </a>
                                    <small class="kt-widget4__number fsize-11 kt-mr-20">PDF - 23mb</small>
                                    <span class="kt-widget3__number kt-font-info">
                                        <a href="#" class="btn-label-brand btn btn-sm btn-bold">Download</a>
                                    </span>
                                </div>
                                <div class="kt-widget4__item p-2">
                                    <img class="kt-mr-10" src="/Content/assets/media/files/pdf.svg" height="26" alt="">
                                    <a href="#" class="kt-widget4__title kt-widget4__title--light">Documents VueJS version is in progress. Stay tuned!
                                    </a>
                                    <small class="kt-widget4__number fsize-11 kt-mr-20">Excel - 23mb</small>
                                    <span class="kt-widget3__number kt-font-info">
                                        <a href="#" class="btn-label-brand btn btn-sm btn-bold">Download</a>
                                    </span>
                                </div>
                                <div class="kt-widget4__item p-2">
                                    <img class="kt-mr-10" src="/Content/assets/media/files/doc.svg" height="26" alt="">
                                    <a href="#" class="kt-widget4__title kt-widget4__title--light">Black Friday! Purchase Documents at ever lowest 90% off for limited time
                                    </a>
                                    <small class="kt-widget4__number fsize-11 kt-mr-20">PDF - 23mb</small>
                                    <span class="kt-widget3__number kt-font-info">
                                        <a href="#" class="btn-label-brand btn btn-sm btn-bold">Download</a>
                                    </span>
                                </div>
                                <div class="kt-widget4__item p-2">
                                    <img class="kt-mr-10" src="/Content/assets/media/files/pdf.svg" height="26" alt="">
                                    <a href="#" class="kt-widget4__title kt-widget4__title--light">Documents React version is in progress.
                                    </a>
                                    <small class="kt-widget4__number fsize-11 kt-mr-20">Word - 23mb</small>
                                    <span class="kt-widget3__number kt-font-info">
                                        <a href="#" class="btn-label-brand btn btn-sm btn-bold">Download</a>
                                    </span>
                                </div>
                            </div>--%>
                            <%--  <div class="kt-pagination kt-pagination--sm kt-pagination--primary kt-mt-40">
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


                            <!--begin::table Materi_And_Poster -->
                            <!--begin::widget 12-->
                            <div class="kt-widget4">
                                <asp:GridView ID="gridMateri_And_Poster" runat="server" class="table table-borderless"
                                    AutoGenerateColumns="false"
                                    AllowPaging="true"
                                    AllowSorting="false"
                                    OnRowDataBound="grid_RowDataBound" ShowHeader="false" GridLines="None">
                                    <Columns>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:HiddenField ID="hdn" runat="server" Value='<%# Eval("id")%>' />
                                                <asp:HiddenField ID="hdnFileExt" runat="server" Value='<%# Eval("file_ext")%>' />
                                                <div class="kt-widget4__item p-2">
                                                    <asp:Image ID="imgFile" runat="server" CssClass="kt-mr-10" Height="26" alt="" ImageUrl="~/Content/assets/media/files/jpg.svg" />
                                                    <asp:HyperLink ID="linkDetail" CssClass="kt-widget4__title kt-widget4__title--light" runat="server"><%# Eval("file_desc")%></asp:HyperLink>
                                                    <small class="kt-widget4__number fsize-11 kt-mr-20"><%# Eval("file_size") %></small>
                                                    <span class="kt-widget3__number kt-font-info">
                                                        <asp:HyperLink ID="linkFile" CssClass="btn-label-brand btn btn-sm btn-bold" runat="server">Download</asp:HyperLink>
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
                            </div>
                            <!--end::Widget 12-->
                            <div id="pagerMateri_And_Poster" class="kt-pagination kt-pagination--sm kt-pagination--primary kt-mt-40">
                                <ul class="kt-pagination__links">
                                    <asp:Repeater ID="rptPagerMateri_And_Poster" runat="server" OnItemDataBound="rptPager_ItemDataBound">
                                        <ItemTemplate>
                                            <li runat="server" id="li">
                                                <asp:LinkButton ID="lnkPage" runat="server" CommandName="Materi_And_Poster" Text='<%#Eval("Text") %>' CommandArgument='<%# Eval("Value") %>' Enabled='<%# Eval("Enabled") %>' OnClick="Page_Changed"></asp:LinkButton>
                                            </li>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </ul>
                                <div class="kt-pagination__toolbar">
                                    <asp:DropDownList ID="ddlPageSizeMateri_And_Poster" AutoPostBack="true" runat="server" CssClass="form-control kt-font-primary" Style="width: 60px;" DataTextField="Text" DataValueField="Code" OnSelectedIndexChanged="ddlPageSize_SelectedIndexChanged"></asp:DropDownList>
                                    <span class="pagination__desc">
                                        <asp:Literal ID="lblTotalInfoMateri_And_Poster" runat="server" Text=""></asp:Literal>
                                        <asp:HiddenField ID="hdnPageMateri_And_Poster" runat="server" />
                                    </span>
                                </div>
                            </div>

                            <!--end::table Materi_And_Poster -->
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

    <!-- end::Global Config -->
    <script type="text/javascript">
        $(document).ready(function () {
            //If your <ul> has the id "glasscase"
            $('#glasscase').glassCase({
                'thumbsPosition': 'left',
                'nrThumbsPerRow': 5,
                // 'heightDisplay': 600,
                'isDownloadEnabled': false,
                'autoInnerZoom': false,
                'isZoomEnabled': false,
                'isZoomDiffWH': false
            });
        });
    </script>

</asp:Content>
