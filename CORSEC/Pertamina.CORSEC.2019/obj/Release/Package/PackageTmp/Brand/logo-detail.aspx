<%@ Page Title="" Language="C#" MasterPageFile="~/Frontend.Master" AutoEventWireup="true" CodeBehind="logo-detail.aspx.cs" Inherits="Pertamina.CORSEC._2019.Brand.logo_detail" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">

    <!-- begin:: Content -->
    <div class="kt-content-height">
        <div class="kt-content kt-content--fit-top  kt-grid__item kt-grid__item--fluid kt-grid kt-grid--hor"
            id="kt_content">

            <!-- begin:: Content -->

            <%-- <!-- begin:: Hero -->
            <div class="kt-sc" style="background-image: url('assets/media/bg/bg-9.jpg')">
                <div class="kt-container ">

                    <div class="kt-sc__bottom">
                        <h3 class="kt-sc__heading kt-heading kt-heading--center kt-heading--xxl kt-heading--medium">Logo HUT
                        </h3>
                    </div>
                </div>
            </div>
            <!-- end:: Hero -->

            <div class="kt-container">
                <div class="kt-portlet">
                    <div class="kt-portlet__body">
                        <div class="kt-infobox">
                            <div class="kt-infobox__header">
                                <h2 class="kt-infobox__title">Logo HUT</h2>
                            </div>
                            <div class="kt-infobox__body">
                                <div class="kt-infobox__section">
                                    <div class="kt-infobox__content text-justify">
                                        Lorem ipsum dolor sit amet, consectetur adipisicing elit. Temporibus at laboriosam
												architecto maiores consequuntur pariatur fuga aperiam labore, consectetur ratione ullam,
												accusamus quos optio quibusdam molestias repellendus! Aut nulla dolores nisi nemo aperiam et
												quos magni ut officia, nesciunt quia ipsa illo nam quibusdam possimus dignissimos ducimus
												veritatis quae tempore amet voluptate repellat. Eos sed est numquam nisi hic eveniet quos,
												rerum culpa ipsa.
                                    </div>
                                </div>
                            </div>
                        </div>
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

            <div class="kt-container">

                <!--begin:: Portlet-->
                <%--                <div class="kt-portlet kt-callout">
                    <div class="kt-portlet__body">
                        <div class="kt-callout__body">
                            <div class="kt-callout__content">
                                <h3 class="kt-callout__title">Panduan Logo</h3>
                                <p class="kt-callout__desc text-justify">
                                    Lorem ipsum dolor sit amet, consectetur adipisicing elit. Temporibus at laboriosam
											architecto maiores consequuntur pariatur fuga aperiam labore, consectetur ratione ullam,
											accusamus quos optio quibusdam molestias repellendus! Aut nulla dolores nisi nemo aperiam et
											quos magni ut officia, nesciunt quia ipsa illo nam quibusdam possimus dignissimos ducimus
											veritatis quae tempore amet voluptate repellat. Eos sed est numquam nisi hic eveniet quos,
											rerum culpa ipsa.
                                </p>
                                <span class="kt-media kt-media--sm">
                                    <img src="assets/media/files/pdf.svg" class="float-left mr-2" alt=" image">
                                    <a href="#" class="kt-link kt-font-boldest mt-2" data-toggle="kt-tooltip" data-skin="dark"
                                        data-placement="right" title="Download">Judul File
                                    </a>
                                </span>
                            </div>
                            <div class="kt-callout__action">
                                <div class="thumbnail">
                                    <div class="media">
                                        <span class="meta bottom darken">
                                            <p class="m-0 semibold">
                                                Judul Gambar
                                            </p>
                                        </span>
                                        <img src="assets/media/gallery/background1.jpg" alt="Photo" width="100%">
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>--%>

                <asp:Literal ID="lblContent" runat="server"></asp:Literal>

                <%--                <div class="kt-portlet kt-callout">
                    <div class="kt-portlet__body">
                        <div class="kt-callout__body">
                            <div class="kt-callout__content">
                                <h3 class="kt-callout__title">Panduan Warna Hut</h3>
                                <p class="kt-callout__desc text-justify">
                                    Lorem ipsum dolor sit amet, consectetur adipisicing elit. Temporibus at laboriosam
											architecto maiores consequuntur pariatur fuga aperiam labore, consectetur ratione ullam,
											accusamus quos optio quibusdam molestias repellendus! Aut nulla dolores nisi nemo aperiam et
											quos magni ut officia, nesciunt quia ipsa illo nam quibusdam possimus dignissimos ducimus
											veritatis quae tempore amet voluptate repellat. Eos sed est numquam nisi hic eveniet quos,
											rerum culpa ipsa.
                                </p>
                            </div>
                            <div class="kt-callout__action">
                                <div class="thumbnail">
                                    <div class="media">
                                        <span class="meta bottom darken">
                                            <p class="m-0 semibold">
                                                Judul Gambar
                                            </p>
                                        </span>
                                        <img src="assets/media/gallery/background1.jpg" alt="Photo" width="100%">
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>--%>

                <div class="kt-portlet kt-portlet--tabs kt-portlet--height-fluid">
                    <div class="kt-portlet__body">
                        <div class="kt-widget4">
                            <asp:Literal ID="lblLogos" runat="server"></asp:Literal>

                            <%--                            <div class="kt-widget4__item p-3">
                                <img class="kt-mr-10" src="https://www.pertamina.com/Media/Image/Pertamina.png" height="75" alt="">
                                <small class="kt-widget4__number fsize-11 kt-mr-20">JPG - 23mb</small>
                                <span class="kt-widget3__number kt-font-info">
                                    <a href="#" class="btn-label-brand btn btn-sm btn-bold">Download</a>
                                </span>
                            </div>
                            <div class="kt-widget4__item p-3">
                                <img class="kt-mr-10" src="https://www.pertamina.com/Media/Image/Pertamina.png" height="75" alt="">
                                <small class="kt-widget4__number fsize-11 kt-mr-20">JPG - 23mb</small>
                                <span class="kt-widget3__number kt-font-info">
                                    <a href="#" class="btn-label-brand btn btn-sm btn-bold">Download</a>
                                </span>
                            </div>
                            <div class="kt-widget4__item p-3">
                                <img class="kt-mr-10" src="https://www.pertamina.com/Media/Image/Pertamina.png" height="75" alt="">
                                <small class="kt-widget4__number fsize-11 kt-mr-20">JPG - 23mb</small>
                                <span class="kt-widget3__number kt-font-info">
                                    <a href="#" class="btn-label-brand btn btn-sm btn-bold">Download</a>
                                </span>
                            </div>--%>
                        </div>
                    </div>
                </div>

                <!--end:: Portlet-->
            </div>
            <!-- end:: Section -->

            <div class="kt-container">
                <div class="kt-portlet">
                    <div class="kt-portlet__body">
                        <div class="kt-infobox">
                            <asp:Literal ID="lbl_Aplikasi_Inspirasi" runat="server"></asp:Literal>
                            <%-- <div class="kt-infobox__header">
                                <h2 class="kt-infobox__title">Aplikasi & Inspirasi</h2>
                            </div>
                            <div class="kt-infobox__body">
                                <div class="kt-infobox__section">
                                    <div class="kt-infobox__content text-justify">
                                        Lorem ipsum dolor sit amet, consectetur adipisicing elit. Temporibus at laboriosam
												architecto maiores consequuntur pariatur fuga aperiam labore, consectetur ratione ullam,
												accusamus quos optio quibusdam molestias repellendus! Aut nulla dolores nisi nemo aperiam et
												quos magni ut officia, nesciunt quia ipsa illo nam quibusdam possimus dignissimos ducimus
												veritatis quae tempore amet voluptate repellat. Eos sed est numquam nisi hic eveniet quos,
												rerum culpa ipsa.
                                    </div>
                                </div>
                            </div>--%>
                        </div>

                        <%--<div class="row">
                            <div class="col-md-4">
                                <div class="kt-portlet kt-portlet--height-fluid kt-widget19">
                                    <div class="kt-portlet__body kt-portlet__body--fit kt-portlet__body--unfill">
                                        <div class="kt-widget19__pic kt-portlet-fit--top kt-portlet-fit--sides"
                                            style="min-height: 300px; background-image: url(/content/assets/media//products/product3.jpg)">
                                            <h3 class="kt-widget19__title kt-font-light">Lorem ipsum dolor sit amet
                                            </h3>
                                        </div>
                                    </div>
                                    <div class="kt-portlet__body bd-thin">
                                        <span class="fsize-11 mb-2">
                                            <i class="fa fa-clock"></i>2 hour ago 
														<i class="fa fa-bookmark"></i>Test
														<i class="flaticon2-calendar-3"></i>Admin
                                        </span>
                                        <div class="kt-widget19__wrapper">
                                            <div class="kt-widget18__text text-justify">
                                                Lorem ipsum dolor sit amet, consectetur adipisicing elit. Temporibus at laboriosam architecto
														  tempore amet voluptate repellat. Eos sed est numquam nisi hic eveniet quos, rerum culpa ipsa.
                                            </div>
                                        </div>
                                        <div class="kt-widget19__action">
                                            <a href="detail-aplikasi-inspirasi.html" class="btn btn-sm btn-label-brand btn-bold">Selengkapnya...</a>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="kt-portlet kt-portlet--height-fluid kt-widget19">
                                    <div class="kt-portlet__body kt-portlet__body--fit kt-portlet__body--unfill">
                                        <div class="kt-widget19__pic kt-portlet-fit--top kt-portlet-fit--sides"
                                            style="min-height: 300px; background-image: url(/content/assets/media//products/product4.jpg)">
                                            <h3 class="kt-widget19__title kt-font-light">Lorem ipsum dolor sit amet
                                            </h3>
                                        </div>
                                    </div>
                                    <div class="kt-portlet__body bd-thin">
                                        <span class="fsize-11 mb-2">
                                            <i class="fa fa-clock"></i>2 hour ago 
														<i class="fa fa-bookmark"></i>Test
														<i class="flaticon2-calendar-3"></i>Admin
                                        </span>
                                        <div class="kt-widget19__wrapper">
                                            <div class="kt-widget18__text text-justify">
                                                Lorem ipsum dolor sit amet, consectetur adipisicing elit. Temporibus at laboriosam architecto
														  tempore amet voluptate repellat. Eos sed est numquam nisi hic eveniet quos, rerum culpa ipsa.
                                            </div>
                                        </div>
                                        <div class="kt-widget19__action">
                                            <a href="detail-aplikasi-inspirasi.html" class="btn btn-sm btn-label-brand btn-bold">Selengkapnya...</a>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="kt-portlet kt-portlet--height-fluid kt-widget19">
                                    <div class="kt-portlet__body kt-portlet__body--fit kt-portlet__body--unfill">
                                        <div class="kt-widget19__pic kt-portlet-fit--top kt-portlet-fit--sides"
                                            style="min-height: 300px; background-image: url(/content/assets/media//products/product2.jpg)">
                                            <h3 class="kt-widget19__title kt-font-light">Lorem ipsum dolor sit amet
                                            </h3>
                                        </div>
                                    </div>
                                    <div class="kt-portlet__body bd-thin">
                                        <span class="fsize-11 mb-2">
                                            <i class="fa fa-clock"></i>2 hour ago 
														<i class="fa fa-bookmark"></i>Test
														<i class="flaticon2-calendar-3"></i>Admin
                                        </span>
                                        <div class="kt-widget19__wrapper">
                                            <div class="kt-widget18__text text-justify">
                                                Lorem ipsum dolor sit amet, consectetur adipisicing elit. Temporibus at laboriosam architecto
														  tempore amet voluptate repellat. Eos sed est numquam nisi hic eveniet quos, rerum culpa ipsa.
                                            </div>
                                        </div>
                                        <div class="kt-widget19__action">
                                            <a href="detail-aplikasi-inspirasi.html" class="btn btn-sm btn-label-brand btn-bold">Selengkapnya...</a>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>


                        <!--begin: Pagination-->
                        <div class="kt-pagination kt-pagination--brand kt-mt-20">
                            <ul class="kt-pagination__links">
                                <li class="kt-pagination__link--first">
                                    <a href="#"><i class="fa fa-angle-double-left kt-font-brand"></i></a>
                                </li>
                                <li class="kt-pagination__link--next">
                                    <a href="#"><i class="fa fa-angle-left kt-font-brand"></i></a>
                                </li>
                                <li>
                                    <a href="#">...</a>
                                </li>
                                <li>
                                    <a href="#">29</a>
                                </li>
                                <li>
                                    <a href="#">30</a>
                                </li>
                                <li class="kt-pagination__link--active">
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
                                    <a href="#"><i class="fa fa-angle-right kt-font-brand"></i></a>
                                </li>
                                <li class="kt-pagination__link--last">
                                    <a href="#"><i class="fa fa-angle-double-right kt-font-brand"></i></a>
                                </li>
                            </ul>
                            <div class="kt-pagination__toolbar">
                                <select class="form-control kt-font-brand" style="width: 60px">
                                    <option value="10">10</option>
                                    <option value="20">20</option>
                                    <option value="30">30</option>
                                    <option value="50">50</option>
                                    <option value="100">100</option>
                                </select>
                                <span class="pagination__desc">Displaying 10 of 230 records
                                </span>
                            </div>
                        </div>
                        <!--end: Pagination-->
                        --%>

                        <!--begin::table Aplikasi_Inspirasi -->
                        <!--begin::widget 12-->
                        <div class="row">
                            <asp:ListView ID="listViewAplikasi_Inspirasi" runat="server">
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
                                    <div class="col-md-4">
                                        <div class="kt-portlet kt-portlet--height-fluid kt-widget19">
                                            <div class="kt-portlet__body kt-portlet__body--fit kt-portlet__body--unfill">
                                                <div class="kt-widget19__pic kt-portlet-fit--top kt-portlet-fit--sides"
                                                    style="min-height: 300px; background-image: url('<%# ConvertUrl(Eval("image_blob"))%>')">
                                                    <h3 class="kt-widget19__title kt-font-light"><%# Eval("Title")%>
                                                    </h3>
                                                </div>
                                            </div>
                                            <div class="kt-portlet__body bd-thin">
                                                <span class="fsize-11 mb-2">
                                                    <i class="fa fa-clock"></i> <%# GetPeriodAgo(Eval("created")) %>
													<%--<i class="fa fa-bookmark"></i>Test--%>
													<i class="flaticon2-calendar-3"></i> <%# string.Format("{0:dd MMM yyyy}", Eval("created_by")) %>
                                                </span>
                                                <div class="kt-widget19__wrapper">
                                                    <div class="kt-widget18__text text-justify">
                                                        <%#  Crop(string.Format("{0}", Eval("Body")), 205) %>
                                                    </div>
                                                </div>
                                                <div class="kt-widget19__action">                                                    
                                                    <asp:HiddenField ID="hdn" runat="server" Value='<%# Eval("id")%>' />
                                                    <asp:HyperLink ID="linkDetail" CssClass="btn btn-sm btn-label-brand btn-bold" NavigateUrl='<%# ResolveUrl(string.Format("~/Brand/detail-aplikasi-inspirasi.aspx{0}&id={1}", PrevUrl, Eval("id"))) %>' runat="server">Selengkapnya...</asp:HyperLink>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    
                                </ItemTemplate>
                            </asp:ListView>
                        </div>
                        <!--end::Widget 12-->
                        <div id="pagerAplikasi_Inspirasi" class="kt-pagination kt-pagination--sm kt-pagination--primary kt-mt-40">
                            <ul class="kt-pagination__links">
                                <asp:Repeater ID="rptPagerAplikasi_Inspirasi" runat="server" OnItemDataBound="rptPager_ItemDataBound">
                                    <ItemTemplate>
                                        <li runat="server" id="li">
                                            <asp:LinkButton ID="lnkPage" runat="server" CommandName="Aplikasi_Inspirasi" Text='<%#Eval("Text") %>' CommandArgument='<%# Eval("Value") %>' Enabled='<%# Eval("Enabled") %>' OnClick="Page_Changed"></asp:LinkButton>
                                        </li>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </ul>
                            <div class="kt-pagination__toolbar">
                                <asp:DropDownList ID="ddlPageSizeAplikasi_Inspirasi" AutoPostBack="true" runat="server" CssClass="form-control kt-font-primary" Style="width: 60px;" DataTextField="Text" DataValueField="Code" OnSelectedIndexChanged="ddlPageSize_SelectedIndexChanged"></asp:DropDownList>
                                <span class="pagination__desc">
                                    <asp:Literal ID="lblTotalInfoAplikasi_Inspirasi" runat="server" Text=""></asp:Literal>
                                    <asp:HiddenField ID="hdnPageAplikasi_Inspirasi" runat="server" />
                                </span>
                            </div>
                        </div>
                        <!--end::table Aplikasi_Inspirasi -->
                    </div>
                </div>

                <!--end:: Portlet-->
            </div>

            <!-- end:: Content -->
        </div>
    </div>
    <!-- end:: Content -->

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="script" runat="server">
</asp:Content>
