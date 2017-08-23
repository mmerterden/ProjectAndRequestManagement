<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MNGFirms.aspx.cs" Inherits="PRM.Web.Mng.MNGFirms" %>

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
    <form id="frmMNGFirms" runat="server">
        <section id="container" class="">
            <uc1:UCTopMenu runat="server" ID="UCTopMenu" />
            <uc1:UCLeftMenu runat="server" ID="UCLeftMenu" />
            <section id="main-content">
                <section class="wrapper">
                    <div class="row">
                        <div class="col-lg-12">
                            <h3 class="page-header"><i class="fa fa-building"></i>Şirketler<meta charset="utf-8" /></h3>
                            <ol class="breadcrumb">
                                <li><i class="fa fa-home"></i><a href="/default.aspx">Ana Sayfa</a></li>
                                <li><i class=""></i>Şirketler</li>
                            </ol>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                            <section class="panel">
                                <div class="panel-body progress-panel">
                                    <div class="row">
                                        <div class="col-lg-12 task-progress pull-left">
                                            <h3 class="pull-left no-margin">Şirketler</h3>
                                            <div class="pull-right MR-8">
                                                <asp:LinkButton ID="lnkbtnAdd" runat="server" CssClass="btn btn-success btn-sm" href="/Mng/MNGFirmAdd.aspx"><i class="fa fa-plus-circle"></i>&nbsp;Yeni Ekle</asp:LinkButton>
                                            </div>

                                        </div>
                                    </div>
                                </div>
                                <asp:Repeater ID="rptFirms" runat="server" OnItemCommand="rptFirms_ItemCommand">
                                    <HeaderTemplate>
                                        <table class="table table-striped table-advance table-hover">
                                            <thead>
                                                <tr>
                                                    <th class="col-xs-2"><i class="fa fa-building"></i>&nbsp;Şirket</th>
                                                    <th class="col-xs-2"><i class="fa fa-building-o"></i>&nbsp;İl</th>
                                                    <th class="col-xs-2"><i class="fa fa-building-o"></i>&nbsp;İlçe</th>
                                                    <th class="col-xs-4"><i class="fa fa-list-alt"></i>&nbsp;Açıklama</th>
                                                    <th class="col-xs-2"><i class="icon_cogs"></i>&nbsp;İşlemler</th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <tr>
                                            <td><%#Eval("NAME") %></td>
                                            <td><%#Eval("FIRMCITYNAME") %></td>
                                            <td><%#Eval("FIRMDISTRICTNAME") %></td>
                                            <td><%#Eval("DESCRIPTION") %></td>
                                            <td>
                                                <div class="btn-group">
                                                    <a href='/Mng/MNGFirmDetail.aspx?ID=<%#Eval("ID") %>' class="btn btn-info" ><i class="fa fa-info-circle"></i></a>
                                                    <asp:LinkButton ID="btnClose" runat="server" CssClass="btn btn-danger" CommandName="Delete" CommandArgument='<%#Eval("ID") %>'><i class="fa fa-times"></i></asp:LinkButton>
                                                </div>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        </tbody>
                                </table>
                                    </FooterTemplate>
                                </asp:Repeater>
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
