<%@ Page Title="" Language="C#" MasterPageFile="~/Frontend.Master" AutoEventWireup="true" CodeBehind="media-monitoring.aspx.cs" Inherits="Pertamina.CORSEC._2019.MonitoringEvaluasi.media_monitoring" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">

    <asp:HiddenField ClientIDMode="Static" ID="hdnInternetPositif" runat="server" Value="0" />
    <asp:HiddenField ClientIDMode="Static" ID="hdnInternetNegatif" runat="server" Value="0" />
    <asp:HiddenField ClientIDMode="Static" ID="hdnInternetNetral" runat="server" Value="0" />

    <asp:HiddenField ClientIDMode="Static" ID="hdnCetakPositif" runat="server" Value="0" />
    <asp:HiddenField ClientIDMode="Static" ID="hdnCetakNegatif" runat="server" Value="0" />
    <asp:HiddenField ClientIDMode="Static" ID="hdnCetakNetral" runat="server" Value="0" />

    <asp:HiddenField ClientIDMode="Static" ID="hdnTVPositif" runat="server" Value="0" />
    <asp:HiddenField ClientIDMode="Static" ID="hdnTVNegatif" runat="server" Value="0" />
    <asp:HiddenField ClientIDMode="Static" ID="hdnTVNetral" runat="server" Value="0" />

    <asp:HiddenField ClientIDMode="Static" ID="hdnTotalPositif" runat="server" Value="0" />
    <asp:HiddenField ClientIDMode="Static" ID="hdnTotalNegatif" runat="server" Value="0" />
    <asp:HiddenField ClientIDMode="Static" ID="hdnTotalNetral" runat="server" Value="0" />
    <asp:HiddenField ClientIDMode="Static" ID="hdnTotalArticle" runat="server" Value="0" />
    <div class="kt-content-height">
        <div class="kt-content  kt-content--fit-top  kt-grid__item kt-grid__item--fluid kt-grid kt-grid--hor"
            id="kt_content">

            <!-- begin:: Content -->

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

            <!-- end:: Section -->
            <div class="kt-container ">
                <div class="kt-portlet">
                    <div class="kt-portlet__head">
                        <div class="kt-portlet__head-toolbar">
                            <%--<ul class="nav nav-pills nav-fill" role="tablist">
                                <li class="nav-item">
                                    <a class="nav-link active" data-toggle="tab" href="#kt_portlet_base_demo_2_4_tab_content"
                                        role="tab" aria-selected="false">Mingguan
                                    </a>
                                </li>
                                <li class="nav-item">
                                    <a class="nav-link " data-toggle="tab" href="#kt_portlet_base_demo_2_4_tab_content" role="tab"
                                        aria-selected="true">Bulanan
                                    </a>
                                </li>
                                <li class="nav-item">
                                    <a class="nav-link " data-toggle="tab" href="#kt_portlet_base_demo_2_4_tab_content" role="tab"
                                        aria-selected="true">Tahunan
                                    </a>
                                </li>
                            </ul>--%>
                            <ul class="nav nav-pills nav-fill" role="tablist">
                                <asp:Literal ID="litTab" runat="server"></asp:Literal>
                            </ul>
                        </div>
                    </div>
                    <div class="kt-portlet__body">
                        <div class="tab-content">
                            <div class="tab-pane active" id="kt_portlet_base_demo_2_4_tab_content" role="tabpanel">
                                <div class="row">
                                    <div class="col-md-6">
                                        <h3 class="text-center">Tone Berita</h3>
                                        <div class="kt-widget14">
                                            <div class="kt-widget14__content">
                                                <div class="kt-widget14__chart">
                                                    <div id="kt_chart_revenue_change" style="height: 250px; width: 250px;"></div>
                                                </div>
                                                <asp:Literal ID="litToneBerita" runat="server"></asp:Literal>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <h3 class="text-center">Jenis Media</h3>
                                        <div class="kt-widget14">
                                            <div class="kt-widget14__content">
                                                <div class="kt-widget14__chart">
                                                    <canvas id="kt_chart_daily_sales"></canvas>
                                                </div>
                                                <asp:Literal ID="litJenisMedia" runat="server"></asp:Literal>

                                            </div>
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
                            <div class="kt-portlet__head-label">
                                <h3 class="kt-portlet__head-title">10 Topik Berita Teratas
                                </h3>
                            </div>
                        </div>
                        <div class="kt-portlet__body">
                            <div class="table-responsive">


                                <asp:GridView ID="grid" runat="server" class="table table-bordered table-hover"
                                    AutoGenerateColumns="false"
                                    AllowPaging="true"
                                    AllowSorting="false"
                                    OnRowDataBound="grid_RowDataBound" ShowHeader="true" GridLines="None">
                                    <Columns>
                                        <asp:TemplateField HeaderText="No" ItemStyle-Width="4%">
                                            <ItemTemplate>
                                                <%# Eval("PAGING_ROW_NUMBER")%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Judul Berita" ItemStyle-Width="15%">
                                            <ItemTemplate>
                                                <%# Eval("Title")%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Jenis Media" ItemStyle-Width="10%">
                                            <ItemTemplate>
                                                <%# Eval("Media_Type")%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Nada Berita" ItemStyle-Width="5%">
                                            <ItemTemplate>
                                                <%# Eval("Tone")%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <EmptyDataTemplate>
                                        There are currently no items in this table.
                                    </EmptyDataTemplate>
                                    <PagerSettings Visible="false" />
                                </asp:GridView>

                                <%--                                <table class="table table-bordered table-hover">
                                    <thead>
                                        <tr class="text-center">
                                            <th width="4%">No</th>
                                            <th>Judul Berita</th>
                                            <th>Jenis Media</th>
                                            <th>Nada Berita</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <tr>
                                            <th scope="row">1</th>
                                            <td>Jenis Media</td>
                                            <td>Jenis Media</td>
                                            <td>Nada Berita</td>
                                        </tr>
                                        <tr>
                                            <th scope="row">2</th>
                                            <td>Loream Ipsum</td>
                                            <td>Jenis Media</td>
                                            <td>Nada Berita</td>
                                        </tr>
                                        <tr>
                                            <th scope="row">3</th>
                                            <td>Loream Ipsum</td>
                                            <td>Jenis Media</td>
                                            <td>Nada Berita</td>
                                        </tr>
                                        <tr>
                                            <th scope="row">4</th>
                                            <td>Loream Ipsum</td>
                                            <td>Jenis Media</td>
                                            <td>Nada Berita</td>
                                        </tr>
                                        <tr>
                                            <th scope="row">5</th>
                                            <td>Loream Ipsum</td>
                                            <td>Jenis Media</td>
                                            <td>Nada Berita</td>
                                        </tr>
                                    </tbody>
                                </table>--%>
                            </div>
                        </div>
                    </div>
                </div>
                <!-- end:: Content -->
            </div>
        </div>
        <!-- end:: Content -->

    </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="script" runat="server">
    <%--<script src="<%: ResolveUrl("~/Content/assets/js/pages/dashboard.js") %>"></script>--%>
    <script type="text/javascript">

        // Class definition
        var KTDashboard = function () {

            // Daily Sales chart.
            // Based on Chartjs plugin - http://www.chartjs.org/
            var dailySales = function () {
                var chartContainer = KTUtil.getByID('kt_chart_daily_sales');

                if (!chartContainer) {
                    return;
                }

                var InternetPositif = $('#hdnInternetPositif').val();
                var InternetNegatif = $('#hdnInternetNegatif').val();
                var InternetNetral = $('#hdnInternetNetral').val();

                var CetakPositif = $('#hdnCetakPositif').val();
                var CetakNegatif = $('#hdnCetakNegatif').val();
                var CetakNetral = $('#hdnCetakNetral').val();

                var TVPositif = $('#hdnTVPositif').val();
                var TVNegatif = $('#hdnTVNegatif').val();
                var TVNetral = $('#hdnTVNetral').val();



                var chartData = {
                    labels: ["Internet", "TV", "Cetak"],
                    datasets: [{
                        label: 'Positif',
                        backgroundColor: KTApp.getStateColor('success'),
                        data: [
                            InternetPositif,
                            TVPositif,
                            CetakPositif
                        ]
                    }, {
                        label: 'Negative',
                        backgroundColor: KTApp.getStateColor('danger'),
                        data: [
                            InternetNegatif,
                            TVNegatif,
                            CetakNegatif
                        ]
                    }, {
                        label: 'Netral',
                        backgroundColor: KTApp.getStateColor('brand'),
                        data: [
                            InternetNetral,
                            TVNetral,
                            CetakNetral
                        ]
                    }]
                };

                var chart = new Chart(chartContainer, {
                    type: 'bar',
                    data: chartData,
                    options: {
                        title: {
                            display: false,
                        },
                        tooltips: {
                            intersect: false,
                            mode: 'nearest',
                            xPadding: 10,
                            yPadding: 10,
                            caretPadding: 10
                        },
                        legend: {
                            display: false
                        },
                        responsive: true,
                        maintainAspectRatio: false,
                        barRadius: 4,
                        scales: {
                            xAxes: [{
                                display: false,
                                gridLines: false,
                                stacked: true
                            }],
                            yAxes: [{
                                display: false,
                                stacked: true,
                                gridLines: false
                            }]
                        },
                        layout: {
                            padding: {
                                left: 0,
                                right: 0,
                                top: 0,
                                bottom: 0
                            }
                        }
                    }
                });
            }

            var revenueChange = function () {
                if ($('#kt_chart_revenue_change').length == 0) {
                    return;
                }
                var TotalPositif = $('#hdnTotalPositif').val();
                var TotalNegatif = $('#hdnTotalNegatif').val();
                var TotalNetral = $('#hdnTotalNetral').val();
                Morris.Donut({
                    element: 'kt_chart_revenue_change',
                    data: [{
                        label: "Positif",
                        value: TotalPositif
                    },
                        {
                            label: "Negatif",
                            value: TotalNegatif
                        },
                        {
                            label: "Netral",
                            value: TotalNetral
                        }
                    ],
                    colors: [
                        KTApp.getStateColor('success'),
                        KTApp.getStateColor('danger'),
                        KTApp.getStateColor('brand')
                    ],
                });
            }

            return {
                // Init demos
                init: function () {
                    // init charts
                    dailySales();


                    revenueChange();


                    // demo loading
                    var loading = new KTDialog({ 'type': 'loader', 'placement': 'top center', 'message': 'Loading ...' });
                    loading.show();

                    setTimeout(function () {
                        loading.hide();
                    }, 3000);
                }
            };
        }();

        // Class initialization on page load
        jQuery(document).ready(function () {
            KTDashboard.init();
        });
    </script>
</asp:Content>
