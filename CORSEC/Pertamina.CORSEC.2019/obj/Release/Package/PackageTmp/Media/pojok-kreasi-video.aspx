<%@ Page Title="" Language="C#" MasterPageFile="~/Frontend.Master" AutoEventWireup="true" CodeBehind="pojok-kreasi-video.aspx.cs" Inherits="Pertamina.CORSEC._2019.Media.pojok_kreasi_video" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">

    <!-- begin:: Content -->
    <div class="kt-content-height">
        <div class="kt-content kt-content--fit-top  kt-grid__item kt-grid__item--fluid kt-grid kt-grid--hor"
            id="kt_content">
            <!-- begin:: Content -->
            <!-- begin:: Hero -->
            <asp:Literal ID="lblHeader" runat="server"></asp:Literal>
            <div class="kt-container">
                <div class="kt-portlet">
                    <div class="kt-portlet__head">
                        <div class="kt-portlet__head-label">
                            <h3>
                                <asp:Label ID="lblTitle" runat="server" Text=""></asp:Label></h3>
                        </div>
                    </div>
                    <div class="kt-portlet__body">
                        <div style="display: flex; justify-content: center;">
                            <asp:Literal runat="server" ID="lblImages"></asp:Literal>
                        </div>


                    </div>
                </div>

                <a href="Infographic.aspx" id="aBack" runat="server" class="btn btn-secondary mt-4"><i class="fa fa-less-than"></i>
                    Back</a>

            </div>
            <!-- end:: Content -->
        </div>
    </div>
    <!-- end:: Content -->


</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="script" runat="server">
</asp:Content>
