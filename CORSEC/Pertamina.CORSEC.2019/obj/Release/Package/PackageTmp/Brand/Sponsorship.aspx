<%@ Page Title="" Language="C#" MasterPageFile="~/Frontend.Master" AutoEventWireup="true" CodeBehind="Sponsorship.aspx.cs" Inherits="Pertamina.CORSEC._2019.Brand.Sponsorship" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">

    <!-- begin:: Content -->
    <div class="kt-content-height">
        <div class="kt-content kt-content--fit-top  kt-grid__item kt-grid__item--fluid kt-grid kt-grid--hor"
            id="kt_content">

            <!-- begin:: Content -->

            <!-- begin:: Hero -->
            <%--<div class="kt-sc" style="background-image: url('assets/media/bg/bg-9.jpg');">
                <div class="kt-container ">
                    <div class="kt-sc__bottom">
                        <h3 class="kt-sc__heading kt-heading kt-heading--center kt-heading--xxl kt-heading--medium">Sponsorship
                        </h3>
                    </div>
                </div>
            </div>--%>

            <asp:Literal ID="lblHeader" runat="server"></asp:Literal>

            <div class="kt-container">
                <div class="kt-portlet">
                    <div class="kt-portlet__body">
                        <div class="kt-infobox">
                            <div class="kt-infobox__header">
                                <h2 class="kt-infobox__title">
                                    <asp:Label ID="lblTittle" runat="server" Text=""></asp:Label></h2>
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

            <div class="kt-container kt-pt10">
                <div class="kt-portlet kt-portlet--responsive-mobile">
                    <div class="kt-portlet__head">
                        <div class="kt-portlet__head-label">
                        </div>
                        <div class="kt-portlet__head-toolbar">
                            <b>Filter : </b>
                            <div class="btn-group ml-1" role="group" aria-label="Button group with nested dropdown">
                                <div class="btn-group" role="group">
                                    <%--<button id="btnGroupDrop" type="button" class="btn btn-secondary dropdown-toggle"
                                        data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                        Tahun
                                    </button>
                                    <div class="dropdown-menu" aria-labelledby="btnGroupDrop">
                                        <a class="dropdown-item" href="#">2020</a>
                                        <a class="dropdown-item" href="#">2019</a>
                                        <a class="dropdown-item" href="#">2018</a>
                                        <a class="dropdown-item" href="#">2017</a>
                                    </div>--%>
                                    <asp:Literal ID="lblFilter" runat="server"></asp:Literal>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="kt-portlet__body">
                        <div class="row">
                            <div class="col-md-12">
                                <div id="SliderCarouselKalender" class="mb-4">
                                    <div id="carouselExampleCaptions" class="carousel slide" data-ride="carousel">
                                        <div class="carousel-inner">

                                            <asp:Literal ID="lbllCarousel" runat="server"></asp:Literal>
                                            <%--<div class="carousel-item active">
                                                <a href="sponsorship-detail.html">
                                                    <img src="/Content/assets/media/products/product1.jpg"
                                                        class="center-block h-100" alt="..."></a>
                                                <div class="carousel-caption d-none d-md-block" id="black-light-caption">
                                                    <h5>Lorem ipsum lorem ipsum <span
                                                        class="pull-right btn btn-sm btn-label-brand btn-bold download"><a
                                                            href="sponsorship-detail.html">Selengkapnya...</a></span>
                                                    </h5>
                                                    <p>Nulla vitae elit libero, a pharetra augue mollis interdum.</p>
                                                </div>
                                            </div>
                                            <div class="carousel-item">
                                                <a href="sponsorship-detail.html">
                                                    <img src="/Content/assets/media/products/product2.jpg"
                                                        class="center-block h-100" alt="..."></a>
                                                <div class="carousel-caption d-none d-md-block" id="black-light-caption">
                                                    <h5>Lorem ipsum lorem ipsum <span
                                                        class="pull-right btn btn-sm btn-label-brand btn-bold download"><a
                                                            href="sponsorship-detail.html">Selengkapnya...</a></span>
                                                    </h5>
                                                    <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit.</p>
                                                </div>
                                            </div>--%>
                                        </div>
                                        <a class="carousel-control-prev" href="#carouselExampleCaptions" role="button"
                                            data-slide="prev">
                                            <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                                            <span class="sr-only">Previous</span>
                                        </a>
                                        <a class="carousel-control-next" href="#carouselExampleCaptions" role="button"
                                            data-slide="next">
                                            <span class="carousel-control-next-icon" aria-hidden="true"></span>
                                            <span class="sr-only">Next</span>
                                        </a>
                                    </div>
                                </div>
                            </div>


                            <asp:ListView ID="listViewSponsorship" runat="server">
                                <EmptyDataTemplate>
                                    <table runat="server">
                                        <tr>
                                            <td>No data was returned.</td>
                                        </tr>
                                    </table>
                                </EmptyDataTemplate>
                                <EmptyItemTemplate>
                                    <td runat="server" />
                                </EmptyItemTemplate>
                                <ItemTemplate>
                                    <div class="col-md-3">
                                        <!--begin:: Widgets/Blog-->
                                        <div class="kt-portlet kt-portlet--height-fluid kt-widget19">
                                            <div class="kt-portlet__body kt-portlet__body--fit kt-portlet__body--unfill">
                                                <div class="kt-widget19__pic kt-portlet-fit--top kt-portlet-fit--sides" style="min-height: 200px; background-image: url('<%# ConvertUrl(Eval("file_blob"))%>')">
                                                </div>
                                            </div>
                                            <div class="kt-portlet__body bd-thin">
                                                <div class="kt-widget19__wrapper">
                                                    <div class="kt-widget19__content">
                                                        <div class="kt-widget19__info p-0">
                                                            <a href='<%# ResolveUrl(string.Format("~/Brand/Sponsorship-Detail.aspx{0}&id={1}", PrevUrl, Eval("id"))) %>' class="kt-widget19__username"><%# Eval("Created_By")%>
                                                            </a>
                                                            <span class="kt-widget1__time fsize-11"><%# string.Format("{0:dd MMM yyyy}", Eval("Created")) %>
                                                            </span>
                                                        </div>
                                                    </div>


                                                    <div class="kt-widget18__text">
                                                        <%# Crop(Eval("Body")) %>
                                                    </div>
                                                </div>
                                                <div class="kt-widget19__action">
                                                    <asp:HiddenField ID="hdn" runat="server" Value='<%# Eval("id")%>' />

                                                    <asp:HiddenField ID="hdnFileExt" runat="server" Value='<%# Eval("file_ext")%>' />
                                                    <asp:HyperLink ID="linkDetail" CssClass="btn btn-sm btn-label-brand btn-bold" NavigateUrl='<%# ResolveUrl(string.Format("~/Brand/Sponsorship-Detail.aspx{0}&id={1}", PrevUrl, Eval("id"))) %>' runat="server">Selengkapnya...</asp:HyperLink>
                                                </div>
                                            </div>
                                        </div>
                                        <!--end:: Widgets/Blog-->
                                    </div>
                                </ItemTemplate>
                            </asp:ListView>

                            <%-- <div class="col-md-3">
                                <!--begin:: Widgets/Blog-->
                                <div class="kt-portlet kt-portlet--height-fluid kt-widget19">
                                    <div class="kt-portlet__body kt-portlet__body--fit kt-portlet__body--unfill">
                                        <div class="kt-widget19__pic kt-portlet-fit--top kt-portlet-fit--sides"
                                            style="min-height: 200px; background-image: url(assets/media//products/product1.jpg)">
                                        </div>
                                    </div>
                                    <div class="kt-portlet__body bd-thin">
                                        <div class="kt-widget19__wrapper">
                                            <div class="kt-widget19__content">
                                                <div class="kt-widget19__info p-0">
                                                    <a href="sponsorship-detail.html" class="kt-widget19__username">Anna Krox
                                                    </a>
                                                    <span class="kt-widget1__time fsize-11">18 Apri 2020
                                                    </span>
                                                </div>
                                            </div>
                                            <div class="kt-widget18__text">
                                                Lorem Ipsum is simply dummy text of the printing and typesetting..
                                            </div>
                                        </div>
                                        <div class="kt-widget19__action">
                                            <a href="sponsorship-detail.html"
                                                class="btn btn-sm btn-label-brand btn-bold">Selengkapnya...</a>
                                        </div>
                                    </div>
                                </div>

                                <!--end:: Widgets/Blog-->
                            </div>

                            <div class="col-md-3">
                                <!--begin:: Widgets/Blog-->
                                <div class="kt-portlet kt-portlet--height-fluid kt-widget19">
                                    <div class="kt-portlet__body kt-portlet__body--fit kt-portlet__body--unfill">
                                        <div class="kt-widget19__pic kt-portlet-fit--top kt-portlet-fit--sides"
                                            style="min-height: 200px; background-image: url(assets/media//products/product2.jpg)">
                                        </div>
                                    </div>
                                    <div class="kt-portlet__body bd-thin">
                                        <div class="kt-widget19__wrapper">
                                            <div class="kt-widget19__content">
                                                <div class="kt-widget19__info p-0">
                                                    <a href="sponsorship-detail.html" class="kt-widget19__username">Fredie Mccain
                                                    </a>
                                                    <span class="kt-widget19__time fsize-11">05 April 2020
                                                    </span>
                                                </div>
                                            </div>
                                            <div class="kt-widget18__text">
                                                Lorem Ipsum is simply dummy text of the printing and typesetting..
                                            </div>
                                        </div>
                                        <div class="kt-widget19__action">
                                            <a href="sponsorship-detail.html"
                                                class="btn btn-sm btn-label-brand btn-bold">Selengkapnya...</a>
                                        </div>
                                    </div>
                                </div>

                                <!--end:: Widgets/Blog-->
                            </div>

                            <div class="col-md-3">
                                <!--begin:: Widgets/Blog-->
                                <div class="kt-portlet kt-portlet--height-fluid kt-widget19">
                                    <div class="kt-portlet__body kt-portlet__body--fit kt-portlet__body--unfill">
                                        <div class="kt-widget19__pic kt-portlet-fit--top kt-portlet-fit--sides"
                                            style="min-height: 200px; background-image: url(assets/media//products/product3.jpg)">
                                        </div>
                                    </div>
                                    <div class="kt-portlet__body bd-thin">
                                        <div class="kt-widget19__wrapper">
                                            <div class="kt-widget19__content">
                                                <div class="kt-widget19__info p-0">
                                                    <a href="sponsorship-detail.html" class="kt-widget19__username">Jane Doe
                                                    </a>
                                                    <span class="kt-widget19__time fsize-11">12 April 2020
                                                    </span>
                                                </div>
                                            </div>
                                            <div class="kt-widget18__text">
                                                Lorem Ipsum is simply dummy text of the printing and typesetting..
                                            </div>
                                        </div>
                                        <div class="kt-widget19__action">
                                            <a href="sponsorship-detail.html"
                                                class="btn btn-sm btn-label-brand btn-bold">Selengkapnya...</a>
                                        </div>
                                    </div>
                                </div>

                                <!--end:: Widgets/Blog-->

                            </div>

                            <div class="col-md-3">
                                <!--begin:: Widgets/Blog-->
                                <div class="kt-portlet kt-portlet--height-fluid kt-widget19">
                                    <div class="kt-portlet__body kt-portlet__body--fit kt-portlet__body--unfill">
                                        <div class="kt-widget19__pic kt-portlet-fit--top kt-portlet-fit--sides"
                                            style="min-height: 200px; background-image: url(assets/media//products/product2.jpg)">
                                        </div>
                                    </div>
                                    <div class="kt-portlet__body bd-thin">
                                        <div class="kt-widget19__wrapper">
                                            <div class="kt-widget19__content">
                                                <div class="kt-widget19__info p-0">
                                                    <a href="sponsorship-detail.html" class="kt-widget19__username">Fredie Mccain
                                                    </a>
                                                    <span class="kt-widget19__time fsize-11">05 April 2020
                                                    </span>
                                                </div>
                                            </div>
                                            <div class="kt-widget18__text">
                                                Lorem Ipsum is simply dummy text of the printing and typesetting..
                                            </div>
                                        </div>
                                        <div class="kt-widget19__action">
                                            <a href="sponsorship-detail.html"
                                                class="btn btn-sm btn-label-brand btn-bold">Selengkapnya...</a>
                                        </div>
                                    </div>
                                </div>

                                <!--end:: Widgets/Blog-->
                            </div>--%>
                        </div>

                        <div id="pagerSponsorship" class="kt-pagination kt-pagination--sm kt-pagination--primary kt-mt-40">
                            <ul class="kt-pagination__links">
                                <asp:Repeater ID="rptPagerSponsorship" runat="server" OnItemDataBound="rptPager_ItemDataBound">
                                    <ItemTemplate>
                                        <li runat="server" id="li">
                                            <asp:LinkButton ID="lnkPage" runat="server" CommandName="Sponsorship" Text='<%#Eval("Text") %>' CommandArgument='<%# Eval("Value") %>' Enabled='<%# Eval("Enabled") %>' OnClick="Page_Changed"></asp:LinkButton>
                                        </li>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </ul>
                            <div class="kt-pagination__toolbar">
                                <asp:DropDownList ID="ddlPageSizeSponsorship" AutoPostBack="true" runat="server" CssClass="form-control kt-font-primary" Style="width: 60px;" DataTextField="Text" DataValueField="Code" OnSelectedIndexChanged="ddlPageSize_SelectedIndexChanged"></asp:DropDownList>
                                <span class="pagination__desc">
                                    <asp:Literal ID="lblTotalInfoSponsorship" runat="server" Text=""></asp:Literal>
                                    <asp:HiddenField ID="hdnPageSponsorship" runat="server" />
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
                                    <option value="9">9</option>
                                    <option value="18">18</option>
                                    <option value="30">30</option>
                                    <option value="50">50</option>
                                    <option value="100">100</option>
                                </select>
                                <span class="pagination__desc">Displaying 9 of 230 records
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
