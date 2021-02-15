<%@ Page Title="" Language="C#" MasterPageFile="~/Frontend.Master" AutoEventWireup="true"  EnableEventValidation="false"  CodeBehind="kartu.aspx.cs" Inherits="Pertamina.CORSEC._2019.CollateralCorporate.kartu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <asp:HiddenField ID="hdnMaxYear" runat="server" />
    <asp:HiddenField ID="hdnMinYear" runat="server" />
    <!-- begin:: Content -->
    <!-- begin:: Hero -->
    <asp:Literal ID="lblHeader" runat="server"></asp:Literal>
    <!-- begin:: Content -->

    <div class="kt-container">
        <div class="kt-portlet">

            <asp:Literal ID="lblFilter" runat="server"></asp:Literal>

            <div class="kt-portlet__body">

                <div class="row">
                    <div class="col-md-8">
                        <div id="SliderCarouselKalender">
                            <div id="carouselExampleCaptions" class="carousel slide" data-ride="carousel">
                                <div class="carousel-inner">
                                    <%--<div class="carousel-item active">
                                        <img src="<%: ResolveUrl("~/Content/assets/media/kalender/1.jpg") %>" class="center-block h-100" alt="...">
                                        <div class="carousel-caption d-none d-md-block" id="black-light-caption">
                                            <h5>First slide label <span class="pull-right download"><a href="#"><i
                                                class="fa fa-download"></i></a></span></h5>
                                            <p>Nulla vitae elit libero, a pharetra augue mollis interdum.</p>
                                        </div>
                                    </div>
                                    <div class="carousel-item">
                                        <img src="<%: ResolveUrl("~/Content/assets/media/kalender/4.jpg") %>" class="center-block h-100" alt="...">
                                        <div class="carousel-caption d-none d-md-block" id="black-light-caption">
                                            <h5>Second slide label <span class="pull-right download"><a href="#"><i
                                                class="fa fa-download"></i></a></span></h5>
                                            <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit.</p>
                                        </div>
                                    </div>
                                    <div class="carousel-item">
                                        <img src="<%: ResolveUrl("~/Content/assets/media/products/product3.jpg") %>" class="center-block h-100" alt="...">
                                        <div class="carousel-caption d-none d-md-block" id="black-light-caption">
                                            <h5>Third slide label <span class="pull-right download"><a href="#"><i
                                                class="fa fa-download"></i></a></span></h5>
                                            <p>Praesent commodo cursus magna, vel scelerisque nisl consectetur.</p>
                                        </div>
                                    </div>--%>

                                    <asp:Literal ID="lblImages" runat="server" Visible="true"></asp:Literal>
                                </div>


                                <a class="carousel-control-prev" href="#carouselExampleCaptions" role="button" data-slide="prev">
                                    <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                                    <span class="sr-only">Previous</span>
                                </a>
                                <a class="carousel-control-next" href="#carouselExampleCaptions" role="button" data-slide="next">
                                    <span class="carousel-control-next-icon" aria-hidden="true"></span>
                                    <span class="sr-only">Next</span>
                                </a>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-4">
                        <div class="kt-widget4">
                            <asp:Literal ID="lblTahun" runat="server"></asp:Literal>


                            <%--   <div class="kt-widget4__item p-2">
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
                            </div>--%>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <%--<a href="collateral-corporate.html" class="btn btn-secondary mt-4"><i class="fa fa-less-than"></i>
            Back</a>--%>

        <a href="collateral-corporate.aspx?p=&m=6" class="btn btn-secondary mt-4"><i class="fa fa-less-than"></i>Back</a>
    </div>

    <!-- end:: Content -->
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="script" runat="server">
</asp:Content>
