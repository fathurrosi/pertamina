<%@ Page Title="" Language="C#" MasterPageFile="~/Frontend.Master" AutoEventWireup="true" CodeBehind="presentasi.aspx.cs" Inherits="Pertamina.CORSEC._2019.SpeechReport.presentasi" EnableEventValidation="false" %>

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
                            <ul
                                class="nav nav-pills nav-fill"
                                role="tablist">
                                <li class="nav-item">
                                    <a class="nav-link active" role="tab" id="tab_Board_Speech" runat="server"
                                        aria-selected="false">Board Speech
                                    </a>
                                </li>
                                <li class="nav-item">
                                    <a class="nav-link" id="tab_Presentasi_Corporate" runat="server"
                                        aria-selected="true">Presentasi Corporate
                                    </a>
                                </li>
                                <li class="nav-item">
                                    <a class="nav-link" role="tab" id="tab_Email_Broadcast" runat="server"
                                        aria-selected="false">Email Broadcast
                                    </a>
                                </li>
                                <li class="nav-item">
                                    <a class="nav-link" role="tab" id="tab_Materi_Presentasi" runat="server"
                                        aria-selected="false">Materi Presentasi
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
                                <!--begin::table BoardSpeech -->
                                <!--begin::widget 12-->
                                <div class="row">
                                    <asp:ListView ID="listViewBoardSpeech" runat="server">

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
                                                                    <a href='<%# ResolveUrl(string.Format("~/SpeechReport/broadspeech-detail.aspx{0}&id={1}", PrevUrl, Eval("id"))) %>' class="kt-widget19__username"><%# Eval("Title")%>
                                                                    </a>
                                                                    <span class="kt-widget1__time fsize-11"><%# string.Format("{0:dd MMM yyyy}", Eval("Created")) %>
                                                                    </span>
                                                                </div>
                                                            </div>
                                                            <div class="kt-widget18__text">
                                                                <%#  Crop(string.Format("{0}", Eval("Body")), 66) %>
                                                            </div>
                                                        </div>
                                                        <div class="kt-widget19__action">
                                                            <asp:HiddenField ID="hdn" runat="server" Value='<%# Eval("id")%>' />
                                                            <asp:HiddenField ID="hdnFileID" runat="server" Value='<%# Eval("file_id")%>' />
                                                            <asp:HiddenField ID="hdnFileExt" runat="server" Value='<%# Eval("file_ext")%>' />
                                                            <asp:HyperLink ID="linkDetail" CssClass="btn btn-sm btn-label-brand btn-bold" NavigateUrl='<%# ResolveUrl(string.Format("~/SpeechReport/broadspeech-detail.aspx{0}&id={1}", PrevUrl, Eval("id"))) %>' runat="server">Selengkapnya...</asp:HyperLink>
                                                        </div>
                                                    </div>
                                                </div>

                                                <!--end:: Widgets/Blog-->
                                            </div>
                                        </ItemTemplate>


                                    </asp:ListView>
                                </div>
                                <!--end::Widget 12-->
                                <div id="pagerBoardSpeech" class="kt-pagination kt-pagination--sm kt-pagination--primary kt-mt-40">
                                    <ul class="kt-pagination__links">
                                        <asp:Repeater ID="rptPagerBoardSpeech" runat="server" OnItemDataBound="rptPager_ItemDataBound">
                                            <ItemTemplate>
                                                <li runat="server" id="li">
                                                    <asp:LinkButton ID="lnkPage" runat="server" CommandName="BoardSpeech" Text='<%#Eval("Text") %>' CommandArgument='<%# Eval("Value") %>' Enabled='<%# Eval("Enabled") %>' OnClick="Page_Changed"></asp:LinkButton>
                                                </li>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </ul>
                                    <div class="kt-pagination__toolbar">
                                        <asp:DropDownList ID="ddlPageSizeBoardSpeech" AutoPostBack="true" runat="server" CssClass="form-control kt-font-primary" Style="width: 60px;" DataTextField="Text" DataValueField="Code" OnSelectedIndexChanged="ddlPageSize_SelectedIndexChanged"></asp:DropDownList>
                                        <span class="pagination__desc">
                                            <asp:Literal ID="lblTotalInfoBoardSpeech" runat="server" Text=""></asp:Literal>
                                            <asp:HiddenField ID="hdnPageBoardSpeech" runat="server" />
                                        </span>
                                    </div>
                                </div>
                                <!--end::table BoardSpeech -->
                            </div>
                            <div runat="server" class="tab-pane" id="kt_portlet_base_demo_2_3_tab_content" role="tabpanel" runat="server">

                                <!--begin::table PresentasiCorporate -->
                                <!--begin::widget 12-->
                                <div class="kt-widget4">
                                    <asp:GridView ID="gridPresentasiCorporate" runat="server" class="table table-borderless"
                                        AutoGenerateColumns="false"
                                        AllowPaging="true"
                                        AllowSorting="false"
                                        OnRowDataBound="grid_RowDataBound" ShowHeader="false" GridLines="None">
                                        <Columns>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:HiddenField ID="hdn" runat="server" Value='<%# Eval("id")%>' />
                                                    <asp:HiddenField ID="hdnFileID" runat="server" Value='<%# Eval("file_id")%>' />
                                                    <asp:HiddenField ID="hdnFileExt" runat="server" Value='<%# Eval("file_ext")%>' />
                                                    <div class="kt-widget4__item p-2">
                                                        <asp:Image ID="imgFile" runat="server" CssClass="kt-mr-10" Height="26" alt="" ImageUrl="~/Content/assets/media/files/jpg.svg" />
                                                        <asp:HyperLink ID="linkDetail" CssClass="kt-widget4__title kt-widget4__title--light" runat="server"><%# Eval("Title")%></asp:HyperLink>
                                                        <small class="kt-widget4__number fsize-11 kt-mr-20"><%# Eval("file_desc") %></small>
                                                        <span class="kt-widget3__number kt-font-info">
                                                            <asp:HyperLink ID="linkFile" CssClass="btn-label-brand btn btn-sm btn-bold" runat="server">Download</asp:HyperLink>
                                                        </span>
                                                    </div>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <EmptyDataTemplate>
                                            There are currently no items in this table.
                                        </EmptyDataTemplate>
                                        <PagerSettings Visible="false" />
                                    </asp:GridView>
                                </div>
                                <!--end::Widget 12-->
                                <div id="pagerPresentasiCorporate" class="kt-pagination kt-pagination--sm kt-pagination--primary kt-mt-40">
                                    <ul class="kt-pagination__links">
                                        <asp:Repeater ID="rptPagerPresentasiCorporate" runat="server" OnItemDataBound="rptPager_ItemDataBound">
                                            <ItemTemplate>
                                                <li runat="server" id="li">
                                                    <asp:LinkButton ID="lnkPage" runat="server" CommandName="PresentasiCorporate" Text='<%#Eval("Text") %>' CommandArgument='<%# Eval("Value") %>' Enabled='<%# Eval("Enabled") %>' OnClick="Page_Changed"></asp:LinkButton>
                                                </li>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </ul>
                                    <div class="kt-pagination__toolbar">
                                        <asp:DropDownList ID="ddlPageSizePresentasiCorporate" AutoPostBack="true" runat="server" CssClass="form-control kt-font-primary" Style="width: 60px;" DataTextField="Text" DataValueField="Code" OnSelectedIndexChanged="ddlPageSize_SelectedIndexChanged"></asp:DropDownList>
                                        <span class="pagination__desc">
                                            <asp:Literal ID="lblTotalInfoPresentasiCorporate" runat="server" Text=""></asp:Literal>
                                            <asp:HiddenField ID="hdnPagePresentasiCorporate" runat="server" />
                                        </span>
                                    </div>
                                </div>
                                <!--end::table PresentasiCorporate -->
                            </div>
                            <div class="tab-pane" id="kt_portlet_base_demo_2_2_tab_content" role="tabpanel" runat="server">

                                <!--begin::table EmailBroadcast -->
                                <!--begin::widget 12-->
                                <div class="kt-widget4">
                                    <asp:GridView ID="gridEmailBroadcast" runat="server" class="table table-borderless"
                                        AutoGenerateColumns="false"
                                        AllowPaging="true"
                                        AllowSorting="false"
                                        OnRowDataBound="grid_RowDataBound" ShowHeader="false" GridLines="None">
                                        <Columns>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:HiddenField ID="hdn" runat="server" Value='<%# Eval("id")%>' />
                                                    <asp:HiddenField ID="hdnFileID" runat="server" Value='<%# Eval("file_id")%>' />
                                                    <asp:HiddenField ID="hdnFileExt" runat="server" Value='<%# Eval("file_ext")%>' />
                                                    <div class="kt-widget4__item p-2">
                                                        <asp:Image ID="imgFile" runat="server" CssClass="kt-mr-10" Height="26" alt="" ImageUrl="~/Content/assets/media/files/jpg.svg" />
                                                        <asp:HyperLink ID="linkDetail" CssClass="kt-widget4__title kt-widget4__title--light" runat="server"><%# Eval("Title")%></asp:HyperLink>
                                                        <small class="kt-widget4__number fsize-11 kt-mr-20"><%# Eval("file_desc") %></small>
                                                        <span class="kt-widget3__number kt-font-info">
                                                            <asp:HyperLink ID="linkFile" CssClass="btn-label-brand btn btn-sm btn-bold" runat="server">Download</asp:HyperLink>
                                                        </span>
                                                    </div>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <EmptyDataTemplate>
                                            There are currently no items in this table.
                                        </EmptyDataTemplate>
                                        <PagerSettings Visible="false" />
                                    </asp:GridView>
                                </div>
                                <!--end::Widget 12-->
                                <div id="pagerEmailBroadcast" class="kt-pagination kt-pagination--sm kt-pagination--primary kt-mt-40">
                                    <ul class="kt-pagination__links">
                                        <asp:Repeater ID="rptPagerEmailBroadcast" runat="server" OnItemDataBound="rptPager_ItemDataBound">
                                            <ItemTemplate>
                                                <li runat="server" id="li">
                                                    <asp:LinkButton ID="lnkPage" runat="server" CommandName="EmailBroadcast" Text='<%#Eval("Text") %>' CommandArgument='<%# Eval("Value") %>' Enabled='<%# Eval("Enabled") %>' OnClick="Page_Changed"></asp:LinkButton>
                                                </li>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </ul>
                                    <div class="kt-pagination__toolbar">
                                        <asp:DropDownList ID="ddlPageSizeEmailBroadcast" AutoPostBack="true" runat="server" CssClass="form-control kt-font-primary" Style="width: 60px;" DataTextField="Text" DataValueField="Code" OnSelectedIndexChanged="ddlPageSize_SelectedIndexChanged"></asp:DropDownList>
                                        <span class="pagination__desc">
                                            <asp:Literal ID="lblTotalInfoEmailBroadcast" runat="server" Text=""></asp:Literal>
                                            <asp:HiddenField ID="hdnPageEmailBroadcast" runat="server" />
                                        </span>
                                    </div>
                                </div>
                                <!--end::table EmailBroadcast-->

                            </div>
                            <div class="tab-pane" id="kt_portlet_base_demo_2_31_tab_content" role="tabpanel" runat="server">

                                <!--begin::table MateriPresentasi -->
                                <!--begin::widget 12-->
                                <div class="kt-widget4">
                                    <asp:GridView ID="gridMateriPresentasi" runat="server" class="table table-borderless"
                                        AutoGenerateColumns="false"
                                        AllowPaging="true"
                                        AllowSorting="false"
                                        OnRowDataBound="grid_RowDataBound" ShowHeader="false" GridLines="None">
                                        <Columns>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:HiddenField ID="hdn" runat="server" Value='<%# Eval("id")%>' />
                                                    <asp:HiddenField ID="hdnFileID" runat="server" Value='<%# Eval("file_id")%>' />
                                                    <asp:HiddenField ID="hdnFileExt" runat="server" Value='<%# Eval("file_ext")%>' />
                                                    <div class="kt-widget4__item p-2">
                                                        <asp:Image ID="imgFile" runat="server" CssClass="kt-mr-10" Height="26" alt="" ImageUrl="~/Content/assets/media/files/jpg.svg" />
                                                        <asp:HyperLink ID="linkDetail" CssClass="kt-widget4__title kt-widget4__title--light" runat="server"><%# Eval("Title")%></asp:HyperLink>
                                                        <small class="kt-widget4__number fsize-11 kt-mr-20"><%# Eval("file_desc") %></small>
                                                        <span class="kt-widget3__number kt-font-info">
                                                            <asp:HyperLink ID="linkFile" CssClass="btn-label-brand btn btn-sm btn-bold" runat="server">Download</asp:HyperLink>
                                                        </span>
                                                    </div>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <EmptyDataTemplate>
                                            There are currently no items in this table.
                                        </EmptyDataTemplate>
                                        <PagerSettings Visible="false" />
                                    </asp:GridView>
                                </div>
                                <!--end::Widget 12-->
                                <div id="pagerMateriPresentasi" class="kt-pagination kt-pagination--sm kt-pagination--primary kt-mt-40">
                                    <ul class="kt-pagination__links">
                                        <asp:Repeater ID="rptPagerMateriPresentasi" runat="server" OnItemDataBound="rptPager_ItemDataBound">
                                            <ItemTemplate>
                                                <li runat="server" id="li">
                                                    <asp:LinkButton ID="lnkPage" runat="server" CommandName="MateriPresentasi" Text='<%#Eval("Text") %>' CommandArgument='<%# Eval("Value") %>' Enabled='<%# Eval("Enabled") %>' OnClick="Page_Changed"></asp:LinkButton>
                                                </li>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </ul>
                                    <div class="kt-pagination__toolbar">
                                        <asp:DropDownList ID="ddlPageSizeMateriPresentasi" AutoPostBack="true" runat="server" CssClass="form-control kt-font-primary" Style="width: 60px;" DataTextField="Text" DataValueField="Code" OnSelectedIndexChanged="ddlPageSize_SelectedIndexChanged"></asp:DropDownList>
                                        <span class="pagination__desc">
                                            <asp:Literal ID="lblTotalInfoMateriPresentasi" runat="server" Text=""></asp:Literal>
                                            <asp:HiddenField ID="hdnPageMateriPresentasi" runat="server" />
                                        </span>
                                    </div>
                                </div>
                                <!--end::table MateriPresentasi -->
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
