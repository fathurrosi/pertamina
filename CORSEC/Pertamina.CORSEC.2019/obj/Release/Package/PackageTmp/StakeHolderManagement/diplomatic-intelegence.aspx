<%@ Page Title="" Language="C#" MasterPageFile="~/Frontend.Master" AutoEventWireup="true" CodeBehind="diplomatic-intelegence.aspx.cs" Inherits="Pertamina.CORSEC._2019.StakeHolderManagement.diplomatic_intelegence" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">

    <!-- begin:: Content -->
    <div class="kt-content-height">
        <div class="kt-content  kt-content--fit-top  kt-grid__item kt-grid__item--fluid kt-grid kt-grid--hor"
            id="kt_content">

            <!-- begin:: Content -->

            <!-- begin:: Hero -->
            <%--   <div class="kt-sc" style="background-image: url('assets/media/bg/bg-9.jpg')">
              <div class="kt-container ">

                <div class="kt-sc__bottom">
                  <h3 class="kt-sc__heading kt-heading kt-heading--center kt-heading--xxl kt-heading--medium">
                    Strategic Stake holder Engagement
                  </h3>

                </div>
              </div>
            </div>--%>
            <!-- end:: Hero -->


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

            <!-- end:: Section -->


            <div class="kt-container ">
                <div class="kt-portlet">
                    <div class="kt-portlet__head">
                        <div class="kt-portlet__head-toolbar">
                            <ul class="nav nav-pills nav-fill" role="tablist">
                                <%--<li class="nav-item">
                                    <a class="nav-link active" data-toggle="tab" href="#kt_portlet_base_demo_2_4_tab_content"
                                        role="tab"
                                        aria-selected="false">County Profile
                                    </a>
                                </li>
                                <li class="nav-item">
                                    <a class="nav-link " data-toggle="tab" href="#kt_portlet_base_demo_2_3_tab_content"
                                        role="tab" aria-selected="true">Business Analisys
                                    </a>
                                </li>--%>
                                <asp:Literal ID="litTab" runat="server"></asp:Literal>
                            </ul>
                        </div>
                        <div class="kt-portlet__head-toolbar">
                            <div class="btn-group ml-1" role="group" aria-label="Button group with nested dropdown">
                                <div class="btn-group" role="group">
                                    <asp:Literal ID="litCountry" runat="server"></asp:Literal>

                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="kt-portlet__body">
                        <div class="tab-content">


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
                                    <asp:TemplateField HeaderText="Konten" ItemStyle-Width="15%">
                                        <ItemTemplate>
                                            <%# Eval("body")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Tahun" ItemStyle-Width="10%">
                                        <ItemTemplate>
                                            <%# Eval("year")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Judul">
                                        <ItemTemplate>
                                            <asp:HiddenField ID="hdnFileID" runat="server" Value='<%# Eval("id")%>' />
                                            <asp:HiddenField ID="hdnFileExt" runat="server" Value='<%# Eval("file_ext")%>' />
                                            <span class="kt-media kt-media--xs">
                                                <asp:Image ID="imgFile" runat="server" CssClass="float-left mr-2" alt=" image" ImageUrl="~/Content/assets/media/files/jpg.svg" />
                                                <asp:HyperLink ID="linkFile" CssClass="mt-1" runat="server"><%# Eval("Title")%></asp:HyperLink>
                                            </span>

                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Action" ItemStyle-Width="5%">
                                        <ItemTemplate>
                                            <a href="#" class="btn-label-brand btn btn-sm btn-bold">Lihat</a>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <EmptyDataTemplate>
                                    There are currently no items in this table.
                                </EmptyDataTemplate>
                                <PagerSettings Visible="false" />
                            </asp:GridView>

                        </div>

                        <div id="pager" class="kt-pagination kt-pagination--sm kt-pagination--primary kt-mt-40">
                            <ul class="kt-pagination__links">
                                <asp:Repeater ID="rptPager" runat="server" OnItemDataBound="rptPager_ItemDataBound">
                                    <ItemTemplate>
                                        <li runat="server" id="li">
                                            <asp:LinkButton ID="lnkPage" runat="server" CommandName="" Text='<%#Eval("Text") %>' CommandArgument='<%# Eval("Value") %>' Enabled='<%# Eval("Enabled") %>' OnClick="Page_Changed"></asp:LinkButton>
                                        </li>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </ul>
                            <div class="kt-pagination__toolbar">
                                <asp:DropDownList ID="ddlPageSize" AutoPostBack="true" runat="server" CssClass="form-control kt-font-primary" Style="width: 60px;" DataTextField="Text" DataValueField="Code" OnSelectedIndexChanged="ddlPageSize_SelectedIndexChanged"></asp:DropDownList>
                                <span class="pagination__desc">
                                    <asp:Literal ID="lblTotalInfo" runat="server" Text=""></asp:Literal>
                                    <asp:HiddenField ID="hdnPage" runat="server" />
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
