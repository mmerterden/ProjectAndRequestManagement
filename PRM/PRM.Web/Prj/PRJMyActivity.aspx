<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PRJMyActivity.aspx.cs" Inherits="PRM.Web.Prj.PRJMyActivity" %>

<%@ Register Src="~/UserControl/UCFooterJS.ascx" TagPrefix="uc1" TagName="UCFooterJS" %>
<%@ Register Src="~/UserControl/UCTopMenu.ascx" TagPrefix="uc1" TagName="UCTopMenu" %>
<%@ Register Src="~/UserControl/UCLeftMenu.ascx" TagPrefix="uc1" TagName="UCLeftMenu" %>
<%@ Register Src="~/UserControl/UCFooter.ascx" TagPrefix="uc1" TagName="UCFooter" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title></title>
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
                    <div class="row ">
                        <div class="col-lg-12">
                            <h3 class="page-header"><i class="fa fa-tasks"></i>Aktivitelerim<meta charset="utf-8" /></h3>

                            <ol class="breadcrumb">
                                <li><i class="fa fa-home"></i><a href="/Default.aspx">Ana Sayfa</a></li>
                                <li><i class="fa fa-tasks"></i><a href="/Prj/PRJMyTasks.aspx">Görevlerim</a></li>
                                <li><i class=""></i>Aktivitelerim</li>
                            </ol>
                        </div>
                    </div>
                    <div class="row FS12">
                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                            <section class="panel">
                                <div class="panel-body progress-panel">
                                    <div class="row">
                                        <div class="col-lg-8 task-progress pull-left">
                                            <h1>Aktivite Listesi</h1>
                                        </div>
                                    </div>
                                </div>
                                <asp:Repeater ID="rptActivity" runat="server" OnItemCommand="rptActivity_ItemCommand">
                                    <HeaderTemplate>
                                        <table class="table table-striped table-advance table-hover">
                                            <thead>
                                                <tr>
                                                    <th><i class="fa fa-bullseye"></i>&nbsp Aktivite</th>
                                                    <th><i class="fa fa-suitcase"></i>&nbsp Proje Adı</th>
                                                    <th><i class="fa fa-tasks"></i>&nbsp Görev Adı</th>
                                                    <th><i class="fa fa-calendar"></i>&nbsp Başlangıç Tarihi</th>
                                                    <th><i class="fa fa-clock-o"></i>&nbsp Süre</th>
                                                    <th><i class="icon_cogs "></i>&nbsp İşlem</th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <tr>
                                            <td><%#Eval("DESCRIPTION") %></td>
                                            <td><%#Eval("PROJECTNAME") %></td>
                                            <td><%#Eval("PROJECTTASKNAME") %></td>
                                            <td><%#Eval("DATE") %></td>
                                            <td><%#Eval("RESOURSEDURATION") %></td>
                                            <td>
                                                <div class="btn-group">
                                                    <a href='/Prj/PRJProjectMyTasksActivityUpdate.aspx?ID=<%#Eval("ID") %>' class="btn btn-primary"><i class="fa fa-pencil"></i></a>
                                                    <asp:LinkButton ID="btnDelete" runat="server" CssClass="btn btn-danger" CommandName="Delete" CommandArgument='<%#Eval("ID") %>'><i class="fa fa-times"></i></asp:LinkButton>
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
