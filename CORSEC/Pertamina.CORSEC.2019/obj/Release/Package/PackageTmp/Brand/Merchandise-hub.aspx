<%@ Page Title="" Language="C#" MasterPageFile="~/Frontend.Master" AutoEventWireup="true" CodeBehind="Merchandise-hub.aspx.cs" Inherits="Pertamina.CORSEC._2019.Brand.Merchandise_hub" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">

    <!-- begin:: Content -->
    <div class="kt-content-height">
        <div class="kt-content kt-content--fit-top  kt-grid__item kt-grid__item--fluid kt-grid kt-grid--hor"
            id="kt_content">

            <!-- begin:: Content -->

            <%--<!-- begin:: Hero -->
            <div class="kt-sc" style="background-image: url('assets/media/bg/bg-9.jpg')">
              <div class="kt-container ">

                <div class="kt-sc__bottom">
                  <h3 class="kt-sc__heading kt-heading kt-heading--center kt-heading--xxl kt-heading--medium">
                    Merchandise hub
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
                      <h2 class="kt-infobox__title">Merchandise hub</h2>
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
                            <b>Urutkan:</b>
                            <div class="btn-group ml-1" role="group" aria-label="Button group with nested dropdown">
                                <div class="btn-group" role="group">
                                    <%--<button id="btnGroupDrop1" type="button" class="btn btn-secondary dropdown-toggle"
                                        data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                        Kategori
                                    </button>
                                    <div class="dropdown-menu" aria-labelledby="btnGroupDrop1">
                                        <a class="dropdown-item" href="#">Kategori A</a>
                                        <a class="dropdown-item" href="#">Kategori B</a>
                                        <a class="dropdown-item" href="#">Kategori C</a>
                                        <a class="dropdown-item" href="#">Kategori D</a>
                                    </div>--%>
                                    <asp:Literal ID="lblFilter" runat="server"></asp:Literal>
                                </div>
                            </div>
                            <div class="btn-group ml-1" role="group" aria-label="Button group with nested dropdown">
                                <div class="btn-group" role="group">
                                    <%--<button id="btnGroupDrop1" type="button" class="btn btn-secondary dropdown-toggle"
                                        data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                        Sort list
                                    </button>
                                    <div class="dropdown-menu" aria-labelledby="btnGroupDrop1">
                                        <a class="dropdown-item" href="#">Last Added</a>
                                        <a class="dropdown-item" href="#">Sort A-Z</a>
                                        <a class="dropdown-item" href="#">Sort Z-A</a>
                                    </div>--%>
                                      <asp:Literal ID="lblSort" runat="server"></asp:Literal>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="kt-portlet__body">


                        <div class="row">
                            <asp:ListView ID="listViewMerchandiseHub" runat="server">
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
                                                <a href='<%# ResolveUrl(string.Format("~/Brand/Merchandise-Hub-Detail.aspx{0}&id={1}", PrevUrl, Eval("id"))) %>'>
                                                    <div class="kt-widget19__pic kt-portlet-fit--top kt-portlet-fit--sides" style="min-height: 280px; background-image: url('<%# ConvertUrl(Eval("file_blob"))%>')">
                                                    </div>
                                                </a>

                                            </div>

                                            <div class="kt-portlet__body bd-thin">
                                                <div class="kt-widget19__wrapper">
                                                    <div class="kt-widget19__content">
                                                        <div class="kt-widget19__info p-0">
                                                            <a href='<%# ResolveUrl(string.Format("~/Brand/Merchandise-Hub-Detail.aspx{0}&id={1}", PrevUrl, Eval("id"))) %>' class="kt-widget19__username"><%# Eval("title")%>
                                                            </a>
                                                        </div>
                                                    </div>


                                                    <div class="kt-widget18__text">
                                                        <%# Crop(Eval("Body"), 66) %>
                                                        <asp:HiddenField ID="hdn" runat="server" Value='<%# Eval("id")%>' />

                                                        <asp:HiddenField ID="hdnFileExt" runat="server" Value='<%# Eval("file_ext")%>' />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <!--end:: Widgets/Blog-->
                                    </div>
                                </ItemTemplate>
                            </asp:ListView>
                        </div>

                        <div id="pagerMerchandiseHub" class="kt-pagination kt-pagination--sm kt-pagination--primary kt-mt-40">
                            <ul class="kt-pagination__links">
                                <asp:Repeater ID="rptPagerMerchandiseHub" runat="server" OnItemDataBound="rptPager_ItemDataBound">
                                    <ItemTemplate>
                                        <li runat="server" id="li">
                                            <asp:LinkButton ID="lnkPage" runat="server" CommandName="MerchandiseHub" Text='<%#Eval("Text") %>' CommandArgument='<%# Eval("Value") %>' Enabled='<%# Eval("Enabled") %>' OnClick="Page_Changed"></asp:LinkButton>
                                        </li>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </ul>
                            <div class="kt-pagination__toolbar">
                                <asp:DropDownList ID="ddlPageSizeMerchandiseHub" AutoPostBack="true" runat="server" CssClass="form-control kt-font-primary" Style="width: 60px;" DataTextField="Text" DataValueField="Code" OnSelectedIndexChanged="ddlPageSize_SelectedIndexChanged"></asp:DropDownList>
                                <span class="pagination__desc">
                                    <asp:Literal ID="lblTotalInfoMerchandiseHub" runat="server" Text=""></asp:Literal>
                                    <asp:HiddenField ID="hdnPageMerchandiseHub" runat="server" />
                                </span>
                            </div>
                        </div>


                        <%--                        <div class="row">
                            <div class="col-md-3">
                                <!--begin:: Widgets/Blog-->
                                <div class="kt-portlet kt-portlet--height-fluid kt-widget19">
                                    <div class="kt-portlet__body kt-portlet__body--fit kt-portlet__body--unfill">
                                        <a href="merchandise-hub-detail.html">
                                            <div class="kt-widget19__pic kt-portlet-fit--top kt-portlet-fit--sides"
                                                style="min-height: 280px; background-image: url(assets/media/merchandise/3.jpg)">
                                            </div>
                                        </a>
                                    </div>
                                    <div class="kt-portlet__body bd-thin">
                                        <div class="kt-widget19__wrapper">
                                            <div class="kt-widget19__content">
                                                <div class="kt-widget19__info p-0">
                                                    <a href="merchandise-hub-detail.html" class="kt-widget19__username">Lorem Ipsum Lorem Ipsum
                                                    </a>
                                                </div>
                                            </div>
                                            <div class="kt-widget18__text">
                                                Lorem Ipsum is simply dummy text of the printing and typesetting..
                                            </div>
                                        </div>
                                    </div>
                                </div>

                                <!--end:: Widgets/Blog-->
                            </div>

                            <div class="col-md-3">
                                <!--begin:: Widgets/Blog-->
                                <div class="kt-portlet kt-portlet--height-fluid kt-widget19">
                                    <div class="kt-portlet__body kt-portlet__body--fit kt-portlet__body--unfill">
                                        <a href="merchandise-hub-detail.html">
                                            <div class="kt-widget19__pic kt-portlet-fit--top kt-portlet-fit--sides"
                                                style="min-height: 280px; background-image: url(assets/media/merchandise/6.jpg)">
                                            </div>
                                        </a>
                                    </div>
                                    <div class="kt-portlet__body bd-thin">
                                        <div class="kt-widget19__wrapper">
                                            <div class="kt-widget19__content">
                                                <div class="kt-widget19__info p-0">
                                                    <a href="merchandise-hub-detail.html" class="kt-widget19__username">Lorem Ipsum Lorem Ipsum
                                                    </a>
                                                </div>
                                            </div>
                                            <div class="kt-widget18__text">
                                                Lorem Ipsum is simply dummy text of the printing and typesetting..
                                            </div>
                                        </div>
                                    </div>
                                </div>

                                <!--end:: Widgets/Blog-->
                            </div>

                            <div class="col-md-3">
                                <!--begin:: Widgets/Blog-->
                                <div class="kt-portlet kt-portlet--height-fluid kt-widget19">
                                    <div class="kt-portlet__body kt-portlet__body--fit kt-portlet__body--unfill">
                                        <a href="merchandise-hub-detail.html">
                                            <div class="kt-widget19__pic kt-portlet-fit--top kt-portlet-fit--sides"
                                                style="min-height: 280px; background-image: url(assets/media/merchandise/2.jpg)">
                                            </div>
                                        </a>
                                    </div>
                                    <div class="kt-portlet__body bd-thin">
                                        <div class="kt-widget19__wrapper">
                                            <div class="kt-widget19__content">
                                                <div class="kt-widget19__info p-0">
                                                    <a href="merchandise-hub-detail.html" class="kt-widget19__username">Lorem Ipsum Lorem Ipsum
                                                    </a>
                                                </div>
                                            </div>
                                            <div class="kt-widget18__text">
                                                Lorem Ipsum is simply dummy text of the printing and typesetting..
                                            </div>
                                        </div>
                                    </div>
                                </div>

                                <!--end:: Widgets/Blog-->
                            </div>

                            <div class="col-md-3">
                                <!--begin:: Widgets/Blog-->
                                <div class="kt-portlet kt-portlet--height-fluid kt-widget19">
                                    <div class="kt-portlet__body kt-portlet__body--fit kt-portlet__body--unfill">
                                        <a href="merchandise-hub-detail.html">
                                            <div class="kt-widget19__pic kt-portlet-fit--top kt-portlet-fit--sides"
                                                style="min-height: 280px; background-image: url(assets/media/merchandise/3.jpg)">
                                            </div>
                                        </a>
                                    </div>
                                    <div class="kt-portlet__body bd-thin">
                                        <div class="kt-widget19__wrapper">
                                            <div class="kt-widget19__content">
                                                <div class="kt-widget19__info p-0">
                                                    <a href="merchandise-hub-detail.html" class="kt-widget19__username">Lorem Ipsum Lorem Ipsum
                                                    </a>
                                                </div>
                                            </div>
                                            <div class="kt-widget18__text">
                                                Lorem Ipsum is simply dummy text of the printing and typesetting..
                                            </div>
                                        </div>
                                    </div>
                                </div>

                                <!--end:: Widgets/Blog-->
                            </div>
                        </div>
                        <div class="kt-pagination kt-pagination--sm kt-pagination--primary kt-mt-40">
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
                                    <option value="12">12</option>
                                    <option value="24">24</option>
                                    <option value="30">30</option>
                                    <option value="50">50</option>
                                    <option value="100">100</option>
                                </select>
                                <span class="pagination__desc">Displaying 12 of 230 records
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
