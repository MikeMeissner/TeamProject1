<%@ Page Title="Home" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="comp2007TeamProject.Default" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!--Authors: Nathan Siu and Mike Meissner
    Website Name: Game Tracker
    Page Description: This is the home page it greets the visitor and lets them know what our site does
    File Name: Default.aspx
-->
    <body id="homecontent">

        <div class="container" id="homeContent">
            <div class="row">

                <h1>Welcome To Game Tracker</h1>
             <%--   <div class="jumbotron">--%>
                    <%-- <p id="text">Welcome to Game Tracker!</p>
                 <a href="Calendar.aspx" class="btn btn-primary">Click to see our featured games</a>--%>
                 <div class="row">
                <div class="col-md-6">
                    <img src="Assets/Images/HE4CvOr_.jpg" alt="logo" />
                </div>
                <div class="col-md-6">
                    <div class="jumbotron" id="secondaryText">
                        <h1>List Of Tracked Games</h1>
                        <hr />

                        <p>CSGO: A 5v5 competitive FPS</p>
                        <p>League Of Legends: A 5v5 MOBA Game</p>
                        <p>DOTA2: A 5v5 comptitive MOBA</p>
                        <p>SMITE: A 5v5 comptitive objective based MOBA</p>
                         <a href="Calendar.aspx" class="btn btn-primary">Click to see our featured games</a>
                    </div>
                </div>
            </div>
                               
                    <div id="myCarousel" class="carousel slide" data-ride="carousel" >
                        <!-- Indicators -->
                        <ol class="carousel-indicators">
                            <li data-target="#myCarousel" data-slide-to="0" class="active"></li>
                            <li data-target="#myCarousel" data-slide-to="1"></li>
                            <li data-target="#myCarousel" data-slide-to="2"></li>
                     
                        </ol>
                        <!-- Wrapper for slides -->
                        <div class="carousel-inner" role="listbox">
                            <div class="item active">
                                <img src="Assets/Images/csgogameplay.jpg" class="img-responsive"  alt="csgo">
                                <div class="carousel-caption">
                                    <h3>Counter Strike Global Offensive</h3>
                                </div>
                            </div>

                            <div class="item">
                                <img src="Assets/Images/leaguegameplay.jpg" class="img-responsive"  alt="league">
                                <div class="carousel-caption">
                                    <h3>League Of Legends</h3>
                                </div>
                            </div>

                            <div class="item">
                                <img src="Assets/Images/dotagameplay.jpg" class="img-responsive" alt="dota">
                                <div class="carousel-caption">
                                    <h3>Dota 2</h3>
                                </div>
                            </div>

                        
                        </div>
                        <!-- Left and right controls -->
  <a class="left carousel-control" href="#myCarousel" role="button" data-slide="prev">
    <span class="glyphicon glyphicon-chevron-left" aria-hidden="true"></span>
    <span class="sr-only">Previous</span>
  </a>
  <a class="right carousel-control" href="#myCarousel" role="button" data-slide="next">
    <span class="glyphicon glyphicon-chevron-right" aria-hidden="true"></span>
    <span class="sr-only">Next</span>
  </a>
                    </div>
              <%--  </div>--%>

            </div>
           
        </div>
        <!--scripts-->
        <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.2/jquery.min.js"></script>
<script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.4/js/bootstrap.min.js"></script>
    </body>

</asp:Content>
