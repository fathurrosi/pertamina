<%@ Page Title="" Language="C#" MasterPageFile="~/Custom.Master" AutoEventWireup="true" CodeBehind="struktur.aspx.cs" Inherits="Pertamina.CORSEC._2019.Organisasi.struktur" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!--begin::Fonts -->
    <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Poppins:300,400,500,600,700|Roboto:300,400,500,600,700">
    <!--end::Fonts -->
    <!--begin::Page Vendors Styles(used by this page) -->
    <link href="<%: ResolveUrl("~/Content/assets/plugins/custom/fullcalendar/fullcalendar.bundle.css") %>" rel="stylesheet" type="text/css" />
    <link href="<%: ResolveUrl("~/Content/assets/css/pages/support-center/home-1.css") %>" rel="stylesheet" type="text/css" />
    <link href="<%: ResolveUrl("~/Content/assets/css/custom.css") %>" rel="stylesheet" type="text/css" />
    <link href="<%: ResolveUrl("~/Content/assets/css/product.css") %>" rel="stylesheet" type="text/css" />

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

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div class="kt-content  kt-content--fit-top  kt-grid__item kt-grid__item--fluid kt-grid kt-grid--hor" id="kt_content">
        <asp:Literal ID="lblHeader" runat="server"></asp:Literal>

                <div class="kt-container">
            <div class="kt-portlet">
                <div class="kt-portlet__head">
                    <div class="kt-portlet__head-toolbar">
                        <ul class="nav nav-pills nav-fill" role="tablist">
                            <li class="nav-item">
                                <a class="nav-link active" data-toggle="tab" href="#kt_portlet_base_demo_2_3_tab_content"
                                    role="tab" aria-selected="true">Corsec
                                </a>
                            </li>
                            <li class="nav-item">
                                <a class="nav-link" data-toggle="tab" href="#kt_portlet_base_demo_2_2_tab_content" role="tab"
                                    aria-selected="false">Corcom
                                </a>
                            </li>
                        </ul>
                    </div>
                </div>
                <div class="kt-portlet__body">
                    <div class="tab-content">
                        <div class="tab-pane active" id="kt_portlet_base_demo_2_3_tab_content" role="tabpanel">
                            <asp:Literal ID="lblorganization_Corsec" runat="server"></asp:Literal>
                        </div>
                        <div class="tab-pane" id="kt_portlet_base_demo_2_2_tab_content" role="tabpanel">
                            <asp:Literal ID="lblorganization_Corcom" runat="server"></asp:Literal>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="script" runat="server">
    <script src="<%: ResolveUrl("~/Content/assets/plugins/global/plugins.bundle.js") %>" type="text/javascript"></script>
    <script src="<%: ResolveUrl("~/Content/assets/js/scripts.bundle.js") %>" type="text/javascript"></script>
</asp:Content>
