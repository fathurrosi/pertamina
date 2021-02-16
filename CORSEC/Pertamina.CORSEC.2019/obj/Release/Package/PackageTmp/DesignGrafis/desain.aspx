<%@ Page Title="" Language="C#" MasterPageFile="~/Frontend.Master" AutoEventWireup="true" CodeBehind="desain.aspx.cs" Inherits="Pertamina.CORSEC._2019.DesignGrafis.desain" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">

    <!-- begin:: Content -->
    <div class="kt-content-height">
        <div class="kt-content  kt-content--fit-top  kt-grid__item kt-grid__item--fluid kt-grid kt-grid--hor"
            id="kt_content">

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
            <div class="kt-container">

                <div class="kt-portlet">
                    <div class="kt-portlet__head">
                        <div class="kt-portlet__head-toolbar">
                            <ul class="nav nav-pills nav-fill" role="tablist">

                                <asp:Literal ID="litTab" runat="server"></asp:Literal>
                            </ul>
                        </div>

                    </div>
                    <div class="kt-portlet__body">
                        <div class="tab-content">
                            <div class="tab-pane active" id="kt_portlet_base_demo_2_3_tab_content" role="tabpanel">


                                <!--begin::widget 12-->
                                <div class="row">
                                    <asp:ListView ID="listViewPrint_Ad" runat="server">

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
                                                                    <a href='<%# ResolveUrl(string.Format("~/DesignGrafis/desain-detail.aspx{0}&id={1}", PrevUrl, Eval("id"))) %>' class="kt-widget19__username"><%# Eval("created_by")%>
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
                                                            <asp:HyperLink ID="linkDetail" CssClass="btn btn-sm btn-label-brand btn-bold" NavigateUrl='<%# ResolveUrl(string.Format("~/DesignGrafis/desain-detail.aspx{0}&id={1}", PrevUrl, Eval("id"))) %>' runat="server">Lihat</asp:HyperLink>
                                                        </div>
                                                    </div>
                                                </div>

                                                <!--end:: Widgets/Blog-->
                                            </div>
                                        </ItemTemplate>


                                    </asp:ListView>
                                </div>
                                <!--end::Widget 12-->
                                <div id="pagerPrint_Ad" class="kt-pagination kt-pagination--sm kt-pagination--primary kt-mt-40">
                                    <ul class="kt-pagination__links">
                                        <asp:Repeater ID="rptPagerPrint_Ad" runat="server" OnItemDataBound="rptPager_ItemDataBound">
                                            <ItemTemplate>
                                                <li runat="server" id="li">
                                                    <asp:LinkButton ID="lnkPage" runat="server" CommandName="Print_Ad" Text='<%#Eval("Text") %>' CommandArgument='<%# Eval("Value") %>' Enabled='<%# Eval("Enabled") %>' OnClick="Page_Changed"></asp:LinkButton>
                                                </li>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </ul>
                                    <div class="kt-pagination__toolbar">
                                        <asp:DropDownList ID="ddlPageSizePrint_Ad" AutoPostBack="true" runat="server" CssClass="form-control kt-font-primary" Style="width: 60px;" DataTextField="Text" DataValueField="Code" OnSelectedIndexChanged="ddlPageSize_SelectedIndexChanged"></asp:DropDownList>
                                        <span class="pagination__desc">
                                            <asp:Literal ID="lblTotalInfoPrint_Ad" runat="server" Text=""></asp:Literal>
                                            <asp:HiddenField ID="hdnPagePrint_Ad" runat="server" />
                                        </span>
                                    </div>
                                </div>
                                <!--end::table Print_Ad -->
                            </div>

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
