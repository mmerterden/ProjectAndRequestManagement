<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MNGFirmAdd.aspx.cs" Inherits="PRM.Web.Mng.MNGFirmAdd" %>

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
    <form id="frmMNGFirmAdd" runat="server">
        <section id="container" class="">
            <uc1:UCTopMenu runat="server" ID="UCTopMenu" />
            <uc1:UCLeftMenu runat="server" ID="UCLeftMenu" />

            <section id="main-content">
                <section class="wrapper">
                    <div class="row">
                        <div class="col-lg-12">
                            <h3 class="page-header"><i class="fa fa-building"></i>Şirket Ekle<meta charset="utf-8" /></h3>
                            <ol class="breadcrumb">
                                <li><i class="fa fa-home"></i><a href="/Default.aspx">Ana Sayfa</a></li>
                                <li><i class="fa fa-building"></i><a href="/Mng/MNGFirms.aspx">Şirketler</a></li>
                                <li><i class=""></i>Şirket Ekle</li>
                            </ol>
                        </div>
                    </div>

                    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>

                            <div class="row" id="dvMNGFirmAdd" runat="server">
                                <div class="col-lg-12">
                                    <section class="panel">
                                        <header class="panel-heading">
                                            Şirket Ekleme
                                        </header>
                                        <div class="panel-body">
                                            <div class="form">
                                                <div class="form-validate form-horizontal">
                                                    <div class="form-group ">

                                                        <div class="row">
                                                            <div class="col-lg-12">
                                                                <label for="cname" class="control-label col-lg-1 col-md-2 col-sm-2 MT10">Şirket Adı</label>
                                                                <div class="col-lg-11 col-md-10 col-sm-10 MT10">
                                                                    <div class="input-group input-icon input-icon-right padding-right-2n">
                                                                    <asp:TextBox ID="txtFirmName" runat="server" MaxLength="50" CssClass="form-control"></asp:TextBox>
                                                                        <span class="input-group-addon"><i class="ace-icon fa fa-building bigger-120"></i></span>
                                                                        </div>
                                                                </div>

                                                            </div>
                                                        </div>
                                                        <div class="row">
                                                            <div class="col-lg-12">
                                                                <label for="cname" class="control-label col-lg-1 col-md-2 col-sm-2 MT10"><span class="MT10">İl </span></label>
                                                                <div class="col-lg-5 col-md-4 col-sm-4 MT10">
                                                                    <asp:DropDownList ID="drpCity" CssClass="form-control" OnSelectedIndexChanged="drpCity_SelectedIndexChanged" AutoPostBack="true" runat="server"></asp:DropDownList>
                                                         
                                                                </div>
                                                                <label for="cname" class="control-label col-lg-1 col-md-2 col-sm-2 MT10"><span class="MT10">İlçe</span></label>
                                                                <div class="col-lg-5 col-md-4 col-sm-4 MT10">
                                                                    <asp:DropDownList ID="drpDistrict" CssClass="form-control" runat="server"></asp:DropDownList>
                                                                </div>

                                                            </div>
                                                        </div>
                                                        <br />
                                                        <div class="row">
                                                            <div class="col-lg-12">
                                                                <label for="cname" class="control-label col-lg-1 col-md-2 col-sm-2 MT10">Adres</label>
                                                                <div class="col-lg-5 col-md-4 col-sm-4 MT10">
                                                                    <asp:TextBox ID="txtAddress" runat="server" MaxLength="50" CssClass="form-control W50" TextMode="MultiLine" Rows="3"></asp:TextBox>
                                                                </div>
                                                                <label for="cname" class="control-label col-lg-1 col-md-2 col-sm-2 MT10">Açıklama</label>
                                                                <div class="col-lg-5 col-md-4 col-sm-4 MT10">
                                                                    <asp:TextBox ID="txtDescription" runat="server" MaxLength="50" CssClass="form-control W50" TextMode="MultiLine" Rows="3"></asp:TextBox>
                                                                </div>

                                                            </div>
                                                        </div>
                                                        <br />
                                                        <div class="col-lg-12 col-xs-12">
                                                            <asp:Literal ID="lblError2" runat="server"></asp:Literal>
                                                        </div>

                                                        </br>
                                                <div class="form-group MT20 MT10">
                                                    <div class="col-lg-12">
                                                        <div class="col-lg-12">
                                                            <div class="pull-right">
                                                                <asp:LinkButton ID="btnRedirect" runat="server" CssClass="btn btn-warning" href="/Mng/MNGFirms.aspx"><i class="fa fa-minus-circle"></i>&nbsp;İptal</asp:LinkButton>
                                                                <asp:LinkButton ID="btnAdd" runat="server" CssClass="btn btn-success" OnClick="btnAdd_Click"><i class="fa fa-floppy-o"></i>&nbsp;Kaydet</asp:LinkButton>
                                                            </div>
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

                        </ContentTemplate>
                    </asp:UpdatePanel>
                </section>
            </section>
        </section>

    </form>
    <uc1:UCFooterJS runat="server" ID="UCFooterJS" />
    <script type="text/javascript">
    </script>
</body>
</html>
