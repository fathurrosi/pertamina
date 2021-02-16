<%@ Page Title="" Language="C#" MasterPageFile="~/Frontend.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="kalender.aspx.cs" Inherits="Pertamina.CORSEC._2019.CollateralCorporate.kalender" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">

    <!-- begin:: Content -->
    <div class="kt-content-height">
        <div class="kt-content kt-content--fit-top  kt-grid__item kt-grid__item--fluid kt-grid kt-grid--hor"
            id="kt_content">

            <!-- begin:: Content -->

            <!-- begin:: Hero -->

            <asp:Literal ID="lblHeader" runat="server"></asp:Literal>

            <div class="kt-container">
                <div class="kt-portlet">
                    <div class="kt-portlet__head">

                        <%-- <div class="kt-portlet__head-toolbar">
                            <ul class="nav nav-pills nav-fill" role="tablist">
                                <li class="nav-item">
                                    <a class="nav-link active" data-toggle="tab" href="#kt_portlet_base_demo_2_3_tab_content"
                                        role="tab" aria-selected="true">Kalendar
                                    </a>
                                </li>
                                <li class="nav-item">
                                    <a class="nav-link" data-toggle="tab" href="#kt_portlet_base_demo_2_2_tab_content" role="tab"
                                        aria-selected="false">Kalendar meja
                                    </a>
                                </li>
                            </ul>
                        </div>--%>
                        <asp:Literal ID="lblTab" runat="server"></asp:Literal>
                        <%-- <div class="kt-portlet__head-toolbar">
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
                        </div>--%>

                        <asp:Literal ID="lblFilter" runat="server"></asp:Literal>

                    </div>
                    <div class="kt-portlet__body">
                        <div class="tab-content">

                            <asp:Literal ID="lblTabImages" runat="server" Visible="true"></asp:Literal>
                           <%-- <div class="tab-pane active" id="kt_portlet_base_demo_1_2_tab_content" role="tabpanel">
                                <div class="row">
                                    <div class="col-md-8">
                                        <div id="SliderCarouselKalender">
                                            <div id="carouselExampleCaptions" class="carousel slide" data-ride="carousel">
                                                <div class="carousel-inner">
                                                    <div class="carousel-item active">
                                                        <img src="assets/media/kalender/1.jpg" class="center-block h-100" alt="...">
                                                        <div class="carousel-caption d-none d-md-block" id="black-light-caption">
                                                            <h5>First slide label <span class="pull-right download"><a href="#"><i
                                                                class="fa fa-download"></i></a></span></h5>
                                                            <p>Nulla vitae elit libero, a pharetra augue mollis interdum.</p>
                                                        </div>
                                                    </div>
                                                    <div class="carousel-item">
                                                        <img src="assets/media/kalender/4.jpg" class="center-block h-100" alt="...">
                                                        <div class="carousel-caption d-none d-md-block" id="black-light-caption">
                                                            <h5>Second slide label <span class="pull-right download"><a href="#"><i
                                                                class="fa fa-download"></i></a></span></h5>
                                                            <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit.</p>
                                                        </div>
                                                    </div>
                                                    <div class="carousel-item">
                                                        <img src="assets/media/kalender/3.jpg" class="center-block h-100" alt="...">
                                                        <div class="carousel-caption d-none d-md-block" id="black-light-caption">
                                                            <h5>Third slide label <span class="pull-right download"><a href="#"><i
                                                                class="fa fa-download"></i></a></span></h5>
                                                            <p>Praesent commodo cursus magna, vel scelerisque nisl consectetur.</p>
                                                        </div>
                                                    </div>
                                                    <div class="carousel-item">
                                                        <img src="assets/media/products/product2.jpg" class="d-block w-100" alt="...">
                                                        <div class="carousel-caption d-none d-md-block" id="black-light-caption">
                                                            <h5>Second slide label <span class="pull-right download"><a href="#"><i class="fa fa-download"></i></a></span>
                                                            </h5>
                                                            <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit.</p>
                                                        </div>
                                                    </div>
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
                                    <div class="col-md-4">
                                        <div class="kt-widget4">
                                            <div class="kt-widget4__item p-2">
                                                <a href="#" class="kt-widget4__title kt-widget4__title--light">Kalender tahun 2020
                                                </a>
                                                <span class="kt-widget3__number kt-font-info">
                                                    <a href="#" class="btn-label-brand btn btn-sm btn-bold">Lihat</a>
                                                </span>
                                            </div>
                                            <div class="kt-widget4__item p-2 bg-secondary">
                                                <a href="#" class="kt-widget4__title kt-widget4__title--light">Kalender tahun 2019
                                                </a>
                                                <span class="kt-widget3__number kt-font-info">
                                                    <a href="#" class="btn-label-brand btn btn-sm btn-bold">Lihat</a>
                                                </span>
                                            </div>
                                            <div class="kt-widget4__item p-2">
                                                <a href="#" class="kt-widget4__title kt-widget4__title--light">Kalender tahun 2018
                                                </a>
                                                <span class="kt-widget3__number kt-font-info">
                                                    <a href="#" class="btn-label-brand btn btn-sm btn-bold">Lihat</a>
                                                </span>
                                            </div>
                                            <div class="kt-widget4__item p-2 bg-secondary">
                                                <a href="#" class="kt-widget4__title kt-widget4__title--light">Kalender tahun 2017
                                                </a>
                                                <span class="kt-widget3__number kt-font-info">
                                                    <a href="#" class="btn-label-brand btn btn-sm btn-bold">Lihat</a>
                                                </span>
                                            </div>
                                            <div class="kt-widget4__item p-2">
                                                <a href="#" class="kt-widget4__title kt-widget4__title--light">Kalender tahun 2016
                                                </a>
                                                <span class="kt-widget3__number kt-font-info">
                                                    <a href="#" class="btn-label-brand btn btn-sm btn-bold">Lihat</a>
                                                </span>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="tab-pane" id="kt_portlet_base_demo_2_1_tab_content" role="tabpanel">
                                <div class="row">
                                    <div class="col-md-8">
                                        <div id="SliderCarouselKalender">
                                            <div id="myCarousel" class="carousel slide" data-ride="carousel">
                                                <div class="carousel-inner">
                                                    <div class="carousel-item active">
                                                        <img src="assets/media/kalender/6.jpg" class="center-block h-100" alt="...">
                                                        <div class="carousel-caption d-none d-md-block" id="black-light-caption">
                                                            <h5>First slide label <span class="pull-right download"><a href="#"><i class="fa fa-download"></i></a></span></h5>
                                                            <p>Nulla vitae elit libero, a pharetra augue mollis interdum.</p>
                                                        </div>
                                                    </div>
                                                    <div class="carousel-item">
                                                        <img src="assets/media/kalender/7.jpg" class="center-block h-100" alt="...">
                                                        <div class="carousel-caption d-none d-md-block" id="black-light-caption">
                                                            <h5>Second slide label <span class="pull-right download"><a href="#"><i class="fa fa-download"></i></a></span>
                                                            </h5>
                                                            <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit.</p>
                                                        </div>
                                                    </div>
                                                    <div class="carousel-item">
                                                        <img src="assets/media/kalender/8.jpg" class="center-block h-100" alt="...">
                                                        <div class="carousel-caption d-none d-md-block" id="black-light-caption">
                                                            <h5>Third slide label <span class="pull-right download"><a href="#"><i class="fa fa-download"></i></a></span></h5>
                                                            <p>Praesent commodo cursus magna, vel scelerisque nisl consectetur.</p>
                                                        </div>
                                                    </div>
                                                </div>
                                                <a class="carousel-control-prev" href="#myCarousel" role="button" data-slide="prev">
                                                    <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                                                    <span class="sr-only">Previous</span>
                                                </a>
                                                <a class="carousel-control-next" href="#myCarousel" role="button" data-slide="next">
                                                    <span class="carousel-control-next-icon" aria-hidden="true"></span>
                                                    <span class="sr-only">Next</span>
                                                </a>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="col-md-4">
                                        <div class="kt-widget4">
                                            <div class="kt-widget4__item p-2">
                                                <a href="#" class="kt-widget4__title kt-widget4__title--light">Kalender tahun 2020
                                                </a>
                                                <span class="kt-widget3__number kt-font-info">
                                                    <a href="#" class="btn-label-brand btn btn-sm btn-bold">Lihat</a>
                                                </span>
                                            </div>
                                            <div class="kt-widget4__item p-2 bg-secondary">
                                                <a href="#" class="kt-widget4__title kt-widget4__title--light">Kalender tahun 2019
                                                </a>
                                                <span class="kt-widget3__number kt-font-info">
                                                    <a href="#" class="btn-label-brand btn btn-sm btn-bold">Lihat</a>
                                                </span>
                                            </div>
                                            <div class="kt-widget4__item p-2">
                                                <a href="#" class="kt-widget4__title kt-widget4__title--light">Kalender tahun 2018
                                                </a>
                                                <span class="kt-widget3__number kt-font-info">
                                                    <a href="#" class="btn-label-brand btn btn-sm btn-bold">Lihat</a>
                                                </span>
                                            </div>
                                            <div class="kt-widget4__item p-2 bg-secondary">
                                                <a href="#" class="kt-widget4__title kt-widget4__title--light">Kalender tahun 2017
                                                </a>
                                                <span class="kt-widget3__number kt-font-info">
                                                    <a href="#" class="btn-label-brand btn btn-sm btn-bold">Lihat</a>
                                                </span>
                                            </div>
                                            <div class="kt-widget4__item p-2">
                                                <a href="#" class="kt-widget4__title kt-widget4__title--light">Kalender tahun 2016
                                                </a>
                                                <span class="kt-widget3__number kt-font-info">
                                                    <a href="#" class="btn-label-brand btn btn-sm btn-bold">Lihat</a>
                                                </span>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>--%>
                        </div>
                    </div>
                </div>
                <a href="collateral-corporate.aspx?p=&m=6" class="btn btn-secondary mt-4"><i class="fa fa-less-than"></i>Back</a>
            </div>

            <!-- end:: Content -->
        </div>
    </div>
    <!-- end:: Content -->
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="script" runat="server">
</asp:Content>
