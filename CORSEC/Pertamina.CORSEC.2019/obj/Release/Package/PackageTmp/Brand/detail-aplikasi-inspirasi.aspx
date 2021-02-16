<%@ Page Title="" Language="C#" MasterPageFile="~/Frontend.Master" AutoEventWireup="true" CodeBehind="detail-aplikasi-inspirasi.aspx.cs" Inherits="Pertamina.CORSEC._2019.Brand.detail_aplikasi_inspirasi" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">

    <!-- begin:: Content -->
    <div class="kt-content-height">
        <div class="kt-content kt-content--fit-top  kt-grid__item kt-grid__item--fluid kt-grid kt-grid--hor"
            id="kt_content">

            <!-- begin:: Content -->

            <!-- begin:: Hero -->
           <%-- <div class="kt-sc" style="background-image: url('assets/media/bg/bg-9.jpg')">
                <div class="kt-container ">

                    <div class="kt-sc__bottom">
                        <h3 class="kt-sc__heading kt-heading kt-heading--center kt-heading--xxl kt-heading--medium">Detail Aplikasi & Inspirasi
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

<%--                            <div class="kt-infobox__header">
                                <h2 class="kt-infobox__title">Lorem ipsum dolor sit amet</h2>
                            </div>
                            <div class="kt-infobox__body">
                                <div class="kt-infobox__section">
                                    <div class="kt-infobox__content text-justify">
                                        <div class="row">
                                            <div class="col-md-9">
                                                <img src="assets/media/products/product4.jpg" style="max-width: 100%; width: 100%;" />
                                            </div>
                                            <div class="col-md-3">
                                                <p>
                                                    Lorem ipsum dolor sit amet, consectetur adipisicing elit. Temporibus at
																laboriosam
																architecto maiores consequuntur pariatur fuga aperiam labore, consectetur
																ratione ullam,
																accusamus quos optio quibusdam molestias repellendus! Aut nulla dolores nisi
																nemo aperiam et
																quos magni ut officia, nesciunt quia ipsa illo nam quibusdam possimus
																dignissimos ducimus
																veritatis quae tempore amet voluptate repellat. Eos sed est numquam nisi hic
																eveniet quos,
																rerum culpa ipsa, Obcaecati nisi natus, laboriosam quo quibusdam
																nesciunt numquam blanditiis.
                                                </p>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>--%>
                            <asp:Literal ID="lblDetail" runat="server"></asp:Literal>
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
