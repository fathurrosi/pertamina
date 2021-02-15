<%@ Page Title="" Language="C#" MasterPageFile="~/Frontend.Master" AutoEventWireup="true" CodeBehind="kinerja-sekper.aspx.cs" Inherits="Pertamina.CORSEC._2019.SpeechReport.kinerja_sekper"  EnableEventValidation="false"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">

        <!-- begin:: Content -->
        <div class="kt-content-height">
          <div class="kt-content kt-content--fit-top  kt-grid__item kt-grid__item--fluid kt-grid kt-grid--hor"
            id="kt_content">

            <!-- begin:: Hero -->
           <%-- <div class="kt-sc" style="background-image: url('assets/media/bg/bg-9.jpg')">
              <div class="kt-container ">

                <div class="kt-sc__bottom">
                  <h3 class="kt-sc__heading kt-heading kt-heading--center kt-heading--xxl kt-heading--medium">
                    Kinerja Sekper
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
                                    <asp:Label ID="lblTitle" runat="server" Text=""></asp:Label>
                                </h2>
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

              <div class="kt-portlet">
                <div class="kt-portlet__head">
                  <div class="kt-portlet__head-toolbar">
                    <ul class="nav nav-pills nav-fill" role="tablist">
                      <li class="nav-item">

                
                        <a class="nav-link active"  id="tab_Semester1" runat="server"
                          role="tab" aria-selected="true">
                          Semester 1
                        </a>
                      </li>
                      <li class="nav-item">
                        <a class="nav-link"  role="tab" id="tab_Semester2" runat="server"
                          aria-selected="false">
                          Semester 2
                        </a>
                      </li>
                    </ul>
                  </div>
                  <div class="kt-portlet__head-toolbar">
                    <b>Archive:</b>
                    <div class="btn-group ml-1" role="group" aria-label="Button group with nested dropdown">
                      <div class="btn-group" role="group">
                       <%-- <button id="btnGroupDrop1" type="button" class="btn btn-secondary dropdown-toggle"
                          data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                          5 Tahun Terakhir & Archive
                        </button>
                        <div class="dropdown-menu" aria-labelledby="btnGroupDrop1">
                          <a class="dropdown-item" href="#">5 Tahun Terakhir & Archive A</a>
                          <a class="dropdown-item" href="#">5 Tahun Terakhir & Archive B</a>
                          <a class="dropdown-item" href="#">5 Tahun Terakhir & Archive C</a>
                          <a class="dropdown-item" href="#">5 Tahun Terakhir & Archive D</a>
                        </div>--%>
                        <asp:Literal ID="lblFilter" runat="server"></asp:Literal>
                      </div>
                    </div>
                  </div>
                </div>
                <div class="kt-portlet__body">
                  <div class="tab-content">
                      <asp:Literal ID="lblContent" runat="server"></asp:Literal>
                    <div class="tab-pane active" id="kt_portlet_base_demo_2_3_tab_content" role="tabpanel" runat="server">
                      <%--<img src="/Content/assets/media/products/product1.jpg" width="100%">--%>
                      <asp:Image ID="img_semester_1" runat="server" Width="100%"  alt="" ImageUrl='/Content/assets/media/products/product1.jpg' />
                    </div>
                    <div class="tab-pane" id="kt_portlet_base_demo_2_2_tab_content" role="tabpanel" runat="server">
                      <%--<img src="/Content/assets/media/products/product2.jpg" width="100%">--%>
                      <asp:Image ID="img_semester_2" runat="server" Width="100%" alt="" ImageUrl='/Content/assets/media/products/product2.jpg' />
                    </div>                  
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
