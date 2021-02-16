<%@ Page Title="" Language="C#" MasterPageFile="~/Frontend.Master" AutoEventWireup="true" CodeBehind="strategic-stake-holder-engagement.aspx.cs" Inherits="Pertamina.CORSEC._2019.StakeHolderManagement.strategic_stake_holder_engagement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">

        <!-- begin:: Content -->
        <div class="kt-content-height">
          <div class="kt-content  kt-content--fit-top  kt-grid__item kt-grid__item--fluid kt-grid kt-grid--hor"
            id="kt_content">

            <!-- begin:: Content -->

            <!-- begin:: Hero -->
         <%--   <div class="kt-sc" style="background-image: url('assets/media/bg/bg-9.jpg')">
              <div class="kt-container ">

                <div class="kt-sc__bottom">
                  <h3 class="kt-sc__heading kt-heading kt-heading--center kt-heading--xxl kt-heading--medium">
                    Strategic Stake holder Engagement
                  </h3>

                </div>
              </div>
            </div>--%>
            <!-- end:: Hero -->
            

            <asp:Literal ID="lblHeader" runat="server"></asp:Literal>


            <!-- begin:: Section -->
            <div class="kt-container ">
              <div class="kt-portlet">
                <div class="kt-portlet__body">
                  <div class="kt-infobox">
                    <div class="kt-infobox__header">
                      <h2 class="kt-infobox__title"><asp:Label ID="lblTitle" runat="server" Text=""></asp:Label></h2>
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

            <!-- end:: Section -->

            <!-- end:: Content -->
          </div>
        </div>
        <!-- end:: Content -->

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="script" runat="server">
</asp:Content>
