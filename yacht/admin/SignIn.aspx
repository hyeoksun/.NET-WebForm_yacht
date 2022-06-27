<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SignIn.aspx.cs" Inherits="yacht.admin.SignIn" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Flat Able - Premium Admin Template by Phoenixcoded</title>
    <!-- HTML5 Shim and Respond.js IE11 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 11]>
        <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
        <script src="https://oss.maxcdn.com/libs/respond.js/1.4.2/respond.min.js"></script>
    <![endif]-->
    <!-- Meta -->
    <meta charset="utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1.0, user-scalable=0, minimal-ui"/>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="description" content="" />
    <meta name="keywords" content=""/>
    <meta name="author" content="Phoenixcoded" />
    <!-- Favicon icon -->
    <link rel="icon" href="/admin/images/favicon.ico" type="image/x-icon"/>

    <!-- vendor css -->
    <link rel="stylesheet" href="/admin/css/style.css"/>
</head>
<body>
    <form id="form1" runat="server">
        <!-- [ auth-signin ] start -->
        <div class="auth-wrapper">
            <div class="auth-content text-center">
                <div class="card borderless">
                    <div class="row align-items-center ">
                        <div class="col-md-12">
                            <div class="card-body">
                                <h4 class="mb-3 f-w-400">Signin</h4>
                                <hr/>
                                <div class="form-group mb-3">
                                    <asp:TextBox ID="accountTB" runat="server" CssClass="form-control" Text="" placholder=""></asp:TextBox>
                                </div>
                                <div class="form-group mb-4">
                                    <asp:TextBox ID="passwordTB" runat="server" CssClass="form-control" Text="" placeholder="" TextMode="Password"></asp:TextBox>
                                </div>
                                <%--<div class="custom-control custom-checkbox text-left mb-4 mt-2">
                                    <input type="checkbox" class="custom-control-input" id="customCheck1">
                                    <label class="custom-control-label" for="customCheck1">Save credentials.</label>
                                </div>--%>
                                <br/>
                                <asp:Label ID="Label1" runat="server" Text="" Visible="False"></asp:Label>
                                <asp:Button ID="SignInBtn" runat="server" CssClass="btn btn-block btn-primary mb-4" Text="Signin" OnClick="SignInBtn_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <!-- [ auth-signin ] end -->

    </form>
<!-- Required Js -->
<script src="/admin/js/vendor-all.min.js"></script>
<script src="/admin/js/plugins/bootstrap.min.js"></script>

<script src="/admin/js/pcoded.min.js"></script>
</body>
</html>
