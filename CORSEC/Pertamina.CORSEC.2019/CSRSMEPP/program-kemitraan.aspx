<%@ Page Title="" Language="C#" MasterPageFile="~/Frontend.Master" AutoEventWireup="true" CodeBehind="program-kemitraan.aspx.cs" Inherits="Pertamina.CORSEC._2019.CSRSMEPP.program_kemitraan" EnableEventValidation="false" %>

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

            <!-- begin:: Hero -->
            <%--  <div class="kt-sc" style="background-image: url('assets/media/bg/bg-9.jpg')">
                <div class="kt-container ">

                    <div class="kt-sc__bottom">
                        <h3 class="kt-sc__heading kt-heading kt-heading--center kt-heading--xxl kt-heading--medium">Strategi Pengelolaan CSR-BL
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
                                <h2 class="kt-infobox__title">Strategi Pengelolaan CSR-BL</h2>
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
            </div>--%>


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

                                <asp:Literal ID="litTab" runat="server"></asp:Literal>
                            </ul>
                        </div>



                    </div>
                    <div class="kt-portlet__body">
                        <div class="tab-content">
                            <div class="tab-pane active">
                                <div class="pull-right mb-3">
                                    <div class="btn-group" role="group" aria-label="Button group with nested dropdown">
                                        <div class="btn-group" role="group">
                                            <asp:Literal ID="litBulan" runat="server"></asp:Literal>

                                        </div>
                                        <div class="btn-group" role="group">
                                            <asp:Literal ID="litDocument" runat="server"></asp:Literal>

                                        </div>
                                    </div>
                                </div>
                                <div class="table-responsive">

                                    <asp:GridView ID="grid" runat="server" class="table table-bordered table-hover"
                                        AutoGenerateColumns="false"
                                        AllowPaging="true"
                                        AllowSorting="false"
                                        OnRowDataBound="grid_RowDataBound" ShowHeader="true" GridLines="None">
                                        <Columns>

                                            <asp:TemplateField HeaderText="No" ItemStyle-Width="4%">
                                                <ItemTemplate>
                                                    <%# Eval("ROW_NUMBER")%>
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
                            </div>

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
            <div class="kt-container ">
                <div class="kt-portlet">
                    <div class="kt-portlet__head">
                        <div class="kt-portlet__head-label">
                            <h3 class="kt-portlet__head-title">Kolektibilitas PK
                            </h3>
                        </div>
                        <div class="kt-portlet__head-toolbar">
                            <div class="btn-group ml-1" role="group" aria-label="Button group with nested dropdown">
                                <div class="btn-group" role="group">
                                    <asp:Literal ID="litTahun" runat="server"></asp:Literal>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="kt-portlet__body">
                        <div class="kt-widget4">

                         <asp:GridView ID="gridUncategorized" runat="server" class="table table-borderless"
                                AutoGenerateColumns="false"
                                AllowPaging="true"
                                AllowSorting="false"
                                OnRowDataBound="grid_RowDataBound" ShowHeader="false" GridLines="None">
                                <Columns>
                                    <asp:TemplateField HeaderText="Judul">
                                        <ItemTemplate>
                                            <asp:HiddenField ID="hdnFileID" runat="server" Value='<%# Eval("id")%>' />
                                            <asp:HiddenField ID="hdnFileExt" runat="server" Value='<%# Eval("file_ext")%>' />
                                            <div class="kt-widget4__item p-2">
                                                <asp:Image ID="imgFile" runat="server" CssClass="float-left mr-2" alt=" image" ImageUrl="~/Content/assets/media/files/jpg.svg" Visible="false" />
                                                <asp:HyperLink ID="linkFile" CssClass="kt-widget4__title kt-widget4__title--light" runat="server"><%# Eval("Title")%></asp:HyperLink>
                                                <span class="kt-widget3__number kt-font-info">
                                                    <a href="#" class="btn-label-brand btn btn-sm btn-bold">Lihat</a>
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

<%--                            <div class="kt-widget4__item p-2">
                                <a href="#" class="kt-widget4__title kt-widget4__title--light">Documents v6 has been arrived!
                                </a>
                                <span class="kt-widget3__number kt-font-info">
                                    <a href="#" class="btn-label-brand btn btn-sm btn-bold">Lihat</a>
                                </span>
                            </div>
                            <div class="kt-widget4__item p-2">
                                <a href="#" class="kt-widget4__title kt-widget4__title--light">Documents community meet-up 2019 in Rome.
                                </a>
                                <span class="kt-widget3__number kt-font-info">
                                    <a href="#" class="btn-label-brand btn btn-sm btn-bold">Lihat</a>
                                </span>
                            </div>
                            <div class="kt-widget4__item p-2">
                                <a href="#" class="kt-widget4__title kt-widget4__title--light">Documents Angular 8 version will be landing soon...
                                </a>
                                <span class="kt-widget3__number kt-font-info">
                                    <a href="#" class="btn-label-brand btn btn-sm btn-bold">Lihat</a>
                                </span>
                            </div>
                            <div class="kt-widget4__item p-2">
                                <a href="#" class="kt-widget4__title kt-widget4__title--light">ale! Purchase Documents at 70% off for limited time
                                </a>
                                <span class="kt-widget3__number kt-font-info">
                                    <a href="#" class="btn-label-brand btn btn-sm btn-bold">Lihat</a>
                                </span>
                            </div>
                            <div class="kt-widget4__item p-2">
                                <a href="#" class="kt-widget4__title kt-widget4__title--light">Documents VueJS version is in progress. Stay tuned!
                                </a>
                                <span class="kt-widget3__number kt-font-info">
                                    <a href="#" class="btn-label-brand btn btn-sm btn-bold">Lihat</a>
                                </span>
                            </div>
                            <div class="kt-widget4__item p-2">
                                <a href="#" class="kt-widget4__title kt-widget4__title--light">Black Friday! Purchase Documents at ever lowest 90% off for limited time
                                </a>
                                <span class="kt-widget3__number kt-font-info">
                                    <a href="#" class="btn-label-brand btn btn-sm btn-bold">Lihat</a>
                                </span>
                            </div>
                            <div class="kt-widget4__item p-2">
                                <a href="#" class="kt-widget4__title kt-widget4__title--light">Documents React version is in progress.
                                </a>
                                <span class="kt-widget3__number kt-font-info">
                                    <a href="#" class="btn-label-brand btn btn-sm btn-bold">Lihat</a>
                                </span>
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
