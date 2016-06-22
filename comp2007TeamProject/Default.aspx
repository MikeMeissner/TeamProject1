﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="comp2007TeamProject.Default" %>

 
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
    </div>
    </body>
   
</asp:Content>
