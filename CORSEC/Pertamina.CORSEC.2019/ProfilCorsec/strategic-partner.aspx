<%@ Page Title="" Language="C#" MasterPageFile="~/Frontend.Master" AutoEventWireup="true" CodeBehind="strategic-partner.aspx.cs" Inherits="Pertamina.CORSEC._2019.ProfilCorsec.strategic_partner" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
  
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">


    <!-- begin:: Content -->
    <div class="kt-content-height">
        <div class="kt-content  kt-content--fit-top  kt-grid__item kt-grid__item--fluid kt-grid kt-grid--hor"
            id="kt_content">

            <!-- begin:: Content -->

            <!-- begin:: Hero -->
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
                                        <asp:Label ID="lblTab1" runat="server" Text=""></asp:Label>
                                    </a>
                                </li>
                                <li class="nav-item">
                                    <a class="nav-link" data-toggle="tab" href="#kt_portlet_base_demo_2_2_tab_content" role="tab"
                                        aria-selected="false">
                                        <asp:Label ID="lblTab2" runat="server" Text=""></asp:Label>
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
                                            <asp:Label ID="lblTitle1" runat="server" Text=""></asp:Label></h2>
                                    </div>
                                    <div class="kt-infobox__body">
                                        <div class="kt-infobox__section">
                                            <div class="kt-infobox__content text-justify">
                                                <asp:Literal ID="lblContent1" runat="server"></asp:Literal>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="tab-pane" id="kt_portlet_base_demo_2_2_tab_content" role="tabpanel">
                                <div class="kt-infobox">
                                    <div class="kt-infobox__header">
                                        <h2 class="kt-infobox__title">
                                            <asp:Label ID="lblTitle2" runat="server" Text=""></asp:Label></h2>
                                    </div>
                                    <div class="kt-infobox__body">
                                        <div class="kt-infobox__section">
                                            <div class="kt-infobox__content text-justify">
                                                <asp:Literal ID="lblContent2" runat="server"></asp:Literal>
                                            </div>
                                        </div>
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
