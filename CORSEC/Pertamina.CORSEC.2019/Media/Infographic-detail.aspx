<%@ Page Title="" Language="C#" MasterPageFile="~/Frontend.Master" AutoEventWireup="true" CodeBehind="Infographic-detail.aspx.cs" Inherits="Pertamina.CORSEC._2019.Media.Infographic_detail" EnableEventValidation="false" %>

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
                  <h3 class="kt-sc__heading kt-heading kt-heading--center kt-heading--xxl kt-heading--medium">
                    Lorem ipsum dolor sit amet
                  </h3>
                </div>
              </div>
            </div>--%>

            <asp:Literal ID="lblHeader" runat="server"></asp:Literal>

            <div class="kt-container">
                <div class="kt-portlet">
                    <div class="kt-portlet__head">
                        <div class="kt-portlet__head">
                            <div class="kt-portlet__head-label">
                                <h3><asp:Label ID="lblTitle" runat="server" Text="Label"></asp:Label></h3>
                            </div>
                        </div>

                        <%--<div class="kt-portlet__head-toolbar">
                        </div>--%>

                        <%--                  <div class="kt-portlet__head-toolbar">
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
                    </div>
                    <div class="kt-portlet__body">
                        <div id="SliderCarouselKalender">
                            <div id="carouselExampleCaptions" class="carousel slide" data-ride="carousel">
                                <div class="carousel-inner">
                                    <asp:Literal runat="server" ID="lblImages"></asp:Literal>
                                    <%--<div class="carousel-item active">
                                        <img src="assets/media/infografis/1.jpg" class="center-block h-100" alt="...">
                                        <div class="carousel-caption d-none d-md-block" id="black-light-caption">
                                            <h5>First slide label <span class="pull-right download"><a href="#"><i class="fa fa-download"></i></a></span></h5>
                                            <p>Nulla vitae elit libero, a pharetra augue mollis interdum.</p>
                                        </div>
                                    </div>
                                    <div class="carousel-item">
                                        <img src="assets/media/infografis/2.jpg" class="center-block h-100" alt="...">
                                        <div class="carousel-caption d-none d-md-block" id="black-light-caption">
                                            <h5>Second slide label <span class="pull-right download"><a href="#"><i class="fa fa-download"></i></a></span></h5>
                                            <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit.</p>
                                        </div>
                                    </div>
                                    <div class="carousel-item">
                                        <img src="assets/media/infografis/1.jpg" class="center-block h-100" alt="...">
                                        <div class="carousel-caption d-none d-md-block" id="black-light-caption">
                                            <h5>Third slide label <span class="pull-right download"><a href="#"><i class="fa fa-download"></i></a></span></h5>
                                            <p>Praesent commodo cursus magna, vel scelerisque nisl consectetur.</p>
                                        </div>
                                    </div>
                                    <div class="carousel-item">
                                        <img src="assets/media/infografis/3.jpg" class="d-block w-100" alt="...">
                                        <div class="carousel-caption d-none d-md-block" id="black-light-caption">
                                            <h5>Second slide label <span class="pull-right download"><a href="#"><i class="fa fa-download"></i></a></span>
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
                </div>
                <a href="Infographic.aspx" id="aBack" runat="server" class="btn btn-secondary mt-4"><i class="fa fa-less-than"></i>
                    Back</a>
            </div>

            <!-- end:: Content -->
        </div>
    </div>
    <!-- end:: Content -->

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="script" runat="server">
</asp:Content>
