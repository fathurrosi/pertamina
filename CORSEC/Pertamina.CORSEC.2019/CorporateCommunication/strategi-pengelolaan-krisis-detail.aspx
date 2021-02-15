<%@ Page Title="" Language="C#" MasterPageFile="~/Frontend.Master" AutoEventWireup="true" CodeBehind="strategi-pengelolaan-krisis-detail.aspx.cs" Inherits="Pertamina.CORSEC._2019.CorporateCommunication.strategi_pengelolaan_krisis_detail" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">

    <!-- begin:: Content -->
    <div class="kt-content-height">
        <div class="kt-content  kt-content--fit-top  kt-grid__item kt-grid__item--fluid kt-grid kt-grid--hor"
            id="kt_content">

            <!-- begin:: Content -->

            <%--   <!-- begin:: Hero -->
            <div class="kt-sc" style="background-image: url('assets/media/bg/bg-9.jpg')">
              <div class="kt-container ">

                <div class="kt-sc__bottom">
                  <h3 class="kt-sc__heading kt-heading kt-heading--center kt-heading--xxl kt-heading--medium">
                   Krisis Komunikasi Pertamina
                  </h3>

                </div>
              </div>
            </div>
            <!-- end:: Hero -->--%>



            <asp:Literal ID="lblHeader" runat="server"></asp:Literal>

            <!-- end:: Section -->

            <!-- begin:: Section -->
            <div class="kt-container ">
                <div class="kt-portlet kt-portlet--mobile">
                    <div class="kt-portlet__head kt-portlet__head--lg">
                        <div class="kt-portlet__head-label">
                            <h3 class="kt-portlet__head-title">
                                <asp:Label ID="lblTitle" runat="server" Text=""></asp:Label>
                            </h3>
                        </div>
                        <div class="kt-portlet__head-toolbar">
                            <div class="btn-group" role="group" aria-label="Button group with nested dropdown">
                                <div class="btn-group" role="group">
                                    <%-- <button id="btnGroupDrop1" type="button" class="btn btn-secondary dropdown-toggle"
                                        data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                        Search Jenis Dokumen
                                    </button>
                                    <div class="dropdown-menu" aria-labelledby="btnGroupDrop1" x-placement="bottom-start"
                                        style="position: absolute; will-change: transform; top: 0px; left: 0px; transform: translate3d(0px, 39px, 0px);">
                                        <a class="dropdown-item" href="#">Pedoman</a>
                                        <a class="dropdown-item" href="#">TKO</a>
                                        <a class="dropdown-item" href="#">TKI</a>
                                    </div>--%>
                                    <asp:Literal ID="litDocType" runat="server"></asp:Literal>
                                </div>
                                <div class="btn-group" role="group">
                                    <%--<button id="btnGroupDrop1" type="button" class="btn btn-secondary dropdown-toggle"
                                        data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                        Tahun
                                    </button>
                                    <div class="dropdown-menu" aria-labelledby="btnGroupDrop1" x-placement="bottom-start"
                                        style="position: absolute; will-change: transform; top: 0px; left: 0px; transform: translate3d(0px, 39px, 0px);">
                                        <a class="dropdown-item" href="#">2020</a>
                                        <a class="dropdown-item" href="#">2019</a>
                                        <a class="dropdown-item" href="#">2018</a>
                                        <a class="dropdown-item" href="#">2017</a>
                                    </div>--%>

                                    <asp:Literal ID="litYear" runat="server"></asp:Literal>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="kt-portlet__body">
                        <div class="kt-section">
                            <div class="kt-section__content">
                                <%--       <div class="kt-widget4">
                                    <div class="kt-widget4__item p-2">
                                        <img class="kt-mr-10 kt-mt-0 kt-pt-0" src="assets/media/files/doc.svg" height="26" alt="">
                                        <div class="kt-widget4__title kt-widget4__title--light">
                                            Documents v6 has been arrived!<br />
                                            <small class="kt-widget4__number fsize-11 kt-mr-20 kt-pb-3"><i class="fa fa-clock"></i>13 April 2020 <i
                                                class="fa fa-download"></i>123</small><br />
                                            I distinguish three main text objektive could be merely to inform people.
A second could be persuade people.You want people to bay objective
                                        </div>
                                        <small class="kt-widget4__number fsize-11 kt-mr-20">PDF - 23mb</small>
                                        <span class="kt-widget3__number kt-font-info">
                                            <a href="#" class="btn-label-brand btn btn-sm btn-bold">Download</a>
                                        </span>
                                    </div>
                                    <div class="kt-widget4__item p-2">
                                        <img class="kt-mr-10" src="assets/media/files/doc.svg" height="26" alt="">
                                        <div class="kt-widget4__title kt-widget4__title--light">
                                            Documents v6 has been arrived!<br />
                                            <small class="kt-widget4__number fsize-11 kt-mr-20 kt-pb-3"><i class="fa fa-clock"></i>13 April 2020 <i
                                                class="fa fa-download"></i>123</small><br />
                                            I distinguish three main text objektive could be merely to inform people.
A second could be persuade people.You want people to bay objective
                                        </div>
                                        <small class="kt-widget4__number fsize-11 kt-mr-20">PDF - 23mb</small>
                                        <span class="kt-widget3__number kt-font-info">
                                            <a href="#" class="btn-label-brand btn btn-sm btn-bold">Download</a>
                                        </span>
                                    </div>
                                    <div class="kt-widget4__item p-2">
                                        <img class="kt-mr-10" src="assets/media/files/doc.svg" height="26" alt="">
                                        <div class="kt-widget4__title kt-widget4__title--light">
                                            Documents v6 has been arrived!<br />
                                            <small class="kt-widget4__number fsize-11 kt-mr-20 kt-pb-3"><i class="fa fa-clock"></i>13 April 2020 <i
                                                class="fa fa-download"></i>123</small><br />
                                            I distinguish three main text objektive could be merely to inform people.
A second could be persuade people.You want people to bay objective
                                        </div>
                                        <small class="kt-widget4__number fsize-11 kt-mr-20">PDF - 23mb</small>
                                        <span class="kt-widget3__number kt-font-info">
                                            <a href="#" class="btn-label-brand btn btn-sm btn-bold">Download</a>
                                        </span>
                                    </div>
                                    <div class="kt-widget4__item p-2">
                                        <img class="kt-mr-10" src="assets/media/files/doc.svg" height="26" alt="">
                                        <div class="kt-widget4__title kt-widget4__title--light">
                                            Documents v6 has been arrived!<br />
                                            <small class="kt-widget4__number fsize-11 kt-mr-20 kt-pb-3"><i class="fa fa-clock"></i>13 April 2020 <i
                                                class="fa fa-download"></i>123</small><br />
                                            I distinguish three main text objektive could be merely to inform people.
A second could be persuade people.You want people to bay objective
                                        </div>
                                        <small class="kt-widget4__number fsize-11 kt-mr-20">PDF - 23mb</small>
                                        <span class="kt-widget3__number kt-font-info">
                                            <a href="#" class="btn-label-brand btn btn-sm btn-bold">Download</a>
                                        </span>
                                    </div>
                                    <div class="kt-widget4__item p-2">
                                        <img class="kt-mr-10" src="assets/media/files/doc.svg" height="26" alt="">
                                        <div class="kt-widget4__title kt-widget4__title--light">
                                            Documents v6 has been arrived!<br />
                                            <small class="kt-widget4__number fsize-11 kt-mr-20 kt-pb-3"><i class="fa fa-clock"></i>13 April 2020 <i
                                                class="fa fa-download"></i>123</small><br />
                                            I distinguish three main text objektive could be merely to inform people.
A second could be persuade people.You want people to bay objective
                                        </div>
                                        <small class="kt-widget4__number fsize-11 kt-mr-20">Excel - 23mb</small>
                                        <span class="kt-widget3__number kt-font-info">
                                            <a href="#" class="btn-label-brand btn btn-sm btn-bold">Download</a>
                                        </span>
                                    </div>
                                    <div class="kt-widget4__item p-2">
                                        <img class="kt-mr-10" src="assets/media/files/doc.svg" height="26" alt="">
                                        <div class="kt-widget4__title kt-widget4__title--light">
                                            Documents v6 has been arrived!<br />
                                            <small class="kt-widget4__number fsize-11 kt-mr-20 kt-pb-3"><i class="fa fa-clock"></i>13 April 2020 <i
                                                class="fa fa-download"></i>123</small><br />
                                            I distinguish three main text objektive could be merely to inform people.
A second could be persuade people.You want people to bay objective
                                        </div>
                                        <small class="kt-widget4__number fsize-11 kt-mr-20">PDF - 23mb</small>
                                        <span class="kt-widget3__number kt-font-info">
                                            <a href="#" class="btn-label-brand btn btn-sm btn-bold">Download</a>
                                        </span>
                                    </div>
                                    <div class="kt-widget4__item p-2">
                                        <img class="kt-mr-10" src="assets/media/files/doc.svg" height="26" alt="">
                                        <div class="kt-widget4__title kt-widget4__title--light">
                                            Documents v6 has been arrived!<br />
                                            <small class="kt-widget4__number fsize-11 kt-mr-20 kt-pb-3"><i class="fa fa-clock"></i>13 April 2020 <i
                                                class="fa fa-download"></i>123</small><br />
                                            I distinguish three main text objektive could be merely to inform people.
A second could be persuade people.You want people to bay objective
                                        </div>
                                        <small class="kt-widget4__number fsize-11 kt-mr-20">Word - 23mb</small>
                                        <span class="kt-widget3__number kt-font-info">
                                            <a href="#" class="btn-label-brand btn btn-sm btn-bold">Download</a>
                                        </span>
                                    </div>
                                </div>
                                <div class="kt-pagination kt-pagination--sm kt-pagination--primary kt-mt-40">
                                    <ul class="kt-pagination__links">
                                        <li class="kt-pagination__link--first">
                                            <a href="#"><i class="fa fa-angle-double-left kt-font-primary"></i></a>
                                        </li>
                                        <li class="kt-pagination__link--next">
                                            <a href="#"><i class="fa fa-angle-left kt-font-primary"></i></a>
                                        </li>
                                        <li>
                                            <a href="#">...</a>
                                        </li>
                                        <li>
                                            <a href="#">29</a>
                                        </li>
                                        <li class="kt-pagination__link--active">
                                            <a href="#">30</a>
                                        </li>
                                        <li>
                                            <a href="#">31</a>
                                        </li>
                                        <li>
                                            <a href="#">32</a>
                                        </li>
                                        <li>
                                            <a href="#">33</a>
                                        </li>
                                        <li>
                                            <a href="#">34</a>
                                        </li>
                                        <li>
                                            <a href="#">...</a>
                                        </li>
                                        <li class="kt-pagination__link--prev">
                                            <a href="#"><i class="fa fa-angle-right kt-font-primary"></i></a>
                                        </li>
                                        <li class="kt-pagination__link--last">
                                            <a href="#"><i class="fa fa-angle-double-right kt-font-primary"></i></a>
                                        </li>
                                    </ul>
                                    <div class="kt-pagination__toolbar">
                                        <select class="form-control kt-font-primary" style="width: 60px;">
                                            <option value="10">10</option>
                                            <option value="20">20</option>
                                            <option value="30">30</option>
                                            <option value="50">50</option>
                                            <option value="100">100</option>
                                        </select>
                                        <span class="pagination__desc">Displaying 10 of 230 records
                                        </span>
                                    </div>
                                </div>--%>
                                <div class="kt-widget4">
                                    <asp:GridView ID="grid" runat="server" class="table table-borderless"
                                        AutoGenerateColumns="false"
                                        AllowPaging="true"
                                        AllowSorting="false"
                                        OnRowDataBound="grid_RowDataBound" ShowHeader="false" GridLines="None">
                                        <Columns>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:HiddenField ID="hdnID" runat="server" Value='<%# Eval("id")%>' />
                                                    <asp:HiddenField ID="hdnFileExt" runat="server" Value='<%# Eval("file_ext")%>' />
                                                    <div class="kt-widget4__item p-2">
                                                        <img class="kt-mr-10" src="assets/media/files/doc.svg" height="26" alt="">
                                                        <asp:Image ID="imgFile" runat="server" CssClass="kt-mr-10" Height="26" alt="" ImageUrl="~/Content/assets/media/files/jpg.svg" />
                                                        <div class="kt-widget4__title kt-widget4__title--light">
                                                            <%# Eval("Title")%>
                                                            <br />
                                                            <small class="kt-widget4__number fsize-11 kt-mr-20 kt-pb-3"><i class="fa fa-clock"></i><%# string.Format("{0:dd MMM yyyyy}", Eval("updated")) %> <i class="fa fa-download"></i><%# Eval("downloaded")%></small><br />
                                                            <%# Eval("Body")%>
                                                        </div>
                                                        <small class="kt-widget4__number fsize-11 kt-mr-20"><%# Pertamina.CORSEC.Business.Utilities.ExtToName( Eval("file_ext")) %> - <%# Eval("file_size")%></small>
                                                        <span class="kt-widget3__number kt-font-info">
                                                            <%--<a href="#" class="btn-label-brand btn btn-sm btn-bold">Download</a>--%>
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
