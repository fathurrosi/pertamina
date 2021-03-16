<%@ Page Title="" Language="C#" MasterPageFile="~/Backend.Master" AutoEventWireup="true" CodeBehind="kinerja-sekper-monitoring.aspx.cs" Inherits="Pertamina.CORSEC._2019.Admin.MonitoringEvaluasi.details.kinerja_sekper_monitoring" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <style type="text/css">
        .ui-datepicker-calendar {
            display: none;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div class="form-group">
        <div class="col-sm-12" style="text-align: center">
            <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
        </div>
    </div>
    <br />




    <div class="form-group">
        <label class="control-label col-sm-2">Tipe Kinerja</label>
        <div class="col-sm-4">
            <asp:DropDownList ID="ddlKineja" runat="server" class="form-control">
                <asp:ListItem Text="--Pilih--" Value=""></asp:ListItem>
                <asp:ListItem Text="Kinerja Sekper" Value="1"></asp:ListItem>
                <asp:ListItem Text="Kinerja Unit/Fungsi" Value="2"></asp:ListItem>
            </asp:DropDownList>
        </div>
    </div>


    <div class="form-group">
        <label class="control-label col-sm-2">Laporan</label>
        <div class="col-sm-6">
            <asp:TextBox ID="lblTitle" runat="server" class="form-control" MaxLength="1000"></asp:TextBox>
        </div>
    </div>


    <div class="form-group">
        <label class="control-label col-sm-2">Bulan</label>
        <div class="col-sm-2">
            <asp:TextBox ID="txtMonth" runat="server" class="date-picker form-control"></asp:TextBox>
        </div>
    </div>

    <div class="form-group">
        <label class="control-label col-sm-2">Periode</label>
        <div class="col-sm-4">
            <asp:DropDownList ID="ddlPeriode" runat="server" class="form-control">
                <asp:ListItem Text="--Pilih--" Value=""></asp:ListItem>
                <asp:ListItem Text="Triwulan" Value="Triwulan"></asp:ListItem>
            </asp:DropDownList>
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

            $(".date-picker").datepicker({
                format: "M-yyyy",
                viewMode: "months",
                minViewMode: "months"
            });

        });
    </script>

</asp:Content>
