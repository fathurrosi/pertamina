<%@ Page Title="" Language="C#" MasterPageFile="~/Frontend.Master" AutoEventWireup="true" CodeBehind="Exhibition.aspx.cs" Inherits="Pertamina.CORSEC._2019.Brand.Exhibition" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">

    <!-- begin:: Content -->
    <div class="kt-content-height">
        <div class="kt-content kt-content--fit-top  kt-grid__item kt-grid__item--fluid kt-grid kt-grid--hor"
            id="kt_content">

            <!-- begin:: Content -->

            <!-- begin:: Hero -->            
            <asp:Literal ID="lblHeader" runat="server"></asp:Literal>
            <!-- end:: Hero -->

            <div class="kt-container">
                <div class="kt-portlet">
                    <div class="kt-portlet__body">
                        <div class="kt-infobox">
                            <div class="kt-infobox__header">
                                <h2 class="kt-infobox__title">
                                    <asp:Label ID="lblTittle" runat="server" Text=""></asp:Label></h2>
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
            <div class="kt-container kt-pt10">
                <div class="kt-portlet">
                    <div class="kt-portlet__body">

                        <div class="row">
                            <asp:ListView ID="listViewExhibition" runat="server">
                                <EmptyDataTemplate>
                                    <table runat="server">
                                        <tr>
                                            <td>No data was returned.</td>
                                        </tr>
                                    </table>
                                </EmptyDataTemplate>
                                <EmptyItemTemplate>
                                    <td runat="server" />
                                </EmptyItemTemplate>
                                <ItemTemplate>
                                    <div class="col-md-4">
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
                                                            <a href='<%# ResolveUrl(string.Format("~/Brand/Exhibition-Detail.aspx{0}&id={1}", PrevUrl, Eval("id"))) %>' class="kt-widget19__username"><%# Eval("Created_By")%>
                                                            </a>
                                                            <span class="kt-widget1__time fsize-11"><%# string.Format("{0:dd MMM yyyy}", Eval("Created")) %>
                                                            </span>
                                                        </div>
                                                    </div>


                                                    <div class="kt-widget18__text">
                                                        <%# Crop(Eval("Body"), 66) %>
                                                    </div>
                                                </div>
                                                <div class="kt-widget19__action">
                                                    <asp:HiddenField ID="hdn" runat="server" Value='<%# Eval("id")%>' />

                                                    <asp:HiddenField ID="hdnFileExt" runat="server" Value='<%# Eval("file_ext")%>' />
                                                    <asp:HyperLink ID="linkDetail" CssClass="btn btn-sm btn-label-brand btn-bold" NavigateUrl='<%# ResolveUrl(string.Format("~/Brand/Exhibition-Detail.aspx{0}&id={1}", PrevUrl, Eval("id"))) %>' runat="server">Selengkapnya...</asp:HyperLink>
                                                </div>
                                            </div>
                                        </div>
                                        <!--end:: Widgets/Blog-->
                                    </div>
                                </ItemTemplate>
                            </asp:ListView>
                        </div>

                        <div id="pagerExhibition" class="kt-pagination kt-pagination--sm kt-pagination--primary kt-mt-40">
                            <ul class="kt-pagination__links">
                                <asp:Repeater ID="rptPagerExhibition" runat="server" OnItemDataBound="rptPager_ItemDataBound">
                                    <ItemTemplate>
                                        <li runat="server" id="li">
                                            <asp:LinkButton ID="lnkPage" runat="server" CommandName="Exhibition" Text='<%#Eval("Text") %>' CommandArgument='<%# Eval("Value") %>' Enabled='<%# Eval("Enabled") %>' OnClick="Page_Changed"></asp:LinkButton>
                                        </li>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </ul>
                            <div class="kt-pagination__toolbar">
                                <asp:DropDownList ID="ddlPageSizeExhibition" AutoPostBack="true" runat="server" CssClass="form-control kt-font-primary" Style="width: 60px;" DataTextField="Text" DataValueField="Code" OnSelectedIndexChanged="ddlPageSize_SelectedIndexChanged"></asp:DropDownList>
                                <span class="pagination__desc">
                                    <asp:Literal ID="lblTotalInfoExhibition" runat="server" Text=""></asp:Literal>
                                    <asp:HiddenField ID="hdnPageExhibition" runat="server" />
                                </span>
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
