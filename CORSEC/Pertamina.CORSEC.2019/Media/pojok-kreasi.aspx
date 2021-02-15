<%@ Page Title="" Language="C#" MasterPageFile="~/Frontend.Master" AutoEventWireup="true" CodeBehind="pojok-kreasi.aspx.cs" Inherits="Pertamina.CORSEC._2019.Media.pojok_kreasi" EnableEventValidation="false" %>

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
        <div class="kt-content kt-content--fit-top  kt-grid__item kt-grid__item--fluid kt-grid kt-grid--hor"
            id="kt_content">

            <!-- begin:: Hero -->
            <%--<div class="kt-sc" style="background-image: url('assets/media/bg/bg-9.jpg')">
                <div class="kt-container ">

                    <div class="kt-sc__bottom">
                        <h3 class="kt-sc__heading kt-heading kt-heading--center kt-heading--xxl kt-heading--medium">Materi Presentasi
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
                                    <asp:Label ID="lblTittle" runat="server" Text=""></asp:Label>
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

                <div class="kt-portlet">
                    <div class="kt-portlet__head">
                        <div class="kt-portlet__head-toolbar">
                            <ul
                                class="nav nav-pills nav-fill"
                                role="tablist">
                                <li class="nav-item">
                                    <a class="nav-link active" role="tab" id="tab_Print_Ad" runat="server"
                                        aria-selected="false">Print Ad
                                    </a>
                                </li>
                                <li class="nav-item">
                                    <a class="nav-link" id="tab_Stock_Photo" runat="server"
                                        aria-selected="true">Stock Photo
                                    </a>
                                </li>
                                <li class="nav-item">
                                    <a class="nav-link" role="tab" id="tab_TVC" runat="server"
                                        aria-selected="false">TVC
                                    </a>
                                </li>

                            </ul>
                        </div>

                        <div class="kt-portlet__head-toolbar">
                            <b>Urutkan:</b>
                            <div class="btn-group ml-1" role="group" aria-label="Button group with nested dropdown">
                                <div class="btn-group" role="group">
                                    <asp:Literal ID="lblFilter" runat="server"></asp:Literal>
                                    <%-- <button id="btnGroupDrop1" type="button" class="btn btn-secondary dropdown-toggle"
                                        data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                        5 Tahun Terakhir & Archive
                                    </button>
                                    <div class="dropdown-menu" aria-labelledby="btnGroupDrop1">
                                        <a class="dropdown-item" href="#">5 Tahun Terakhir & Archive A</a>
                                        <a class="dropdown-item" href="#">5 Tahun Terakhir & Archive B</a>
                                        <a class="dropdown-item" href="#">5 Tahun Terakhir & Archive C</a>
                                        <a class="dropdown-item" href="#">5 Tahun Terakhir & Archive D</a>
                                    </div>--%>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="kt-portlet__body">
                        <div class="tab-content">
                            <div class="tab-pane active" id="kt_portlet_base_demo_2_4_tab_content" role="tabpanel" runat="server">
                                <!--begin::table Print_Ad -->
                                <!--begin::widget 12-->
                                <div class="row">
                                    <asp:ListView ID="listViewPrint_Ad" runat="server">

                                        <EmptyDataTemplate>
                                            <table runat="server">
                                                <tr>
                                                    <td></td>
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
                                                                    <a href='<%# ResolveUrl(string.Format("~/Media/pojok-kreasi-detail.aspx{0}&id={1}", PrevUrl, Eval("id"))) %>' class="kt-widget19__username"><%# Eval("created_by")%>
                                                                    </a>
                                                                    <span class="kt-widget1__time fsize-11"><%# string.Format("{0:dd MMM yyyy}", Eval("Created")) %>
                                                                    </span>
                                                                </div>
                                                            </div>
                                                            <div class="kt-widget18__text">
                                                                <%#  Crop(string.Format("{0}", Eval("Title")), 66) %>
                                                            </div>
                                                        </div>
                                                        <div class="kt-widget19__action">
                                                            <asp:HiddenField ID="hdn" runat="server" Value='<%# Eval("id")%>' />

                                                            <asp:HiddenField ID="hdnFileExt" runat="server" Value='<%# Eval("file_ext")%>' />
                                                            <asp:HyperLink ID="linkDetail" CssClass="btn btn-sm btn-label-brand btn-bold" NavigateUrl='<%# ResolveUrl(string.Format("~/Media/pojok-kreasi-detail.aspx{0}&id={1}", PrevUrl, Eval("id"))) %>' runat="server">Lihat</asp:HyperLink>
                                                        </div>
                                                    </div>
                                                </div>

                                                <!--end:: Widgets/Blog-->
                                            </div>
                                        </ItemTemplate>


                                    </asp:ListView>
                                </div>
                                <!--end::Widget 12-->
                                <div id="pagerPrint_Ad" class="kt-pagination kt-pagination--sm kt-pagination--primary kt-mt-40">
                                    <ul class="kt-pagination__links">
                                        <asp:Repeater ID="rptPagerPrint_Ad" runat="server" OnItemDataBound="rptPager_ItemDataBound">
                                            <ItemTemplate>
                                                <li runat="server" id="li">
                                                    <asp:LinkButton ID="lnkPage" runat="server" CommandName="Print_Ad" Text='<%#Eval("Text") %>' CommandArgument='<%# Eval("Value") %>' Enabled='<%# Eval("Enabled") %>' OnClick="Page_Changed"></asp:LinkButton>
                                                </li>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </ul>
                                    <div class="kt-pagination__toolbar">
                                        <asp:DropDownList ID="ddlPageSizePrint_Ad" AutoPostBack="true" runat="server" CssClass="form-control kt-font-primary" Style="width: 60px;" DataTextField="Text" DataValueField="Code" OnSelectedIndexChanged="ddlPageSize_SelectedIndexChanged"></asp:DropDownList>
                                        <span class="pagination__desc">
                                            <asp:Literal ID="lblTotalInfoPrint_Ad" runat="server" Text=""></asp:Literal>
                                            <asp:HiddenField ID="hdnPagePrint_Ad" runat="server" />
                                        </span>
                                    </div>
                                </div>
                                <!--end::table Print_Ad -->
                            </div>
                            <div runat="server" class="tab-pane" id="kt_portlet_base_demo_2_3_tab_content" role="tabpanel" runat="server">
                                <!--begin::table Stock_Photo -->
                                <!--begin::widget 12-->
                                <div class="row">
                                    <asp:ListView ID="listViewStock_Photo" runat="server">
                                        <EmptyDataTemplate>
                                            <table runat="server">
                                                <tr>
                                                    <td></td>
                                                </tr>
                                            </table>
                                        </EmptyDataTemplate>
                                        <EmptyItemTemplate>
                                            <td runat="server" />
                                        </EmptyItemTemplate>
                                        <ItemTemplate>
                                            <div class="col-lg-3">
                                                <div class="kt-portlet kt-portlet--bordered">
                                                    <div class="kt-portlet__body">
                                                        <div class="kt-iconbox__body">
                                                            <div class="kt-iconbox__desc text-center">
                                                                <a href="<%# ResolveUrl(string.Format("~/Media/stock-photo.aspx{0}&id={1}", PrevUrl, Eval("id"))) %>">
                                                                    <img src="<%# ConvertUrl(Eval("img_blob"))%>" width="100%" alt="Photo">
                                                                    <h3 class="kt-iconbox__title mt-3">
                                                                        <%#  string.Format("{0}", Eval("Title")) %>
                                                                    </h3>
                                                                </a>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </ItemTemplate>
                                    </asp:ListView>
                                </div>
                                <!--end::Widget 12-->
                                <!--end::table Stock_Photo -->
                            </div>
                            <div class="tab-pane" id="kt_portlet_base_demo_2_2_tab_content" role="tabpanel" runat="server">
                                <!--begin::table TVC -->


                                <ul class="list-unstyled video-list-thumbs row">
                                    <asp:ListView ID="listViewTVC" runat="server">
                                        <EmptyDataTemplate>
                                            <table runat="server">
                                                <tr>
                                                    <td></td>
                                                </tr>
                                            </table>
                                        </EmptyDataTemplate>
                                        <EmptyItemTemplate>
                                            <td runat="server" />
                                        </EmptyItemTemplate>
                                        <ItemTemplate>

                                            <!--begin:: Widgets/Blog-->
                                            <li class="col-lg-3 col-sm-4 col-xs-6">
                                                <a href="<%# ResolveUrl(string.Format("~/Media/pojok-kreasi-video.aspx{0}&id={1}", PrevUrl, Eval("id"))) %>" title=" <%#  Crop(string.Format("{0}", Eval("Title")), 66) %>">

                                                    <img src="<%# ConvertUrl(Eval("img_blob"))%>" alt="Barca" class="img-responsive" style="width: 100%; height: 130px" />
                                                    <h2><%#  Crop(string.Format("{0}", Eval("Title")), 66) %></h2>
                                                    <span class="glyphicon glyphicon-play-circle"></span>
                                                    <span class="duration"><%# string.Format("{0}", Eval("body")) %></span>
                                                </a>
                                            </li>                                   

                                        </ItemTemplate>
                                    </asp:ListView>
                                </ul>


                                <div id="pagerTVC" class="kt-pagination kt-pagination--sm kt-pagination--primary kt-mt-40">
                                    <ul class="kt-pagination__links">
                                        <asp:Repeater ID="rptPagerTVC" runat="server" OnItemDataBound="rptPager_ItemDataBound">
                                            <ItemTemplate>
                                                <li runat="server" id="li">
                                                    <asp:LinkButton ID="lnkPage" runat="server" CommandName="TVC" Text='<%#Eval("Text") %>' CommandArgument='<%# Eval("Value") %>' Enabled='<%# Eval("Enabled") %>' OnClick="Page_Changed"></asp:LinkButton>
                                                </li>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </ul>
                                    <div class="kt-pagination__toolbar">
                                        <asp:DropDownList ID="ddlPageSizeTVC" AutoPostBack="true" runat="server" CssClass="form-control kt-font-primary" Style="width: 60px;" DataTextField="Text" DataValueField="Code" OnSelectedIndexChanged="ddlPageSize_SelectedIndexChanged"></asp:DropDownList>
                                        <span class="pagination__desc">
                                            <asp:Literal ID="lblTotalInfoTVC" runat="server" Text=""></asp:Literal>
                                            <asp:HiddenField ID="hdnPageTVC" runat="server" />
                                        </span>
                                    </div>
                                </div>
                                <!--end::table TVC -->
                            </div>

                        </div>

                    </div>
                </div>

            </div>

        </div>
    </div>
    <!-- end:: Content -->

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="script" runat="server">



    <%--				<!-- begin:: Content -->
				<div class="kt-content-height">
				<div class="kt-content kt-content--fit-top  kt-grid__item kt-grid__item--fluid kt-grid kt-grid--hor"
					id="kt_content">

					<!-- begin:: Hero -->
					<div class="kt-sc" style="background-image: url('assets/media/bg/bg-9.jpg')">
						<div class="kt-container ">

							<div class="kt-sc__bottom">
								<h3 class="kt-sc__heading kt-heading kt-heading--center kt-heading--xxl kt-heading--medium">
									Pojok Kreasi
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
										<h2 class="kt-infobox__title">Pojok Kreasi</h2>
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

						<div class="kt-portlet">
							<div class="kt-portlet__head">
								<div class="kt-portlet__head-toolbar">
									<ul class="nav nav-pills nav-fill" role="tablist">
										<li class="nav-item">
											<a class="nav-link active" data-toggle="tab" href="#kt_portlet_base_demo_2_3_tab_content"
												role="tab" aria-selected="true">
												Print Ad
											</a>
										</li>
										<li class="nav-item">
											<a class="nav-link" data-toggle="tab" href="#kt_portlet_base_demo_2_2_tab_content" role="tab"
												aria-selected="false">
												Stock Photo
											</a>
										</li>
										<li class="nav-item">
											<a class="nav-link" data-toggle="tab" href="#kt_portlet_base_demo_2_31_tab_content" role="tab"
												aria-selected="false">
												TVC
											</a>
										</li>
									</ul>
								</div>
								<div class="kt-portlet__head-toolbar">
									<b>Urutkan:</b>
									<div class="btn-group ml-1" role="group" aria-label="Button group with nested dropdown">
										<div class="btn-group" role="group">
											<button id="btnGroupDrop1" type="button" class="btn btn-secondary dropdown-toggle"
												data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
												5 Tahun Terakhir & Archive
											</button>
											<div class="dropdown-menu" aria-labelledby="btnGroupDrop1">
												<a class="dropdown-item" href="#">5 Tahun Terakhir & Archive A</a>
												<a class="dropdown-item" href="#">5 Tahun Terakhir & Archive B</a>
												<a class="dropdown-item" href="#">5 Tahun Terakhir & Archive C</a>
												<a class="dropdown-item" href="#">5 Tahun Terakhir & Archive D</a>
											</div>
										</div>
									</div>
								</div>
							</div>
							<div class="kt-portlet__body">
								<div class="tab-content">
									<div class="tab-pane active" id="kt_portlet_base_demo_2_3_tab_content" role="tabpanel">
										
										<div class="row">
											<div class="col-md-3">
												<!--begin:: Widgets/Blog-->
												<div class="kt-portlet kt-portlet--height-fluid kt-widget19">
													<div class="kt-portlet__body kt-portlet__body--fit kt-portlet__body--unfill">
														<div class="kt-widget19__pic kt-portlet-fit--top kt-portlet-fit--sides" style="min-height: 200px; background-image: url(assets/media/printad/1.jpg)">
														</div>
													</div>
													<div class="kt-portlet__body bd-thin">
														<div class="kt-widget19__wrapper">
															<div class="kt-widget19__content">
																<div class="kt-widget19__info p-0">
																	<a href="printadd-detail.html" class="kt-widget19__username">
																		Loresem Ipsum
																	</a>
																	<span class="kt-widget1__time fsize-11">
																		18 Apri 2020
																	</span>
																</div>
															</div>
															<div class="kt-widget18__text">
																Lorem Ipsum is simply dummy text of the printing and typesetting..
															</div>
														</div>
														<div class="kt-widget19__action">
															<a href="printadd-detail.html" class="btn btn-sm btn-label-brand btn-bold">Lihat</a>
														</div>
													</div>
												</div>

												<!--end:: Widgets/Blog-->
											</div>

											<div class="col-md-3">
												<!--begin:: Widgets/Blog-->
												<div class="kt-portlet kt-portlet--height-fluid kt-widget19">
													<div class="kt-portlet__body kt-portlet__body--fit kt-portlet__body--unfill">
														<div class="kt-widget19__pic kt-portlet-fit--top kt-portlet-fit--sides" style="min-height: 200px; background-image: url(assets/media/printad/4.jpg)">
														</div>
													</div>
													<div class="kt-portlet__body bd-thin">
														<div class="kt-widget19__wrapper">
															<div class="kt-widget19__content">
																<div class="kt-widget19__info p-0">
																	<a href="printadd-detail.html" class="kt-widget19__username">
																		Loresem Ipsum
																	</a>
																	<span class="kt-widget19__time fsize-11">
																		05 April 2020
																	</span>
																</div>
															</div>
															<div class="kt-widget18__text">
																Lorem Ipsum is simply dummy text of the printing and typesetting..
															</div>
														</div>
														<div class="kt-widget19__action">
															<a href="printadd-detail.html" class="btn btn-sm btn-label-brand btn-bold">Lihat</a>
														</div>
													</div>
												</div>

												<!--end:: Widgets/Blog-->
											</div>

											<div class="col-md-3">
												<!--begin:: Widgets/Blog-->
												<div class="kt-portlet kt-portlet--height-fluid kt-widget19">
													<div class="kt-portlet__body kt-portlet__body--fit kt-portlet__body--unfill">
														<div class="kt-widget19__pic kt-portlet-fit--top kt-portlet-fit--sides" style="min-height: 200px; background-image: url(assets/media/printad/3.jpg)">
														</div>
													</div>
													<div class="kt-portlet__body bd-thin">
														<div class="kt-widget19__wrapper">
															<div class="kt-widget19__content">
																<div class="kt-widget19__info p-0">
																	<a href="printadd-detail.html" class="kt-widget19__username">
																		Loresem Ipsum
																	</a>
																	<span class="kt-widget19__time fsize-11">
																		12 April 2020
																	</span>
																</div>
															</div>
															<div class="kt-widget18__text">
																Lorem Ipsum is simply dummy text of the printing and typesetting..
															</div>
														</div>
														<div class="kt-widget19__action">
															<a href="printadd-detail.html" class="btn btn-sm btn-label-brand btn-bold">Lihat</a>
														</div>
													</div>
												</div>

												<!--end:: Widgets/Blog-->

											</div>

											<div class="col-md-3">
												<!--begin:: Widgets/Blog-->
												<div class="kt-portlet kt-portlet--height-fluid kt-widget19">
													<div class="kt-portlet__body kt-portlet__body--fit kt-portlet__body--unfill">
														<div class="kt-widget19__pic kt-portlet-fit--top kt-portlet-fit--sides" style="min-height: 200px; background-image: url(assets/media/printad/2.png)">
														</div>
													</div>
													<div class="kt-portlet__body bd-thin">
														<div class="kt-widget19__wrapper">
															<div class="kt-widget19__content">
																<div class="kt-widget19__info p-0">
																	<a href="printadd-detail.html" class="kt-widget19__username">
																		Loresem Ipsum
																	</a>
																	<span class="kt-widget19__time fsize-11">
																		05 April 2020
																	</span>
																</div>
															</div>
															<div class="kt-widget18__text">
																Lorem Ipsum is simply dummy text of the printing and typesetting..
															</div>
														</div>
														<div class="kt-widget19__action">
															<a href="printadd-detail.html" class="btn btn-sm btn-label-brand btn-bold">Lihat</a>
														</div>
													</div>
												</div>

												<!--end:: Widgets/Blog-->
											</div>
										</div>

										<div class="kt-pagination kt-pagination--sm kt-pagination--primary kt-mt-20">
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
													<option value="10">12</option>
													<option value="20">20</option>
													<option value="30">30</option>
													<option value="50">50</option>
													<option value="100">100</option>
												</select>
												<span class="pagination__desc">
													Displaying 12 of 230 records
												</span>
											</div>
										</div>
									</div>
									<div class="tab-pane" id="kt_portlet_base_demo_2_2_tab_content" role="tabpanel">
										<div class="row">
											<div class="col-lg-3">
												<div class="kt-portlet kt-portlet--bordered">
													<div class="kt-portlet__body">
														<div class="kt-iconbox__body">
															<div class="kt-iconbox__desc text-center">
																<a href="stock-photo.html">
																	<img src="assets/media/project-logos/3.png" width="100%" alt="Photo">
																	<h3 class="kt-iconbox__title mt-3">
																		CSR
																	</h3>
																</a>
															</div>
														</div>
													</div>
												</div>
											</div>
											<div class="col-lg-3">
												<div class="kt-portlet kt-portlet--bordered">
													<div class="kt-portlet__body">
														<div class="kt-iconbox__body">
															<div class="kt-iconbox__desc text-center">
																<a href="stock-photo.html">
																	<img src="assets/media/project-logos/2.png" width="100%" alt="Photo">
																	<h3 class="kt-iconbox__title mt-3">
																		Hulu Hilir
																	</h3>
																</a>
															</div>
														</div>
													</div>
												</div>
											</div>
											<div class="col-lg-3">
												<div class="kt-portlet kt-portlet--bordered">
													<div class="kt-portlet__body">
														<div class="kt-iconbox__body">
															<div class="kt-iconbox__desc text-center">
																<a href="stock-photo.html">
																	<img src="assets/media/project-logos/1.png" width="100%" alt="Photo">
																	<h3 class="kt-iconbox__title mt-3">
																		Produk dan Layanan
																	</h3>
																</a>
															</div>
														</div>
													</div>
												</div>
											</div>
											<div class="col-lg-3">
												<div class="kt-portlet kt-portlet--bordered">
													<div class="kt-portlet__body">
														<div class="kt-iconbox__body">
															<div class="kt-iconbox__desc text-center">
																<a href="stock-photo.html">
																	<img src="assets/media/project-logos/4.png" width="100%" alt="Photo">
																	<h3 class="kt-iconbox__title mt-3">
																		Kinerja
																	</h3>
																</a>
															</div>
														</div>
													</div>
												</div>
											</div>
										</div>
									</div>
									<div class="tab-pane" id="kt_portlet_base_demo_2_31_tab_content" role="tabpanel">

										<ul class="list-unstyled video-list-thumbs row">
											<li class="col-lg-3 col-sm-4 col-xs-6">
												<a href="#" title="Claudio Bravo, antes su debut con el Barça en la Liga">
													<img src="assets/media/gallery/background1.jpg" alt="Barca" class="img-responsive" width="100%" height="130px" />
													<h2>Lorem ipsum lorem ipsum lorem ipsum</h2>
													<span class="glyphicon glyphicon-play-circle"></span>
													<span class="duration">03:15</span>
												</a>
											</li>
											<li class="col-lg-3 col-sm-4 col-xs-6">
												<a href="#" title="Lorem ipsum lorem ipsum lorem ipsum">
													<img src="assets/media/gallery/background2.jpg" alt="Barca" class="img-responsive" width="100%"" height="130px" />
													<h2>Lorem ipsum lorem ipsum lorem ipsum</h2>
													<span class="glyphicon glyphicon-play-circle"></span>
													<span class="duration">03:15</span>
												</a>
											</li>
											<li class="col-lg-3 col-sm-4 col-xs-6">
												<a href="#" title="Lorem ipsum lorem ipsum lorem ipsum">
													<img src="assets/media/gallery/background3.jpg" alt="Barca" class="img-responsive" width="100%" height="130px" />
													<h2>Lorem ipsum lorem ipsum lorem ipsum</h2>
													<span class="glyphicon glyphicon-play-circle"></span>
													<span class="duration">03:15</span>
												</a>
											</li>
											<li class="col-lg-3 col-md-4 col-sm-4 col-xs-6">
												<a href="#" title="Lorem ipsum lorem ipsum lorem ipsum">
													<img src="assets/media/gallery/background4.jpg" alt="Barca" class="img-responsive" width="100%" height="130px" />
													<h2>Lorem ipsum lorem ipsum lorem ipsum</h2>
													<span class="glyphicon glyphicon-play-circle"></span>
													<span class="duration">03:15</span>
												</a>
											</li>
										</ul>

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
													<option value="10">12</option>
													<option value="20">20</option>
													<option value="30">30</option>
													<option value="50">50</option>
													<option value="100">100</option>
												</select>
												<span class="pagination__desc">
													Displaying 12 of 230 records
												</span>
											</div>
										</div>
									</div>
								</div>
							</div>
						</div>

					</div>

				</div>
				</div>
				<!-- end:: Content -->--%>
</asp:Content>
