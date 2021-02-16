<%@ Page Title="" Language="C#" MasterPageFile="~/Frontend.Master" AutoEventWireup="true" CodeBehind="stock-photo.aspx.cs" 
Inherits="Pertamina.CORSEC._2019.Media.stock_photo" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">

    <!-- begin:: Content -->
    <div class="kt-content-height">
        <div class="kt-content kt-content--fit-top  kt-grid__item kt-grid__item--fluid kt-grid kt-grid--hor"
            id="kt_content">
            

            <!-- begin:: Hero -->
            <%--  <div class="kt-sc" style="background-image: url('assets/media/bg/bg-9.jpg')">
                <div class="kt-container ">

                    <div class="kt-sc__bottom">
                        <h3 class="kt-sc__heading kt-heading kt-heading--center kt-heading--xxl kt-heading--medium">Stock Photo
                        </h3>
                    </div>
                </div>
            </div>--%>
            <asp:Literal ID="lblHeader" runat="server"></asp:Literal>
            <!-- end:: Hero -->

            <div class="kt-container">
                <div class="kt-portlet">
                    <div class="kt-portlet__body">
                        <div class="row">
                            <div class="col-md-6">

                                <!-- Expanded image -->
                                <%--<img id="expandedImg" src="assets/media/gallery/background1.jpg" style="width: 100%">--%>
                                <asp:Literal ID="lblExpandedImg" runat="server"></asp:Literal>
                                <!-- Image text -->
                                <div id="imgtext"></div>
                            </div>
                            <div class="col-md-6">
                                <div class="row-grid-gallery">
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
                                            <div class="column-grid-gallery">
                                                <img src='<%# ConvertUrl(Eval("file_blob"))%>' onclick="myFunction(this);">
                                            </div>
                                            <%--<div class="column-grid-gallery">
                                                <img src="assets/media/gallery/background2.jpg" onclick="myFunction(this);">
                                            </div>
                                            <div class="column-grid-gallery">
                                                <img src="assets/media/gallery/background3.jpg" onclick="myFunction(this);">
                                            </div>
                                            <div class="column-grid-gallery">
                                                <img src="assets/media/gallery/background4.jpg" onclick="myFunction(this);">
                                            </div>
                                            <div class="column-grid-gallery">
                                                <img src="assets/media/gallery/background1.jpg" onclick="myFunction(this);">
                                            </div>
                                            <div class="column-grid-gallery">
                                                <img src="assets/media/gallery/background2.jpg" onclick="myFunction(this);">
                                            </div>
                                            <div class="column-grid-gallery">
                                                <img src="assets/media/gallery/background3.jpg" onclick="myFunction(this);">
                                            </div>
                                            <div class="column-grid-gallery">
                                                <img src="assets/media/gallery/background4.jpg" onclick="myFunction(this);">
                                            </div>
                                            <div class="column-grid-gallery">
                                                <img src="assets/media/gallery/background1.jpg" onclick="myFunction(this);">
                                            </div>
                                            <div class="column-grid-gallery">
                                                <img src="assets/media/gallery/background2.jpg" onclick="myFunction(this);">
                                            </div>
                                            <div class="column-grid-gallery">
                                                <img src="assets/media/gallery/background3.jpg" onclick="myFunction(this);">
                                            </div>
                                            <div class="column-grid-gallery">
                                                <img src="assets/media/gallery/background4.jpg" onclick="myFunction(this);">
                                            </div>
                                            <div class="column-grid-gallery">
                                                <img src="assets/media/gallery/background1.jpg" onclick="myFunction(this);">
                                            </div>
                                            <div class="column-grid-gallery">
                                                <img src="assets/media/gallery/background2.jpg" onclick="myFunction(this);">
                                            </div>
                                            <div class="column-grid-gallery">
                                                <img src="assets/media/gallery/background3.jpg" onclick="myFunction(this);">
                                            </div>
                                            <div class="column-grid-gallery">
                                                <img src="assets/media/gallery/background4.jpg" onclick="myFunction(this);">
                                            </div>--%>
                                        </ItemTemplate>
                                    </asp:ListView>
                                </div>
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

        </div>
    </div>
    <!-- end:: Content -->

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="script" runat="server">

    <script>

        function myFunction(imgs) {
            // Get the expanded image
            var expandImg = document.getElementById("expandedImg");
            // Get the image text
            var imgText = document.getElementById("imgtext");
            // Use the same src in the expanded image as the image being clicked on from the grid
            expandImg.src = imgs.src;
            // Use the value of the alt attribute of the clickable image as text inside the expanded image
            imgText.innerHTML = imgs.alt;
            // Show the container element (hidden with CSS)
            expandImg.parentElement.style.display = "block";
        }
    </script>


</asp:Content>
