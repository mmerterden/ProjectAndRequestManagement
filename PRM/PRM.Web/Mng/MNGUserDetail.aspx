<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MNGUserDetail.aspx.cs" Inherits="PRM.Web.Mng.MNGUserDetail" %>

<%@ Register Src="~/UserControl/UCFooterJS.ascx" TagPrefix="uc1" TagName="UCFooterJS" %>
<%@ Register Src="~/UserControl/UCTopMenu.ascx" TagPrefix="uc1" TagName="UCTopMenu" %>
<%@ Register Src="~/UserControl/UCLeftMenu.ascx" TagPrefix="uc1" TagName="UCLeftMenu" %>
<%@ Register Src="~/UserControl/UCFooter.ascx" TagPrefix="uc1" TagName="UCFooter" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link rel="icon" href="/assets/img/icons/search-line-icon.png" type="image/x-icon" />

    <title></title>
    <!-- Bootstrap CSS -->
    <link href="/assets/css/bootstrap.min.css" rel="stylesheet" />
    <link href="//netdna.bootstrapcdn.com/bootstrap/3.3.2/css/bootstrap.min.css" rel="stylesheet" />
    <!-- bootstrap theme -->
    <link href="/assets/css/bootstrap-theme.css" rel="stylesheet" />
    <!--external css-->
    <!-- font icon -->
    <link href="/assets/css/elegant-icons-style.css" rel="stylesheet" />
    <link href="/assets/css/font-awesome.min.css" rel="stylesheet" />
    <!-- full calendar css-->
    <link href="/assets/Components/fullcalendar/fullcalendar/bootstrap-fullcalendar.css" rel="stylesheet" />
    <link href="/assets/Components/fullcalendar/fullcalendar/fullcalendar.css" rel="stylesheet" />
    <!-- easy pie chart-->
    <link href="/assets/Components/jquery-easy-pie-chart/jquery.easy-pie-chart.css" rel="stylesheet" type="text/css" media="screen" />
    <!-- owl carousel -->
    <link rel="stylesheet" href="/assets/css/owl.carousel.css" type="text/css" />
    <link href="/assets/css/jquery-jvectormap-1.2.2.css" rel="stylesheet" />
    <!-- Custom styles -->
    <link rel="stylesheet" href="/assets/css/fullcalendar.css" />
    <link href="/assets/css/widgets.css" rel="stylesheet" />
    <link href="/assets/css/style.css" rel="stylesheet" />
    <link href="/assets/css/style-responsive.css" rel="stylesheet" />
    <link href="/assets/css/xcharts.min.css" rel=" stylesheet" />
    <link href="/assets/css/jquery-ui-1.10.4.min.css" rel="stylesheet" />
    <link href="/assets/css/Custom.css" rel="stylesheet" />
</head>
<body>
    <form id="frmMNGUserDetail" runat="server">
        <section id="container" class="">
            <uc1:UCTopMenu runat="server" ID="UCTopMenu" />
            <uc1:UCLeftMenu runat="server" ID="UCLeftMenu" />

            <section id="main-content">
                <section class="wrapper">
                    <div class="row">
                        <div class="col-lg-12">
                            <h3 class="page-header"><i class="fa fa-file-text-o"></i>Kullanıcı Detayı<meta charset="utf-8" /></h3>
                            <ol class="breadcrumb">
                                <li><i class="fa fa-home"></i><a href="/Default.aspx">Ana Sayfa</a></li>
                                <li><i class="fa fa-building"></i><a href="/Mng/MNGFirms.aspx">Şirketler</a></li>
                                <li><i class="fa fa-user"></i><a href='/MNG/MNGFirmDetail.aspx?ID=<%=FIRMID%>'>Kullanıcılar</a></li>
                                <li><i class=""></i>Kullanıcı Detayı</li>
                            </ol>
                        </div>
                    </div>
                    <div class="row" id="dvInfoView" runat="server">
                        <div class="col-lg-12">
                            <section class="panel">
                                <div class="panel-body progress-panel">
                                    <div class="row">
                                        <div class="col-lg-8 task-progress pull-left">
                                            <h1>Kullanıcı</h1>
                                        </div>
                                        <div class="col-lg-4">
                                            <span class="pull-right MR11">
                                                <a href='/Mng/MNGUserUpdate.aspx?ID=<%=USERID %>' class="btn btn-primary btn-sm"><i class="fa fa-pencil-square-o"></i>&nbsp;Güncelle</a>
                                            </span>
                                        </div>
                                    </div>
                                </div>
                                <div class="panel-body">
                                    <div class="form">
                                        <div class="form-validate form-horizontal">
                                            <div class="form-group ">

                                                <div class="row">
                                                    <div class="col-xs-12">
                                                        <label class="col-lg-2 col-md-2 col-sm-2 MT10"><strong> Adı</strong></label>
                                                        <div class="col-lg-2 col-md-4 col-sm-4 MT10">
                                                            <asp:Label ID="lblName" runat="server"></asp:Label>
                                                        </div>
                                                        <label class="col-lg-2 col-md-2 col-sm-2 MT10"><strong>Soyadı</strong></label>
                                                        <div class="col-lg-2 col-md-4 col-sm-4 MT10">
                                                            <asp:Label ID="lblSurname" runat="server"></asp:Label>
                                                        </div>
                                                    </div>
                                                </div>
                                                <br />
                                                <div class="row">
                                                    <div class="col-xs-12">
                                                        <label class="col-lg-2 col-md-2 col-sm-2 MT10"><strong>Şirket Adı</strong></label>
                                                        <div class="col-lg-2 col-md-4 col-sm-4 MT10">
                                                            <asp:Label ID="lblFirmName" runat="server"></asp:Label>
                                                        </div>
                                                        <label class="col-lg-2 col-md-2 col-sm-2 MT10"><strong>Kayıt Tarihi</strong></label>
                                                        <div class="col-lg-2 col-md-4 col-sm-4 MT10">
                                                            <asp:Label ID="lblCreateDate" runat="server"></asp:Label>
                                                        </div>
                                                    </div>
                                                </div>
                                                <br />
                                                <div class="row">
                                                    <div class="col-xs-12">
                                                        <label class="col-lg-2 col-md-2 col-sm-2 MT10"><strong>E-Posta</strong></label>
                                                        <div class="col-lg-2 col-md-4 col-sm-4 MT10">
                                                            <asp:Label ID="lblEmail" runat="server"></asp:Label>
                                                        </div>
                                                        <label class="col-lg-2 col-md-2 col-sm-2 MT10"><strong>Telefon</strong></label>
                                                        <div class="col-lg-2 col-md-4 col-sm-4 MT10">
                                                            <asp:Label ID="lblPhone" runat="server"></asp:Label>
                                                        </div>
                                                    </div>
                                                </div>
                                                <br />
                                                <div class="row">
                                                    <div class="col-xs-12">
                                                        <label class="col-lg-2 col-md-2 col-sm-2 MT10"><strong>Durum</strong></label>
                                                        <div class="col-lg-2 col-md-4 col-sm-4 MT10">
                                                            <asp:Label ID="lblStatus" runat="server"></asp:Label>
                                                        </div>
                                                        <label class="col-lg-2 col-md-2 col-sm-2 MT10"><strong>Kullanıcı Tipi</strong></label>
                                                        <div class="col-lg-2 col-md-4 col-sm-4 MT10">
                                                            <asp:Label ID="lblUserType" runat="server"></asp:Label>
                                                        </div>
                                                    </div>
                                                </div>
                                                <br />
                                                 <div class="row">
                                                    <div class="col-xs-12">
                                                        <label class="col-lg-2 col-md-2 col-sm-2 MT10"><strong>Dil</strong></label>
                                                        <div class="col-lg-2 col-md-4 col-sm-4 MT10">
                                                            <asp:Label ID="lblLanguage" runat="server"></asp:Label>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>

                                        </div>
                                    </div>

                                </div>
                            </section>
                        </div>
                    </div>
                </section>
            </section>
        </section>
    </form>
    <uc1:UCFooterJS runat="server" ID="UCFooterJS" />
    <script type="text/javascript">
    </script>
</body>
</html>
