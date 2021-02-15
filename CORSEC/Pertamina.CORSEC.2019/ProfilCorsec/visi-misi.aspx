<%@ Page Title="" Language="C#" MasterPageFile="~/Frontend.Master" AutoEventWireup="true" CodeBehind="visi-misi.aspx.cs" Inherits="Pertamina.CORSEC._2019.ProfilCorsec.visi_misi" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">





    <!-- begin:: Content -->
    <div class="kt-content-height">
        <div class="kt-content  kt-content--fit-top  kt-grid__item kt-grid__item--fluid kt-grid kt-grid--hor"
            id="kt_content">

            <!-- begin:: Content -->

            <!-- begin:: Hero -->
            <%--     <div class="kt-sc" style="background-image: url('assets/media/bg/bg-9.jpg')">
                <div class="kt-container ">

                    <div class="kt-sc__bottom">
                        <h3 class="kt-sc__heading kt-heading kt-heading--center kt-heading--xxl kt-heading--medium">Visi Misi PT Pertamina
                        </h3>

                    </div>
                </div>
            </div>--%>
            <asp:Literal ID="lblHeader" runat="server"></asp:Literal>
            <!-- end:: Hero -->

            <div class="kt-container">
                <div class="kt-portlet">
                    <div class="kt-portlet__head">
                        <div class="kt-portlet__head-toolbar">
                            <ul class="nav nav-pills nav-fill" role="tablist">
                                <li class="nav-item">
                                    <a class="nav-link active" data-toggle="tab" href="#kt_portlet_base_demo_2_3_tab_content"
                                        role="tab" aria-selected="true">
                                        <asp:Label ID="lblTab1" runat="server" Text="Label"></asp:Label>
                                    </a>
                                </li>
                                <li class="nav-item">
                                    <a class="nav-link" data-toggle="tab" href="#kt_portlet_base_demo_2_2_tab_content" role="tab"
                                        aria-selected="false">
                                        <asp:Label ID="lblTab2" runat="server" Text="Label"></asp:Label>
                                    </a>
                                </li>
                            </ul>
                        </div>
                    </div>
                    <div class="kt-portlet__body">
                        <div class="tab-content">
                            <div class="tab-pane active" id="kt_portlet_base_demo_2_3_tab_content" role="tabpanel">
                                <div class="kt-infobox">
                                    <div class="kt-infobox__header">
                                        <h2 class="kt-infobox__title">
                                            <asp:Label ID="lblTitle1" runat="server" Text="Label"></asp:Label></h2>
                                    </div>
                                    <div class="kt-infobox__body">
                                        <div class="kt-infobox__section">
                                            <h3 class="kt-infobox__subtitle">
                                                <asp:Label ID="lblSubtitle1" runat="server" Text="Label"></asp:Label></h3>
                                            <div class="kt-infobox__content text-justify">
                                                <asp:Literal ID="lblContent1" runat="server"></asp:Literal>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-lg-6">
                                        <div class="kt-portlet kt-callout">
                                            <div class="kt-portlet__body">
                                                <div class="kt-callout__body">
                                                    <div class="kt-callout__content">
                                                        <h3 class="kt-callout__title">
                                                            <asp:Label ID="lblVisi1" runat="server" Text="Label"></asp:Label></h3>
                                                        <p class="kt-callout__desc">
                                                            <asp:Literal ID="lblVisiContent1" runat="server"></asp:Literal>
                                                        </p>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-lg-6">
                                        <div class="kt-portlet kt-callout">
                                            <div class="kt-portlet__body">
                                                <div class="kt-callout__body">
                                                    <div class="kt-callout__content">
                                                        <h3 class="kt-callout__title">
                                                            <asp:Label ID="lblMisi1" runat="server" Text="Label"></asp:Label></h3>
                                                        <p class="kt-callout__desc">
                                                            <asp:Literal ID="lblMisiContent1" runat="server"></asp:Literal>
                                                        </p>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="tab-pane" id="kt_portlet_base_demo_2_2_tab_content" role="tabpanel">
                                <div class="kt-infobox">
                                    <div class="kt-infobox__header">
                                        <h2 class="kt-infobox__title">
                                            <asp:Label ID="lblTitle2" runat="server" Text="Label"></asp:Label></h2>
                                    </div>
                                    <div class="kt-infobox__body">
                                        <div class="kt-infobox__section">
                                            <h3 class="kt-infobox__subtitle">
                                                <asp:Label ID="lblSubtitle2" runat="server" Text="Label"></asp:Label></h3>
                                            <div class="kt-infobox__content text-justify">
                                                <asp:Literal ID="lblContent2" runat="server"></asp:Literal>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-lg-6">
                                        <div class="kt-portlet kt-callout">
                                            <div class="kt-portlet__body">
                                                <div class="kt-callout__body">
                                                    <div class="kt-callout__content">
                                                        <h3 class="kt-callout__title">
                                                            <asp:Label ID="lblVisi2" runat="server" Text="Label"></asp:Label></h3>
                                                        <p class="kt-callout__desc">
                                                            <asp:Literal ID="lblVisiContent2" runat="server"></asp:Literal>
                                                        </p>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-lg-6">
                                        <div class="kt-portlet kt-callout">
                                            <div class="kt-portlet__body">
                                                <div class="kt-callout__body">
                                                    <div class="kt-callout__content">
                                                        <h3 class="kt-callout__title">
                                                            <asp:Label ID="lblMisi2" runat="server" Text="Label"></asp:Label></h3>
                                                        <p class="kt-callout__desc">
                                                            <asp:Literal ID="lblMisiContent2" runat="server"></asp:Literal>
                                                        </p>
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
        </div>
    </div>
    <!-- end:: Content -->

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="script" runat="server">
</asp:Content>
