<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="str.aspx.cs" Inherits="Pertamina.CORSEC._2019.Organisasi.str" %>

<!DOCTYPE html>

<html lang="en">

<!-- begin::Head -->

<head>
	<base href="">
	<meta charset="utf-8" />
	<title>Pertamina Intranet</title>
	<meta name="description" content="Aside light skin example">
	<meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">


     <!--begin::Fonts -->
    <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Poppins:300,400,500,600,700|Roboto:300,400,500,600,700" />

    <!--end::Fonts -->
    <!--begin::Page Vendors Styles(used by this page) -->
    <link href="<%: ResolveUrl("~/Content/assets/plugins/custom/fullcalendar/fullcalendar.bundle.css") %>" rel="stylesheet" type="text/css" />
    <link href="<%: ResolveUrl("~/Content/assets/css/pages/support-center/home-1.css") %>" rel="stylesheet" type="text/css" />
    <link href="<%: ResolveUrl("~/Content/assets/css/custom.css") %>" rel="stylesheet" type="text/css" />


    <!--end::Page Vendors Styles -->
    <!--begin::Global Theme Styles(used by all pages) -->
    <link href="<%: ResolveUrl("~/Content/assets/plugins/global/plugins.bundle.css") %>" rel="stylesheet" type="text/css" />
    <link href="<%: ResolveUrl("~/Content/assets/css/style.bundle.css") %>" rel="stylesheet" type="text/css" />

    <!--end::Global Theme Styles -->
    <!--begin::Layout Skins(used by all pages) -->
    <link href="<%: ResolveUrl("~/Content/assets/css/skins/header/base/light.css") %>" rel="stylesheet" type="text/css" />
    <link href="<%: ResolveUrl("~/Content/assets/css/skins/header/menu/light.css") %>" rel="stylesheet" type="text/css" />
    <link href="<%: ResolveUrl("~/Content/assets/css/skins/brand/light.css") %>" rel="stylesheet" type="text/css" />
    <link href="<%: ResolveUrl("~/Content/assets/css/skins/aside/light.css") %>" rel="stylesheet" type="text/css" />

    <!--end::Layout Skins -->
    <link rel="shortcut icon" href="<%: ResolveUrl("~/Content/assets/media/logos/favicon.ico") %>" />

</head>

<!-- end::Head -->

<!-- begin::Body -->

<body
	class="kt-quick-panel--right kt-demo-panel--right kt-offcanvas-panel--right kt-header--fixed kt-header-mobile--fixed kt-subheader--enabled kt-subheader--fixed kt-subheader--solid kt-aside--enabled kt-aside--fixed kt-page--loading">

	<!-- begin:: Page -->

	<!-- begin:: Header Mobile -->
	<div id="kt_header_mobile" class="kt-header-mobile  kt-header-mobile--fixed ">
		<div class="kt-header-mobile__logo">
			<a href="javascript:;">
				<img alt="Logo" src="assets/media/logos/logo-dark.png" />
			</a>
		</div>
		<div class="kt-header-mobile__toolbar">
			<button class="kt-header-mobile__toggler kt-header-mobile__toggler--left"
				id="kt_aside_mobile_toggler"><span></span></button>
			<button class="kt-header-mobile__toggler" id="kt_header_mobile_toggler"><span></span></button>
			<button class="kt-header-mobile__topbar-toggler" id="kt_header_mobile_topbar_toggler"><i
					class="flaticon-more"></i></button>
		</div>
	</div>

	<!-- end:: Header Mobile -->
	<div class="kt-grid kt-grid--hor kt-grid--root">
		<div class="kt-grid__item kt-grid__item--fluid kt-grid kt-grid--ver kt-page">

			<!-- begin:: Aside -->

			<!-- Uncomment this to display the close button of the panel
<button class="kt-aside-close " id="kt_aside_close_btn"><i class="la la-close"></i></button>
-->
			<div class="kt-aside  kt-aside--fixed  kt-grid__item kt-grid kt-grid--desktop kt-grid--hor-desktop" id="kt_aside">

				<!-- begin:: Aside -->
				<div class="kt-aside__brand kt-grid__item " id="kt_aside_brand">
					<div class="kt-aside__brand-logo">
						<a href="javascript:;">
							<img alt="Logo" src="assets/media/logos/logo-dark.png" height="40" />
						</a>
					</div>
					<div class="kt-aside__brand-tools">
						<button class="kt-aside__brand-aside-toggler" id="kt_aside_toggler">
							<span><svg xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink" width="24px"
									height="24px" viewBox="0 0 24 24" version="1.1" class="kt-svg-icon">
									<g stroke="none" stroke-width="1" fill="none" fill-rule="evenodd">
										<polygon points="0 0 24 0 24 24 0 24" />
										<path
											d="M5.29288961,6.70710318 C4.90236532,6.31657888 4.90236532,5.68341391 5.29288961,5.29288961 C5.68341391,4.90236532 6.31657888,4.90236532 6.70710318,5.29288961 L12.7071032,11.2928896 C13.0856821,11.6714686 13.0989277,12.281055 12.7371505,12.675721 L7.23715054,18.675721 C6.86395813,19.08284 6.23139076,19.1103429 5.82427177,18.7371505 C5.41715278,18.3639581 5.38964985,17.7313908 5.76284226,17.3242718 L10.6158586,12.0300721 L5.29288961,6.70710318 Z"
											fill="#000000" fill-rule="nonzero"
											transform="translate(8.999997, 11.999999) scale(-1, 1) translate(-8.999997, -11.999999) " />
										<path
											d="M10.7071009,15.7071068 C10.3165766,16.0976311 9.68341162,16.0976311 9.29288733,15.7071068 C8.90236304,15.3165825 8.90236304,14.6834175 9.29288733,14.2928932 L15.2928873,8.29289322 C15.6714663,7.91431428 16.2810527,7.90106866 16.6757187,8.26284586 L22.6757187,13.7628459 C23.0828377,14.1360383 23.1103407,14.7686056 22.7371482,15.1757246 C22.3639558,15.5828436 21.7313885,15.6103465 21.3242695,15.2371541 L16.0300699,10.3841378 L10.7071009,15.7071068 Z"
											fill="#000000" fill-rule="nonzero" opacity="0.3"
											transform="translate(15.999997, 11.999999) scale(-1, 1) rotate(-270.000000) translate(-15.999997, -11.999999) " />
									</g>
								</svg></span>
							<span><svg xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink" width="24px"
									height="24px" viewBox="0 0 24 24" version="1.1" class="kt-svg-icon">
									<g stroke="none" stroke-width="1" fill="none" fill-rule="evenodd">
										<polygon points="0 0 24 0 24 24 0 24" />
										<path
											d="M12.2928955,6.70710318 C11.9023712,6.31657888 11.9023712,5.68341391 12.2928955,5.29288961 C12.6834198,4.90236532 13.3165848,4.90236532 13.7071091,5.29288961 L19.7071091,11.2928896 C20.085688,11.6714686 20.0989336,12.281055 19.7371564,12.675721 L14.2371564,18.675721 C13.863964,19.08284 13.2313966,19.1103429 12.8242777,18.7371505 C12.4171587,18.3639581 12.3896557,17.7313908 12.7628481,17.3242718 L17.6158645,12.0300721 L12.2928955,6.70710318 Z"
											fill="#000000" fill-rule="nonzero" />
										<path
											d="M3.70710678,15.7071068 C3.31658249,16.0976311 2.68341751,16.0976311 2.29289322,15.7071068 C1.90236893,15.3165825 1.90236893,14.6834175 2.29289322,14.2928932 L8.29289322,8.29289322 C8.67147216,7.91431428 9.28105859,7.90106866 9.67572463,8.26284586 L15.6757246,13.7628459 C16.0828436,14.1360383 16.1103465,14.7686056 15.7371541,15.1757246 C15.3639617,15.5828436 14.7313944,15.6103465 14.3242754,15.2371541 L9.03007575,10.3841378 L3.70710678,15.7071068 Z"
											fill="#000000" fill-rule="nonzero" opacity="0.3"
											transform="translate(9.000003, 11.999999) rotate(-270.000000) translate(-9.000003, -11.999999) " />
									</g>
								</svg></span>
						</button>

						<!--
			<button class="kt-aside__brand-aside-toggler kt-aside__brand-aside-toggler--left" id="kt_aside_toggler"><span></span></button>
			-->
					</div>
				</div>

				<!-- end:: Aside -->

				<!-- begin:: Aside Menu -->
				<div class="kt-aside-menu-wrapper kt-grid__item kt-grid__item--fluid" id="kt_aside_menu_wrapper">
					<div id="kt_aside_menu" class="kt-aside-menu mg-0 pb-5" data-ktmenu-vertical="1" data-ktmenu-scroll="1"
						data-ktmenu-dropdown-timeout="500">

						<ul class="kt-menu__nav pd-0 mb-5">
							<li class="kt-menu__item" aria-haspopup="true">
								<a href="index.html" class="kt-menu__link ">
									<span class="kt-menu__link-icon">
										<i class="fa fa-home"></i>
									</span>
									<span class="kt-menu__link-text">About</span>
								</a>
							</li>

							<li class="kt-menu__item  kt-menu__item--submenu" aria-haspopup="true" data-ktmenu-submenu-toggle="hover">
								<a href="javascript:;" class="kt-menu__link kt-menu__toggle">
									<span class="kt-menu__link-icon">
										<i class="fa fa-file-invoice"></i>
									</span>
									<span class="kt-menu__link-text">Profil Corsec</span>
									<i class="kt-menu__ver-arrow la la-angle-right"></i></a>
								<div class="kt-menu__submenu "><span class="kt-menu__arrow"></span>
									<ul class="kt-menu__subnav">
										<li class="kt-menu__item " aria-haspopup="true">
											<a href="visi-misi.html" class="kt-menu__link ">
												<i class="kt-menu__link-bullet kt-menu__link-bullet--dot"><span></span></i>
												<span class="kt-menu__link-text">Overview, Visi & Misi</span>
											</a>
										</li>
										<li class="kt-menu__item" aria-haspopup="true">
											<a href="strategic-partner.html" class="kt-menu__link ">
												<i class="kt-menu__link-bullet kt-menu__link-bullet--dot"><span></span></i>
												<span class="kt-menu__link-text">Strategic Partner</span>
											</a>
										</li>
									</ul>
								</div>
							</li>

							<li class="kt-menu__item kt-menu__item--open kt-menu__item--here" aria-haspopup="true">
								<a href="struktur.html" class="kt-menu__link ">
									<span class="kt-menu__link-icon">
										<i class="fa fa-bezier-curve"></i>
									</span>
									<span class="kt-menu__link-text">Organization</span>
								</a>
							</li>

							<li class="kt-menu__item" aria-haspopup="true" data-toggle="kt-tooltip" data-placement="right"
								data-original-title="STK, TKO, TKI">
								<a href="stk.html" class="kt-menu__link ">
									<span class="kt-menu__link-icon">
										<i class="fa fa-file-signature"></i>
									</span>
									<span class="kt-menu__link-text">Guidelines & Policy</span>
								</a>
							</li>

							<li class="kt-menu__item" aria-haspopup="true" data-toggle="kt-tooltip" data-placement="right"
								data-original-title="Kalender, Agenda, Kartu ucapan">
								<a href="collateral-corporate.html" class="kt-menu__link ">
									<span class="kt-menu__link-icon">
										<i class="fa fa-file-signature"></i>
									</span>
									<span class="kt-menu__link-text">Collateral corporate</span>
								</a>
							</li>

							<li class="kt-menu__item" aria-haspopup="true" data-ktmenu-submenu-toggle="hover"><a href="javascript:;"
									class="kt-menu__link kt-menu__toggle">
									<span class="kt-menu__link-icon">
										<i class="fa fa-building"></i>
									</span>
									<span class="kt-menu__link-text">Brand Management</span>
									<i class="kt-menu__ver-arrow la la-angle-right"></i></a>
								<div class="kt-menu__submenu "><span class="kt-menu__arrow"></span>
									<ul class="kt-menu__subnav">
										<li class="kt-menu__item " aria-haspopup="true">
											<a href="brand-equity.html" class="kt-menu__link ">
												<i class="kt-menu__link-bullet kt-menu__link-bullet--dot"><span></span></i>
												<span class="kt-menu__link-text">Brand Equity</span>
											</a>
										</li>
										<li class="kt-menu__item " aria-haspopup="true">
											<a href="logos.html" class="kt-menu__link ">
												<i class="kt-menu__link-bullet kt-menu__link-bullet--dot"><span></span></i>
												<span class="kt-menu__link-text">Brand Guideline</span>
											</a>
										</li>
										<li class="kt-menu__item " aria-haspopup="true">
											<a href="communication-campaign.html" class="kt-menu__link ">
												<i class="kt-menu__link-bullet kt-menu__link-bullet--dot"><span></span></i>
												<span class="kt-menu__link-text">Communication Campaign</span>
											</a>
										</li>
										<li class="kt-menu__item " aria-haspopup="true">
											<a href="merchandise-hub.html" class="kt-menu__link ">
												<i class="kt-menu__link-bullet kt-menu__link-bullet--dot"><span></span></i>
												<span class="kt-menu__link-text">Merchandise hub</span>
											</a>
										</li>
										<li class="kt-menu__item " aria-haspopup="true">
											<a href="pameran-corporate.html" class="kt-menu__link ">
												<i class="kt-menu__link-bullet kt-menu__link-bullet--dot"><span></span></i>
												<span class="kt-menu__link-text">Exhibition</span>
											</a>
										</li>
										<li class="kt-menu__item " aria-haspopup="true">
											<a href="sponsorship.html" class="kt-menu__link ">
												<i class="kt-menu__link-bullet kt-menu__link-bullet--dot"><span></span></i>
												<span class="kt-menu__link-text">Sponsorship</span>
											</a>
										</li>
									</ul>
								</div>
							</li>

							<li class="kt-menu__item  kt-menu__item--submenu" aria-haspopup="true" data-ktmenu-submenu-toggle="hover">
								<a href="javascript:;" class="kt-menu__link kt-menu__toggle">
									<span class="kt-menu__link-icon">
										<i class="fa fa-archive"></i>
									</span>
									<span class="kt-menu__link-text">Program</span>
									<i class="kt-menu__ver-arrow la la-angle-right"></i>
								</a>
								<div class="kt-menu__submenu "><span class="kt-menu__arrow"></span>
									<ul class="kt-menu__subnav">
										<li class="kt-menu__item  kt-menu__item--active" aria-haspopup="true"><a
												href="corporate-communication.html" class="kt-menu__link "><i
													class="kt-menu__link-bullet kt-menu__link-bullet--dot"><span></span></i><span
													class="kt-menu__link-text">Corporate Communication</span></a></li>
										<li class="kt-menu__item " aria-haspopup="true"><a href="stakeholder-relation.html"
												class="kt-menu__link "><i
													class="kt-menu__link-bullet kt-menu__link-bullet--dot"><span></span></i><span
													class="kt-menu__link-text">Stakeholders Relation</span></a></li>
										<li class="kt-menu__item " aria-haspopup="true"><a href="csr-smepp.html" class="kt-menu__link "><i
													class="kt-menu__link-bullet kt-menu__link-bullet--dot"><span></span></i><span
													class="kt-menu__link-text">CSR SMEPP</span></a></li>
										<li class="kt-menu__item " aria-haspopup="true"><a href="bod-support.html" class="kt-menu__link "><i
													class="kt-menu__link-bullet kt-menu__link-bullet--dot"><span></span></i><span
													class="kt-menu__link-text">BOD Support</span></a></li>
										<li class="kt-menu__item " aria-haspopup="true"><a href="planning-governance.html"
												class="kt-menu__link "><i
													class="kt-menu__link-bullet kt-menu__link-bullet--dot"><span></span></i><span
													class="kt-menu__link-text">Planning & Governance</span></a></li>
									</ul>
								</div>
							</li>

							<li class="kt-menu__item  kt-menu__item--submenu" aria-haspopup="true" data-ktmenu-submenu-toggle="hover">
								<a href="javascript:;" class="kt-menu__link kt-menu__toggle">
									<span class="kt-menu__link-icon">
										<i class="fa fa-calendar-day"></i>
									</span>
									<span class="kt-menu__link-text">Event & Information</span>
									<i class="kt-menu__ver-arrow la la-angle-right"></i>
								</a>
								<div class="kt-menu__submenu "><span class="kt-menu__arrow"></span>
									<ul class="kt-menu__subnav">
										<li class="kt-menu__item " aria-haspopup="true"><a href="trends-issues.html"
												class="kt-menu__link "><i
													class="kt-menu__link-bullet kt-menu__link-bullet--dot"><span></span></i><span
													class="kt-menu__link-text">Trends & Issues</span></a></li>
										<li class="kt-menu__item " aria-haspopup="true"><a href="kalender-korporat.html"
												class="kt-menu__link "><i
													class="kt-menu__link-bullet kt-menu__link-bullet--dot"><span></span></i><span
													class="kt-menu__link-text">Kalender Event Korpoat</span></a></li>
										<li class="kt-menu__item " aria-haspopup="true"><a href="volunteer.html" class="kt-menu__link "><i
													class="kt-menu__link-bullet kt-menu__link-bullet--dot"><span></span></i><span
													class="kt-menu__link-text">Volunteer</span></a></li>
										<li class="kt-menu__item " aria-haspopup="true"><a href="informasi-magang.html"
												class="kt-menu__link "><i
													class="kt-menu__link-bullet kt-menu__link-bullet--dot"><span></span></i><span
													class="kt-menu__link-text">
													Informasi Magang</span></a></li>
										<li class="kt-menu__item " aria-haspopup="true"><a href="gallery.html" class="kt-menu__link "><i
													class="kt-menu__link-bullet kt-menu__link-bullet--dot"><span></span></i><span
													class="kt-menu__link-text">
													Galeri</span></a></li>
									</ul>
								</div>
							</li>

							<li class="kt-menu__item  kt-menu__item--submenu" aria-haspopup="true" data-ktmenu-submenu-toggle="hover">
								<a href="javascript:;" class="kt-menu__link kt-menu__toggle">
									<span class="kt-menu__link-icon">
										<i class="fa fa-images"></i>
									</span>
									<span class="kt-menu__link-text">Media</span>
									<i class="kt-menu__ver-arrow la la-angle-right"></i>
								</a>
								<div class="kt-menu__submenu "><span class="kt-menu__arrow"></span>
									<ul class="kt-menu__subnav">
										<li class="kt-menu__item " aria-haspopup="true" data-toggle="kt-tooltip" data-placement="right"
											data-original-title="Infographic corporate, Pertapedia, konten social
                                    media, Media eksternal"><a href="pertapedia.html" class="kt-menu__link "><i
													class="kt-menu__link-bullet kt-menu__link-bullet--dot"><span></span></i><span
													class="kt-menu__link-text">Infographic</span></a></li>
										<li class="kt-menu__item " aria-haspopup="true" data-toggle="kt-tooltip" data-placement="right"
											data-original-title="Print ad, Stock photo, TVC"><a href="pojok-kreasi.html"
												class="kt-menu__link "><i
													class="kt-menu__link-bullet kt-menu__link-bullet--dot"><span></span></i><span
													class="kt-menu__link-text">Pojok kreasi</span></a></li>
									</ul>
								</div>
							</li>

							<li class="kt-menu__item  kt-menu__item--submenu" aria-haspopup="true" data-ktmenu-submenu-toggle="hover">
								<a href="javascript:;" class="kt-menu__link kt-menu__toggle">
									<span class="kt-menu__link-icon">
										<i class="fa fa-archive"></i>
									</span>
									<span class="kt-menu__link-text">Speech & Report</span>
									<i class="kt-menu__ver-arrow la la-angle-right"></i>
								</a>
								<div class="kt-menu__submenu "><span class="kt-menu__arrow"></span>
									<ul class="kt-menu__subnav">
										<li class="kt-menu__item " aria-haspopup="true" data-toggle="kt-tooltip" data-placement="right"
											data-original-title="Board Speech, Presentasi corporate, Email broadcast, Materi
                          presentasi"><a href="presentasi.html" class="kt-menu__link "><i
													class="kt-menu__link-bullet kt-menu__link-bullet--dot"><span></span></i><span
													class="kt-menu__link-text">Board Speech & Presentation</span></a></li>
										<li class="kt-menu__item " aria-haspopup="true"><a href="kinerja-sekper.html"
												class="kt-menu__link "><i
													class="kt-menu__link-bullet kt-menu__link-bullet--dot"><span></span></i><span
													class="kt-menu__link-text">Kinerja Sekper</span></a></li>
									</ul>
								</div>
							</li>

							<li class="kt-menu__item" aria-haspopup="true">
								<a href="mitra-binaan.html" class="kt-menu__link ">
									<span class="kt-menu__link-icon">
										<i class="fa fa-handshake"></i>
									</span>
									<span class="kt-menu__link-text">Mitra binaan</span>
								</a>
							</li>

						</ul>

					</div>
				</div>

				<!-- end:: Aside Menu -->
			</div>

			<!-- end:: Aside -->
			<div class="kt-grid__item kt-grid__item--fluid kt-grid kt-grid--hor kt-wrapper" id="kt_wrapper">

				<!-- begin:: Header -->
				<div id="kt_header" class="kt-header kt-grid__item  kt-header--fixed ">

					<!-- begin:: Header Menu -->

					<!-- Uncomment this to display the close button of the panel
<button class="kt-header-menu-wrapper-close" id="kt_header_menu_mobile_close_btn"><i class="la la-close"></i></button>
-->
					<div class="kt-header-menu-wrapper" id="kt_header_menu_wrapper">
						<div id="kt_header_menu" class="kt-header-menu kt-header-menu-mobile  kt-header-menu--layout-default ">
							<ul class="kt-menu__nav">
								<li class="kt-menu__item  kt-menu__item--submenu kt-menu__item--rel" data-ktmenu-submenu-toggle="click"
									aria-haspopup="true"><a href="javascript:;" class="kt-menu__link kt-menu__toggle"><span
											class="kt-menu__link-text">Corporate
											Communication</span></a>
									<div class="kt-menu__submenu kt-menu__submenu--classic kt-menu__submenu--left">
										<ul class="kt-menu__subnav">
											<li class="kt-menu__item " aria-haspopup="true"><a href="strategi-komunikasi-korporate.html"
													class="kt-menu__link"><i
														class="kt-menu__link-bullet kt-menu__link-bullet--dot"><span></span></i><span
														class="kt-menu__link-text">Strategi Komunikasi Korporat</span></a></li>
											<li class="kt-menu__item " aria-haspopup="true"><a href="strategi-pengelolaan-krisis.html"
													class="kt-menu__link"><i
														class="kt-menu__link-bullet kt-menu__link-bullet--dot"><span></span></i><span
														class="kt-menu__link-text">Strategi Pengelolaan Krisis</span></a></li>
										</ul>
									</div>
								</li>
								<li class="kt-menu__item kt-menu__item--submenu kt-menu__item--rel" data-ktmenu-submenu-toggle="click"
									aria-haspopup="true"><a href="javascript:;" class="kt-menu__link kt-menu__toggle"><span
											class="kt-menu__link-text">Stake Holder Management</span></a>
									<div class="kt-menu__submenu kt-menu__submenu--classic">
										<ul class="kt-menu__subnav">
											<li class="kt-menu__item " aria-haspopup="true"><a href="strategic-stake-holder-engagement.html"
													class="kt-menu__link"><i
														class="kt-menu__link-bullet kt-menu__link-bullet--dot"><span></span></i><span
														class="kt-menu__link-text">Strategic Stake holder Engagement</span></a></li>
											<li class="kt-menu__item " aria-haspopup="true"><a href="diplomatic-intelegence.html"
													class="kt-menu__link"><i
														class="kt-menu__link-bullet kt-menu__link-bullet--dot"><span></span></i><span
														class="kt-menu__link-text">Diplomatic Intelegence</span></a></li>
											<li class="kt-menu__item " aria-haspopup="true"><a href="stake-holder-database.html"
													class="kt-menu__link"><i
														class="kt-menu__link-bullet kt-menu__link-bullet--dot"><span></span></i><span
														class="kt-menu__link-text">Stake Holder Database</span></a></li>
										</ul>
									</div>
								</li>
								<li class="kt-menu__item kt-menu__item--submenu kt-menu__item--rel" data-ktmenu-submenu-toggle="click"
									aria-haspopup="true"><a href="javascript:;" class="kt-menu__link kt-menu__toggle"><span
											class="kt-menu__link-text">CSR-SMEPP</span></a>
									<div class="kt-menu__submenu kt-menu__submenu--classic">
										<ul class="kt-menu__subnav">
											<li class="kt-menu__item " aria-haspopup="true"><a href="strategi-pengelolaan.html"
													class="kt-menu__link"><i
														class="kt-menu__link-bullet kt-menu__link-bullet--dot"><span></span></i><span
														class="kt-menu__link-text">Strategi Pengelolaan</span></a></li>
											<li class="kt-menu__item " aria-haspopup="true"><a href="program-csr-bl.html"
													class="kt-menu__link"><i
														class="kt-menu__link-bullet kt-menu__link-bullet--dot"><span></span></i><span
														class="kt-menu__link-text">Program CSR-BL</span></a></li>
											<li class="kt-menu__item " aria-haspopup="true"><a href="program-kemitraan.html"
													class="kt-menu__link"><i
														class="kt-menu__link-bullet kt-menu__link-bullet--dot"><span></span></i><span
														class="kt-menu__link-text">Program Kemitraan</span></a></li>
										</ul>
									</div>
								</li>
								<li class="kt-menu__item kt-menu__item--submenu kt-menu__item--rel" data-ktmenu-submenu-toggle="click"
									aria-haspopup="true"><a href="javascript:;" class="kt-menu__link kt-menu__toggle"><span
											class="kt-menu__link-text">Design Grafis</span></a>
									<div class="kt-menu__submenu kt-menu__submenu--classic">
										<ul class="kt-menu__subnav">
											<li class="kt-menu__item " aria-haspopup="true"><a href="desain.html" class="kt-menu__link"><i
														class="kt-menu__link-bullet kt-menu__link-bullet--dot"><span></span></i><span
														class="kt-menu__link-text">Desain</span></a></li>
											<li class="kt-menu__item " aria-haspopup="true"><a href="infografis.html" class="kt-menu__link"><i
														class="kt-menu__link-bullet kt-menu__link-bullet--dot"><span></span></i><span
														class="kt-menu__link-text">Infografis</span></a></li>
										</ul>
									</div>
								</li>
								<li class="kt-menu__item kt-menu__item--submenu kt-menu__item--rel" data-ktmenu-submenu-toggle="click"
									aria-haspopup="true"><a href="javascript:;" class="kt-menu__link kt-menu__toggle"><span
											class="kt-menu__link-text">Monitoring & Evaluasi</span></a>
									<div class="kt-menu__submenu kt-menu__submenu--classic">
										<ul class="kt-menu__subnav">
											<li class="kt-menu__item " aria-haspopup="true"><a href="media-monitoring.html"
													class="kt-menu__link"><i
														class="kt-menu__link-bullet kt-menu__link-bullet--dot"><span></span></i><span
														class="kt-menu__link-text">Media Monitoring</span></a></li>
											<li class="kt-menu__item " aria-haspopup="true"><a href="kinerja-sekper-monitoring.html"
													class="kt-menu__link"><i
														class="kt-menu__link-bullet kt-menu__link-bullet--dot"><span></span></i><span
														class="kt-menu__link-text">Kinerja Sekper</span></a></li>
										</ul>
									</div>
								</li>
							</ul>
						</div>
					</div>

					<!-- end:: Header Menu -->

					<!-- begin:: Header Topbar -->
					<div class="kt-header__topbar">

						<!--begin: Search -->

						<!--begin: Search -->
						<div class="kt-header__topbar-item kt-header__topbar-item--search dropdown" id="kt_quick_search_toggle">
							<div class="kt-header__topbar-wrapper" data-toggle="dropdown" data-offset="10px,0px">
								<span class="kt-header__topbar-icon">
									<svg xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink" width="24px"
										height="24px" viewBox="0 0 24 24" version="1.1" class="kt-svg-icon">
										<g stroke="none" stroke-width="1" fill="none" fill-rule="evenodd">
											<rect x="0" y="0" width="24" height="24" />
											<path
												d="M14.2928932,16.7071068 C13.9023689,16.3165825 13.9023689,15.6834175 14.2928932,15.2928932 C14.6834175,14.9023689 15.3165825,14.9023689 15.7071068,15.2928932 L19.7071068,19.2928932 C20.0976311,19.6834175 20.0976311,20.3165825 19.7071068,20.7071068 C19.3165825,21.0976311 18.6834175,21.0976311 18.2928932,20.7071068 L14.2928932,16.7071068 Z"
												fill="#000000" fill-rule="nonzero" opacity="0.3" />
											<path
												d="M11,16 C13.7614237,16 16,13.7614237 16,11 C16,8.23857625 13.7614237,6 11,6 C8.23857625,6 6,8.23857625 6,11 C6,13.7614237 8.23857625,16 11,16 Z M11,18 C7.13400675,18 4,14.8659932 4,11 C4,7.13400675 7.13400675,4 11,4 C14.8659932,4 18,7.13400675 18,11 C18,14.8659932 14.8659932,18 11,18 Z"
												fill="#000000" fill-rule="nonzero" />
										</g>
									</svg> </span>
							</div>
							<div class="dropdown-menu dropdown-menu-fit dropdown-menu-right dropdown-menu-anim dropdown-menu-lg">
								<div class="kt-quick-search kt-quick-search--dropdown kt-quick-search--result-compact"
									id="kt_quick_search_dropdown">
									<form method="get" class="kt-quick-search__form">
										<div class="input-group">
											<div class="input-group-prepend"><span class="input-group-text"><i
														class="flaticon2-search-1"></i></span></div>
											<input type="text" class="form-control kt-quick-search__input" placeholder="Search...">
											<div class="input-group-append"><span class="input-group-text"><i
														class="la la-close kt-quick-search__close"></i></span></div>
										</div>
									</form>
									<div class="kt-quick-search__wrapper kt-scroll" data-scroll="true" data-height="325"
										data-mobile-height="200">
									</div>
								</div>
							</div>
						</div>

						<!--end: Search -->


						<!--begin: User Bar -->
						<div class="kt-header__topbar-item kt-header__topbar-item--user">
							<div class="kt-header__topbar-wrapper" data-toggle="dropdown" data-offset="0px,0px">
								<div class="kt-header__topbar-user">
									<span class="kt-header__topbar-username kt-hidden-mobile">Administrator</span>
									<img class="kt-hidden" alt="Pic" src="assets/media/users/300_25.jpg" />

									<div class="kt-widget3__user-img">
										<img class="kt-widget3__img" src="assets/media/users/user1.jpg" alt="">
									</div>
								</div>
							</div>
							<div
								class="dropdown-menu dropdown-menu-fit dropdown-menu-right dropdown-menu-anim dropdown-menu-top-unround dropdown-menu-xl">

								<!--begin: Head -->
								<div class="kt-user-card kt-user-card--skin-dark kt-notification-item-padding-x"
									style="background-image: url(assets/media/misc/bg-1.jpg)">
									<div class="kt-user-card__avatar">
										<img class="kt-hidden" alt="Pic" src="assets/media/users/300_25.jpg" />

										<!--use below badge element instead the user avatar to display username's first letter(remove kt-hidden class to display it) -->
										<span class="kt-badge kt-badge--lg kt-badge--rounded kt-badge--bold kt-font-success">S</span>
									</div>
									<div class="kt-user-card__name">
										Administrator
									</div>
									<div class="kt-user-card__badge">
										<span class="btn btn-success btn-sm btn-bold btn-font-md">23 Pesan</span>
									</div>
								</div>

								<!--end: Head -->

								<!--begin: Navigation -->
								<div class="kt-notification">
									<a href="custom/apps/user/profile-1/personal-information.html" class="kt-notification__item">
										<div class="kt-notification__item-icon">
											<i class="flaticon2-calendar-3 kt-font-success"></i>
										</div>
										<div class="kt-notification__item-details">
											<div class="kt-notification__item-title kt-font-bold">
												Profile
											</div>
										</div>
									</a>
									<a href="custom/apps/user/profile-3.html" class="kt-notification__item">
										<div class="kt-notification__item-icon">
											<i class="flaticon2-mail kt-font-warning"></i>
										</div>
										<div class="kt-notification__item-details">
											<div class="kt-notification__item-title kt-font-bold">
												Pesan
											</div>
										</div>
									</a>
									<div class="kt-notification__custom kt-space-between">
										<a href="custom/user/login-v2.html" target="_blank"
											class="btn btn-label btn-label-brand btn-sm btn-bold">Sign Out</a>
									</div>
								</div>

								<!--end: Navigation -->
							</div>
						</div>

						<!--end: User Bar -->
					</div>

					<!-- end:: Header Topbar -->
				</div>

				<!-- end:: Header -->
				<div class="kt-grid__item kt-grid__item--fluid kt-grid kt-grid--hor" id="kt_content">

					<!-- begin:: Content Head -->
					<div class="kt-subheader  kt-grid__item" id="kt_subheader">
						<div class="kt-container  kt-container--fluid ">
							<div class="kt-subheader__main">
								<h3 class="kt-subheader__title">Organization</h3>
							</div>
							<div class="kt-subheader__toolbar">
								<div class="kt-subheader__wrapper">

								</div>
							</div>
						</div>
					</div>
				</div>


				<!-- end:: Content Head -->

				<!-- begin:: Content -->
				<div class="kt-content  kt-content--fit-top  kt-grid__item kt-grid__item--fluid kt-grid kt-grid--hor"
					id="kt_content">

					<!-- begin:: Content -->

					<!-- begin:: Hero -->
					<div class="kt-sc" style="background-image: url('assets/media/bg/bg-9.jpg')">
						<div class="kt-container ">

							<div class="kt-sc__bottom">
								<h3 class="kt-sc__heading kt-heading kt-heading--center kt-heading--xxl kt-heading--medium">
									Struktur Organisasi Sekper
								</h3>

							</div>
						</div>
					</div>
					<!-- end:: Hero -->


					<div class="kt-container ">
						<div class="kt-portlet">
							<div class="kt-portlet__body">
								<div class="kt-infobox">
									<div class="kt-infobox__header">
										<h2 class="kt-infobox__title">Obcaecati nisi laboriosam</h2>
									</div>
									<div class="kt-infobox__body">
										<div class="kt-infobox__section">
											<div class="kt-infobox__content">
												Lorem ipsum dolor sit amet, consectetur adipisicing elit. Temporibus at laboriosam
												architecto maiores consequuntur pariatur fuga aperiam labore, consectetur ratione ullam,
												accusamus quos optio quibusdam molestias repellendus! Aut nulla dolores nisi nemo aperiam et
												quos magni ut officia, nesciunt quia ipsa illo nam quibusdam possimus dignissimos ducimus
												veritatis quae tempore amet voluptate repellat. Eos sed est numquam nisi hic eveniet quos,
												rerum culpa ipsa,
											</div>
										</div>
									</div>
								</div>
							</div>
						</div>
					</div>

					<div class="kt-container">
						<div class="kt-portlet">
							<div class="kt-portlet__head">
								<div class="kt-portlet__head-toolbar">
									<ul class="nav nav-pills nav-fill" role="tablist">
										<li class="nav-item">
											<a class="nav-link active" data-toggle="tab" href="#kt_portlet_base_demo_2_3_tab_content"
												role="tab" aria-selected="true">
												Corsec
											</a>
										</li>
										<li class="nav-item">
											<a class="nav-link" data-toggle="tab" href="#kt_portlet_base_demo_2_2_tab_content" role="tab"
												aria-selected="false">
												Corcom
											</a>
										</li>
									</ul>
								</div>
							</div>
							<div class="kt-portlet__body">
								<div class="tab-content">
									<div class="tab-pane active" id="kt_portlet_base_demo_2_3_tab_content" role="tabpanel">
										<div id="organization">
											<ul class="tree-view">
												<li>
													<input type="checkbox" id="c5" />
													<div class="row">
														<div class="col-md-5">
															<!--begin::Accordion-->
															<div class="accordion accordion-solid accordion-toggle-plus" id="accordionExample5">
																<div class="card">
																	<div class="card-header" id="headingOne5">
																		<div class="card-title collapsed" data-toggle="collapse" data-target="#collapseOne5"
																			aria-expanded="false" aria-controls="collapseOne5">
																			<label class="tree_label" for="c5"></label> Vice President
																		</div>
																	</div>
																	<div id="collapseOne5" class="collapse" aria-labelledby="headingOne5"
																		data-parent="#accordionExample5" style="">
																		<div class="card-body">
																			<div
																				class="kt-portlet kt-callout kt-callout--info kt-callout--diagonal-bg bg-struktur bg-struktur">
																				<div class="kt-portlet__body m-0 p-0">
																					<div class="kt-callout__body">
																						<div class="kt-callout__content">
																							<h3 class="text-right kt-font-bolder">Jason Muller
																								<br /><small>GOF03055</small></h3>
																							<span class="text-left"><i class="fa fa-phone"></i>
																								082119071726</span><br />
																							<span class="text-left"><i class="flaticon2-new-email"></i>
																								jason@siastudio.com</span>
																						</div>
																					</div>
																				</div>
																			</div>
																		</div>
																	</div>
																</div>
															</div>
															<!--end::Accordion-->
														</div>
														<!-- end 6th row -->
													</div>
													<ul>
														<li>
															<input type="checkbox" id="c6" />
															<div class="row">
																<div class="col-md-5">
																	<!--begin::Accordion-->
																	<div class="accordion accordion-solid accordion-toggle-plus" id="accordionExample6">
																		<div class="card">
																			<div class="card-header" id="headingOne6">
																				<div class="card-title collapsed" data-toggle="collapse"
																					data-target="#collapseOne6" aria-expanded="false"
																					aria-controls="collapseOne6">
																					<label class="tree_label" for="c6"></label> Manager
																				</div>
																			</div>
																			<div id="collapseOne6" class="collapse" aria-labelledby="headingOne6"
																				data-parent="#accordionExample6" style="">
																				<div class="card-body">
																					<div
																						class="kt-portlet kt-callout kt-callout--info kt-callout--diagonal-bg bg-struktur">
																						<div class="kt-portlet__body m-0 p-0">
																							<div class="kt-callout__body">
																								<div class="kt-callout__content">
																									<h3 class="text-right kt-font-bolder">Jason Muller
																										<br /><small>GOF03055</small>
																									</h3>
																									<span class="text-left"><i class="fa fa-phone"></i>
																										082119071726</span><br />
																									<span class="text-left"><i class="flaticon2-new-email"></i>
																										jason@siastudio.com</span>
																								</div>
																							</div>
																						</div>
																					</div>
																				</div>
																			</div>
																		</div>
																	</div>
																	<!--end::Accordion-->
																</div>
																<!-- end 6th row -->
															</div>
															<ul>
																<li>
																	<input type="checkbox" id="c7" />
																	<div class="row">
																		<div class="col-md-5">
																			<!--begin::Accordion-->
																			<div class="accordion accordion-solid accordion-toggle-plus"
																				id="accordionExample7">
																				<div class="card">
																					<div class="card-header" id="headingOne7">
																						<div class="card-title collapsed" data-toggle="collapse"
																							data-target="#collapseOne7" aria-expanded="false"
																							aria-controls="collapseOne7">
																							<label class="tree_label" for="c7"></label> Sr Officer
																						</div>
																					</div>
																					<div id="collapseOne7" class="collapse" aria-labelledby="headingOne7"
																						data-parent="#accordionExample7" style="">
																						<div class="card-body">
																							<div
																								class="kt-portlet kt-callout kt-callout--info kt-callout--diagonal-bg bg-struktur">
																								<div class="kt-portlet__body m-0 p-0">
																									<div class="kt-callout__body">
																										<div class="kt-callout__content">
																											<h3 class="text-right kt-font-bolder">Jason Muller
																												<br /><small>GOF03055</small>
																											</h3>
																											<span class="text-left"><i class="fa fa-phone"></i>
																												082119071726</span><br />
																											<span class="text-left"><i class="flaticon2-new-email"></i>
																												jason@siastudio.com</span>
																										</div>
																									</div>
																								</div>
																							</div>
																						</div>
																					</div>
																				</div>
																			</div>
																			<!--end::Accordion-->
																		</div>
																		<!-- end 6th row -->
																	</div>
																	<ul>
																		<li>
																			<input type="checkbox" id="c8" />
																			<div class="row">
																				<div class="col-md-5">
																					<!--begin::Accordion-->
																					<div class="accordion accordion-solid accordion-toggle-plus"
																						id="accordionExample8">
																						<div class="card">
																							<div class="card-header" id="headingOne8">
																								<div class="card-title collapsed" data-toggle="collapse"
																									data-target="#collapseOne8" aria-expanded="false"
																									aria-controls="collapseOne8">
																									<label class="tree_label" for="c8"></label> Officer
																								</div>
																							</div>
																							<div id="collapseOne8" class="collapse" aria-labelledby="headingOne8"
																								data-parent="#accordionExample8" style="">
																								<div class="card-body">
																									<div
																										class="kt-portlet kt-callout kt-callout--info kt-callout--diagonal-bg bg-struktur">
																										<div class="kt-portlet__body m-0 p-0">
																											<div class="kt-callout__body">
																												<div class="kt-callout__content">
																													<h3 class="text-right kt-font-bolder">Jason Muller
																														<br /><small>GOF03055</small>
																													</h3>
																													<span class="text-left"><i class="fa fa-phone"></i>
																														082119081826</span><br />
																													<span class="text-left"><i class="flaticon2-new-email"></i>
																														jason@siastudio.com</span>
																												</div>
																											</div>
																										</div>
																									</div>
																								</div>
																							</div>
																						</div>
																					</div>
																					<!--end::Accordion-->
																				</div>
																				<!-- end 6th row -->
																			</div>
																			<ul>
																				<li>
																					<input type="checkbox" id="c9" />
																					<div class="row">
																						<div class="col-md-5">
																							<!--begin::Accordion-->
																							<div class="accordion accordion-solid accordion-toggle-plus"
																								id="accordionExample9">
																								<div class="card">
																									<div class="card-header" id="headingOne9">
																										<div class="card-title collapsed" data-toggle="collapse"
																											data-target="#collapseOne9" aria-expanded="false"
																											aria-controls="collapseOne9">
																											<label class="tree_label" for="c9"></label> Jr Officer
																										</div>
																									</div>
																									<div id="collapseOne9" class="collapse" aria-labelledby="headingOne9"
																										data-parent="#accordionExample9" style="">
																										<div class="card-body">
																											<div
																												class="kt-portlet kt-callout kt-callout--info kt-callout--diagonal-bg bg-struktur">
																												<div class="kt-portlet__body m-0 p-0">
																													<div class="kt-callout__body">
																														<div class="kt-callout__content">
																															<h3 class="text-right kt-font-bolder">Jason Muller
																																<br /><small>GOF03055</small>
																															</h3>
																															<span class="text-left"><i class="fa fa-phone"></i>
																																092119091926</span><br />
																															<span class="text-left"><i
																																	class="flaticon2-new-email"></i>
																																jason@siastudio.com</span>
																														</div>
																													</div>
																												</div>
																											</div>
																										</div>
																									</div>
																								</div>
																							</div>
																							<!--end::Accordion-->
																						</div>
																						<!-- end 6th row -->
																					</div>
																				</li>
																				<li>
																					<div class="row">
																						<div class="col-md-5">
																							<!--begin::Accordion-->
																							<div class="accordion accordion-solid accordion-toggle-plus"
																								id="accordionExample91">
																								<div class="card">
																									<div class="card-header" id="headingOne91">
																										<div class="card-title collapsed" data-toggle="collapse"
																											data-target="#collapseOne91" aria-expanded="false"
																											aria-controls="collapseOne91">
																											<span class="tree_label"></span> Jr Officer
																										</div>
																									</div>
																									<div id="collapseOne91" class="collapse"
																										aria-labelledby="headingOne91" data-parent="#accordionExample91"
																										style="">
																										<div class="card-body">
																											<div
																												class="kt-portlet kt-callout kt-callout--info kt-callout--diagonal-bg bg-struktur">
																												<div class="kt-portlet__body m-0 p-0">
																													<div class="kt-callout__body">
																														<div class="kt-callout__content">
																															<h3 class="text-right kt-font-bolder">Jason Muller
																																<br /><small>GOF03055</small>
																															</h3>
																															<span class="text-left"><i class="fa fa-phone"></i>
																																082119081826</span><br />
																															<span class="text-left"><i
																																	class="flaticon2-new-email"></i>
																																jason@siastudio.com</span>
																														</div>
																													</div>
																												</div>
																											</div>
																										</div>
																									</div>
																								</div>
																							</div>
																							<!--end::Accordion-->
																						</div>
																						<!-- end 6th row -->
																					</div>
																				</li>
																			</ul>
																		</li>
																		<li>
																			<div class="row">
																				<div class="col-md-5">
																					<!--begin::Accordion-->
																					<div class="accordion accordion-solid accordion-toggle-plus"
																						id="accordionExample81">
																						<div class="card">
																							<div class="card-header" id="headingOne81">
																								<div class="card-title collapsed" data-toggle="collapse"
																									data-target="#collapseOne81" aria-expanded="false"
																									aria-controls="collapseOne81">
																									<span class="tree_label"></span> Officer
																								</div>
																							</div>
																							<div id="collapseOne81" class="collapse" aria-labelledby="headingOne81"
																								data-parent="#accordionExample81" style="">
																								<div class="card-body">
																									<div
																										class="kt-portlet kt-callout kt-callout--info kt-callout--diagonal-bg bg-struktur">
																										<div class="kt-portlet__body m-0 p-0">
																											<div class="kt-callout__body">
																												<div class="kt-callout__content">
																													<h3 class="text-right kt-font-bolder">Jason Muller
																														<br /><small>GOF03055</small>
																													</h3>
																													<span class="text-left"><i class="fa fa-phone"></i>
																														082119081826</span><br />
																													<span class="text-left"><i class="flaticon2-new-email"></i>
																														jason@siastudio.com</span>
																												</div>
																											</div>
																										</div>
																									</div>
																								</div>
																							</div>
																						</div>
																					</div>
																					<!--end::Accordion-->
																				</div>
																				<!-- end 6th row -->
																			</div>
																		</li>
																	</ul>
																</li>
																<li>
																	<div class="row">
																		<div class="col-md-5">
																			<!--begin::Accordion-->
																			<div class="accordion accordion-solid accordion-toggle-plus"
																				id="accordionExample71">
																				<div class="card">
																					<div class="card-header" id="headingOne71">
																						<div class="card-title collapsed" data-toggle="collapse"
																							data-target="#collapseOne71" aria-expanded="false"
																							aria-controls="collapseOne71">
																							<span class="tree_label"></span> Sr Officer 2
																						</div>
																					</div>
																					<div id="collapseOne71" class="collapse" aria-labelledby="headingOne71"
																						data-parent="#accordionExample71" style="">
																						<div class="card-body">
																							<div
																								class="kt-portlet kt-callout kt-callout--info kt-callout--diagonal-bg bg-struktur">
																								<div class="kt-portlet__body m-0 p-0">
																									<div class="kt-callout__body">
																										<div class="kt-callout__content">
																											<h3 class="text-right kt-font-bolder">Jason Muller
																												<br /><small>GOF03055</small>
																											</h3>
																											<span class="text-left"><i class="fa fa-phone"></i>
																												082119071726</span><br />
																											<span class="text-left"><i class="flaticon2-new-email"></i>
																												jason@siastudio.com</span>
																										</div>
																									</div>
																								</div>
																							</div>
																						</div>
																					</div>
																				</div>
																			</div>
																			<!--end::Accordion-->
																		</div>
																		<!-- end 6th row -->
																	</div>
																</li>
															</ul>
														</li>
														<li>
															<div class="row">
																<div class="col-md-5">
																	<!--begin::Accordion-->
																	<div class="accordion accordion-solid accordion-toggle-plus" id="accordionExample61">
																		<div class="card">
																			<div class="card-header" id="headingOne61">
																				<div class="card-title collapsed" data-toggle="collapse"
																					data-target="#collapseOne61" aria-expanded="false"
																					aria-controls="collapseOne61">
																					<span class="tree_label"></span> Manager 2
																				</div>
																			</div>
																			<div id="collapseOne61" class="collapse" aria-labelledby="headingOne61"
																				data-parent="#accordionExample61" style="">
																				<div class="card-body">
																					<div
																						class="kt-portlet kt-callout kt-callout--info kt-callout--diagonal-bg bg-struktur">
																						<div class="kt-portlet__body m-0 p-0">
																							<div class="kt-callout__body">
																								<div class="kt-callout__content">
																									<h3 class="text-right kt-font-bolder">Jason Muller
																										<br /><small>GOF03055</small>
																									</h3>
																									<span class="text-left"><i class="fa fa-phone"></i>
																										082119071726</span><br />
																									<span class="text-left"><i class="flaticon2-new-email"></i>
																										jason@siastudio.com</span>
																								</div>
																							</div>
																						</div>
																					</div>
																				</div>
																			</div>
																		</div>
																	</div>
																	<!--end::Accordion-->
																</div>
																<!-- end 6th row -->
															</div>
														</li>
													</ul>
												</li>
											</ul>
										</div>
									</div>
									<div class="tab-pane" id="kt_portlet_base_demo_2_2_tab_content" role="tabpanel">
										<div id="organization">
											<ul class="tree-view">
												<li>
													<input type="checkbox" id="c5" />
													<div class="row">
														<div class="col-md-5">
															<!--begin::Accordion-->
															<div class="accordion accordion-solid accordion-toggle-plus" id="accordionExample5">
																<div class="card">
																	<div class="card-header" id="headingOne5">
																		<div class="card-title collapsed" data-toggle="collapse" data-target="#collapseOne5"
																			aria-expanded="false" aria-controls="collapseOne5">
																			<label class="tree_label" for="c5"></label> Vice President
																		</div>
																	</div>
																	<div id="collapseOne5" class="collapse" aria-labelledby="headingOne5"
																		data-parent="#accordionExample5" style="">
																		<div class="card-body">
																			<div
																				class="kt-portlet kt-callout kt-callout--info kt-callout--diagonal-bg bg-struktur bg-struktur">
																				<div class="kt-portlet__body m-0 p-0">
																					<div class="kt-callout__body">
																						<div class="kt-callout__content">
																							<h3 class="text-right kt-font-bolder">Jason Muller
																								<br /><small>GOF03055</small></h3>
																							<span class="text-left"><i class="fa fa-phone"></i>
																								082119071726</span><br />
																							<span class="text-left"><i class="flaticon2-new-email"></i>
																								jason@siastudio.com</span>
																						</div>
																					</div>
																				</div>
																			</div>
																		</div>
																	</div>
																</div>
															</div>
															<!--end::Accordion-->
														</div>
														<!-- end 6th row -->
													</div>
													<ul>
														<li>
															<input type="checkbox" id="c6" />
															<div class="row">
																<div class="col-md-5">
																	<!--begin::Accordion-->
																	<div class="accordion accordion-solid accordion-toggle-plus" id="accordionExample6">
																		<div class="card">
																			<div class="card-header" id="headingOne6">
																				<div class="card-title collapsed" data-toggle="collapse"
																					data-target="#collapseOne6" aria-expanded="false"
																					aria-controls="collapseOne6">
																					<label class="tree_label" for="c6"></label> Manager
																				</div>
																			</div>
																			<div id="collapseOne6" class="collapse" aria-labelledby="headingOne6"
																				data-parent="#accordionExample6" style="">
																				<div class="card-body">
																					<div
																						class="kt-portlet kt-callout kt-callout--info kt-callout--diagonal-bg bg-struktur">
																						<div class="kt-portlet__body m-0 p-0">
																							<div class="kt-callout__body">
																								<div class="kt-callout__content">
																									<h3 class="text-right kt-font-bolder">Jason Muller
																										<br /><small>GOF03055</small>
																									</h3>
																									<span class="text-left"><i class="fa fa-phone"></i>
																										082119071726</span><br />
																									<span class="text-left"><i class="flaticon2-new-email"></i>
																										jason@siastudio.com</span>
																								</div>
																							</div>
																						</div>
																					</div>
																				</div>
																			</div>
																		</div>
																	</div>
																	<!--end::Accordion-->
																</div>
																<!-- end 6th row -->
															</div>
															<ul>
																<li>
																	<input type="checkbox" id="c7" />
																	<div class="row">
																		<div class="col-md-5">
																			<!--begin::Accordion-->
																			<div class="accordion accordion-solid accordion-toggle-plus"
																				id="accordionExample7">
																				<div class="card">
																					<div class="card-header" id="headingOne7">
																						<div class="card-title collapsed" data-toggle="collapse"
																							data-target="#collapseOne7" aria-expanded="false"
																							aria-controls="collapseOne7">
																							<label class="tree_label" for="c7"></label> Sr Officer
																						</div>
																					</div>
																					<div id="collapseOne7" class="collapse" aria-labelledby="headingOne7"
																						data-parent="#accordionExample7" style="">
																						<div class="card-body">
																							<div
																								class="kt-portlet kt-callout kt-callout--info kt-callout--diagonal-bg bg-struktur">
																								<div class="kt-portlet__body m-0 p-0">
																									<div class="kt-callout__body">
																										<div class="kt-callout__content">
																											<h3 class="text-right kt-font-bolder">Jason Muller
																												<br /><small>GOF03055</small>
																											</h3>
																											<span class="text-left"><i class="fa fa-phone"></i>
																												082119071726</span><br />
																											<span class="text-left"><i class="flaticon2-new-email"></i>
																												jason@siastudio.com</span>
																										</div>
																									</div>
																								</div>
																							</div>
																						</div>
																					</div>
																				</div>
																			</div>
																			<!--end::Accordion-->
																		</div>
																		<!-- end 6th row -->
																	</div>
																	<ul>
																		<li>
																			<input type="checkbox" id="c8" />
																			<div class="row">
																				<div class="col-md-5">
																					<!--begin::Accordion-->
																					<div class="accordion accordion-solid accordion-toggle-plus"
																						id="accordionExample8">
																						<div class="card">
																							<div class="card-header" id="headingOne8">
																								<div class="card-title collapsed" data-toggle="collapse"
																									data-target="#collapseOne8" aria-expanded="false"
																									aria-controls="collapseOne8">
																									<label class="tree_label" for="c8"></label> Officer
																								</div>
																							</div>
																							<div id="collapseOne8" class="collapse" aria-labelledby="headingOne8"
																								data-parent="#accordionExample8" style="">
																								<div class="card-body">
																									<div
																										class="kt-portlet kt-callout kt-callout--info kt-callout--diagonal-bg bg-struktur">
																										<div class="kt-portlet__body m-0 p-0">
																											<div class="kt-callout__body">
																												<div class="kt-callout__content">
																													<h3 class="text-right kt-font-bolder">Jason Muller
																														<br /><small>GOF03055</small>
																													</h3>
																													<span class="text-left"><i class="fa fa-phone"></i>
																														082119081826</span><br />
																													<span class="text-left"><i class="flaticon2-new-email"></i>
																														jason@siastudio.com</span>
																												</div>
																											</div>
																										</div>
																									</div>
																								</div>
																							</div>
																						</div>
																					</div>
																					<!--end::Accordion-->
																				</div>
																				<!-- end 6th row -->
																			</div>
																			<ul>
																				<li>
																					<input type="checkbox" id="c9" />
																					<div class="row">
																						<div class="col-md-5">
																							<!--begin::Accordion-->
																							<div class="accordion accordion-solid accordion-toggle-plus"
																								id="accordionExample9">
																								<div class="card">
																									<div class="card-header" id="headingOne9">
																										<div class="card-title collapsed" data-toggle="collapse"
																											data-target="#collapseOne9" aria-expanded="false"
																											aria-controls="collapseOne9">
																											<label class="tree_label" for="c9"></label> Jr Officer
																										</div>
																									</div>
																									<div id="collapseOne9" class="collapse" aria-labelledby="headingOne9"
																										data-parent="#accordionExample9" style="">
																										<div class="card-body">
																											<div
																												class="kt-portlet kt-callout kt-callout--info kt-callout--diagonal-bg bg-struktur">
																												<div class="kt-portlet__body m-0 p-0">
																													<div class="kt-callout__body">
																														<div class="kt-callout__content">
																															<h3 class="text-right kt-font-bolder">Jason Muller
																																<br /><small>GOF03055</small>
																															</h3>
																															<span class="text-left"><i class="fa fa-phone"></i>
																																092119091926</span><br />
																															<span class="text-left"><i
																																	class="flaticon2-new-email"></i>
																																jason@siastudio.com</span>
																														</div>
																													</div>
																												</div>
																											</div>
																										</div>
																									</div>
																								</div>
																							</div>
																							<!--end::Accordion-->
																						</div>
																						<!-- end 6th row -->
																					</div>
																				</li>
																				<li>
																					<div class="row">
																						<div class="col-md-5">
																							<!--begin::Accordion-->
																							<div class="accordion accordion-solid accordion-toggle-plus"
																								id="accordionExample91">
																								<div class="card">
																									<div class="card-header" id="headingOne91">
																										<div class="card-title collapsed" data-toggle="collapse"
																											data-target="#collapseOne91" aria-expanded="false"
																											aria-controls="collapseOne91">
																											<span class="tree_label"></span> Jr Officer
																										</div>
																									</div>
																									<div id="collapseOne91" class="collapse"
																										aria-labelledby="headingOne91" data-parent="#accordionExample91"
																										style="">
																										<div class="card-body">
																											<div
																												class="kt-portlet kt-callout kt-callout--info kt-callout--diagonal-bg bg-struktur">
																												<div class="kt-portlet__body m-0 p-0">
																													<div class="kt-callout__body">
																														<div class="kt-callout__content">
																															<h3 class="text-right kt-font-bolder">Jason Muller
																																<br /><small>GOF03055</small>
																															</h3>
																															<span class="text-left"><i class="fa fa-phone"></i>
																																082119081826</span><br />
																															<span class="text-left"><i
																																	class="flaticon2-new-email"></i>
																																jason@siastudio.com</span>
																														</div>
																													</div>
																												</div>
																											</div>
																										</div>
																									</div>
																								</div>
																							</div>
																							<!--end::Accordion-->
																						</div>
																						<!-- end 6th row -->
																					</div>
																				</li>
																			</ul>
																		</li>
																		<li>
																			<div class="row">
																				<div class="col-md-5">
																					<!--begin::Accordion-->
																					<div class="accordion accordion-solid accordion-toggle-plus"
																						id="accordionExample81">
																						<div class="card">
																							<div class="card-header" id="headingOne81">
																								<div class="card-title collapsed" data-toggle="collapse"
																									data-target="#collapseOne81" aria-expanded="false"
																									aria-controls="collapseOne81">
																									<span class="tree_label"></span> Officer
																								</div>
																							</div>
																							<div id="collapseOne81" class="collapse" aria-labelledby="headingOne81"
																								data-parent="#accordionExample81" style="">
																								<div class="card-body">
																									<div
																										class="kt-portlet kt-callout kt-callout--info kt-callout--diagonal-bg bg-struktur">
																										<div class="kt-portlet__body m-0 p-0">
																											<div class="kt-callout__body">
																												<div class="kt-callout__content">
																													<h3 class="text-right kt-font-bolder">Jason Muller
																														<br /><small>GOF03055</small>
																													</h3>
																													<span class="text-left"><i class="fa fa-phone"></i>
																														082119081826</span><br />
																													<span class="text-left"><i class="flaticon2-new-email"></i>
																														jason@siastudio.com</span>
																												</div>
																											</div>
																										</div>
																									</div>
																								</div>
																							</div>
																						</div>
																					</div>
																					<!--end::Accordion-->
																				</div>
																				<!-- end 6th row -->
																			</div>
																		</li>
																	</ul>
																</li>
																<li>
																	<div class="row">
																		<div class="col-md-5">
																			<!--begin::Accordion-->
																			<div class="accordion accordion-solid accordion-toggle-plus"
																				id="accordionExample71">
																				<div class="card">
																					<div class="card-header" id="headingOne71">
																						<div class="card-title collapsed" data-toggle="collapse"
																							data-target="#collapseOne71" aria-expanded="false"
																							aria-controls="collapseOne71">
																							<span class="tree_label"></span> Sr Officer 2
																						</div>
																					</div>
																					<div id="collapseOne71" class="collapse" aria-labelledby="headingOne71"
																						data-parent="#accordionExample71" style="">
																						<div class="card-body">
																							<div
																								class="kt-portlet kt-callout kt-callout--info kt-callout--diagonal-bg bg-struktur">
																								<div class="kt-portlet__body m-0 p-0">
																									<div class="kt-callout__body">
																										<div class="kt-callout__content">
																											<h3 class="text-right kt-font-bolder">Jason Muller
																												<br /><small>GOF03055</small>
																											</h3>
																											<span class="text-left"><i class="fa fa-phone"></i>
																												082119071726</span><br />
																											<span class="text-left"><i class="flaticon2-new-email"></i>
																												jason@siastudio.com</span>
																										</div>
																									</div>
																								</div>
																							</div>
																						</div>
																					</div>
																				</div>
																			</div>
																			<!--end::Accordion-->
																		</div>
																		<!-- end 6th row -->
																	</div>
																</li>
															</ul>
														</li>
														<li>
															<div class="row">
																<div class="col-md-5">
																	<!--begin::Accordion-->
																	<div class="accordion accordion-solid accordion-toggle-plus" id="accordionExample61">
																		<div class="card">
																			<div class="card-header" id="headingOne61">
																				<div class="card-title collapsed" data-toggle="collapse"
																					data-target="#collapseOne61" aria-expanded="false"
																					aria-controls="collapseOne61">
																					<span class="tree_label"></span> Manager 2
																				</div>
																			</div>
																			<div id="collapseOne61" class="collapse" aria-labelledby="headingOne61"
																				data-parent="#accordionExample61" style="">
																				<div class="card-body">
																					<div
																						class="kt-portlet kt-callout kt-callout--info kt-callout--diagonal-bg bg-struktur">
																						<div class="kt-portlet__body m-0 p-0">
																							<div class="kt-callout__body">
																								<div class="kt-callout__content">
																									<h3 class="text-right kt-font-bolder">Jason Muller
																										<br /><small>GOF03055</small>
																									</h3>
																									<span class="text-left"><i class="fa fa-phone"></i>
																										082119071726</span><br />
																									<span class="text-left"><i class="flaticon2-new-email"></i>
																										jason@siastudio.com</span>
																								</div>
																							</div>
																						</div>
																					</div>
																				</div>
																			</div>
																		</div>
																	</div>
																	<!--end::Accordion-->
																</div>
																<!-- end 6th row -->
															</div>
														</li>
													</ul>
												</li>
											</ul>
										</div>
									</div>
								</div>
							</div>
						</div>

					</div>


					<!-- end:: Section -->

					<!-- end:: Content -->
				</div>
				<!-- end:: Content -->

			</div>


		</div>
	</div>
	

	<!-- end:: Page -->

	<!-- begin::Quick Panel -->
	<div id="kt_quick_panel" class="kt-quick-panel">
		<a href="#" class="kt-quick-panel__close" id="kt_quick_panel_close_btn"><i class="flaticon2-delete"></i></a>
		<div class="kt-quick-panel__nav">
			<ul
				class="nav nav-tabs nav-tabs-line nav-tabs-bold nav-tabs-line-3x nav-tabs-line-brand  kt-notification-item-padding-x"
				role="tablist">
				<li class="nav-item active">
					<a class="nav-link active" data-toggle="tab" href="#kt_quick_panel_tab_notifications"
						role="tab">Notifications</a>
				</li>
				<li class="nav-item">
					<a class="nav-link" data-toggle="tab" href="#kt_quick_panel_tab_logs" role="tab">Audit Logs</a>
				</li>
				<li class="nav-item">
					<a class="nav-link" data-toggle="tab" href="#kt_quick_panel_tab_settings" role="tab">Settings</a>
				</li>
			</ul>
		</div>
		<div class="kt-quick-panel__content">
			<div class="tab-content">
				<div class="tab-pane fade show kt-scroll active" id="kt_quick_panel_tab_notifications" role="tabpanel">
					<div class="kt-notification">
						<a href="#" class="kt-notification__item">
							<div class="kt-notification__item-icon">
								<i class="flaticon2-line-chart kt-font-success"></i>
							</div>
							<div class="kt-notification__item-details">
								<div class="kt-notification__item-title">
									New order has been received
								</div>
								<div class="kt-notification__item-time">
									2 hrs ago
								</div>
							</div>
						</a>
						<a href="#" class="kt-notification__item">
							<div class="kt-notification__item-icon">
								<i class="flaticon2-box-1 kt-font-brand"></i>
							</div>
							<div class="kt-notification__item-details">
								<div class="kt-notification__item-title">
									New customer is registered
								</div>
								<div class="kt-notification__item-time">
									3 hrs ago
								</div>
							</div>
						</a>
						<a href="#" class="kt-notification__item">
							<div class="kt-notification__item-icon">
								<i class="flaticon2-chart2 kt-font-danger"></i>
							</div>
							<div class="kt-notification__item-details">
								<div class="kt-notification__item-title">
									Application has been approved
								</div>
								<div class="kt-notification__item-time">
									3 hrs ago
								</div>
							</div>
						</a>
						<a href="#" class="kt-notification__item">
							<div class="kt-notification__item-icon">
								<i class="flaticon2-image-file kt-font-warning"></i>
							</div>
							<div class="kt-notification__item-details">
								<div class="kt-notification__item-title">
									New file has been uploaded
								</div>
								<div class="kt-notification__item-time">
									5 hrs ago
								</div>
							</div>
						</a>
						<a href="#" class="kt-notification__item">
							<div class="kt-notification__item-icon">
								<i class="flaticon2-drop kt-font-info"></i>
							</div>
							<div class="kt-notification__item-details">
								<div class="kt-notification__item-title">
									New user feedback received
								</div>
								<div class="kt-notification__item-time">
									8 hrs ago
								</div>
							</div>
						</a>
						<a href="#" class="kt-notification__item">
							<div class="kt-notification__item-icon">
								<i class="flaticon2-pie-chart-2 kt-font-success"></i>
							</div>
							<div class="kt-notification__item-details">
								<div class="kt-notification__item-title">
									System reboot has been successfully completed
								</div>
								<div class="kt-notification__item-time">
									12 hrs ago
								</div>
							</div>
						</a>
						<a href="#" class="kt-notification__item">
							<div class="kt-notification__item-icon">
								<i class="flaticon2-favourite kt-font-danger"></i>
							</div>
							<div class="kt-notification__item-details">
								<div class="kt-notification__item-title">
									New order has been placed
								</div>
								<div class="kt-notification__item-time">
									15 hrs ago
								</div>
							</div>
						</a>
						<a href="#" class="kt-notification__item kt-notification__item--read">
							<div class="kt-notification__item-icon">
								<i class="flaticon2-safe kt-font-primary"></i>
							</div>
							<div class="kt-notification__item-details">
								<div class="kt-notification__item-title">
									Company meeting canceled
								</div>
								<div class="kt-notification__item-time">
									19 hrs ago
								</div>
							</div>
						</a>
						<a href="#" class="kt-notification__item">
							<div class="kt-notification__item-icon">
								<i class="flaticon2-psd kt-font-success"></i>
							</div>
							<div class="kt-notification__item-details">
								<div class="kt-notification__item-title">
									New report has been received
								</div>
								<div class="kt-notification__item-time">
									23 hrs ago
								</div>
							</div>
						</a>
						<a href="#" class="kt-notification__item">
							<div class="kt-notification__item-icon">
								<i class="flaticon-download-1 kt-font-danger"></i>
							</div>
							<div class="kt-notification__item-details">
								<div class="kt-notification__item-title">
									Finance report has been generated
								</div>
								<div class="kt-notification__item-time">
									25 hrs ago
								</div>
							</div>
						</a>
						<a href="#" class="kt-notification__item">
							<div class="kt-notification__item-icon">
								<i class="flaticon-security kt-font-warning"></i>
							</div>
							<div class="kt-notification__item-details">
								<div class="kt-notification__item-title">
									New customer comment recieved
								</div>
								<div class="kt-notification__item-time">
									2 days ago
								</div>
							</div>
						</a>
						<a href="#" class="kt-notification__item">
							<div class="kt-notification__item-icon">
								<i class="flaticon2-pie-chart kt-font-warning"></i>
							</div>
							<div class="kt-notification__item-details">
								<div class="kt-notification__item-title">
									New customer is registered
								</div>
								<div class="kt-notification__item-time">
									3 days ago
								</div>
							</div>
						</a>
					</div>
				</div>
				<div class="tab-pane fade kt-scroll" id="kt_quick_panel_tab_logs" role="tabpanel">
					<div class="kt-notification-v2">
						<a href="#" class="kt-notification-v2__item">
							<div class="kt-notification-v2__item-icon">
								<i class="flaticon-bell kt-font-brand"></i>
							</div>
							<div class="kt-notification-v2__itek-wrapper">
								<div class="kt-notification-v2__item-title">
									5 new user generated report
								</div>
								<div class="kt-notification-v2__item-desc">
									Reports based on sales
								</div>
							</div>
						</a>
						<a href="#" class="kt-notification-v2__item">
							<div class="kt-notification-v2__item-icon">
								<i class="flaticon2-box kt-font-danger"></i>
							</div>
							<div class="kt-notification-v2__itek-wrapper">
								<div class="kt-notification-v2__item-title">
									2 new items submited
								</div>
								<div class="kt-notification-v2__item-desc">
									by Grog John
								</div>
							</div>
						</a>
						<a href="#" class="kt-notification-v2__item">
							<div class="kt-notification-v2__item-icon">
								<i class="flaticon-psd kt-font-brand"></i>
							</div>
							<div class="kt-notification-v2__itek-wrapper">
								<div class="kt-notification-v2__item-title">
									79 PSD files generated
								</div>
								<div class="kt-notification-v2__item-desc">
									Reports based on sales
								</div>
							</div>
						</a>
						<a href="#" class="kt-notification-v2__item">
							<div class="kt-notification-v2__item-icon">
								<i class="flaticon2-supermarket kt-font-warning"></i>
							</div>
							<div class="kt-notification-v2__itek-wrapper">
								<div class="kt-notification-v2__item-title">
									$2900 worth producucts sold
								</div>
								<div class="kt-notification-v2__item-desc">
									Total 234 items
								</div>
							</div>
						</a>
						<a href="#" class="kt-notification-v2__item">
							<div class="kt-notification-v2__item-icon">
								<i class="flaticon-paper-plane-1 kt-font-success"></i>
							</div>
							<div class="kt-notification-v2__itek-wrapper">
								<div class="kt-notification-v2__item-title">
									4.5h-avarage response time
								</div>
								<div class="kt-notification-v2__item-desc">
									Fostest is Barry
								</div>
							</div>
						</a>
						<a href="#" class="kt-notification-v2__item">
							<div class="kt-notification-v2__item-icon">
								<i class="flaticon2-information kt-font-danger"></i>
							</div>
							<div class="kt-notification-v2__itek-wrapper">
								<div class="kt-notification-v2__item-title">
									Database server is down
								</div>
								<div class="kt-notification-v2__item-desc">
									10 mins ago
								</div>
							</div>
						</a>
						<a href="#" class="kt-notification-v2__item">
							<div class="kt-notification-v2__item-icon">
								<i class="flaticon2-mail-1 kt-font-brand"></i>
							</div>
							<div class="kt-notification-v2__itek-wrapper">
								<div class="kt-notification-v2__item-title">
									System report has been generated
								</div>
								<div class="kt-notification-v2__item-desc">
									Fostest is Barry
								</div>
							</div>
						</a>
						<a href="#" class="kt-notification-v2__item">
							<div class="kt-notification-v2__item-icon">
								<i class="flaticon2-hangouts-logo kt-font-warning"></i>
							</div>
							<div class="kt-notification-v2__itek-wrapper">
								<div class="kt-notification-v2__item-title">
									4.5h-avarage response time
								</div>
								<div class="kt-notification-v2__item-desc">
									Fostest is Barry
								</div>
							</div>
						</a>
					</div>
				</div>
				<div class="tab-pane kt-quick-panel__content-padding-x fade kt-scroll" id="kt_quick_panel_tab_settings"
					role="tabpanel">
					<form class="kt-form">
						<div class="kt-heading kt-heading--sm kt-heading--space-sm">Customer Care</div>
						<div class="form-group form-group-xs row">
							<label class="col-8 col-form-label">Enable Notifications:</label>
							<div class="col-4 kt-align-right">
								<span class="kt-switch kt-switch--success kt-switch--sm">
									<label>
										<input type="checkbox" checked="checked" name="quick_panel_notifications_1">
										<span></span>
									</label>
								</span>
							</div>
						</div>
						<div class="form-group form-group-xs row">
							<label class="col-8 col-form-label">Enable Case Tracking:</label>
							<div class="col-4 kt-align-right">
								<span class="kt-switch kt-switch--success kt-switch--sm">
									<label>
										<input type="checkbox" name="quick_panel_notifications_2">
										<span></span>
									</label>
								</span>
							</div>
						</div>
						<div class="form-group form-group-last form-group-xs row">
							<label class="col-8 col-form-label">Support Portal:</label>
							<div class="col-4 kt-align-right">
								<span class="kt-switch kt-switch--success kt-switch--sm">
									<label>
										<input type="checkbox" checked="checked" name="quick_panel_notifications_2">
										<span></span>
									</label>
								</span>
							</div>
						</div>
						<div class="kt-separator kt-separator--space-md kt-separator--border-dashed"></div>
						<div class="kt-heading kt-heading--sm kt-heading--space-sm">Reports</div>
						<div class="form-group form-group-xs row">
							<label class="col-8 col-form-label">Generate Reports:</label>
							<div class="col-4 kt-align-right">
								<span class="kt-switch kt-switch--sm kt-switch--danger">
									<label>
										<input type="checkbox" checked="checked" name="quick_panel_notifications_3">
										<span></span>
									</label>
								</span>
							</div>
						</div>
						<div class="form-group form-group-xs row">
							<label class="col-8 col-form-label">Enable Report Export:</label>
							<div class="col-4 kt-align-right">
								<span class="kt-switch kt-switch--sm kt-switch--danger">
									<label>
										<input type="checkbox" name="quick_panel_notifications_3">
										<span></span>
									</label>
								</span>
							</div>
						</div>
						<div class="form-group form-group-last form-group-xs row">
							<label class="col-8 col-form-label">Allow Data Collection:</label>
							<div class="col-4 kt-align-right">
								<span class="kt-switch kt-switch--sm kt-switch--danger">
									<label>
										<input type="checkbox" checked="checked" name="quick_panel_notifications_4">
										<span></span>
									</label>
								</span>
							</div>
						</div>
						<div class="kt-separator kt-separator--space-md kt-separator--border-dashed"></div>
						<div class="kt-heading kt-heading--sm kt-heading--space-sm">Memebers</div>
						<div class="form-group form-group-xs row">
							<label class="col-8 col-form-label">Enable Member singup:</label>
							<div class="col-4 kt-align-right">
								<span class="kt-switch kt-switch--sm kt-switch--brand">
									<label>
										<input type="checkbox" checked="checked" name="quick_panel_notifications_5">
										<span></span>
									</label>
								</span>
							</div>
						</div>
						<div class="form-group form-group-xs row">
							<label class="col-8 col-form-label">Allow User Feedbacks:</label>
							<div class="col-4 kt-align-right">
								<span class="kt-switch kt-switch--sm kt-switch--brand">
									<label>
										<input type="checkbox" name="quick_panel_notifications_5">
										<span></span>
									</label>
								</span>
							</div>
						</div>
						<div class="form-group form-group-last form-group-xs row">
							<label class="col-8 col-form-label">Enable Customer Portal:</label>
							<div class="col-4 kt-align-right">
								<span class="kt-switch kt-switch--sm kt-switch--brand">
									<label>
										<input type="checkbox" checked="checked" name="quick_panel_notifications_6">
										<span></span>
									</label>
								</span>
							</div>
						</div>
					</form>
				</div>
			</div>
		</div>
	</div>
	<!-- end::Quick Panel -->

	<!-- begin::Scrolltop -->
	<div id="kt_scrolltop" class="kt-scrolltop">
		<i class="fa fa-arrow-up"></i>
	</div>

	<!-- end::Scrolltop -->


	<!-- begin::Global Config(global config for global JS sciprts) -->
	<script>
		var KTAppOptions = {
			"colors": {
				"state": {
					"brand": "#5d78ff",
					"dark": "#282a3c",
					"light": "#ffffff",
					"primary": "#5867dd",
					"success": "#34bfa3",
					"info": "#36a3f7",
					"warning": "#ffb822",
					"danger": "#fd3995"
				},
				"base": {
					"label": [
						"#c5cbe3",
						"#a1a8c3",
						"#3d4465",
						"#3e4466"
					],
					"shape": [
						"#f0f3ff",
						"#d9dffa",
						"#afb4d4",
						"#646c9a"
					]
				}
			}
		};
	</script>

	<!-- end::Global Config -->

	<!--begin::Global Theme Bundle(used by all pages) -->
<%--	<script src="assets/plugins/global/plugins.bundle.js" type="text/javascript"></script>
	<script src="assets/js/scripts.bundle.js" type="text/javascript"></script>--%>
    
    <script src="<%: ResolveUrl("~/Content/assets/plugins/global/plugins.bundle.js") %>" type="text/javascript"></script>
    <script src="<%: ResolveUrl("~/Content/assets/js/scripts.bundle.js") %>" type="text/javascript"></script>
	<!--end::Page Scripts -->
</body>

<!-- end::Body -->

</html>