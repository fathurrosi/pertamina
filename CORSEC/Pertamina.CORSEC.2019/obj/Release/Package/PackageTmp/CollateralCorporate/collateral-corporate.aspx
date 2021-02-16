<%@ Page Title="" Language="C#" MasterPageFile="~/Frontend.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="collateral-corporate.aspx.cs" Inherits="Pertamina.CORSEC._2019.CollateralCorporate.collateral_corporate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">

    <!-- begin:: Content -->
    <div class="kt-content-height">
        <div class="kt-content kt-content--fit-top  kt-grid__item kt-grid__item--fluid kt-grid kt-grid--hor"
            id="kt_content">

            <!-- begin:: Content -->

            <!-- begin:: Hero -->
           <%-- <div class="kt-sc" style="background-image: url('assets/media/bg/bg-9.jpg')">
                <div class="kt-container ">

                    <div class="kt-sc__bottom">
                        <h3 class="kt-sc__heading kt-heading kt-heading--center kt-heading--xxl kt-heading--medium">
                            <asp:Label ID="lblTitle" runat="server" Text="Collateral corporate (kalender, agenda, kartu ucapan)"></asp:Label>

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
                                    <asp:Label ID="lblTitle" runat="server" Text=""></asp:Label>
                                </h2>
                            </div>
                            <div class="kt-infobox__body">
                                <div class="kt-infobox__section">
                                    <div class="kt-infobox__content">
                                        <asp:Literal ID="lblIsi" runat="server"></asp:Literal>

                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div class="kt-container">
                <div class="row">
                    <asp:Literal ID="lblDetail" runat="server"></asp:Literal>

                    
<%--                    <div class="col-md-4">
                        <div class="kt-portlet kt-portlet--height-fluid kt-widget19">
                            <div class="kt-portlet__body kt-portlet__body--fit kt-portlet__body--unfill">
                                <div class="kt-widget19__pic kt-portlet-fit--top kt-portlet-fit--sides"
                                    style="min-height: 200px; background-image: url(assets/media/products/product27.jpg)">
                                    <h3 class="kt-widget19__title kt-font-light">Kalendar
                                    </h3>
                                    <div class="kt-widget19__shadow"></div>
                                </div>
                            </div>
                            <div class="kt-portlet__body">
                                <div class="kt-widget19__wrapper">
                                    <div class="kt-widget19__text">
                                        Lorem Ipsum is simply dummy text of the printing and typesetting scrambled a type specimen book text
												of the dummy text of the printing printing and typesetting industry scrambled dummy text of the
												printing.
                                    </div>
                                </div>
                                <div class="kt-widget19__action">
                                    <a href="kalendar.html" class="btn btn-sm btn-label-brand btn-bold pull-right">Lihat...</a>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-4">
                        <div class="kt-portlet kt-portlet--height-fluid kt-widget19">
                            <div class="kt-portlet__body kt-portlet__body--fit kt-portlet__body--unfill">
                                <div class="kt-widget19__pic kt-portlet-fit--top kt-portlet-fit--sides"
                                    style="min-height: 200px; background-image: url(assets/media/products/product21.jpg)">
                                    <h3 class="kt-widget19__title kt-font-light">Agenda
                                    </h3>
                                    <div class="kt-widget19__shadow"></div>
                                </div>
                            </div>
                            <div class="kt-portlet__body">
                                <div class="kt-widget19__wrapper">
                                    <div class="kt-widget19__text">
                                        Lorem Ipsum is simply dummy text of the printing and typesetting scrambled a type specimen book text
												of the dummy text of the printing printing and typesetting industry scrambled dummy text of the
												printing.
                                    </div>
                                </div>
                                <div class="kt-widget19__action">
                                    <a href="agenda.html" class="btn btn-sm btn-label-brand btn-bold pull-right">Lihat...</a>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-4">
                        <div class="kt-portlet kt-portlet--height-fluid kt-widget19">
                            <div class="kt-portlet__body kt-portlet__body--fit kt-portlet__body--unfill">
                                <div class="kt-widget19__pic kt-portlet-fit--top kt-portlet-fit--sides"
                                    style="min-height: 200px; background-image: url(assets/media/products/product15.jpg)">
                                    <h3 class="kt-widget19__title kt-font-light">Kartu Ucapan
                                    </h3>
                                    <div class="kt-widget19__shadow"></div>
                                </div>
                            </div>
                            <div class="kt-portlet__body">
                                <div class="kt-widget19__wrapper">
                                    <div class="kt-widget19__text">
                                        Lorem Ipsum is simply dummy text of the printing and typesetting scrambled a type specimen book text
												of the dummy text of the printing printing and typesetting industry scrambled dummy text of the
												printing.
                                    </div>
                                </div>
                                <div class="kt-widget19__action">
                                    <a href="kartu-ucapan.html" class="btn btn-sm btn-label-brand btn-bold pull-right">Lihat...</a>
                                </div>
                            </div>
                        </div>
                    </div>--%>


                </div>

            </div>
            <!-- end:: Section -->

            <!-- end:: Content -->
        </div>
    </div>
    <!-- end:: Content -->

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="script" runat="server">
</asp:Content>
