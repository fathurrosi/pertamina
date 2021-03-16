<%@ Page Title="" Language="C#" MasterPageFile="~/Frontend.Master" AutoEventWireup="true" CodeBehind="strategi-pengelolaan.aspx.cs" Inherits="Pertamina.CORSEC._2019.CSRSMEPP.strategi_pengelolaan" EnableEventValidation="false" %>

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
    <div class="kt-content-height">
        <div class="kt-content  kt-content--fit-top  kt-grid__item kt-grid__item--fluid kt-grid kt-grid--hor"
            id="kt_content">

            <!-- begin:: Content -->

            <%--<!-- begin:: Hero -->
            <div class="kt-sc" style="background-image: url('assets/media/bg/bg-9.jpg')">
                <div class="kt-container ">

                    <div class="kt-sc__bottom">
                        <h3 class="kt-sc__heading kt-heading kt-heading--center kt-heading--xxl kt-heading--medium">Strategi Pengelolaan CSR-SMEPP
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
                                <h2 class="kt-infobox__title">Strategi Pengelolaan CSR-SMEPP</h2>
                            </div>
                            <div class="kt-infobox__body">
                                <div class="kt-infobox__section">
                                    <div class="kt-infobox__content text-justify">
                                        Lorem ipsum dolor sit amet, consectetur adipisicing elit. Temporibus at laboriosam architecto
                          maiores consequuntur pariatur fuga aperiam labore, consectetur ratione ullam, accusamus quos
                          optio quibusdam molestias repellendus! Aut nulla dolores nisi nemo aperiam et quos magni ut
                          officia, nesciunt quia ipsa illo nam quibusdam possimus dignissimos ducimus veritatis quae
                          tempore amet voluptate repellat. Eos sed est numquam nisi hic eveniet quos, rerum culpa ipsa,
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


            <!-- begin:: Section -->
            <div class="kt-container ">
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

            <div class="kt-container ">
                <div class="kt-portlet">
                    <div class="kt-portlet__head">
                        <div class="kt-portlet__head-toolbar">
                            <ul class="nav nav-pills nav-fill" role="tablist">
                                <%-- <li class="nav-item">
                                    <a class="nav-link active" data-toggle="tab" href="#kt_portlet_base_demo_2_4_tab_content"
                                        role="tab" aria-selected="false">Pendidikan
                                    </a>
                                </li>
                                <li class="nav-item">
                                    <a class="nav-link " data-toggle="tab" href="#kt_portlet_base_demo_2_3_tab_content" role="tab"
                                        aria-selected="true">Loream Ipsum
                                    </a>
                                </li>
                                <li class="nav-item">
                                    <a class="nav-link " data-toggle="tab" href="#kt_portlet_base_demo_2_5_tab_content" role="tab"
                                        aria-selected="true">Loream Ipsum 2
                                    </a>
                                </li>--%>

                                <asp:Literal ID="litTab" runat="server"></asp:Literal>
                            </ul>
                        </div>
                    </div>
                    <div class="kt-portlet__body">
                        <div class="tab-content">
                            <div class="tab-pane active" id="tab_content" role="tabpanel">
                                <div class="text-justify">


                                    <asp:Literal ID="litContent" runat="server"></asp:Literal>

                                    <%--    <h2 class="pb-2 pt-3">Lorem ipsum</h2>
                                    <div class="row">
                                        <div class="col-md-9">
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
                              nesciunt numquam blanditiis.Lorem ipsum dolor sit amet, consectetur adipisicing elit.
                              Temporibus at laboriosam
                              architecto maiores consequuntur pariatur fuga aperiam labore, consectetur ratione
                              ullam,
                              accusamus quos optio quibusdam molestias repellendus! Aut nulla dolores nisi nemo
                              aperiam et
                              quos magni ut officia, nesciunt quia ipsa illo nam quibusdam possimus dignissimos
                              ducimus
                              veritatis quae tempore amet voluptate repellat. Eos sed est numquam nisi hic eveniet
                              quos,
                              rerum culpa ipsa, Obcaecati nisi natus, laboriosam quo quibusdam
                              nesciunt numquam blanditiis.
                                            </p>
                                        </div>
                                        <div class="col-md-3">
                                            <div class="kt-widget19__pic kt-portlet-fit--top kt-portlet-fit--sides"
                                                style="min-height: 150px; background-image: url(assets/media//products/product3.jpg)">
                                            </div>
                                        </div>
                                    </div>
                                    <h2 class="pb-2 pt-3">Lorem ipsum</h2>
                                    <div class="row">
                                        <div class="col-md-3">
                                            <div class="kt-widget19__pic kt-portlet-fit--top kt-portlet-fit--sides"
                                                style="min-height: 150px; background-image: url(assets/media//products/product1.jpg)">
                                            </div>
                                        </div>
                                        <div class="col-md-9">
                                            <p>
                                                Lorem ipsum dolor sit amet, consectetur adipisicing elit. Temporibus at laboriosam
                              architecto maiores consequuntur pariatur fuga aperiam labore, consectetur ratione
                              ullam,
                              accusamus quos optio quibusdam molestias repellendus! Aut nulla dolores nisi nemo
                              aperiam et
                              quos magni ut officia, nesciunt quia ipsa illo nam quibusdam possimus dignissimos
                              ducimus
                              veritatis quae tempore amet voluptate repellat. Eos sed est numquam nisi hic eveniet
                              quos,
                              rerum culpa ipsa, Obcaecati nisi natus, laboriosam quo quibusdam
                              nesciunt numquam blanditiis.Lorem ipsum dolor sit amet, consectetur adipisicing elit.
                              Temporibus at laboriosam
                              architecto maiores consequuntur pariatur fuga aperiam labore, consectetur ratione
                              ullam,
                              accusamus quos optio quibusdam molestias repellendus! Aut nulla dolores nisi nemo
                              aperiam et
                              quos magni ut officia, nesciunt quia ipsa illo nam quibusdam possimus dignissimos
                              ducimus
                              veritatis quae tempore amet voluptate repellat. Eos sed est numquam nisi hic eveniet
                              quos,
                              rerum culpa ipsa, Obcaecati nisi natus, laboriosam quo quibusdam
                              nesciunt numquam blanditiis.
                                            </p>
                                        </div>
                                    </div>--%>
                                </div>
                            </div>
                            <%--   <div class="tab-pane" id="kt_portlet_base_demo_2_3_tab_content" role="tabpanel">
                                <div class="text-justify">
                                    <h2 class="pb-2 pt-3">Lorem ipsum</h2>
                                    <div class="row">
                                        <div class="col-md-3">
                                            <div class="kt-widget19__pic kt-portlet-fit--top kt-portlet-fit--sides"
                                                style="min-height: 150px; background-image: url(assets/media//products/product1.jpg)">
                                            </div>
                                        </div>
                                        <div class="col-md-9">
                                            <p>
                                                Lorem ipsum dolor sit amet, consectetur adipisicing elit. Temporibus at laboriosam
                              architecto maiores consequuntur pariatur fuga aperiam labore, consectetur ratione
                              ullam,
                              accusamus quos optio quibusdam molestias repellendus! Aut nulla dolores nisi nemo
                              aperiam et
                              quos magni ut officia, nesciunt quia ipsa illo nam quibusdam possimus dignissimos
                              ducimus
                              veritatis quae tempore amet voluptate repellat. Eos sed est numquam nisi hic eveniet
                              quos,
                              rerum culpa ipsa, Obcaecati nisi natus, laboriosam quo quibusdam
                              nesciunt numquam blanditiis.Lorem ipsum dolor sit amet, consectetur adipisicing elit.
                              Temporibus at laboriosam
                              architecto maiores consequuntur pariatur fuga aperiam labore, consectetur ratione
                              ullam,
                              accusamus quos optio quibusdam molestias repellendus! Aut nulla dolores nisi nemo
                              aperiam et
                              quos magni ut officia, nesciunt quia ipsa illo nam quibusdam possimus dignissimos
                              ducimus
                              veritatis quae tempore amet voluptate repellat. Eos sed est numquam nisi hic eveniet
                              quos,
                              rerum culpa ipsa, Obcaecati nisi natus, laboriosam quo quibusdam
                              nesciunt numquam blanditiis.
                                            </p>
                                        </div>
                                    </div>
                                    <h2 class="pb-2 pt-3">Lorem ipsum</h2>
                                    <div class="row">
                                        <div class="col-md-9">
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
                              nesciunt numquam blanditiis.Lorem ipsum dolor sit amet, consectetur adipisicing elit.
                              Temporibus at laboriosam
                              architecto maiores consequuntur pariatur fuga aperiam labore, consectetur ratione
                              ullam,
                              accusamus quos optio quibusdam molestias repellendus! Aut nulla dolores nisi nemo
                              aperiam et
                              quos magni ut officia, nesciunt quia ipsa illo nam quibusdam possimus dignissimos
                              ducimus
                              veritatis quae tempore amet voluptate repellat. Eos sed est numquam nisi hic eveniet
                              quos,
                              rerum culpa ipsa, Obcaecati nisi natus, laboriosam quo quibusdam
                              nesciunt numquam blanditiis.
                                            </p>
                                        </div>
                                        <div class="col-md-3">
                                            <div class="kt-widget19__pic kt-portlet-fit--top kt-portlet-fit--sides"
                                                style="min-height: 150px; background-image: url(assets/media//products/product3.jpg)">
                                            </div>
                                        </div>
                                    </div>
                                    <h2 class="pb-2 pt-3">Lorem ipsum</h2>
                                    <div class="row">
                                        <div class="col-md-3">
                                            <div class="kt-widget19__pic kt-portlet-fit--top kt-portlet-fit--sides"
                                                style="min-height: 150px; background-image: url(assets/media//products/product1.jpg)">
                                            </div>
                                        </div>
                                        <div class="col-md-9">
                                            <p>
                                                Lorem ipsum dolor sit amet, consectetur adipisicing elit. Temporibus at laboriosam
                              architecto maiores consequuntur pariatur fuga aperiam labore, consectetur ratione
                              ullam,
                              accusamus quos optio quibusdam molestias repellendus! Aut nulla dolores nisi nemo
                              aperiam et
                              quos magni ut officia, nesciunt quia ipsa illo nam quibusdam possimus dignissimos
                              ducimus
                              veritatis quae tempore amet voluptate repellat. Eos sed est numquam nisi hic eveniet
                              quos,
                              rerum culpa ipsa, Obcaecati nisi natus, laboriosam quo quibusdam
                              nesciunt numquam blanditiis.Lorem ipsum dolor sit amet, consectetur adipisicing elit.
                              Temporibus at laboriosam
                              architecto maiores consequuntur pariatur fuga aperiam labore, consectetur ratione
                              ullam,
                              accusamus quos optio quibusdam molestias repellendus! Aut nulla dolores nisi nemo
                              aperiam et
                              quos magni ut officia, nesciunt quia ipsa illo nam quibusdam possimus dignissimos
                              ducimus
                              veritatis quae tempore amet voluptate repellat. Eos sed est numquam nisi hic eveniet
                              quos,
                              rerum culpa ipsa, Obcaecati nisi natus, laboriosam quo quibusdam
                              nesciunt numquam blanditiis.
                                            </p>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="tab-pane" id="kt_portlet_base_demo_2_5_tab_content" role="tabpanel">
                                <div class="text-justify">
                                    <h2 class="pb-2 pt-3">Lorem ipsum</h2>
                                    <div class="row">
                                        <div class="col-md-3">
                                            <div class="kt-widget19__pic kt-portlet-fit--top kt-portlet-fit--sides"
                                                style="min-height: 150px; background-image: url(assets/media//products/product1.jpg)">
                                            </div>
                                        </div>
                                        <div class="col-md-9">
                                            <p>
                                                Lorem ipsum dolor sit amet, consectetur adipisicing elit. Temporibus at laboriosam
                              architecto maiores consequuntur pariatur fuga aperiam labore, consectetur ratione
                              ullam,
                              accusamus quos optio quibusdam molestias repellendus! Aut nulla dolores nisi nemo
                              aperiam et
                              quos magni ut officia, nesciunt quia ipsa illo nam quibusdam possimus dignissimos
                              ducimus
                              veritatis quae tempore amet voluptate repellat. Eos sed est numquam nisi hic eveniet
                              quos,
                              rerum culpa ipsa, Obcaecati nisi natus, laboriosam quo quibusdam
                              nesciunt numquam blanditiis.Lorem ipsum dolor sit amet, consectetur adipisicing elit.
                              Temporibus at laboriosam
                              architecto maiores consequuntur pariatur fuga aperiam labore, consectetur ratione
                              ullam,
                              accusamus quos optio quibusdam molestias repellendus! Aut nulla dolores nisi nemo
                              aperiam et
                              quos magni ut officia, nesciunt quia ipsa illo nam quibusdam possimus dignissimos
                              ducimus
                              veritatis quae tempore amet voluptate repellat. Eos sed est numquam nisi hic eveniet
                              quos,
                              rerum culpa ipsa, Obcaecati nisi natus, laboriosam quo quibusdam
                              nesciunt numquam blanditiis.
                                            </p>
                                        </div>
                                    </div>
                                    <h2 class="pb-2 pt-3">Lorem ipsum</h2>
                                    <div class="row">
                                        <div class="col-md-9">
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
                              nesciunt numquam blanditiis.Lorem ipsum dolor sit amet, consectetur adipisicing elit.
                              Temporibus at laboriosam
                              architecto maiores consequuntur pariatur fuga aperiam labore, consectetur ratione
                              ullam,
                              accusamus quos optio quibusdam molestias repellendus! Aut nulla dolores nisi nemo
                              aperiam et
                              quos magni ut officia, nesciunt quia ipsa illo nam quibusdam possimus dignissimos
                              ducimus
                              veritatis quae tempore amet voluptate repellat. Eos sed est numquam nisi hic eveniet
                              quos,
                              rerum culpa ipsa, Obcaecati nisi natus, laboriosam quo quibusdam
                              nesciunt numquam blanditiis.
                                            </p>
                                        </div>
                                        <div class="col-md-3">
                                            <div class="kt-widget19__pic kt-portlet-fit--top kt-portlet-fit--sides"
                                                style="min-height: 150px; background-image: url(assets/media//products/product3.jpg)">
                                            </div>
                                        </div>
                                    </div>
                                    <h2 class="pb-2 pt-3">Lorem ipsum</h2>
                                    <div class="row">
                                        <div class="col-md-3">
                                            <div class="kt-widget19__pic kt-portlet-fit--top kt-portlet-fit--sides"
                                                style="min-height: 150px; background-image: url(assets/media//products/product1.jpg)">
                                            </div>
                                        </div>
                                        <div class="col-md-9">
                                            <p>
                                                Lorem ipsum dolor sit amet, consectetur adipisicing elit. Temporibus at laboriosam
                              architecto maiores consequuntur pariatur fuga aperiam labore, consectetur ratione
                              ullam,
                              accusamus quos optio quibusdam molestias repellendus! Aut nulla dolores nisi nemo
                              aperiam et
                              quos magni ut officia, nesciunt quia ipsa illo nam quibusdam possimus dignissimos
                              ducimus
                              veritatis quae tempore amet voluptate repellat. Eos sed est numquam nisi hic eveniet
                              quos,
                              rerum culpa ipsa, Obcaecati nisi natus, laboriosam quo quibusdam
                              nesciunt numquam blanditiis.Lorem ipsum dolor sit amet, consectetur adipisicing elit.
                              Temporibus at laboriosam
                              architecto maiores consequuntur pariatur fuga aperiam labore, consectetur ratione
                              ullam,
                              accusamus quos optio quibusdam molestias repellendus! Aut nulla dolores nisi nemo
                              aperiam et
                              quos magni ut officia, nesciunt quia ipsa illo nam quibusdam possimus dignissimos
                              ducimus
                              veritatis quae tempore amet voluptate repellat. Eos sed est numquam nisi hic eveniet
                              quos,
                              rerum culpa ipsa, Obcaecati nisi natus, laboriosam quo quibusdam
                              nesciunt numquam blanditiis.
                                            </p>
                                        </div>
                                    </div>
                                </div>
                            </div>--%>
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
