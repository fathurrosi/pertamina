<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Pertamina.CORSEC._2019.Admin.Login" %>

<%--<link href="<%: ResolveUrl("~/Content/admin/script/bootstrap.min.css") %>" rel="stylesheet" id="bootstrap-css">
<script src="<%: ResolveUrl("~/Content/admin/script/bootstrap.min.js") %>"></script>
<script src="<%: ResolveUrl("~/Content/admin/script/jquery.min.js") %>"></script>--%>
<!------ Include the above in your HEAD tag ---------->

<!DOCTYPE html>
<html>
<head>
    <title>Login Page</title>
    <!--Made with love by Mutiullah Samim -->
    <script src="https://kit.fontawesome.com/fd3d3f9361.js" crossorigin="anonymous"></script>

    <!--Bootsrap 4 CDN-->
    <link rel="stylesheet" href="<%: ResolveUrl("~/Content/admin/css/bootstrap.min.css") %>">

    <!--Fontawesome CDN-->
    <link rel="stylesheet" href="<%: ResolveUrl("~/Content/admin/css/all.css") %>">

    <!--Custom styles-->
    <style type="text/css">
        /* Made with love by Mutiullah Samim*/

        @import url('https://fonts.googleapis.com/css?family=Numans');

        html, body {
            /*background-image: url('<%: ResolveUrl("~/Content/admin/images/544750.jpg") %>');*/
            background-image: url('<%: ResolveUrl("~/Content/assets/media/bg/bg-9.jpg") %>');
            background-size: cover;
            background-repeat: no-repeat;
            height: 100%;
            font-family: 'Numans', sans-serif;
        }

        .container {
            height: 100%;
            align-content: center;
        }

        .card {
            height: 300px;
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

        .card-header h4 {
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
</head>
<body>
    <div class="container">
        <div class="d-flex justify-content-center h-100">
            <div class="card">
                <div class="card-header">
                    <h4>Login to admin page</h4>
                    <div class="d-flex justify-content-end social_icon">
                        <%--<span><i class="fab fa-facebook-square"></i></span>
                        <span><i class="fab fa-google-plus-square"></i></span>
                        <span><i class="fab fa-twitter-square"></i></span>--%>
                        <img alt="Logo" src="/CORSEC/Content/assets/media/logos/logo-dark.png" height="40">
                    </div>
                </div>
                <div class="card-body">
                    <form runat="server">
                        <div class="input-group form-group">
                            <div class="input-group-prepend">
                                <span class="input-group-text"><i class="fas fa-user"></i></span>
                            </div>
                            <%--<input type="text" class="form-control" placeholder="username">--%>
                            <asp:TextBox ID="txtUsername" runat="server" class="form-control" placeholder="Username" required="" autofocus=""></asp:TextBox>

                        </div>
                        <div class="input-group form-group">
                            <div class="input-group-prepend">
                                <span class="input-group-text"><i class="fas fa-key"></i></span>
                            </div>
                            <%--<input type="password" class="form-control" placeholder="password">--%>
                            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" class="form-control" placeholder="Password" required=""></asp:TextBox>
                        </div>
                        <div class="row align-items-center remember">
                            <%--  <input type="checkbox">Remember Me--%>
                            <asp:CheckBox ID="remember" runat="server" TextAlign="Right" Text="Remember me" />
                        </div>
                        <div class="form-group">

                            <asp:Button ID="btnLogin" runat="server" Text="Login" class="btn float-right login_btn" OnClick="btnLogin_Click" />
                        </div>
                    </form>
                </div>
                <%--<div class="card-footer">
                    <div class="d-flex justify-content-center links">
                        Don't have an account?<a href="#">Sign Up</a>
                    </div>
                    <div class="d-flex justify-content-center">
                        <a href="#">Forgot your password?</a>
                    </div>
                </div>--%>
            </div>
        </div>
    </div>
</body>
</html>
