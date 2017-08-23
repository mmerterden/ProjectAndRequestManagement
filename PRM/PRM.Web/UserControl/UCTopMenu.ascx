<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCTopMenu.ascx.cs" Inherits="PRM.Web.UserControl.UCTopMenu" %>
<header class="header dark-bg">
    <div class="toggle-nav">
        <div class="icon-reorder tooltips" data-original-title="Toggle Navigation" data-placement="bottom"><i class="icon_menu"></i></div>
    </div>

    <!--logo start-->
    <a href="/Default.aspx" class="logo">PR<span class="lite">M</span></a>
    <!--logo end-->

    <div class="nav search-row MR65" id="top_menu">
        <!--  search form start -->
        <ul class="nav top-menu">
            <li>
                <div class="navbar-form">
                    <input class="form-control" placeholder="Search" type="text">
                </div>
            </li>
        </ul>
        <!--  search form end -->
    </div>

    <div class="top-nav notification-row">
        <!-- notificatoin dropdown start-->
        <ul class="nav pull-right top-menu">   

            <!-- task notificatoin start -->
            <li id="task_notificatoin_bar" class="dropdown">
                <a data-toggle="dropdown" class="dropdown-toggle" href="#">
                    <i class="icon-task-l"></i>
                    <span class="badge bg-important">6</span>
                </a>
                <ul class="dropdown-menu extended tasks-bar">
                    <div class="notify-arrow notify-arrow-blue"></div>
                    <li>
                        <p class="blue">You have 6 pending letter</p>
                    </li>
                    <li>
                        <a href="#">
                            <div class="task-info">
                                <div class="desc">Design PSD </div>
                                <div class="percent">90%</div>
                            </div>
                            <div class="progress progress-striped">
                                <div class="progress-bar progress-bar-success" role="progressbar" aria-valuenow="90" aria-valuemin="0" aria-valuemax="100" style="width: 90%">
                                    <span class="sr-only">90% Complete (success)</span>
                                </div>
                            </div>
                        </a>
                    </li>
                    <li>
                        <a href="#">
                            <div class="task-info">
                                <div class="desc">
                                    Project 1
                                </div>
                                <div class="percent">30%</div>
                            </div>
                            <div class="progress progress-striped">
                                <div class="progress-bar progress-bar-warning" role="progressbar" aria-valuenow="30" aria-valuemin="0" aria-valuemax="100" style="width: 30%">
                                    <span class="sr-only">30% Complete (warning)</span>
                                </div>
                            </div>
                        </a>
                    </li>
                    <li>
                        <a href="#">
                            <div class="task-info">
                                <div class="desc">Digital Marketing</div>
                                <div class="percent">80%</div>
                            </div>
                            <div class="progress progress-striped">
                                <div class="progress-bar progress-bar-info" role="progressbar" aria-valuenow="80" aria-valuemin="0" aria-valuemax="100" style="width: 80%">
                                    <span class="sr-only">80% Complete</span>
                                </div>
                            </div>
                        </a>
                    </li>
                    <li>
                        <a href="#">
                            <div class="task-info">
                                <div class="desc">Logo Designing</div>
                                <div class="percent">78%</div>
                            </div>
                            <div class="progress progress-striped">
                                <div class="progress-bar progress-bar-danger" role="progressbar" aria-valuenow="78" aria-valuemin="0" aria-valuemax="100" style="width: 78%">
                                    <span class="sr-only">78% Complete (danger)</span>
                                </div>
                            </div>
                        </a>
                    </li>
                    <li>
                        <a href="#">
                            <div class="task-info">
                                <div class="desc">Mobile App</div>
                                <div class="percent">50%</div>
                            </div>
                            <div class="progress progress-striped active">
                                <div class="progress-bar" role="progressbar" aria-valuenow="50" aria-valuemin="0" aria-valuemax="100" style="width: 50%">
                                    <span class="sr-only">50% Complete</span>
                                </div>
                            </div>

                        </a>
                    </li>
                    <li class="external">
                        <a href="#">See All Tasks</a>
                    </li>
                </ul>
            </li>
            <!-- task notificatoin end -->
            <!-- inbox notificatoin start-->
            <li id="mail_notificatoin_bar" class="dropdown">
                <a data-toggle="dropdown" class="dropdown-toggle" href="#">
                    <i class="icon-envelope-l"></i>
                    <span class="badge bg-important">5</span>
                </a>
                <ul class="dropdown-menu extended inbox">
                    <div class="notify-arrow notify-arrow-blue"></div>
                    <li>
                        <p class="blue">You have 5 new messages</p>
                    </li>
                    <li>
                        <a href="#">
                            <span class="photo">
                                <img alt="avatar" src="/assets/img/avatar-mini.jpg"></span>
                            <span class="subject">
                                <span class="from">Greg  Martin</span>
                                <span class="time">1 min</span>
                            </span>
                            <span class="message">I really like this admin panel.
                            </span>
                        </a>
                    </li>
                    <li>
                        <a href="#">
                            <span class="photo">
                                <img alt="avatar" src="/assets/img/avatar-mini2.jpg"></span>
                            <span class="subject">
                                <span class="from">Bob   Mckenzie</span>
                                <span class="time">5 mins</span>
                            </span>
                            <span class="message">Hi, What is next project plan?
                            </span>
                        </a>
                    </li>
                    <li>
                        <a href="#">
                            <span class="photo">
                                <img alt="avatar" src="/assets/img/avatar-mini3.jpg" /></span>
                            <span class="subject">
                                <span class="from">Phillip   Park</span>
                                <span class="time">2 hrs</span>
                            </span>
                            <span class="message">I am like to buy this Admin Template.
                            </span>
                        </a>
                    </li>
                    <li>
                        <a href="#">
                            <span class="photo">
                                <img alt="avatar" src="/assets/img/avatar-mini4.jpg"></span>
                            <span class="subject">
                                <span class="from">Ray   Munoz</span>
                                <span class="time">1 day</span>
                            </span>
                            <span class="message">Icon fonts are great.
                            </span>
                        </a>
                    </li>
                    <li>
                        <a href="#">See all messages</a>
                    </li>
                </ul>
            </li>
            <!-- inbox notificatoin end -->
            <!-- user login dropdown start-->
            <li class="dropdown">
                <a data-toggle="dropdown" class="dropdown-toggle" href="#">
                    <span class="profile-ava">
                        <img alt="" src="/assets/img/avatar-mini2.jpg">
                    </span>
                    <span class="username">
                        <asp:Literal ID="lblFullName" runat="server"></asp:Literal>
                    </span>
                    <b class="caret"></b>
                </a>
                <ul class="dropdown-menu extended logout">
                    <div class="log-arrow-up"></div>
                    <li class="eborder-top">
                        <a href="/MyInfo.aspx"><i class="icon_profile"></i>Profil</a>
                    </li>
                    <li>
                        <a href="/Req/REQRequests.aspx"><i class="icon_mail_alt"></i>Talepler</a>
                    </li>
                    <li>
                        <a href="/Rpt/RPTReportsFirmandResourse.aspx"><i class="icon_piechart"></i>Rapor</a>
                    </li>
                    <li>
                        <a href="/Logout.aspx"><i class="icon_key_alt"></i>Çıkış</a>
                    </li>  
                </ul>
            </li>
            <!-- user login dropdown end -->
        </ul>
        <!-- notificatoin dropdown end-->
    </div>
</header>
