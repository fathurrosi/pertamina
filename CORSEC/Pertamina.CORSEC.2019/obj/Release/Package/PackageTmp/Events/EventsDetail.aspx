<%@ Page Title="Pertamina Intranet - Event Detail" Language="C#" MasterPageFile="~/CORSEC.Master" AutoEventWireup="true" CodeBehind="EventsDetail.aspx.cs" Inherits="Pertamina.CORSEC._2019.Events.EventsDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">

    <!-- end:: Header -->
	<div class="kt-grid__item kt-grid__item--fluid kt-grid kt-grid--hor" id="kt_content">

		<!-- begin:: Content Head -->
		<div class="kt-subheader  kt-grid__item" id="kt_subheader">
			<div class="kt-container  kt-container--fluid ">
				<div class="kt-subheader__main">
					<h3 class="kt-subheader__title">Detail Event</h3>
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

    <div style="margin-top: -6%;">
        
        <div align="center" style="width: 100%; margin-bottom: 20px">
            <object data="<%= Resp_.LinkBanner %>" type="image/png" style="width: 100%; max-height: 550px; ">
                <img src="/Media/images/img-broken.png" style="width: 100%; " alt="poster event" />  
            </object>
        </div>
        <div class="kt-container  kt-container--fluid  kt-grid__item kt-grid__item--fluid">

            <div class="row">
                <aside class="col-md-4">
                    <div class="card mb-3">
                        <div class="card-header transparent b-b">
                            <strong>Detail</strong>
                        </div>
                        <ul class="playlist list-group list-group-flush">
                            <li class="list-group-item">
                                <div class="d-flex align-items-center">
                                    <div>
                                        <a class="no-ajaxy media-url" href="javascript:void(0)" >
                                            <i class="icon-menu-1 mr-1 "></i>
                                        </a>
                                    </div>
                                    <div class="col-10">
                                        <small><%= Resp_.KategoriEvent %></small>
                                    </div>
                                </div>
                            </li>
                            <li class="list-group-item">
                                <div class="d-flex align-items-center">
                                    <div>
                                        <a class="no-ajaxy media-url" href="javascript:void(0)" >
                                            <i class="icon-placeholder-3 mr-1 "></i>
                                        </a>
                                    </div>
                                    <div class="col-10">
                                        <small><%= Resp_.LokasiEvent %></small>
                                    </div>
                                </div>
                            </li>
                            <li class="list-group-item">
                                <div class="d-flex align-items-center">
                                    <div>
                                        <a class="no-ajaxy media-url" href="javascript:void(0)" >
                                            <i class="icon-calendar text-primary mr-2"></i>
                                        </a>
                                    </div>
                                    <div class="col-10">
                                        <small><%= Resp_.TanggalPelaksanaanDari %> until <%= Resp_.TanggalPelaksanaanSampai %></small>
                                    </div>
                                </div>
                            </li>
                            <li class="list-group-item">
                                <div class="d-flex align-items-center">
                                    <div>
                                        <a class="no-ajaxy media-url" href="javascript:void(0)" >
                                            <i class="icon-alarm-clock mr-1"></i>
                                        </a>
                                    </div>
                                    <div class="col-10">
                                        <small><%= Resp_.WaktuPelaksanaanDari %> </small>
                                    </div>
                                </div>
                            </li>
                        </ul>
                    </div>
                    <div class="card mb-3">
                        <div class="card-header transparent b-b">
                            <strong>Posted By</strong>
                        </div>
                        <ul class="playlist list-group list-group-flush">
                                    
                                <li class="list-group-item" >
                                    <div class="d-flex align-items-center">
                                        <div class="col-10">
                                            <h6><%= Resp_.NamaRequester %></h6>
                                        </div>
                                    </div>
                                </li>

                                    
                        </ul>
                    </div>           
                </aside>
                <div class="col-md-8">
                    <div class="card mb-3">
                        <div class="card-header transparent b-b">
                            <strong><%= Resp_.NamaEvent %></strong>
                        </div>
                        <div class="card-body has-items-overlay playlist p-5">
                            <p>
                                <%= Resp_.DeskripsiEvent %>
                            </p>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12">
                            <div class="card mb-3" >
                                <div class="card-header transparent b-b">
                                    <strong>Counting Down <%= countingDown %></strong>
                                </div>
                                <div class="countDown text-white" data-date="<%= countingDown %>"   style="margin-left: 20%; margin-top: 2%;">
                                    <div class="bg-primary"><span class="weeks">0</span> <span class="count-type">Weeks</span>
                                </div>
                                <div class="bg-primary">
                                    <span class="days" id="day">317</span> 
                                    <span class="count-type">Days</span>
                                </div>
                                <div class="bg-primary">
                                    <span class="hours" id="hour">04</span> 
                                    <span class="count-type">Hours</span>
                                </div>
                                <div class="bg-primary"><span class="minutes">57</span> <span class="count-type">Minutes</span></div>
                                    <div class="bg-primary"><span class="seconds">11</span> <span class="count-type">Seconds</span></div>
                                </div>
                            </div>                
                        </div>
                                
                            <div class="col-md-12">
                                <div class="card mb-3">
                                
                                    <ul class="list-group no-b">
                                        <li class="list-group-item my-1">
                                            <div class="row">
                                                <div class="col-md-2 ">
                                                    <div class="text-lg-center">
                                                        <div class="s-24">Open</div>
                                                        <span>Register <small>Now</small></span>
                                                    </div>
                                                </div>
                                                <div class=" col-lg-3 ml-auto my-3 text-lg-right">
                                                    <a href="<%= Resp_.LinkEvent %>"" target="_BLANK" class="btn btn-outline-primary btn-sm">Register Now</a>
                                                           
                                                </div>
                                            </div>
                                        </li>
                                    </ul>
                                </div>
                            </div>
                               
                    </div>
                </div>
                <div class="col-md-12">
                    <div class="card mb-3">
                        <iframe src="http://maps.google.com/maps?q=<%= Resp_.LokasiEvent %>&amp;t=&amp;z=13&amp;ie=UTF8&amp;iwloc=&amp;output=embed"  height="450" frameborder="0" style="border:0;" allowfullscreen=""></iframe>
                    </div>
                </div>
            </div>
            


        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="script" runat="server">
</asp:Content>
