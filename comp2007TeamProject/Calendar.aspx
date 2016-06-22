<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Calendar.aspx.cs" Inherits="comp2007TeamProject.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <!--Authors: Nathan Siu and Mike Meissner
    Website Name: Game Tracker
    Page Description: This is the game page that allows you to select the game you are interested in
    File Name: Calendar.aspx
--> 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

  <body id="guestContent">
    <div class="container" id="featuredGames">
        
         <div class="row">
             <h1>Featured Games</h1>


      <div class="col-xs-6 col-md-3">
        <a href="Csgo.aspx" class="thumbnail">
          <img src="Assets/Images/gamebox_csgo.jpg" alt="Counter-Strike Global Offensive"/>
        </a>
      </div>

      <div class="col-xs-6 col-md-3">
        <a href="Dota.aspx" class="thumbnail">
          <img src="Assets/Images/gamebox_dota2.jpg" alt="Dota2"/>
        </a>
       </div>

      <div class="col-xs-6 col-md-3">
        <a href="League.aspx" class="thumbnail">
          <img src="Assets/Images/gamebox_lol.jpg" alt="League of Legends"/>
        </a>
      </div>

      <div class="col-xs-6 col-md-3">
        <a href="Smite.aspx" class="thumbnail">
          <img src="Assets/Images/gamebox_smite.jpg" alt="Smite"/>
        </a>
      </div>

   </div>
    </div>
    
 
    </body>
    
    


</asp:Content>
