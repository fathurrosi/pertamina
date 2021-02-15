<%@ Page Title="Pertamina Intranet - List Events" Language="C#" MasterPageFile="~/CORSEC.Master" AutoEventWireup="true" CodeBehind="EventsList.aspx.cs" Inherits="Pertamina.CORSEC._2019.Events.EventsList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <!-- end:: Header -->
	<div class="kt-grid__item kt-grid__item--fluid kt-grid kt-grid--hor" id="kt_content">

		<!-- begin:: Content Head -->
		<div class="kt-subheader  kt-grid__item" id="kt_subheader">
			<div class="kt-container  kt-container--fluid ">
				<div class="kt-subheader__main">
					<h3 class="kt-subheader__title">More Upcoming Events</h3>
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

    <div class="kt-sc" style="background-image: url('/Media/images/background/bg-01.jpg'); min-height: 240px; padding-top: 5%;">
         <h3 class="kt-sc__heading kt-heading kt-heading--center kt-heading--xxl kt-heading--medium">
            <font style="vertical-align: inherit; color: white; text-align: center; vertical-align: middle;"><b>More Events</b></font>
        </h3>
    </div>

    <div class="kt-container  kt-container--fluid  kt-grid__item kt-grid__item--fluid" style="margin-top: 20px; margin-bottom: 20px;">
        <div class="card">
            <div class="card-body">
                <div class="row">
                    <div class="col-md-12">
                        <div class="form-group">
                            <label>Filter By Category</label><br />
                            <div class="form-check form-check-inline">
                                <asp:CheckBox id="checkboxTalkShow" runat="server" class="form-check-input"
                                    AutoPostBack="True"
                                    Text="Talkshow"
                                    OnCheckedChanged="Check_Clicked"/>
                            </div>
                            <div class="form-check form-check-inline">
                               <asp:CheckBox id="checkboxPeresmian" runat="server" class="form-check-input"
                                    AutoPostBack="True"
                                    Text="Peresmian"
                                    OnCheckedChanged="Check_Clicked"/>
                            </div>
                            <div class="form-check form-check-inline">
                               <asp:CheckBox id="checkboxSeremoni" runat="server" class="form-check-input"
                                    AutoPostBack="True"
                                    Text="Seremoni"
                                    OnCheckedChanged="Check_Clicked"/>
                            </div>
                            <div class="form-check form-check-inline">
                                <asp:CheckBox id="checkboxEventTahunan" runat="server" class="form-check-input"
                                    AutoPostBack="True"
                                    Text="Event Tahunan"
                                    OnCheckedChanged="Check_Clicked"/>
                            </div>
                            <div class="form-check form-check-inline">
                                <asp:CheckBox id="checkboxPameran" runat="server" class="form-check-input"
                                    AutoPostBack="True"
                                    Text="Pameran"
                                    OnCheckedChanged="Check_Clicked"/>
                            </div>
                            <div class="form-check form-check-inline">
                                <asp:CheckBox id="checkboxBranchmarking" runat="server" class="form-check-input"
                                    AutoPostBack="True"
                                    Text="Branchmarking"
                                    OnCheckedChanged="Check_Clicked"/>
                            </div>
                            <div class="form-check form-check-inline">
                                <asp:CheckBox id="checkboxMWTVirtual" runat="server" class="form-check-input"
                                    AutoPostBack="True"
                                    Text="MWT Virtual"
                                    OnCheckedChanged="Check_Clicked"/>
                            </div>
                        </div>
                    </div>
                </div>

                <% if (Resp_.Count > 0 && !onLoad)
                    { %>
                        <div class="row" style="margin-top: 20px;">
                        <% Resp_.ForEach(item =>
                            { %>
                            <div class="col-md-4">
                                <a href="/EventDetail/<%= item.RequestNumber %>">
                                    <div class="card" style="width: 100%">
                                        <object data="<%= item.LinkBanner %>" type="image/png" style="width: 100%; ">
                                            <img src="/Media/images/img-broken.png" class="card-img-top" style="width: 100%; " alt="Event Poster" />  
                                        </object>
                                        <div class="card-body" style="text-align: center; background-color: #f5e8e6;">
                                            <h5 class="card-title" style="color: black;"><b><%= item.NamaEvent %></b></h5>
                                            <p class="card-text">
                                                <span><%= item.TanggalPelaksanaanDari %></span>
                                            </p>
                                        </div>
                                    </div>
                                </a>
                            </div>
                            <% }); %>
                        </div>
                 <% }
                    else
                    {%>
                        <div class="container card" style="margin-top: 5%;">
                            <div class="col-xl-8 mx-lg-auto">
                                <div class="pt-5  text-center">
                                    <i class="icon icon-calendar-times-o" style="color: red; font-size: 80pt; margin-bottom: 5%;"></i>
                                    <h1 class="text-primary">oops!</h1>
                                    <p class="section-subtitle">No Upcoming Event <br />Please Come Back Later!</p>
                                    <b style="font-size: 50pt;">404</b>
                                </div>
                            </div>
                        </div>
                <%  } %>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="script" runat="server">
</asp:Content>
