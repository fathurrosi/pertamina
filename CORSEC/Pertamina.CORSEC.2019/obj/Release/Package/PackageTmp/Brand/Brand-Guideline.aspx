<%@ Page Title="" Language="C#" MasterPageFile="~/Frontend.Master" AutoEventWireup="true" CodeBehind="Brand-Guideline.aspx.cs" Inherits="Pertamina.CORSEC._2019.Brand.Brand_Guideline" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">


    <!-- begin:: Content -->
    <div class="kt-content-height">
        <div class="kt-content kt-content--fit-top  kt-grid__item kt-grid__item--fluid kt-grid kt-grid--hor"
            id="kt_content">

            <!-- begin:: Content -->

            <!-- begin:: Hero -->
            <%--	<div class="kt-sc" style="background-image: url('assets/media/bg/bg-9.jpg')">
						<div class="kt-container ">

							<div class="kt-sc__bottom">
								<h3 class="kt-sc__heading kt-heading kt-heading--center kt-heading--xxl kt-heading--medium">
									Logos (Logo korporat, logo HUT)
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
                                    <asp:Label ID="lblTittle" runat="server" Text=""></asp:Label></h2>
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
            </div>

            <div class="kt-container">
                <div class="row">
                    <div class="col-lg-6">
                        <div class="kt-portlet kt-iconbox kt-iconbox--wave">
                            <div class="kt-portlet__body">
                                <div class="kt-iconbox__body">
                                    <div class="kt-iconbox__desc text-center">
                                        <%--<asp:Literal ID="lblCorporate" runat="server"></asp:Literal>--%>
                                        <a id="corporate" runat="server" href="logo-detail.aspx">
                                            <div class="mb-4">
                                                <div class="media">
                                                    <asp:Image ID="imgThumnail" ImageUrl="~/Content/assets/media/project-logos/3.png" runat="server" alt="photo" Width="100%" />
                                                </div>
                                            </div>
                                            <h3 class="kt-iconbox__title">
                                                <asp:Label ID="lblNamaLogo" runat="server" Text="Label"></asp:Label>
                                            </h3>
                                        </a>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-6">
                        <div class="kt-portlet kt-iconbox kt-iconbox--wave">
                            <div class="kt-portlet__body">
                                <div class="kt-iconbox__body">
                                    <div class="kt-iconbox__desc text-center">
                                        <%--<asp:Literal ID="lblHUT" runat="server"></asp:Literal>--%>
                                        <a id="hut" runat="server" href="logo-detail.aspx">
                                            <div class="mb-4">
                                                <div class="media">
                                                    <asp:Image ID="imgThumnailHUT" ImageUrl="~/Content/assets/media/project-logos/2.png" runat="server" alt="photo" Width="100%" />
                                                </div>
                                            </div>
                                            <h3 class="kt-iconbox__title">
                                                <asp:Label ID="lblNamaLogoHUT" runat="server" Text="Label"></asp:Label>
                                            </h3>
                                        </a>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
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
