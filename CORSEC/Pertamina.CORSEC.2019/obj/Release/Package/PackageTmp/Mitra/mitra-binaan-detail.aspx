<%@ Page Title="" Language="C#" MasterPageFile="~/Frontend.Master" AutoEventWireup="true" CodeBehind="mitra-binaan-detail.aspx.cs" Inherits="Pertamina.CORSEC._2019.Mitra.mitra_binaan_detail" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $(function () {
            $("#btnAdd").click(function (e) {
                var isLogin = $("#hdnIsLogin").val();
                var loginUrl = $("#hdnLoginUrl").val();
                if (isLogin == "0") {
                    window.location.href = loginUrl;
                }
                else {
                    $.ajax({
                        type: "POST",
                        url: ResolveUrl("~/Services/Session.asmx/Add"),
                        contentType: 'application/json; charset=utf-8',
                        dataType: 'json',

                        data: '{"data":"' + $("#hdnId").val() + '"}',
                        success: function (result) {
                            alert(result.d);
                        },
                        error: function (err) {
                            //alert("readyState: " + xhr.readyState + "\nstatus: " + xhr.status);
                            //alert("responseText: " + xhr.responseText);
                        }
                    });
                }                e.preventDefault();
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">

    <!-- begin:: Content -->
    <div class="kt-content kt-content--fit-top  kt-grid__item kt-grid__item--fluid kt-grid kt-grid--hor"
        id="kt_content">

        <!-- begin:: Content -->
        <div class="kt-container mt-2">
            <div class="kt-portlet">
                <div class="kt-portlet__body">
                    <div class="kt-portlet__content mb-4">
                        <a href="Mitra-binaan.aspx" class="btn btn-secondary mb-4" runat="server" id="btnBack"><i class="fa fa-less-than"></i>Back</a>
                        <div class="row">
                            <div class="col-md-6">
                                <ul id="glasscase" class="gc-start">
                                    <%--<li><img src="assets/media/merchandise/3.jpg" alt="Text" /></li>
                                    <li><img src="assets/media/merchandise/4.jpg" alt="Text" /></li>--%>
                                    <asp:Literal ID="lblImages" runat="server"></asp:Literal>
                                </ul>
                            </div>
                            <div class="col-md-6">
                                <div class="kt-portlet kt-portlet--bordered">
                                    <div class="kt-portlet__head">
                                        <div class="kt-portlet__head-label">
                                            <h3 class="kt-portlet__head-title">
                                                <a href="#">
                                                    <asp:Label ID="lblJudul" runat="server" Text=""></asp:Label>
                                                    <asp:HiddenField ID="hdnId" runat="server" ClientIDMode="Static"></asp:HiddenField>
                                                    <asp:HiddenField ID="hdnLoginUrl" runat="server" ClientIDMode="Static"></asp:HiddenField>
                                                </a>
                                            </h3>
                                        </div>
                                    </div>
                                    <div class="kt-portlet__body kt-scroll scroll-desc-product" data-scroll="true">
                                        <div class="row mt-0 mb-0">
                                            <label class="col-4">SKU</label>
                                            <div class="col-8">
                                                :
                              <asp:Label ID="lblSKU" runat="server" Text=""></asp:Label>
                                            </div>
                                        </div>
                                        <div class="row mt-0 mb-0">
                                            <label class="col-4">Estimasi Harga</label>
                                            <div class="col-8">
                                                :
                              <span>Rp.
                                  <asp:Label ID="lblHargaMulai" runat="server" Text=""></asp:Label></span> - <span>
                                      <asp:Label ID="lblHargaHingga" runat="server" Text=""></asp:Label></span>
                                            </div>
                                        </div>
                                        <div class="row mt-0 mb-0">
                                            <label class="col-4">Min. Quantity</label>
                                            <div class="col-8">
                                                :
                              <asp:Label ID="lblQty" runat="server" Text=""></asp:Label>
                                            </div>
                                        </div>

                                        <p class="mt-4 mb-0 text-justify">
                                            <asp:Label ID="lblIsi" runat="server" Text=""></asp:Label>
                                        </p>
                                        <div class="kt-separator kt-separator--space-lg kt-separator--border-solid"></div>
                                        <h5>Informasi Contact Person</h5>
                                        <div class="kt-widget kt-widget--user-profile-3">
                                            <div class="kt-widget__top">
                                                <div class="kt-widget__content">
                                                    <div class="kt-widget__subhead">
                                                        <%--<a href="#"><i class="flaticon2-new-email"></i>support@site.com</a>
                                                        <a href="#"><i class="fa fa-phone-square"></i>+6282 0000 0000 </a>--%>
                                                        <asp:Literal ID="lblContactPerson" runat="server"></asp:Literal>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <%--<button type="button" class="btn btn-outline-brand">
                                        </button>
                                        <a href="../Login.aspx" class="btn btn-outline-brand"><i class="fa fa-heart"></i>Wishlist </a>--%>
                                        <asp:HiddenField ID="hdnIsLogin" ClientIDMode="Static" runat="server" />
                                        <asp:LinkButton ID="btnAdd" ClientIDMode="Static" runat="server" class="btn btn-outline-brand"><i class="fa fa-heart"></i>Wishlist </asp:LinkButton>

                                    </div>
                                </div>
                            </div>
                        </div>

                    </div>

                    <%--  <h2 class="mt-3 mb-4">Produk Lainnya</h2>
                    <div class="row">
                        <div class="col-md-3">
                            <!--begin:: Widgets/Blog-->
                            <div class="kt-portlet kt-portlet--height-fluid kt-widget19">
                                <div class="kt-portlet__body kt-portlet__body--fit kt-portlet__body--unfill">
                                    <a href="Mitra-binaan-detail.html">
                                        <div class="kt-widget19__pic kt-portlet-fit--top kt-portlet-fit--sides"
                                            style="min-height: 280px; background-image: url(assets/media/merchandise/3.jpg)">
                                        </div>
                                    </a>
                                </div>
                                <div class="kt-portlet__body bd-thin">
                                    <div class="kt-widget19__wrapper">
                                        <div class="kt-widget19__content">
                                            <div class="kt-widget19__info p-0">
                                                <a href="Mitra-binaan-detail.html" class="kt-widget19__username">Lorem Ipsum Lorem Ipsum
                                                </a>
                                            </div>
                                        </div>
                                        <div class="kt-widget18__text">
                                            Lorem Ipsum is simply dummy text of the printing and typesetting..
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <!--end:: Widgets/Blog-->
                        </div>

                        <div class="col-md-3">
                            <!--begin:: Widgets/Blog-->
                            <div class="kt-portlet kt-portlet--height-fluid kt-widget19">
                                <div class="kt-portlet__body kt-portlet__body--fit kt-portlet__body--unfill">
                                    <a href="Mitra-binaan-detail.html">
                                        <div class="kt-widget19__pic kt-portlet-fit--top kt-portlet-fit--sides"
                                            style="min-height: 280px; background-image: url(assets/media/merchandise/4.jpg)">
                                        </div>
                                    </a>
                                </div>
                                <div class="kt-portlet__body bd-thin">
                                    <div class="kt-widget19__wrapper">
                                        <div class="kt-widget19__content">
                                            <div class="kt-widget19__info p-0">
                                                <a href="Mitra-binaan-detail.html" class="kt-widget19__username">Lorem Ipsum Lorem Ipsum
                                                </a>
                                            </div>
                                        </div>
                                        <div class="kt-widget18__text">
                                            Lorem Ipsum is simply dummy text of the printing and typesetting..
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <!--end:: Widgets/Blog-->
                        </div>

                        <div class="col-md-3">
                            <!--begin:: Widgets/Blog-->
                            <div class="kt-portlet kt-portlet--height-fluid kt-widget19">
                                <div class="kt-portlet__body kt-portlet__body--fit kt-portlet__body--unfill">
                                    <a href="Mitra-binaan-detail.html">
                                        <div class="kt-widget19__pic kt-portlet-fit--top kt-portlet-fit--sides"
                                            style="min-height: 280px; background-image: url(assets/media/merchandise/5.jpg)">
                                        </div>
                                    </a>
                                </div>
                                <div class="kt-portlet__body bd-thin">
                                    <div class="kt-widget19__wrapper">
                                        <div class="kt-widget19__content">
                                            <div class="kt-widget19__info p-0">
                                                <a href="Mitra-binaan-detail.html" class="kt-widget19__username">Lorem Ipsum Lorem Ipsum
                                                </a>
                                            </div>
                                        </div>
                                        <div class="kt-widget18__text">
                                            Lorem Ipsum is simply dummy text of the printing and typesetting..
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <!--end:: Widgets/Blog-->
                        </div>

                        <div class="col-md-3">
                            <!--begin:: Widgets/Blog-->
                            <div class="kt-portlet kt-portlet--height-fluid kt-widget19">
                                <div class="kt-portlet__body kt-portlet__body--fit kt-portlet__body--unfill">
                                    <a href="Mitra-binaan-detail.html">
                                        <div class="kt-widget19__pic kt-portlet-fit--top kt-portlet-fit--sides"
                                            style="min-height: 280px; background-image: url(assets/media/merchandise/6.jpg)">
                                        </div>
                                    </a>
                                </div>
                                <div class="kt-portlet__body bd-thin">
                                    <div class="kt-widget19__wrapper">
                                        <div class="kt-widget19__content">
                                            <div class="kt-widget19__info p-0">
                                                <a href="Mitra-binaan-detail.html" class="kt-widget19__username">Lorem Ipsum Lorem Ipsum
                                                </a>
                                            </div>
                                        </div>
                                        <div class="kt-widget18__text">
                                            Lorem Ipsum is simply dummy text of the printing and typesetting..
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <!--end:: Widgets/Blog-->
                        </div>
                        
                    </div>--%>

                    <asp:Literal ID="lblProdukLainnya" runat="server"></asp:Literal>
                </div>
            </div>
        </div>

        <!-- end:: Content -->
    </div>
    <!-- end:: Content -->
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="script" runat="server">

    <!-- end::Global Config -->
    <script type="text/javascript">
        $(document).ready(function () {
            //If your <ul> has the id "glasscase"
            $('#glasscase').glassCase({
                'thumbsPosition': 'left',
                'nrThumbsPerRow': 5,
                // 'heightDisplay': 600,
                'isDownloadEnabled': false,
                'autoInnerZoom': false,
                'isZoomEnabled': false,
                'isZoomDiffWH': false
            });
        });
    </script>
</asp:Content>
