<%@ Page Title="" Language="C#" MasterPageFile="~/Frontend.Master" AutoEventWireup="true" CodeBehind="ErrorPage.aspx.cs" Inherits="Pertamina.CORSEC._2019.ErrorPage" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">



    <!-- begin:: Content -->
    <div class="kt-content kt-content--fit-top  kt-grid__item kt-grid__item--fluid kt-grid kt-grid--hor" id="kt_content">

        <!-- begin:: Content -->

        <div class="kt-container kt-pt10">


            <div class="kt-portlet">
                <div class="kt-portlet__body">
                    <div class="kt-infobox">
                        <div class="kt-infobox__header">
                            <h2 class="kt-infobox__title">Ups..!</h2>
                        </div>
                        <div class="kt-infobox__body">
                            <div class="kt-infobox__section">
                                <div class="kt-infobox__content text-justify">
                                    <div class="row">
                                        <div class="col-md-12">
                                            <asp:Label ID="lblMessage" runat="server" Text="Label"></asp:Label>
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
    <!-- end:: Content -->
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="script" runat="server">
</asp:Content>
