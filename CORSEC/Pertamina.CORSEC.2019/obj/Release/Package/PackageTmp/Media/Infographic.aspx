<%@ Page Title="" Language="C#" MasterPageFile="~/Frontend.Master" AutoEventWireup="true" CodeBehind="Infographic.aspx.cs" Inherits="Pertamina.CORSEC._2019.Media.Infographic" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .table-borderless tr td {
            padding: 0px !important;
            border-top: none !important;
            border-bottom-width: 1px;
            border-bottom-style: solid;
            border-bottom-color: #ebedf2;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">

    <!-- begin:: Content -->
    <div class="kt-content-height">
        <div class="kt-content kt-content--fit-top  kt-grid__item kt-grid__item--fluid kt-grid kt-grid--hor"
            id="kt_content">

            <!-- begin:: Hero -->
            <%--<div class="kt-sc" style="background-image: url('assets/media/bg/bg-9.jpg')">
                <div class="kt-container ">

                    <div class="kt-sc__bottom">
                        <h3 class="kt-sc__heading kt-heading kt-heading--center kt-heading--xxl kt-heading--medium">Materi Presentasi
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
                                    <asp:Label ID="lblTittle" runat="server" Text=""></asp:Label>
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
                            <ul
                                class="nav nav-pills nav-fill"
                                role="tablist">
                                <li class="nav-item">
                                    <a class="nav-link active" role="tab" id="tab_Infografis_corporate" runat="server"
                                        aria-selected="false">Infografis Corporate
                                    </a>
                                </li>
                                <li class="nav-item">
                                    <a class="nav-link" id="tab_Pertapedia" runat="server"
                                        aria-selected="true">Pertapedia
                                    </a>
                                </li>
                                <li class="nav-item">
                                    <a class="nav-link" role="tab" id="tab_Konten_social_media" runat="server"
                                        aria-selected="false">Konten Social Media
                                    </a>
                                </li>
                                <li class="nav-item">
                                    <a class="nav-link" role="tab" id="tab_Media_external" runat="server"
                                        aria-selected="false">Media External
                                    </a>
                                </li>
                            </ul>
                        </div>

                        <div class="kt-portlet__head-toolbar">
                            <b>Urutkan:</b>
                            <div class="btn-group ml-1" role="group" aria-label="Button group with nested dropdown">
                                <div class="btn-group" role="group">
                                    <asp:Literal ID="lblFilter" runat="server"></asp:Literal>
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
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="kt-portlet__body">
                        <div class="tab-content">
                            <div class="tab-pane active" id="kt_portlet_base_demo_2_4_tab_content" role="tabpanel" runat="server">
                                <!--begin::table Infografis_corporate -->
                                <!--begin::widget 12-->
                                <div class="row">
                                    <asp:ListView ID="listViewInfografis_corporate" runat="server">

                                        <EmptyDataTemplate>
                                            <table runat="server">
                                                <tr>
                                                    <td></td>
                                                </tr>
                                            </table>
                                        </EmptyDataTemplate>
                                        <EmptyItemTemplate>
                                            <td runat="server" />
                                        </EmptyItemTemplate>



                                        <ItemTemplate>
                                            <div class="col-md-3">
                                                <!--begin:: Widgets/Blog-->
                                                <div class="kt-portlet kt-portlet--height-fluid kt-widget19">
                                                    <div class="kt-portlet__body kt-portlet__body--fit kt-portlet__body--unfill">
                                                        <div class="kt-widget19__pic kt-portlet-fit--top kt-portlet-fit--sides" style="min-height: 200px; background-image: url('<%# ConvertUrl(Eval("file_blob"))%>')">
                                                        </div>
                                                    </div>
                                                    <div class="kt-portlet__body bd-thin">
                                                        <div class="kt-widget19__wrapper">
                                                            <div class="kt-widget19__content">
                                                                <div class="kt-widget19__info p-0">
                                                                    <a href='<%# ResolveUrl(string.Format("~/Media/Infographic-detail.aspx{0}&id={1}", PrevUrl, Eval("id"))) %>' class="kt-widget19__username"><%# Eval("created_by")%>
                                                                    </a>
                                                                    <span class="kt-widget1__time fsize-11"><%# string.Format("{0:dd MMM yyyy}", Eval("Created")) %>
                                                                    </span>
                                                                </div>
                                                            </div>
                                                            <div class="kt-widget18__text">
                                                                <%#  Crop(string.Format("{0}", Eval("Title")), 66) %>
                                                            </div>
                                                        </div>
                                                        <div class="kt-widget19__action">
                                                            <asp:HiddenField ID="hdn" runat="server" Value='<%# Eval("id")%>' />

                                                            <asp:HiddenField ID="hdnFileExt" runat="server" Value='<%# Eval("file_ext")%>' />
                                                            <asp:HyperLink ID="linkDetail" CssClass="btn btn-sm btn-label-brand btn-bold" NavigateUrl='<%# ResolveUrl(string.Format("~/Media/Infographic-detail.aspx{0}&id={1}", PrevUrl, Eval("id"))) %>' runat="server">Lihat</asp:HyperLink>
                                                        </div>
                                                    </div>
                                                </div>

                                                <!--end:: Widgets/Blog-->
                                            </div>
                                        </ItemTemplate>


                                    </asp:ListView>
                                </div>
                                <!--end::Widget 12-->
                                <div id="pagerInfografis_corporate" class="kt-pagination kt-pagination--sm kt-pagination--primary kt-mt-40">
                                    <ul class="kt-pagination__links">
                                        <asp:Repeater ID="rptPagerInfografis_corporate" runat="server" OnItemDataBound="rptPager_ItemDataBound">
                                            <ItemTemplate>
                                                <li runat="server" id="li">
                                                    <asp:LinkButton ID="lnkPage" runat="server" CommandName="Infografis_corporate" Text='<%#Eval("Text") %>' CommandArgument='<%# Eval("Value") %>' Enabled='<%# Eval("Enabled") %>' OnClick="Page_Changed"></asp:LinkButton>
                                                </li>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </ul>
                                    <div class="kt-pagination__toolbar">
                                        <asp:DropDownList ID="ddlPageSizeInfografis_corporate" AutoPostBack="true" runat="server" CssClass="form-control kt-font-primary" Style="width: 60px;" DataTextField="Text" DataValueField="Code" OnSelectedIndexChanged="ddlPageSize_SelectedIndexChanged"></asp:DropDownList>
                                        <span class="pagination__desc">
                                            <asp:Literal ID="lblTotalInfoInfografis_corporate" runat="server" Text=""></asp:Literal>
                                            <asp:HiddenField ID="hdnPageInfografis_corporate" runat="server" />
                                        </span>
                                    </div>
                                </div>
                                <!--end::table Infografis_corporate -->
                            </div>
                            <div runat="server" class="tab-pane" id="kt_portlet_base_demo_2_3_tab_content" role="tabpanel" runat="server">
                                <!--begin::table Pertapedia -->
                                <!--begin::widget 12-->
                                <div class="row">
                                    <asp:ListView ID="listViewPertapedia" runat="server">

                                        <EmptyDataTemplate>
                                            <table runat="server">
                                                <tr>
                                                    <td></td>
                                                </tr>
                                            </table>
                                        </EmptyDataTemplate>
                                        <EmptyItemTemplate>
                                            <td runat="server" />
                                        </EmptyItemTemplate>



                                        <ItemTemplate>
                                            <div class="col-md-3">
                                                <!--begin:: Widgets/Blog-->
                                                <div class="kt-portlet kt-portlet--height-fluid kt-widget19">
                                                    <div class="kt-portlet__body kt-portlet__body--fit kt-portlet__body--unfill">
                                                        <div class="kt-widget19__pic kt-portlet-fit--top kt-portlet-fit--sides" style="min-height: 200px; background-image: url('<%# ConvertUrl(Eval("file_blob"))%>')">
                                                        </div>
                                                    </div>
                                                    <div class="kt-portlet__body bd-thin">
                                                        <div class="kt-widget19__wrapper">
                                                            <div class="kt-widget19__content">
                                                                <div class="kt-widget19__info p-0">
                                                                    <a href='<%# ResolveUrl(string.Format("~/Media/Infographic-detail.aspx{0}&id={1}", PrevUrl, Eval("id"))) %>' class="kt-widget19__username"><%# Eval("created_by")%>
                                                                    </a>
                                                                    <span class="kt-widget1__time fsize-11"><%# string.Format("{0:dd MMM yyyy}", Eval("Created")) %>
                                                                    </span>
                                                                </div>
                                                            </div>
                                                            <div class="kt-widget18__text">
                                                                <%#  Crop(string.Format("{0}", Eval("Title")), 66) %>
                                                            </div>
                                                        </div>
                                                        <div class="kt-widget19__action">
                                                            <asp:HiddenField ID="hdn" runat="server" Value='<%# Eval("id")%>' />
                                                            <asp:HiddenField ID="hdnFileExt" runat="server" Value='<%# Eval("file_ext")%>' />
                                                            <asp:HyperLink ID="linkDetail" CssClass="btn btn-sm btn-label-brand btn-bold" NavigateUrl='<%# ResolveUrl(string.Format("~/Media/Infographic-detail.aspx{0}&id={1}", PrevUrl, Eval("id"))) %>' runat="server">Lihat</asp:HyperLink>
                                                        </div>
                                                    </div>
                                                </div>

                                                <!--end:: Widgets/Blog-->
                                            </div>
                                        </ItemTemplate>


                                    </asp:ListView>
                                </div>
                                <!--end::Widget 12-->
                                <div id="pagerPertapedia" class="kt-pagination kt-pagination--sm kt-pagination--primary kt-mt-40">
                                    <ul class="kt-pagination__links">
                                        <asp:Repeater ID="rptPagerPertapedia" runat="server" OnItemDataBound="rptPager_ItemDataBound">
                                            <ItemTemplate>
                                                <li runat="server" id="li">
                                                    <asp:LinkButton ID="lnkPage" runat="server" CommandName="Pertapedia" Text='<%#Eval("Text") %>' CommandArgument='<%# Eval("Value") %>' Enabled='<%# Eval("Enabled") %>' OnClick="Page_Changed"></asp:LinkButton>
                                                </li>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </ul>
                                    <div class="kt-pagination__toolbar">
                                        <asp:DropDownList ID="ddlPageSizePertapedia" AutoPostBack="true" runat="server" CssClass="form-control kt-font-primary" Style="width: 60px;" DataTextField="Text" DataValueField="Code" OnSelectedIndexChanged="ddlPageSize_SelectedIndexChanged"></asp:DropDownList>
                                        <span class="pagination__desc">
                                            <asp:Literal ID="lblTotalInfoPertapedia" runat="server" Text=""></asp:Literal>
                                            <asp:HiddenField ID="hdnPagePertapedia" runat="server" />
                                        </span>
                                    </div>
                                </div>
                                <!--end::table Pertapedia -->
                            </div>
                            <div class="tab-pane" id="kt_portlet_base_demo_2_2_tab_content" role="tabpanel" runat="server">
                                <!--begin::table Konten_social_media -->
                                <!--begin::widget 12-->
                                <div class="row">
                                    <asp:ListView ID="listViewKonten_social_media" runat="server">

                                        <EmptyDataTemplate>
                                            <table runat="server">
                                                <tr>
                                                    <td></td>
                                                </tr>
                                            </table>
                                        </EmptyDataTemplate>
                                        <EmptyItemTemplate>
                                            <td runat="server" />
                                        </EmptyItemTemplate>



                                        <ItemTemplate>
                                            <div class="col-md-3">
                                                <!--begin:: Widgets/Blog-->
                                                <div class="kt-portlet kt-portlet--height-fluid kt-widget19">
                                                    <div class="kt-portlet__body kt-portlet__body--fit kt-portlet__body--unfill">
                                                        <div class="kt-widget19__pic kt-portlet-fit--top kt-portlet-fit--sides" style="min-height: 200px; background-image: url('<%# ConvertUrl(Eval("file_blob"))%>')">
                                                        </div>
                                                    </div>
                                                    <div class="kt-portlet__body bd-thin">
                                                        <div class="kt-widget19__wrapper">
                                                            <div class="kt-widget19__content">
                                                                <div class="kt-widget19__info p-0">
                                                                    <a href='<%# ResolveUrl(string.Format("~/Media/Infographic-detail.aspx{0}&id={1}", PrevUrl, Eval("id"))) %>' class="kt-widget19__username"><%# Eval("created_by")%>
                                                                    </a>
                                                                    <span class="kt-widget1__time fsize-11"><%# string.Format("{0:dd MMM yyyy}", Eval("Created")) %>
                                                                    </span>
                                                                </div>
                                                            </div>
                                                            <div class="kt-widget18__text">
                                                                <%#  Crop(string.Format("{0}", Eval("Title")), 66) %>
                                                            </div>
                                                        </div>
                                                        <div class="kt-widget19__action">
                                                            <asp:HiddenField ID="hdn" runat="server" Value='<%# Eval("id")%>' />
                                                            <asp:HiddenField ID="hdnFileExt" runat="server" Value='<%# Eval("file_ext")%>' />
                                                            <asp:HyperLink ID="linkDetail" CssClass="btn btn-sm btn-label-brand btn-bold" NavigateUrl='<%# ResolveUrl(string.Format("~/Media/Infographic-detail.aspx{0}&id={1}", PrevUrl, Eval("id"))) %>' runat="server">Lihat</asp:HyperLink>
                                                        </div>
                                                    </div>
                                                </div>

                                                <!--end:: Widgets/Blog-->
                                            </div>
                                        </ItemTemplate>


                                    </asp:ListView>
                                </div>
                                <!--end::Widget 12-->
                                <div id="pagerKonten_social_media" class="kt-pagination kt-pagination--sm kt-pagination--primary kt-mt-40">
                                    <ul class="kt-pagination__links">
                                        <asp:Repeater ID="rptPagerKonten_social_media" runat="server" OnItemDataBound="rptPager_ItemDataBound">
                                            <ItemTemplate>
                                                <li runat="server" id="li">
                                                    <asp:LinkButton ID="lnkPage" runat="server" CommandName="Konten_social_media" Text='<%#Eval("Text") %>' CommandArgument='<%# Eval("Value") %>' Enabled='<%# Eval("Enabled") %>' OnClick="Page_Changed"></asp:LinkButton>
                                                </li>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </ul>
                                    <div class="kt-pagination__toolbar">
                                        <asp:DropDownList ID="ddlPageSizeKonten_social_media" AutoPostBack="true" runat="server" CssClass="form-control kt-font-primary" Style="width: 60px;" DataTextField="Text" DataValueField="Code" OnSelectedIndexChanged="ddlPageSize_SelectedIndexChanged"></asp:DropDownList>
                                        <span class="pagination__desc">
                                            <asp:Literal ID="lblTotalInfoKonten_social_media" runat="server" Text=""></asp:Literal>
                                            <asp:HiddenField ID="hdnPageKonten_social_media" runat="server" />
                                        </span>
                                    </div>
                                </div>
                                <!--end::table Konten_social_media -->
                            </div>
                            <div class="tab-pane" id="kt_portlet_base_demo_2_31_tab_content" role="tabpanel" runat="server">

                                <!--begin::table Media_external -->
                                <!--begin::widget 12-->
                                <div class="row">
                                    <asp:ListView ID="listViewMedia_external" runat="server">

                                        <EmptyDataTemplate>
                                            <table runat="server">
                                                <tr>
                                                    <td></td>
                                                </tr>
                                            </table>
                                        </EmptyDataTemplate>
                                        <EmptyItemTemplate>
                                            <td runat="server" />
                                        </EmptyItemTemplate>



                                        <ItemTemplate>
                                            <div class="col-md-3">
                                                <!--begin:: Widgets/Blog-->
                                                <div class="kt-portlet kt-portlet--height-fluid kt-widget19">
                                                    <div class="kt-portlet__body kt-portlet__body--fit kt-portlet__body--unfill">
                                                        <div class="kt-widget19__pic kt-portlet-fit--top kt-portlet-fit--sides" style="min-height: 200px; background-image: url('<%# ConvertUrl(Eval("file_blob"))%>')">
                                                        </div>
                                                    </div>
                                                    <div class="kt-portlet__body bd-thin">
                                                        <div class="kt-widget19__wrapper">
                                                            <div class="kt-widget19__content">
                                                                <div class="kt-widget19__info p-0">
                                                                    <a href='<%# ResolveUrl(string.Format("~/Media/Infographic-detail.aspx{0}&id={1}", PrevUrl, Eval("id"))) %>' class="kt-widget19__username"><%# Eval("created_by")%>
                                                                    </a>
                                                                    <span class="kt-widget1__time fsize-11"><%# string.Format("{0:dd MMM yyyy}", Eval("Created")) %>
                                                                    </span>
                                                                </div>
                                                            </div>
                                                            <div class="kt-widget18__text">
                                                                <%#  Crop(string.Format("{0}", Eval("Title")), 66) %>
                                                            </div>
                                                        </div>
                                                        <div class="kt-widget19__action">
                                                            <asp:HiddenField ID="hdn" runat="server" Value='<%# Eval("id")%>' />

                                                            <asp:HiddenField ID="hdnFileExt" runat="server" Value='<%# Eval("file_ext")%>' />
                                                            <asp:HyperLink ID="linkDetail" CssClass="btn btn-sm btn-label-brand btn-bold" NavigateUrl='<%# ResolveUrl(string.Format("~/Media/Infographic-detail.aspx{0}&id={1}", PrevUrl, Eval("id"))) %>' runat="server">Lihat</asp:HyperLink>
                                                        </div>
                                                    </div>
                                                </div>

                                                <!--end:: Widgets/Blog-->
                                            </div>
                                        </ItemTemplate>


                                    </asp:ListView>
                                </div>
                                <!--end::Widget 12-->
                                <div id="pagerMedia_external" class="kt-pagination kt-pagination--sm kt-pagination--primary kt-mt-40">
                                    <ul class="kt-pagination__links">
                                        <asp:Repeater ID="rptPagerMedia_external" runat="server" OnItemDataBound="rptPager_ItemDataBound">
                                            <ItemTemplate>
                                                <li runat="server" id="li">
                                                    <asp:LinkButton ID="lnkPage" runat="server" CommandName="Media_external" Text='<%#Eval("Text") %>' CommandArgument='<%# Eval("Value") %>' Enabled='<%# Eval("Enabled") %>' OnClick="Page_Changed"></asp:LinkButton>
                                                </li>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </ul>
                                    <div class="kt-pagination__toolbar">
                                        <asp:DropDownList ID="ddlPageSizeMedia_external" AutoPostBack="true" runat="server" CssClass="form-control kt-font-primary" Style="width: 60px;" DataTextField="Text" DataValueField="Code" OnSelectedIndexChanged="ddlPageSize_SelectedIndexChanged"></asp:DropDownList>
                                        <span class="pagination__desc">
                                            <asp:Literal ID="lblTotalInfoMedia_external" runat="server" Text=""></asp:Literal>
                                            <asp:HiddenField ID="hdnPageMedia_external" runat="server" />
                                        </span>
                                    </div>
                                </div>
                                <!--end::table Media_external -->
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
