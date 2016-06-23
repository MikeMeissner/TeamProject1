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
            
            <h1>Game Tracker</h1>
            <div class="jumbotron">
                <p id="text">Welcome to Game Tracker!</p>
                 <a href="Calendar.aspx" class="btn btn-primary">Click to see our featured games</a>
            </div>
                
        </div>
             <div class="row">
                 <div class="col-md-6">
                      <img src="Assets/Images/HE4CvOr_.jpg" alt="logo"/>
                 </div>
                 <div class="col-md-6">
                     <div class="jumbotron" id="secondaryText">
                         <h1>List Of Tracked Games</h1>
                         <hr />

                         <p>CSGO: A 5v5 competitive FPS</p>
                         <p>League Of Legends: A 5v5 MOBA Game</p>
                         <p>DOTA2: A 5v5 comptitive MOBA</p>
                         <p>SMITE: A 5v5 comptitive objective based MOBA</p>

                     </div>
                 </div>
             </div>
    </div>
    </body>
   
</asp:Content>
