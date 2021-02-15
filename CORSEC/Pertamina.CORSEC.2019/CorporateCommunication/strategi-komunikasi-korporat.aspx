<%@ Page Title="" Language="C#" MasterPageFile="~/Frontend.Master" AutoEventWireup="true" CodeBehind="strategi-komunikasi-korporat.aspx.cs" Inherits="Pertamina.CORSEC._2019.CorporateCommunication.strategi_komunikasi_korporat" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">

    <!-- begin:: Content -->
    <div class="kt-content-height">
        <div class="kt-content  kt-content--fit-top  kt-grid__item kt-grid__item--fluid kt-grid kt-grid--hor"
            id="kt_content">

            <!-- begin:: Content -->

            <%--            <!-- begin:: Hero -->
            <div class="kt-sc" style="background-image: url('assets/media/bg/bg-9.jpg')">
                <div class="kt-container ">

                    <div class="kt-sc__bottom">
                        <h3 class="kt-sc__heading kt-heading kt-heading--center kt-heading--xxl kt-heading--medium">Strategi Komunikasi Korporat
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
                                <h2 class="kt-infobox__title">Strategi Komunikasi Korporat</h2>
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
                <div class="kt-portlet kt-callout">
                    <div class="kt-portlet__body">
                        <div class="kt-callout__body">
                            <div class="kt-callout__content">

                                <div class="kt-widget4">
                                    <%-- <div class="kt-widget4__item p-2">
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
                                    </div>--%>

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
                                <hr />
                                <button type="button" class="btn btn-danger pull-right" data-toggle="modal" data-target="#kt_modal_4">Submit Report</button>

                                <!--begin::Modal-->
                                <div class="modal fade" id="kt_modal_4" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
                                    <div class="modal-dialog modal-lg" role="document">
                                        <div class="modal-content">
                                            <div class="modal-header">
                                                <h5 class="modal-title" id="exampleModalLabel">Submit Report</h5>
                                                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                                </button>
                                            </div>
                                            <div class="modal-body">
                                                <form>
                                                    <div class="row">
                                                        <div class="col-md-6">
                                                            <div class="form-group">
                                                                <label for="exampleSelect1">Jenis Laporan</label>
                                                                <select class="form-control" id="exampleSelect1">
                                                                    <option selected>Laporan Bulanan</option>
                                                                    <option>Laporan Triwulan QPI</option>
                                                                    <option>Laporan Informasi Publik</option>
                                                                    <option>Dokument Proper</option>
                                                                    <option>Laporan Bulanan Sekper</option>
                                                                    <option>Laporan Triwulan Sekper</option>
                                                                    <option>Laporan Tahunan Sekper</option>
                                                                    <option>Laporan QPI Sekper</option>
                                                                    <option>Laporan Informasi Publik Pertamina</option>
                                                                </select>
                                                            </div>

                                                            <div class="form-group">
                                                                <label>Laporan Bulanan</label>
                                                                <div class="kt-checkbox-list">
                                                                    <label class="kt-checkbox">
                                                                        <input type="checkbox" name="bulanan">
                                                                        Fungsi
                                        <span></span>
                                                                    </label>
                                                                    <label class="kt-checkbox">
                                                                        <input type="checkbox" name="bulanan">
                                                                        Unit
                                        <span></span>
                                                                    </label>
                                                                    <label class="kt-checkbox">
                                                                        <input type="checkbox" name="bulanan">
                                                                        Region
                                        <span></span>
                                                                    </label>
                                                                </div>
                                                            </div>

                                                            <div class="form-group">
                                                                <label>Laporan Triwulan QPI</label>
                                                                <div class="kt-checkbox-list">
                                                                    <label class="kt-checkbox">
                                                                        <input type="checkbox" name="bulanan">
                                                                        Fungsi
                                        <span></span>
                                                                    </label>
                                                                    <label class="kt-checkbox">
                                                                        <input type="checkbox" name="bulanan">
                                                                        Unit
                                        <span></span>
                                                                    </label>
                                                                    <label class="kt-checkbox">
                                                                        <input type="checkbox" name="bulanan">
                                                                        Region
                                        <span></span>
                                                                    </label>
                                                                </div>
                                                            </div>

                                                            <div class="form-group">
                                                                <label>Laporan Triwulan Informasi Publik</label>
                                                                <div class="kt-checkbox-list">
                                                                    <label class="kt-checkbox">
                                                                        <input type="checkbox" name="bulanan">
                                                                        Fungsi
                                        <span></span>
                                                                    </label>
                                                                    <label class="kt-checkbox">
                                                                        <input type="checkbox" name="bulanan">
                                                                        Unit
                                        <span></span>
                                                                    </label>
                                                                    <label class="kt-checkbox">
                                                                        <input type="checkbox" name="bulanan">
                                                                        Region
                                        <span></span>
                                                                    </label>
                                                                </div>
                                                            </div>
                                                            <div class="form-group">
                                                                <label>Dokument Proper</label>
                                                                <div class="row">
                                                                    <div class="col-md-1">
                                                                    </div>
                                                                    <div class="col-md-11">
                                                                        <input type="text" class="form-control" id="recipient-name" placeholder="Lokasi"><br />
                                                                        <input type="text" class="form-control" id="recipient-name" placeholder="Tahun"><br />

                                                                        <div class="kt-checkbox-inline">
                                                                            <label class="kt-checkbox">
                                                                                <input type="checkbox">Emas
                                        <span></span>
                                                                            </label>
                                                                            <label class="kt-checkbox">
                                                                                <input type="checkbox">
                                                                                Hijau
                                        <span></span>
                                                                            </label>
                                                                            <label class="kt-checkbox">
                                                                                <input type="checkbox">
                                                                                Biru
                                        <span></span>
                                                                            </label>
                                                                            <label class="kt-checkbox">
                                                                                <input type="checkbox">
                                                                                Merah
                                        <span></span>
                                                                            </label>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </form>
                                            </div>
                                            <div class="modal-footer">
                                                <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                                                <button type="button" class="btn btn-primary">Submit File</button>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                                <!--end::Modal-->
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
