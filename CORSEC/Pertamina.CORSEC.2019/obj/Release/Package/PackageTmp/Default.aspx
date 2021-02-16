<%@ Page Title="" Language="C#" MasterPageFile="~/Frontend.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Pertamina.CORSEC._2019.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">

    
        <!-- end:: Header -->
        <div class="kt-content-sm  kt-grid__item kt-grid__item--fluid kt-grid kt-grid--hor" id="kt_content_header">

          <!-- begin:: Content Head -->
          <div class="kt-subheader  kt-grid__item" id="kt_subheader">
            <div class="kt-container  kt-container--fluid ">
              <div class="kt-subheader__main">
                <h3 class="kt-subheader__title">Dashboard</h3>
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
        <div class="kt-content-height">
          <div class="kt-content  kt-content--fit-top  kt-grid__item kt-grid__item--fluid kt-grid kt-grid--hor"
						id="kt_content">

            <div class="kt-container ">
              <div class="kt-portlet">
                <div class="kt-portlet__head">
                  <div class="kt-portlet__head-label">
                    <h3 class="kt-portlet__head-title">
                      <i class="flaticon-notes"></i> Berita & Artikel
                    </h3>
                  </div>
                  <div class="kt-portlet__head-toolbar">
                    <div class="kt-section kt-section--last">
                      <a href="#" class="btn btn-label-brand btn-sm btn-bold"><i class=""></i> Lihat semua berita <i
                          class="flaticon2-right-arrow kt-icon-sm"></i></a>
                    </div>
                    <div class="dropdown-menu dropdown-menu-right dropdown-menu-fit dropdown-menu-md">
                      <!--end::Nav-->
                    </div>
                  </div>
                </div>
                <div class="kt-portlet__body">

                  <div class="row">

                    <div class="col-md-4">
                      <!--begin:: Widgets/Blog-->
                      <div class="kt-portlet kt-portlet--height-fluid kt-widget19">
                        <div class="kt-portlet__body kt-portlet__body--fit kt-portlet__body--unfill">
                          <div class="kt-widget19__pic kt-portlet-fit--top kt-portlet-fit--sides"
                            style="min-height: 200px; background-image: url('<%: ResolveUrl("~/Content/assets/media//products/product1.jpg") %>')">
                          </div>
                        </div>
                        <div class="kt-portlet__body bd-thin">
                          <div class="kt-widget19__wrapper">
                            <div class="kt-widget19__content">
                              <div class="kt-widget19__info p-0 p-0">
                                <a href="#" class="kt-widget19__username">
                                  Anna Krox
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
                            <a href="#" class="btn btn-sm btn-label-brand btn-bold">Selengkapnya...</a>
                          </div>
                        </div>
                      </div>

                      <!--end:: Widgets/Blog-->
                    </div>

                    <div class="col-md-4">
                      <!--begin:: Widgets/Blog-->
                      <div class="kt-portlet kt-portlet--height-fluid kt-widget19">
                        <div class="kt-portlet__body kt-portlet__body--fit kt-portlet__body--unfill">
                          <div class="kt-widget19__pic kt-portlet-fit--top kt-portlet-fit--sides"
                            style="min-height: 200px; background-image: url('<%: ResolveUrl("~/Content/assets/media//products/product2.jpg") %>')">
                          </div>
                        </div>
                        <div class="kt-portlet__body bd-thin">
                          <div class="kt-widget19__wrapper">
                            <div class="kt-widget19__content">
                              <div class="kt-widget19__info p-0">
                                <a href="#" class="kt-widget19__username">
                                  Fredie Mccain
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
                            <a href="#" class="btn btn-sm btn-label-brand btn-bold">Selengkapnya...</a>
                          </div>
                        </div>
                      </div>

                      <!--end:: Widgets/Blog-->
                    </div>

                    <div class="col-md-4">
                      <!--begin:: Widgets/Blog-->
                      <div class="kt-portlet kt-portlet--height-fluid kt-widget19">
                        <div class="kt-portlet__body kt-portlet__body--fit kt-portlet__body--unfill">
                          <div class="kt-widget19__pic kt-portlet-fit--top kt-portlet-fit--sides"
                            style="min-height: 200px; background-image: url('<%: ResolveUrl("~/Content/assets/media//products/product3.jpg") %>')">
                          </div>
                        </div>
                        <div class="kt-portlet__body bd-thin">
                          <div class="kt-widget19__wrapper">
                            <div class="kt-widget19__content">
                              <div class="kt-widget19__info p-0">
                                <a href="#" class="kt-widget19__username">
                                  Jane Doe
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
                            <a href="#" class="btn btn-sm btn-label-brand btn-bold">Selengkapnya...</a>
                          </div>
                        </div>
                      </div>

                      <!--end:: Widgets/Blog-->

                    </div>

                  </div>

                </div>
              </div>
            </div>

            <div class="kt-container ">
              <div class="kt-portlet">
                <div class="kt-portlet__head">
                  <div class="kt-portlet__head-label">
                    <span class="kt-portlet__head-icon">
                      <i class="flaticon2-graph-1"></i>
                    </span>
                    <h3 class="kt-portlet__head-title">
                      Featured Article
                    </h3>
                  </div>
                </div>
                <div class="kt-portlet__body">
                  <div class="row">
                    <div class="col-lg-5">
                      <h2 class="kt-mb-20">Selamat datang di Intranet</strong></h2>
                      <p class="lead-2 kt-mb-20">Mauris lobortis nulla ut aliquet interdum. Donec commodo ac elit sed
                        placerat. Mauris
                        rhoncus est ac sodales
                        gravida. In eros felis, elementum aliquam nisi vel, pellentesque faucibus nulla.</p>
                      <a href="#"
                        class="btn btn-primary btn-outline btn-rounded font-weight-semibold text-3 btn-px-5 btn-py-2">Selengkapnya</a>
                    </div>
                    <div class="col-lg-7 mb-60">
                      <iframe class="youtube-media" width="100%" height="300"
                        src="https://www.youtube.com/embed/R_DYsVFFWss" frameborder="0"
                        allow="accelerometer; autoplay; encrypted-media; gyroscope; picture-in-picture" allowfullscreen>
                      </iframe>
                    </div>
                  </div>
                </div>
                <div class="kt-portlet__foot kt-hidden">
                  <div class="row">
                    <div class="col-lg-6">
                      Portlet footer:
                    </div>
                    <div class="col-lg-6">
                      <button type="submit" class="btn btn-primary">Submit</button>
                      <span class="kt-margin-left-10">or <a href="#" class="kt-link kt-font-bold">Cancel</a></span>
                    </div>
                  </div>
                </div>
              </div>
            </div>

            <div class="kt-container ">
              <div class="row">

                <div class="col-md-6">
                  <div class="kt-portlet">
                    <div class="kt-portlet__head">
                      <div class="kt-portlet__head-label">
                        <h3 class="kt-portlet__head-title">
                          Info
                        </h3>
                      </div>
                      <div class="kt-portlet__head-toolbar">
                        <div class="kt-section kt-section--last">
                          <a href="#" class="btn btn-label-brand btn-sm btn-bold"><i class=""></i> Lihat semua berita <i
                              class="flaticon2-right-arrow kt-icon-sm"></i></a>
                        </div>
                        <div class="dropdown-menu dropdown-menu-right dropdown-menu-fit dropdown-menu-md">
                          <!--end::Nav-->
                        </div>
                      </div>
                    </div>
                    <div class="kt-portlet__body">

                      <div class="kt-widget5">
                        <div class="kt-widget5__item kt-align-left">
                          <div class="kt-widget5__content kt-align-left" >
                            <div class="kt-widget5__pic kt-align-left">
                              <img class="kt-widget7__img" src="<%: ResolveUrl("~/Content/assets/media/products/product22.jpg") %>" alt="">
                            </div>
                            <div class="kt-widget5__section kt-align-left">
                              <a href="#" class="kt-widget5__title">
                                Konsolidasi dan Perkuat Bisnis Utama, Pertamina Rasional...
                              </a>
                              <div class="kt-widget5__info kt-mt-10">
                                <span>Author:</span>
                                <span class="kt-font-info">Admin / 23-04-2020</span>
                              </div>
                            </div>
                          </div>
                        </div>
                        <div class="kt-widget5__item">
                          <div class="kt-widget5__content">
                            <div class="kt-widget5__pic kt-align-left">
                              <img class="kt-widget7__img" src="<%: ResolveUrl("~/Content/assets/media/products/product27.jpg") %>" alt="">
                            </div>
                            <div class="kt-widget5__section kt-align-left">
                              <a href="#" class="kt-widget5__title">
                                Konsolidasi dan Perkuat Bisnis Utama, Pertamina Rasional...
                              </a>
                              <div class="kt-widget5__info kt-mt-10">
                                <span>Author:</span>
                                <span class="kt-font-info">Admin / 23-04-2020</span>
                              </div>
                            </div>
                          </div>
                        </div>

                        <div class="kt-widget5__item">
                          <div class="kt-widget5__content">
                            <div class="kt-widget5__pic kt-align-left">
                              <img class="kt-widget7__img" src="<%: ResolveUrl("~/Content/assets/media/products/product25.jpg") %>" alt="">
                            </div>
                            <div class="kt-widget5__section kt-align-left">
                              <a href="#" class="kt-widget5__title">
                                Konsolidasi dan Perkuat Bisnis Utama, Pertamina Rasional...
                              </a>
                              <div class="kt-widget5__info kt-mt-10">
                                <span>Author:</span>
                                <span class="kt-font-info">Admin / 23-04-2020</span>
                              </div>
                            </div>
                          </div>
                        </div>


                      </div>

                    </div>
                  </div>
                </div>

                <div class="col-md-6 kt-pl0 kt-pr-0">
                  <div class="kt-portlet">
                    <div class="kt-portlet__head">
                      <div class="kt-portlet__head-label">
                        <h3 class="kt-portlet__head-title">
                          Event
                        </h3>
                      </div>
                      <div class="kt-portlet__head-toolbar">
                        <div class="kt-section kt-section--last">
                          <a href="#" class="btn btn-label-brand btn-sm btn-bold"><i class=""></i> Lihat semua berita <i
                              class="flaticon2-right-arrow kt-icon-sm"></i></a>
                        </div>
                        <div class="dropdown-menu dropdown-menu-right dropdown-menu-fit dropdown-menu-md">
                          <!--end::Nav-->
                        </div>
                      </div>
                    </div>
                    <div class="kt-portlet__body">

                      <div class="kt-widget5">
                        <div class="kt-widget5__item">
                          <div class="kt-widget5__content">
                            <div class="kt-widget5__pic kt-align-left">
                              <img class="kt-widget7__img" src="<%: ResolveUrl("~/Content/assets/media/products/product11.jpg") %>" alt="">
                            </div>
                            <div class="kt-widget5__section kt-align-left">
                              <a href="#" class="kt-widget5__title">
                                Pertamina Siaga Amankan Pasokan Energi Nasional
                              </a>
                              <div class="kt-widget5__info">
                                <span>Author:</span>
                                <span class="kt-font-info">Admin / 23-04-2020</span>
                              </div>
                            </div>
                          </div>
                        </div>
                        <div class="kt-widget5__item">
                          <div class="kt-widget5__content">
                            <div class="kt-widget5__pic kt-align-left">
                              <img class="kt-widget7__img" src="<%: ResolveUrl("~/Content/assets/media/products/product2.jpg") %>" alt="">
                            </div>
                            <div class="kt-widget5__section kt-align-left">
                              <a href="#" class="kt-widget5__title">
                                Pertamina Siaga Amankan Pasokan Energi Nasional
                              </a>
                              <div class="kt-widget5__info">
                                <span>Author:</span>
                                <span class="kt-font-info">Admin / 23-04-2020</span>
                              </div>
                            </div>
                          </div>
                        </div>

                        <div class="kt-widget5__item">
                          <div class="kt-widget5__content">
                            <div class="kt-widget5__pic kt-align-left">
                              <img class="kt-widget7__img" src="<%: ResolveUrl("~/Content/assets/media/products/product16.jpg") %>" alt="">
                            </div>
                            <div class="kt-widget5__section kt-align-left">
                              <a href="#" class="kt-widget5__title">
                                Pertamina Siaga Amankan Pasokan Energi Nasional
                              </a>
                              <div class="kt-widget5__info">
                                <span>Author:</span>
                                <span class="kt-font-info">Admin / 23-04-2020</span>
                              </div>
                            </div>
                          </div>
                        </div>


                      </div>

                    </div>
                  </div>
                </div>

              </div>
            </div>

          </div>
        </div>
        <!-- end:: Content -->

        <div class="kt-footer  kt-grid__item kt-grid kt-grid--desktop kt-grid--ver-desktop" id="kt_footer"
          style="background: #fdfdfd;">
          <div class="kt-container">

            <div class="row">
              <div class="col-md-4">
                <h5 class="kt-mb-20 kt-mt-20">Link Footer one</h5>
                <div class="kt-widget4">
                  <div class="kt-widget4__item kt-mt-30">
                    <span class="kt-widget4__icon">
                      <i class="flaticon2-right-arrow kt-font-sm kt-font-info"></i>
                    </span>
                    <a href="#" class="kt-widget4__title kt-widget4__title--light">
                      Intranet v6 has been arrived!
                    </a>
                  </div>
                  <div class="kt-widget4__item">
                    <span class="kt-widget4__icon">
                      <i class="flaticon2-right-arrow kt-font-sm kt-font-info"></i>
                    </span>
                    <a href="#" class="kt-widget4__title kt-widget4__title--light">
                      Intranet community meet-up 2019 in Rome.
                    </a>
                  </div>
                  <div class="kt-widget4__item">
                    <span class="kt-widget4__icon">
                      <i class="flaticon2-right-arrow kt-font-sm kt-font-info"></i>
                    </span>
                    <a href="#" class="kt-widget4__title kt-widget4__title--light">
                      Intranet Angular 8 version will be landing soon...
                    </a>
                  </div>
                  <div class="kt-widget4__item">
                    <span class="kt-widget4__icon">
                      <i class="flaticon2-right-arrow kt-font-sm kt-font-info"></i>
                    </span>
                    <a href="#" class="kt-widget4__title kt-widget4__title--light">
                      ale! Purchase Intranet at 70% off for limited time
                    </a>
                  </div>
                </div>
              </div>

              <div class="col-md-4">
                <h5 class="kt-mb-20 kt-mt-20">Link Footer two</h5>
                <div class="kt-widget4">
                  <div class="kt-widget4__item kt-mt-30">
                    <span class="kt-widget4__icon">
                      <i class="flaticon2-right-arrow kt-font-sm kt-font-info"></i>
                    </span>
                    <a href="#" class="kt-widget4__title kt-widget4__title--light">
                      Intranet v6 has been arrived!
                    </a>
                  </div>
                  <div class="kt-widget4__item">
                    <span class="kt-widget4__icon">
                      <i class="flaticon2-right-arrow kt-font-sm kt-font-info"></i>
                    </span>
                    <a href="#" class="kt-widget4__title kt-widget4__title--light">
                      Intranet community meet-up 2019 in Rome.
                    </a>
                  </div>
                  <div class="kt-widget4__item">
                    <span class="kt-widget4__icon">
                      <i class="flaticon2-right-arrow kt-font-sm kt-font-info"></i>
                    </span>
                    <a href="#" class="kt-widget4__title kt-widget4__title--light">
                      Intranet Angular 8 version will be landing soon...
                    </a>
                  </div>
                  <div class="kt-widget4__item">
                    <span class="kt-widget4__icon">
                      <i class="flaticon2-right-arrow kt-font-sm kt-font-info"></i>
                    </span>
                    <a href="#" class="kt-widget4__title kt-widget4__title--light">
                      ale! Purchase Intranet at 70% off for limited time
                    </a>
                  </div>
                </div>
              </div>

              <div class="col-md-4">
                <h5 class="kt-mb-20 kt-mt-20">Link Footer three</h5>
                <div class="kt-widget4">
                  <div class="kt-widget4__item kt-mt-30">
                    <span class="kt-widget4__icon">
                      <i class="flaticon2-right-arrow kt-font-sm kt-font-info"></i>
                    </span>
                    <a href="#" class="kt-widget4__title kt-widget4__title--light">
                      Intranet v6 has been arrived!
                    </a>
                  </div>
                  <div class="kt-widget4__item">
                    <span class="kt-widget4__icon">
                      <i class="flaticon2-right-arrow kt-font-sm kt-font-info"></i>
                    </span>
                    <a href="#" class="kt-widget4__title kt-widget4__title--light">
                      Intranet community meet-up 2019 in Rome.
                    </a>
                  </div>
                  <div class="kt-widget4__item">
                    <span class="kt-widget4__icon">
                      <i class="flaticon2-right-arrow kt-font-sm kt-font-info"></i>
                    </span>
                    <a href="#" class="kt-widget4__title kt-widget4__title--light">
                      Intranet Angular 8 version will be landing soon...
                    </a>
                  </div>
                  <div class="kt-widget4__item">
                    <span class="kt-widget4__icon">
                      <i class="flaticon2-right-arrow kt-font-sm kt-font-info"></i>
                    </span>
                    <a href="#" class="kt-widget4__title kt-widget4__title--light">
                      ale! Purchase Intranet at 70% off for limited time
                    </a>
                  </div>
                </div>
              </div>

            </div>

          </div>
        </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="script" runat="server">
</asp:Content>
