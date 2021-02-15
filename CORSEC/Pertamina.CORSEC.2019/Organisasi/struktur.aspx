<%@ Page Title="" Language="C#" MasterPageFile="~/Frontend.Master" AutoEventWireup="true" CodeBehind="struktur.aspx.cs" Inherits="Pertamina.CORSEC._2019.Organisasi.struktur" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">

    <!-- begin:: Content -->
    <div class="kt-content  kt-content--fit-top  kt-grid__item kt-grid__item--fluid kt-grid kt-grid--hor" id="kt_content">
        <asp:Literal ID="lblHeader" runat="server"></asp:Literal>
        <%--<div class="kt-container ">


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
                    <div class="kt-infobox">
                        <div class="kt-infobox__header">
                            <h2 class="kt-infobox__title">
                                <asp:Label ID="lblTittleSub" runat="server" Text="Label"></asp:Label>
                            </h2>
                        </div>


                        <div class="kt-infobox__body">
                            <div class="kt-infobox__section">
                                <div class="kt-infobox__content">
                                    <asp:Literal ID="lblIsi" runat="server"></asp:Literal>
                                    <h3 class="text-center kt-mb-40 kt-infobox__title">
                                        <asp:Label ID="lblRoot" runat="server" Text="Label"></asp:Label>
                                    </h3>
                                    
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>--%>
        
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
    <!-- end:: Content -->

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="script" runat="server">
</asp:Content>
