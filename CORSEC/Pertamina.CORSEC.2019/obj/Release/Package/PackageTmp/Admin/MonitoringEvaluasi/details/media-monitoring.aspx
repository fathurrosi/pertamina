<%@ Page Title="" Language="C#" MasterPageFile="~/Backend.Master" AutoEventWireup="true" CodeBehind="media-monitoring.aspx.cs" Inherits="Pertamina.CORSEC._2019.Admin.MonitoringEvaluasi.details.media_monitoring" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div class="form-group">
        <div class="col-sm-12" style="text-align: center">
            <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
        </div>
    </div>
    <br />


    <div class="form-group">
        <label class="control-label col-sm-2">Judul</label>
        <div class="col-sm-6">
            <asp:TextBox ID="lblTitle" runat="server" class="form-control" MaxLength="1000"></asp:TextBox>
        </div>
    </div>


    <div class="form-group">
        <label class="control-label col-sm-2">Total Artikel</label>
        <div class="col-sm-1">
            <asp:TextBox ID="lblTotalArticle" runat="server" class="form-control allownumericwithdecimal" ></asp:TextBox>
        </div>
    </div>

    <div class="form-group">
        <label class="control-label col-sm-2">Tipe Monitoring</label>
        <div class="col-sm-4">
            <asp:DropDownList ID="ddlMonitoring_Type" runat="server" class="form-control">
                <asp:ListItem Text="--Pilih--" Value=""></asp:ListItem>
                <asp:ListItem Text="Mingguan" Value="Mingguan"></asp:ListItem>
                <asp:ListItem Text="Bulanan" Value="Bulanan"></asp:ListItem>
                <asp:ListItem Text="Tahunan" Value="Tahunan"></asp:ListItem>
            </asp:DropDownList>

        </div>
    </div>


    <div class="form-group">
        <label class="control-label col-sm-2">Tipe media</label>
        <div class="col-sm-4">

            <asp:DropDownList ID="ddlMedia_Type" runat="server" class="form-control">
                <asp:ListItem Text="--Pilih--" Value=""></asp:ListItem>
                <asp:ListItem Text="Internet" Value="Internet"></asp:ListItem>
                <asp:ListItem Text="Cetak" Value="Cetak"></asp:ListItem>
                <asp:ListItem Text="TV" Value="TV"></asp:ListItem>
            </asp:DropDownList>

        </div>
    </div>




    <div class="form-group">
        <label class="control-label col-sm-2">Nada Berita</label>
        <div class="col-sm-4">
            <asp:DropDownList ID="ddlTone" runat="server" class="form-control">
                <asp:ListItem Text="--Pilih--" Value=""></asp:ListItem>
                <asp:ListItem Text="Netral" Value="Netral"></asp:ListItem>
                <asp:ListItem Text="Positif" Value="Positif"></asp:ListItem>
                <asp:ListItem Text="Negatif" Value="Negatif"></asp:ListItem>

            </asp:DropDownList>

        </div>
    </div>



    <div class="form-group">
        <div class="col-sm-12" style="text-align: center">
            <div class="row">
                <asp:ListView ID="listViewMitra_binaan" runat="server">
                    <EmptyDataTemplate>
                        <div class="form-group">
                            <asp:Image ID="imgThumnail" ImageUrl="~/Content/assets/media/users/default.jpg" runat="server" CssClass="imgThumnail img-fluid img-thumbnail img-thumbnail-no-borders rounded-0" alt="image thumnail" />
                        </div>
                    </EmptyDataTemplate>
                    <EmptyItemTemplate>
                        <td runat="server" />
                    </EmptyItemTemplate>
                    <ItemTemplate>
                        <div class="col-md-4">
                            <!--begin:: Widgets/Blog-->
                            <div class="kt-portlet kt-portlet--height-fluid kt-widget19">
                                <div class="kt-portlet__body kt-portlet__body--fit kt-portlet__body--unfill">
                                    <a title="klik untuk edit atau hapus." href='<%# ResolveUrl(string.Format("~/Admin/Mitra/Details/Item-Add.aspx{0}&pid={1}&id={2}", PrevUrl, Eval("product_id"), Eval("id"))) %>' class="kt-widget19__username">
                                        <div class="kt-widget19__pic kt-portlet-fit--top kt-portlet-fit--sides" style="min-height: 280px; min-width: 200px; background-image: url('<%# ConvertUrl(Eval("file_blob"))%>')" title="klik untuk edit atau hapus.">
                                        </div>
                                    </a>
                                </div>
                            </div>
                            <!--end:: Widgets/Blog-->
                        </div>
                    </ItemTemplate>
                </asp:ListView>
            </div>
        </div>
    </div>
    <div class="form-group">
        <div class="col-sm-offset-2 col-sm-10">
            <asp:Button ID="btnSave" runat="server" Text="Simpan" OnClick="btnSave_Click" />
        </div>
    </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="script" runat="server">

    <script type="text/javascript">
        $(function () {
            $(".allownumericwithdecimal").on("keypress keyup blur", function (event) {
                //this.value = this.value.replace(/[^0-9\.]/g,'');
                $(this).val($(this).val().replace(/[^0-9\.]/g, ''));
                if ((event.which != 46 || $(this).val().indexOf('.') != -1) && (event.which < 48 || event.which > 57)) {
                    event.preventDefault();
                }
            });
        });



    </script>
</asp:Content>
