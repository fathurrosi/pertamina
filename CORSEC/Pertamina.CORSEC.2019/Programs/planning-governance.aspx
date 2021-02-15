<%@ Page Title="" Language="C#" MasterPageFile="~/Frontend.Master" AutoEventWireup="true" CodeBehind="planning-governance.aspx.cs" Inherits="Pertamina.CORSEC._2019.Programs.planning_governance" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
  .col-md-12 img {
            border: 0px solid #fff;
            border-radius: 4px;
            padding: 10px;
            width: 150px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">


    <!-- begin:: Content -->
    <div class="kt-content kt-content--fit-top  kt-grid__item kt-grid__item--fluid kt-grid kt-grid--hor" id="kt_content">

        <!-- begin:: Content -->

        <div class="kt-container kt-pt10">
            <asp:Literal ID="lblContent" runat="server"></asp:Literal>
        </div>


        <!-- end:: Section -->

        <!-- end:: Content -->
    </div>
    <!-- end:: Content -->

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="script" runat="server">
</asp:Content>
