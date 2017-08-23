<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PRJProjectTaskAdd.aspx.cs" Inherits="PRM.Web.Prj.PRJProjectTaskAdd" %>

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
                            <h3 class="page-header"><i class="fa fa-tasks"></i>Proje Görev Ekle<meta charset="utf-8" /></h3>
                            <ol class="breadcrumb">
                                <li><i class="fa fa-home"></i><a href="/Default.aspx">Ana Sayfa</a></li>
                                <li><i class="fa fa-suitcase"></i><a href="/Prj/PRJProjects.aspx">Projeler</a></li>
                                <li><i class="fa fa-file-text-o"></i><a href='/Prj/PRJProjectDetail.aspx?ID=<%=PROJECTID%>'>Proje Detayı</a></li>
                                <li><i class=""></i>Proje Görev Ekle</li>
                            </ol>
                        </div>
                    </div>
                    <div class="row" id="dvInfoView" runat="server">
                        <div class="col-lg-12">
                            <section class="panel">
                                <header class="panel-heading">
                                    Proje Görev Ekleme
                                </header>
                                <div class="panel-body">
                                    <div class="form">
                                        <div class="form-validate form-horizontal">
                                            <div class="form-group ">
                                                <div class="row">
                                                    <div class="col-xs-12">
                                                        <label for="cname" class="control-label col-lg-1 col-md-2 col-sm-2 MT10">Proje Adı</label>
                                                        <div class="col-lg-11 col-md-11 col-sm-11 MT10">
                                                            <div class="input-group input-icon input-icon-right padding-right-2n">
                                                            <asp:Label CssClass="form-control" ID="lblProjectName" runat="server"></asp:Label>
                                                                <span class="input-group-addon"><i class="ace-icon fa fa-suitcase bigger-120"></i></span>
                                                                </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <br/>
                                                <div class="row">
                                                    <div class="col-xs-12">
                                                        <label for="cname" class="control-label col-lg-1 col-md-2 col-sm-2 MT10">Görev Adı</label>
                                                        <div class="col-lg-5 col-md-4 col-sm-4 MT10">
                                                            <div class="input-group input-icon input-icon-right padding-right-2n">
                                                            <asp:TextBox ID="txtTaskName" runat="server" MaxLength="50" CssClass="form-control" ></asp:TextBox>
                                                                <span class="input-group-addon"><i class="ace-icon fa fa-tasks bigger-120"></i></span>
                                                                </div>
                                                        </div>
                                                         <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                                                        <asp:UpdatePanel ID="updPanl" ChildrenAsTriggers="true" runat="server" RenderMode="Block" UpdateMode="Conditional">
                                                            <Triggers>
                                                                <asp:AsyncPostBackTrigger ControlID="btnCal" EventName="Click" />
                                                            </Triggers>
                                                            <ContentTemplate>
                                                        <label for="cname" class="control-label col-lg-1 col-md-2 col-sm-2 MT10">Termin Tarihi</label>
                                                        <div class="col-lg-5 col-md-4 col-sm-4 MT10">
                                                            <div class="input-group input-icon input-icon-right padding-right-2n" id="datetimepicker1">
                                                                <asp:TextBox ID="txtCreateDate" runat="server" onclick="hide(event)" MaxLength="50" CssClass="form-control" onKeyPress="return nothing(event)"></asp:TextBox>
                                                                <span class="input-group-addon"  onmouseup="hide(event)"><i class="ace-icon fa fa-calendar bigger-120"></i></span>
                                                                <asp:Button ID="btnCal" OnClick="btnCal_Click" Style="display: none" runat="server" />
                                                            </div>
                                                             <asp:Calendar ID="CalDate" runat="server" OnSelectionChanged="CalDate_SelectionChanged"  BackColor="White" WeekendDayStyle-BackColor="#E1E1E1" WeekendDayStyle-BorderColor="Black" SelectorStyle-BackColor="White" SelectedDayStyle-BackColor="#0099FF" SelectionMode="DayWeekMonth"></asp:Calendar>
                                                        </div>
                                                                   </ContentTemplate>
                                                        </asp:UpdatePanel>
                                                    </div>
                                                </div>
                                                <br/>
                                                <div class="row">
                                                    <div class="col-xs-12">
                                                        <label for="cname" class="control-label col-lg-1 col-md-2 col-sm-2 MT10">Açıklama</label>
                                                        <div class="col-lg-11 col-md-10 col-sm-10">
                                                            <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" Rows="3" CssClass="form-control"></asp:TextBox>
                                                        </div>

                                                    </div>
                                                </div>
                                                <br/>
                                                <div class="col-lg-12 col-xs-12">
                                                    <asp:Literal ID="lblError1" runat="server"></asp:Literal>
                                                </div>
                                            </div>
                                            <div class="form-group MT10">
                                                <div class="col-lg-12">
                                                    <div class="pull-right">
                                                         <a class="btn btn-warning" href='/Prj/PRJProjectDetail.aspx?ID=<%=PROJECTID%>'><i class="fa fa-minus-circle"></i>&nbsp;İptal</a>
                                                        <asp:LinkButton ID="btnAddNew" runat="server" CssClass="btn btn-success" OnClick="btnAddNew_Click"><i class="fa fa-floppy-o"></i>&nbsp;Kaydet</asp:LinkButton>
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
      <script type="text/javascript" language="javascript">
          function nothing(evt) {
            evt = (evt) ? evt : window.event
            var charCode = (evt.which) ? evt.which : evt.keyCode
            if ((charCode >= 0 && charCode <= 127)) {
                return false
            }
            return true
        }
          function hide(event) {
              $("#btnCal").click();
          }
    </script>
</body>
</html>
