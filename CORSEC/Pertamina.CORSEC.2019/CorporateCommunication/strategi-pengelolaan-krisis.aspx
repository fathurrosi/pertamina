<%@ Page Title="" Language="C#" MasterPageFile="~/Frontend.Master" AutoEventWireup="true" CodeBehind="strategi-pengelolaan-krisis.aspx.cs" Inherits="Pertamina.CORSEC._2019.CorporateCommunication.strategi_pengelolaan_krisis" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">

    <!-- begin:: Content -->
    <div class="kt-content-height">
        <div class="kt-content  kt-content--fit-top  kt-grid__item kt-grid__item--fluid kt-grid kt-grid--hor"
            id="kt_content">

            <!-- begin:: Content -->

            <%-- <!-- begin:: Hero -->
            <div class="kt-sc" style="background-image: url('assets/media/bg/bg-9.jpg')">
                <div class="kt-container ">

                    <div class="kt-sc__bottom">
                        <h3 class="kt-sc__heading kt-heading kt-heading--center kt-heading--xxl kt-heading--medium">Strategi Pengelolaan Krisis
                        </h3>

                    </div>
                </div>
            </div>
            <!-- end:: Hero -->


            <!-- begin:: Section -->
            <div class="kt-container ">
                <div class="kt-portlet">
                    <div class="kt-portlet__body">
                        <div class="kt-infobox">
                            <div class="kt-infobox__header">
                                <h2 class="kt-infobox__title">Strategi Pengelolaan Krisis</h2>
                            </div>
                            <div class="kt-infobox__body">
                                <div class="kt-infobox__section">
                                    <div class="kt-infobox__content text-justify">
                                        Lorem ipsum dolor sit amet, consectetur adipisicing elit. Temporibus at laboriosam architecto
                          maiores consequuntur pariatur fuga aperiam labore, consectetur ratione ullam, accusamus quos
                          optio quibusdam molestias repellendus! Aut nulla dolores nisi nemo aperiam et quos magni ut
                          officia, nesciunt quia ipsa illo nam quibusdam possimus dignissimos ducimus veritatis quae
                          tempore amet voluptate repellat. Eos sed est numquam nisi hic eveniet quos, rerum culpa ipsa,
                          <br />
                                        <br />
                                        sunt odit ducimus unde recusandae harum eligendi nihil doloribus, libero error dolore esse
                          impedit quam cum! Molestias, adipisci, reprehenderit. Quasi sequi corporis explicabo
                          perferendis? Minus voluptatum corporis earum saepe, ipsa quo nulla deserunt, sed suscipit
                          sapiente eius facilis nisi necessitatibus. Obcaecati nisi natus, laboriosam quo quibusdam
                          nesciunt numquam blanditiis. Recusandae tenetur odio accusantium quaerat, facere est, atque
                          magni laboriosam repellat, cupiditate voluptatum eligendi eum suscipit doloremque laborum
                          cumque
                          consequuntur optio veniam nobis non ducimus! Voluptatibus laborum numquam fuga laboriosam
                          distinctio explicabo reprehenderit minima saepe dicta tempora!
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            

            <!-- end:: Section -->--%>



            <asp:Literal ID="lblHeader" runat="server"></asp:Literal>

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
                                    <div class="kt-infobox__content text-justify">
                                        <asp:Literal ID="lblIsi" runat="server"></asp:Literal>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>



            <!-- begin:: Section -->

            <div class="kt-container ">
                <h3 class="mt-4 ml-1 mb-2">Krisis Komunikasi Pertamina</h3>

                <div class="kt-portlet">
                    <div class="kt-portlet__head">
                        <div class="kt-portlet__head-toolbar">
                            <%-- <ul class="nav nav-pills nav-fill" role="tablist">
                                <li class="nav-item">
                                    <a class="nav-link active" data-toggle="tab" href="#kt_portlet_base_demo_2_4_tab_content"
                                        role="tab" aria-selected="false">Hulu
                                    </a>
                                </li>
                                <li class="nav-item">
                                    <a class="nav-link " data-toggle="tab" href="#kt_portlet_base_demo_2_4_tab_content"
                                        role="tab" aria-selected="false">Adstream
                                    </a>
                                </li>
                                <li class="nav-item">
                                    <a class="nav-link " data-toggle="tab" href="#kt_portlet_base_demo_2_4_tab_content"
                                        role="tab" aria-selected="false">Pemasaran
                                    </a>
                                </li>
                                <li class="nav-item">
                                    <a class="nav-link " data-toggle="tab" href="#kt_portlet_base_demo_2_4_tab_content"
                                        role="tab" aria-selected="false">Kilang
                                    </a>
                                </li>
                                <li class="nav-item">
                                    <a class="nav-link " data-toggle="tab" href="#kt_portlet_base_demo_2_4_tab_content"
                                        role="tab" aria-selected="true">NRE
                                    </a>
                                </li>
                                <li class="nav-item">
                                    <a class="nav-link " data-toggle="tab" href="#kt_portlet_base_demo_2_4_tab_content"
                                        role="tab" aria-selected="false">General
                                    </a>
                                </li>
                            </ul>--%>
                            <asp:Literal ID="litCategory" runat="server"></asp:Literal>
                        </div>
                        <div class="kt-portlet__head-toolbar">



                            <%--                            <div class="btn-group ml-1" role="group" aria-label="Button group with nested dropdown">
                                <div class="btn-group" role="group">
                                    <button id="btnGroupDrop" type="button" class="btn btn-secondary dropdown-toggle"
                                        data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                        Tahun
                                    </button>
                                    <div class="dropdown-menu" aria-labelledby="btnGroupDrop" x-placement="bottom-start"
                                        style="position: absolute; will-change: transform; top: 0px; left: 0px; transform: translate3d(0px, 39px, 0px);">
                                        <a class="dropdown-item" href="#">2020</a>
                                        <a class="dropdown-item" href="#">2019</a>
                                        <a class="dropdown-item" href="#">2018</a>
                                        <a class="dropdown-item" href="#">2017</a>
                                        <asp:Literal ID="litYear" runat="server"></asp:Literal>
                                    </div>
                                </div>
                            --%>

                            <div class="btn-group ml-1" role="group" aria-label="Button group with nested dropdown">
                                <div class="btn-group" role="group">                                    
                                    <asp:Literal ID="litYear" runat="server"></asp:Literal>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="kt-portlet__body">
                        <div class="tab-content">
                            <div class="tab-pane active" id="kt_portlet_base_demo_2_4_tab_content" role="tabpanel">

                                <div class="row">
                                    <%-- <div class="col-md-3 text-center">
                                        <a href="strategi-pengelolaan-krisis-detail.html">
                                            <i class="fa fa-folder-open fa-7x"></i>
                                            <h4>Lorem ipsum</h4>
                                        </a>
                                    </div>
                                    <div class="col-md-3 text-center">
                                        <a href="strategi-pengelolaan-krisis-detail.html">
                                            <i class="fa fa-folder-open fa-7x"></i>
                                            <h4>Lorem ipsum</h4>
                                        </a>
                                    </div>
                                    <div class="col-md-3 text-center">
                                        <a href="strategi-pengelolaan-krisis-detail.html">
                                            <i class="fa fa-folder-open fa-7x"></i>
                                            <h4>Lorem ipsum</h4>
                                        </a>
                                    </div>
                                    <div class="col-md-3 text-center">
                                        <a href="strategi-pengelolaan-krisis-detail.html">
                                            <i class="fa fa-folder-open fa-7x"></i>
                                            <h4>Lorem ipsum</h4>
                                        </a>
                                    </div>
                                    <div class="col-md-3 text-center">
                                        <a href="strategi-pengelolaan-krisis-detail.html">
                                            <i class="fa fa-folder-open fa-7x"></i>
                                            <h4>Lorem ipsum</h4>
                                        </a>
                                    </div>
                                    <div class="col-md-3 text-center">
                                        <a href="strategi-pengelolaan-krisis-detail.html">
                                            <i class="fa fa-folder-open fa-7x"></i>
                                            <h4>Lorem ipsum</h4>
                                        </a>
                                    </div>
                                    <div class="col-md-3 text-center">
                                        <a href="strategi-pengelolaan-krisis-detail.html">
                                            <i class="fa fa-folder-open fa-7x"></i>
                                            <h4>Lorem ipsum</h4>
                                        </a>
                                    </div>
                                    <div class="col-md-3 text-center">
                                        <a href="strategi-pengelolaan-krisis-detail.html">
                                            <i class="fa fa-folder-open fa-7x"></i>
                                            <h4>Lorem ipsum</h4>
                                        </a>
                                    </div>--%>

                                    <asp:Literal ID="litSubCategory" runat="server"></asp:Literal>
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
