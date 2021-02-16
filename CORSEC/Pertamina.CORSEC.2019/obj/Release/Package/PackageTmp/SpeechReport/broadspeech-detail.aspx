<%@ Page Title="" Language="C#" MasterPageFile="~/Frontend.Master" AutoEventWireup="true" CodeBehind="broadspeech-detail.aspx.cs" Inherits="Pertamina.CORSEC._2019.SpeechReport.broadspeech_detail" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <!-- end:: Content Head -->
    <div class="kt-content-height">
        <div class="kt-content kt-content--fit-top  kt-grid__item kt-grid__item--fluid kt-grid kt-grid--hor"
            id="kt_content">

            <!-- begin:: Hero -->
            <%-- <div class="kt-sc" style="background-image: url('/Content/assets/media/bg/bg-9.jpg')">
                <div class="kt-container ">

                    <div class="kt-sc__bottom">
                        <h3 class="kt-sc__heading kt-heading kt-heading--center kt-heading--xxl kt-heading--medium">Broad Speech
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
                                    <asp:Label ID="lblTitle" runat="server" Text=""></asp:Label></h2>
                            </div>
                            <div class="kt-infobox__body">
                                <div class="kt-infobox__section">
                                    <div class="kt-infobox__content">
                                        <div class="row">
                                            <div class="col-md-4">
                                                <%--<div class="kt-widget19__pic kt-portlet-fit--top kt-portlet-fit--sides" style="min-height: 200px; background-image: url(/Content/assets/media//products/product4.jpg)"></div>--%>
                                                  <asp:Literal ID="lblImage" runat="server"></asp:Literal>
                                            </div>
                                            <div class="col-md-8">
                                                <asp:Literal ID="lblIsi" runat="server"></asp:Literal>

                                                <span class="kt-media kt-media--sm">
                                                    <asp:Image ID="imgFile" runat="server" CssClass="kt-mr-10" Height="26" alt="" ImageUrl="~/Content/assets/media/files/jpg.svg" />
                                                    <asp:HyperLink ID="linkFile" CssClass="kt-link kt-font-boldest mt-2" runat="server" data-toggle="kt-tooltip"
                                                        data-skin="dark" data-placement="right" title="Download"></asp:HyperLink>

                                                </span>
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

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="script" runat="server">
</asp:Content>
