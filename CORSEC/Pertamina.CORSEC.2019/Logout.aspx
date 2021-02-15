<%@ Page Title="" Language="C#" MasterPageFile="~/Frontend.Master" AutoEventWireup="true" CodeBehind="Logout.aspx.cs" Inherits="Pertamina.CORSEC._2019.Logout" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <!--Made with love by Mutiullah Samim -->
    <script src="https://kit.fontawesome.com/fd3d3f9361.js" crossorigin="anonymous"></script>
    <!--Bootsrap 4 CDN-->
    <link rel="stylesheet" href="<%: ResolveUrl("~/Content/admin/css/bootstrap.min.css") %>" />

    <!--Fontawesome CDN-->
    <link rel="stylesheet" href="<%: ResolveUrl("~/Content/admin/css/all.css") %>" />
      <!--Custom styles-->
    <style type="text/css">
        /* Made with love by Mutiullah Samim
        @import url('https://fonts.googleapis.com/css?family=Poppins:300,400,500,600,700|Roboto:300,400,500,600,700');
*/

        html, body {
            /*background-image: url('<%: ResolveUrl("~/Content/admin/images/544750.jpg") %>');*/
            background-image: url('<%: ResolveUrl("~/Content/assets/media/bg/bg-9.jpg") %>');
            background-size: cover;
            background-repeat: no-repeat;
            height: 100%;
        }

        .container {
            padding-top: 15%;
            height: 100%;
            align-content: center;
        }

        .card {
            height: 240px;
            margin-top: auto;
            margin-bottom: auto;
            width: 400px;
            background-color: rgba(0,0,0,0.5) !important;
        }

        .social_icon span {
            font-size: 60px;
            margin-left: 10px;
            color: #FFC312;
        }

            .social_icon span:hover {
                color: white;
                cursor: pointer;
            }

        .card-header h3 {
            color: white;
        }

        .social_icon {
            position: absolute;
            right: 20px;
            top: -45px;
        }

        .input-group-prepend span {
            width: 50px;
            /*background-color: #FFC312;*/
            background-color: cornflowerblue;
            color: black;
            border: 0 !important;
        }

        input:focus {
            outline: 0 0 0 0 !important;
            box-shadow: 0 0 0 0 !important;
        }

        .remember {
            color: white;
        }

            .remember input {
                width: 20px;
                height: 20px;
                margin-left: 15px;
                margin-right: 5px;
            }

        .login_btn {
            color: black;
            background-color: cornflowerblue;
            /*background-color: #FFC312;*/
            width: 100px;
        }

            .login_btn:hover {
                color: black;
                background-color: white;
            }

        .links {
            color: white;
        }

            .links a {
                margin-left: 4px;
            }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="script" runat="server">
</asp:Content>
