<%@ Page Title="Pertamina Intranet - Events" Language="C#" MasterPageFile="~/CORSEC.Master" AutoEventWireup="true" CodeBehind="EventsIndex.aspx.cs" Inherits="Pertamina.CORSEC._2019.Events.EventsIndex" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <!-- end:: Header -->
	<div class="kt-grid__item kt-grid__item--fluid kt-grid kt-grid--hor" id="kt_content">

		<!-- begin:: Content Head -->
		<div class="kt-subheader  kt-grid__item" id="kt_subheader">
			<div class="kt-container  kt-container--fluid ">
				<div class="kt-subheader__main">
					<h3 class="kt-subheader__title">Upcoming Events</h3>
					<span class="kt-subheader__separator kt-subheader__separator--v"></span>
					<a href="#" class="btn btn-label-success btn-bold btn-sm btn-icon-h kt-margin-l-10">
						<i class="fa fa-plus"></i>Tambah Data
					</a>
					<div class="kt-input-icon kt-input-icon--right kt-subheader__search kt-hidden">
						<input type="text" class="form-control" placeholder="Search order..."
							id="generalSearch">
						<span class="kt-input-icon__icon kt-input-icon__icon--right">
							<span><i class="flaticon2-search-1"></i></span>
						</span>
					</div>
				</div>
				<div class="kt-subheader__toolbar">
					<div class="kt-subheader__wrapper">
						<a href="#" class="btn kt-subheader__btn-daterange"
							id="kt_dashboard_daterangepicker" data-toggle="kt-tooltip"
							title="Select dashboard daterange" data-placement="left">
							<span class="kt-subheader__btn-daterange-title"
								id="kt_dashboard_daterangepicker_title">Today</span>&nbsp;
							<span class="kt-subheader__btn-daterange-date"
								id="kt_dashboard_daterangepicker_date">Aug 16</span>
							<i class="flaticon2-calendar-1"></i>
						</a>
					</div>
				</div>
			</div>
		</div>
	</div>

	<!-- end:: Content Head -->

    <div >
        <% if (Resp_.Count == 0 && Resp_Sub.Count == 0)
            {  %>
            <div class="container card" style="margin-top: 5%;">
                <div class="col-xl-8 mx-lg-auto">
                    <div class="pt-5  text-center">
                        <i class="icon icon-calendar-times-o" style="color: red; font-size: 140pt; margin-bottom: 5%;"></i>
                        <h1 class="text-primary">oops!</h1>
                        <p class="section-subtitle">No Upcoming Event <br />Please Come Back Later!</p>
                        <b style="font-size: 80pt;">404</b>
                    </div>
                </div>
            </div>
        <% } %>


        <% if (Resp_.Count > 0 )
            {  %>
            <div class="kt-sc" >
                <section class="relative xv-slide" data-bg-possition="left" data-bg-repeat="false">
                    <div class="has-bottom-gradient">
                        <div id="carouselExampleIndicators" class="carousel slide" data-ride="carousel">
                            <div class="carousel-inner" role="listbox" id="carousel-inner">
                                <% Resp_.ForEach(item => { %>
                                    <% if (counter == 0) {  %>
                                        <% counter++;  %>
                                        <div class="item active">
                                            <div class="carousel-item active">
                                                <object data="<%= item.LinkBanner %>" type="image/png" style="width: 100%; max-height: 550px; ">
                                                    <img src="/Media/images/img-broken.png" style="width: 100%; " />  
                                                </object>
                                                
                                                <div class="carousel-caption" style="background-color: #89898985">
                                                    <h2 class="display-4 text-white"><%= item.NamaEvent %></h2>
                                                    <p class="lead">
                                                        <ul class="align-baseline list-inline">
                                                            <li class="list-inline-item">
                                                                <i class="icon-map-location text-white mr-2"></i>
                                                                <%= item.LokasiEvent %>
                                                            </li>
                                                            <li class="list-inline-item">
                                                                <i class="icon-calendar text-white mr-2"></i>
                                                                <%= item.TanggalPelaksanaanDari %>
                                                            </li>
                                                            <li class="list-inline-item">
                                                                <i class="icon-clock text-white mr-2"></i>
                                                                <%= item.WaktuPelaksanaanDari %> 
                                                            </li>
                                                        </ul>
                                                        <a href="/event/<%= item.RequestNumber %>" class="btn btn-primary btn-lg" >DETAIL</a>
                                                    </p>
                                                </div>
                                            </div>

                                        </div>
                                        <% } else { %>
                                            <div class="item">
                                                <div class="carousel-item active" align="center">
                                                    <object data="<%= item.LinkBanner %>" type="image/png" style="width: 100%;  ">
                                                        <img  src="/Media/images/img-broken.png" style="width: 80%;  max-height: 550px;" />  
                                                    </object> 
                                                    <div class="carousel-caption" style="background-color: #89898985">
                                                        <h2 class="display-4 text-white"><%= item.NamaEvent %></h2>
                                                        <p class="lead">
                                                            <ul class="align-baseline list-inline">
                                                                <li class="list-inline-item">
                                                                    <i class="icon-map-location text-white mr-2"></i>
                                                                    <%= item.LokasiEvent %>
                                                                </li>
                                                                <li class="list-inline-item">
                                                                    <i class="icon-calendar text-white mr-2"></i>
                                                                    <%= item.TanggalPelaksanaanDari %>
                                                                </li>
                                                                <li class="list-inline-item">
                                                                    <i class="icon-clock text-white mr-2"></i>
                                                                    <%= item.WaktuPelaksanaanDari %> 
                                                                </li>
                                                            </ul>
                                                            <a href="/event/<%= item.RequestNumber %>" class="btn btn-primary btn-lg" >DETAIL</a>
                                                        </p>
                                                    </div>
                                                </div>
                                            </div>
                                            <% } %>
                                <% }); %>
                            </div>
                            <a class="carousel-control-prev" href="#carouselExampleIndicators" role="button" data-slide="prev">
                                <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                                <span class="sr-only">Previous </span>
                            </a>
                            <a class="carousel-control-next" href="#carouselExampleIndicators" role="button" data-slide="next">
                                <span class="carousel-control-next-icon" aria-hidden="true"></span>
                                <span class="sr-only">Next</span>
                            </a>
                        </div>
                    </div>
                </section>
            </div>
        <% } %>
        <% if (Resp_Sub.Count > 0 )
           {  %>
            <div class="kt-container card" style="margin-top: 10%;">
        
            <section class="section" >
                
                <div class="d-flex relative align-items-center justify-content-between" style="margin-top: 10px;">
                    <div class="mb-4">
                        
                    </div>
                    <a href="/eventlist">More Upcoming Events<i class="icon-angle-right ml-3"></i></a>
                </div>
                <div class="lSSlideOuter "><div class="lSSlideWrapper usingCss" style="transition-duration: 400ms; transition-timing-function: ease;">
                    <div class="lightSlider has-items-overlay showSlider lSSlide lsGrab" data-item="3" data-item-lg="2" data-item-md="1" data-item-sm="1" data-auto="false" data-pager="false" data-controls="true" data-loop="false" style="width: 2255.33px; height: 246.8px; padding-bottom: 0%; transform: translate3d(0px, 0px, 0px);">
                        <% Resp_Sub.ForEach(item => { %>
                            <% if (counterSub == 0) {  %>
                                <% counterSub++;  %>
                                <div class="card lslide active">
                                    <figure class="card-img figure">
                                        <div class="img-wrapper">
                                            <object data="<%= item.LinkBanner %>" type="image/png" style="width: 100%;  ">
                                                <img src="/Media/images/img-broken.png" style="width: 100%;  " />  
                                            </object>
                                        </div>
                                        <div class="img-overlay"></div>
                                        <div class="has-bottom-gradient">
                                            <div class="d-flex">
                                                <div class="card-img-overlay">
                                                    <div class="pt-3 pb-3">
                                                        <a href="/event/<%= item.RequestNumber %>">
                                                        
                                                            <div>
                                                                <h5><%= item.NamaEvent %></h5>
                                                        
                                                            </div>
                                                        </a>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </figure>
                                    <div class="bottom-gradient bottom-gradient-thumbnail"></div>
                                </div>
                                <% } else { %>
                                <div class="card lslide" style="margin-left: 10px;">
                                    <figure class="card-img figure">
                                        <div class="img-wrapper">
                                            <object data="<%= item.LinkBanner %>" type="image/png" style="width: 100%; max-height: 550px; ">
                                                <img src="/Media/images/img-broken.png" style="width: 100%;  max-height: 550px;" />  
                                            </object>
                                        </div>
                                        <div class="img-overlay"></div>
                                        <div class="has-bottom-gradient">
                                            <div class="d-flex">
                                                <div class="card-img-overlay">
                                                    <div class="pt-3 pb-3">
                                                        <a href="/event/<%= item.RequestNumber %>">
                                                        
                                                            <div>
                                                                <h5><%= item.NamaEvent %></h5>
                                                        
                                                            </div>
                                                        </a>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </figure>
                                    <div class="bottom-gradient bottom-gradient-thumbnail"></div>
                                </div>
                                <% } %>
                    <% }); %>
                </div>
                <div class="lSAction"><a class="lSPrev"><span class="icon icon-angle-left"></span></a><a class="lSNext"><span class="icon icon-angle-right"></span></a></div></div></div>
            </section>
        </div>
        <% } %>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="script" runat="server">
</asp:Content>
