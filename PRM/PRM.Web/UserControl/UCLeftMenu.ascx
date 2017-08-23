<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCLeftMenu.ascx.cs" Inherits="PRM.Web.UserControl.UCLeftMenu" %>
<aside>
    <div id="sidebar" class="nav-collapse ">
        <!-- sidebar menu start-->
        <ul class="sidebar-menu">
            <li class="active">
                <a class="" href="/Default.aspx">
                    <i class="fa fa-laptop"></i>
                    <span>Ana Sayfa</span>
                </a>
            </li>
            <li class="sub-menu">
                <a href="javascript:;" class="">
                    <i class="icon_mail_alt"></i>
                    <span>Talepler</span>
                    <span class="menu-arrow arrow_carrot-right"></span>
                </a>
                <ul class="sub">
                    <li><a class="" href="/Req/REQRequests.aspx">Taleplerim</a></li>
                    <li><a class="" href="/Req/REQRequestAdd.aspx">Talep Ekle</a></li>
                </ul>
            </li>
            <li class="sub-menu">
                <a href="/Prj/PRJMyTasks.aspx" class="">
                    <i class="fa fa-tasks"></i>
                    <span>Görevlerim</span>
                </a>
            </li>
            <li class="sub-menu">
                <a href="javascript:;" class="">
                    <i class="fa fa-suitcase"></i>
                    <span>Projelerim</span>
                    <span class="menu-arrow arrow_carrot-right"></span>
                </a>
                <ul class="sub">
                    <li><a class="" href="/Prj/PRJProjects.aspx">Projeler</a></li>
                    <li><a class="" href="/Prj/PRJProjectAdd.aspx">Proje Ekle</a></li>
                </ul>
            </li>
            <li class="sub-menu">
                <a href="/Rpt/RPTReportsFirmandResourse.aspx" class="">
                    <i class="icon_piechart"></i>
                    <span>Raporlar</span>
                </a>
            </li>
            <li class="sub-menu">
                <a href="javascript:;" class="">
                    <i class="fa fa-building"></i>
                    <span>Şirketlerim</span>
                    <span class="menu-arrow arrow_carrot-right"></span>
                </a>
                <ul class="sub">
                    <li><a class="" href="/Mng/MNGFirms.aspx">Şirketler</a></li>
                    <li><a class="" href="/Mng/MNGFirmAdd.aspx">Şirket Ekle</a></li>
                </ul>
            </li>
            <li class="active">
                <a class="" href="/Logout.aspx">
                    <i class="icon_key_alt"></i>
                    <span>Güvenli Çıkış
                    </span>
                </a>
            </li>
        </ul>
        <!-- sidebar menu end-->
    </div>
</aside>
