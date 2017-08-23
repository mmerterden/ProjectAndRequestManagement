<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="REQRequestDetail.aspx.cs" Inherits="PRM.Web.Req.REQRequestDetail" %>

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
    <form id="form1" runat="server">
        <section id="container" class="">
            <uc1:UCTopMenu runat="server" ID="UCTopMenu" />
            <uc1:UCLeftMenu runat="server" ID="UCLeftMenu" />

            <section id="main-content">
                <section class="wrapper">
                    <div class="row">
                        <div class="col-lg-12">
                            <h3 class="page-header"><i class="fa fa-file-text-o"></i>Talep Detayı<meta charset="utf-8" /></h3>

                            <ol class="breadcrumb">
                                <li><i class="fa fa-home"></i><a href="/Default.aspx">Ana Sayfa</a></li>
                                <li><i class="icon_mail_alt"></i><a href="/Req/REQRequests.aspx">Talepler</a></li>
                                <li><i class=""></i>Talep Detayı</li>
                            </ol>
                        </div>
                    </div>
                    <div class="row" id="dvInfoView" runat="server">
                        <div class="col-lg-12">
                            <section class="panel">
                                <header class="panel-heading">
                                    Proje
                                </header>
                                <div class="panel-body">
                                    <div class="form">
                                        <div class="form-validate form-horizontal">
                                            <div class="form-group ">

                                                <div class="row">
                                                    <div class="col-xs-12">
                                                        <label for="cname" class="col-lg-1 col-md-2 col-sm-2 MT10"><strong>Proje Adı</strong></label>
                                                        <div class="col-lg-5 col-md-4 col-sm-4 MT10">
                                                            <asp:Label ID="lblProjectName" runat="server"></asp:Label>
                                                        </div>
                                                        <label for="cname" class="col-lg-1 col-md-2 col-sm-2 MT10"><strong>Durum</strong></label>
                                                        <div class="col-lg-5 col-md-4 col-sm-4 MT10">
                                                            <asp:DropDownList ID="drpRequestStatusName" AutoPostBack="true" OnSelectedIndexChanged="drpRequestStatusName_SelectedIndexChanged" CssClass="form-control" runat="server"></asp:DropDownList>
                                                        </div>
                                                    </div>
                                                </div>
                                                <br />
                                                <div class="row">
                                                    <div class="col-xs-12">
                                                        <label for="cname" class="col-lg-1 col-md-2 col-sm-2 MT10"><strong>Talep Sahibi</strong></label>
                                                        <div class="col-lg-5 col-md-4 col-sm-4 MT10">
                                                            <asp:Label ID="lblUserFullName" runat="server"></asp:Label>
                                                        </div>
                                                        <label for="cname" class="col-lg-1 col-md-2 col-sm-2 MT10"><strong>Talep Tarihi</strong></label>
                                                        <div class="col-lg-5 col-md-4 col-sm-4 MT10">
                                                            <asp:Label ID="lblRequestDate" runat="server"></asp:Label>
                                                        </div>
                                                    </div>
                                                </div>
                                                <br />
                                                <div class="col-lg-12">
                                                    <section class="panel">
                                                        <header class="panel-heading">
                                                            Talep Açıklaması
                                                        </header>
                                                        <div class="panel-body">
                                                            <div class="form">
                                                                <div class="form-validate form-horizontal">
                                                                    <div class="form-group ">
                                                                        <div class="row">
                                                                            <div class="col-xs-12">
                                                                                <div class="col-lg-12 col-md-12 col-sm-12 MT10">
                                                                                    <asp:Label ID="lblDescription" runat="server"></asp:Label>
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

                                        </div>
                                    </div>

                                </div>
                            </section>
                        </div>
                    </div>
                    <div class="row" id="msglist" runat="server">
                        <div class="col-lg-12">
                            <section class="panel">
                                <header class="panel-heading">
                                    Mesaj Listesi
                                </header>
                                <div class="panel-body">
                                    <div class="tab-content">
                                        <div id="recent-activity" class="tab-pane active">
                                            <div class="profile-activity">
                                                <asp:Repeater ID="rptMessage" runat="server">
                                                    <ItemTemplate>
                                                        <div class="<%#Eval("CLASS") %>">
                                                            <div id="usr" runat="server" class="act-time">
                                                                <div class="activity-body act-in">
                                                                    <span class="arrow"></span>
                                                                    <div class="text">
                                                                        <a href="#" class="activity-img">
                                                                            <img class="avatar" src="<%#Eval("PICTURE") %>" alt="" /></a>
                                                                        <p class="attribution"><a href="#"><%#Eval("USERFULLNAME") %></a> <%#Eval("DATE") %></p>
                                                                        <p><%#Eval("MESSAGE") %></p>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <br />
                                                    </ItemTemplate>
                                                </asp:Repeater>

                                            </div>
                                        </div>

                                    </div>
                                </div>
                            </section>
                        </div>
                    </div>
                    <div class="row" id="msg" runat="server">
                        <div class="col-lg-12">
                            <section class="panel">
                                <header class="panel-heading">
                                    Mesajlar
                                </header>
                                <div class="panel-body">
                                    <div class="form">
                                        <div class="form-validate form-horizontal">
                                            <div class="form-group ">
                                                <div class="row">
                                                    <div class="col-xs-12">
                                                        <label for="cname" class="control-label col-lg-1 col-md-2 col-sm-2 MT10">Mesaj</label>
                                                        <div class="col-lg-11 col-md-10 col-sm-10 MT10">
                                                            <asp:TextBox ID="txtMessage" runat="server" MaxLength="50" CssClass="form-control W50" TextMode="MultiLine" Rows="3"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <br />
                                                <div class="col-lg-12 col-xs-12">
                                                    <asp:Literal ID="lblError1" runat="server"></asp:Literal>
                                                </div>
                                            </div>
                                            <div class="form-group MT20 MT10">
                                                <div class="col-lg-12">
                                                    <div class="col-lg-12">
                                                        <div class="pull-right">
                                                            <a class="btn btn-warning" href="/Req/REQRequests.aspx"><i class="fa fa-minus-circle"></i>&nbsp;İptal</a>
                                                            <asp:LinkButton ID="btnSend" runat="server" CssClass="btn btn-success" OnClick="btnSend_Click"><i class="fa fa-comments-o" aria-hidden="true"></i>&nbsp;Gönder</asp:LinkButton>
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
