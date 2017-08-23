<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="PRM.Web.Login"%>

<%@ Register Src="~/UserControl/UCFooterJS.ascx" TagPrefix="uc1" TagName="UCFooterJS" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <meta name="description" content="Creative - Bootstrap 3 Responsive Admin Template" />
    <meta name="author" content="GeeksLabs" />
    <meta name="keyword" content="Creative, Dashboard, Admin, Template, Theme, Bootstrap, Responsive, Retina, Minimal" />
    <link rel="shortcut icon" href="img/favicon.png" />

    <title>Login Page  | Admin Template</title>
    <!-- Bootstrap CSS -->
    <link href="/assets/css/bootstrap.min.css" rel="stylesheet" /> 
    <!-- bootstrap theme -->
    <link href="/assets/css/bootstrap-theme.css" rel="stylesheet" />
    <!--external css-->
    <!-- font icon -->
    <link href="/assets/css/elegant-icons-style.css" rel="stylesheet" />
    <link href="/assets/css/font-awesome.css" rel="stylesheet" />
    <!-- Custom styles -->
    <link href="/assets/css/style.css" rel="stylesheet">
    <link href="/assets/css/style-responsive.css" rel="stylesheet" />
</head>
<body class="login-img3-body">  
    <form runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div class="container">
                    <div class="login-form">
                        <div class="login-wrap">
                            <p class="login-img"><i class="icon_lock_alt"></i></p>
                            <asp:Literal ID="lblError" runat="server"></asp:Literal>
                            <div class="input-group">
                                <asp:Literal ID="Literal1" runat="server"></asp:Literal>
                            </div>
                            <div class="input-group">
                                <span class="input-group-addon"><i class="icon_profile"></i></span>
                                <asp:TextBox ID="txtMail" runat="server" CssClass="form-control" Text="" placeholder="Kullanıcı Adı"></asp:TextBox>
                            </div>
                            <div class="input-group">
                                <span class="input-group-addon"><i class="icon_key_alt"></i></span>
                                <asp:TextBox ID="txtPassword" TextMode="Password" runat="server" Text="" CssClass="form-control" placeholder="Parola"></asp:TextBox>
                            </div>
                            <label class="checkbox">
                                <asp:CheckBox ID="chkRememberMe" runat="server"/>Beni Hatırla
                            </label>
                            <asp:LinkButton ID="btnLogin" runat="server" OnClick="btnLogin_Click" AcceptButton="" CssClass="btn btn-primary btn-lg btn-block">Giriş</asp:LinkButton>
                            
                        </div>
                    </div>
                    <div class="text-right">
                        <uc1:UCFooterJS runat="server" ID="UCFooterJS" />
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>

    </form>
    <script type="text/javascript">
     
    </script>
</body>
</html>
