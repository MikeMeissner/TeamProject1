<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="LeagueDetails.aspx.cs" Inherits="comp2007TeamProject.WebForm7" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <body id="guestContent">
    <div class="container">
        <div class="row">
            <br />
            <br />
            <br />
            <h1>Add LoL match results</h1>
            <h5>Fill out all fields</h5>
            <br />
            <div class="form-group">
                <label class="control-label">Team 1:</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="Team1LoLTextBox" placeholder="Team 1" required="true"></asp:TextBox>
            </div>
            <div class="form-group">
                <label class="control-label">Team 2:</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="Team2LoLTextBox" placeholder="Team 2" required="true"></asp:TextBox>
            </div>
            <div class="form-group">
                <label class="control-label">Kills For Team 1:</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="KillsForTeam1TextBox" placeholder="Kills For Team 1" required="true"></asp:TextBox>
            </div>
               <div class="form-group">
                <label class="control-label">Kills For Team 2:</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="KillsForTeam2TextBox" placeholder="Kills For Team 2" required="true"></asp:TextBox>
            </div>
               <div class="form-group">
                <label class="control-label">Team 1 Objectives Taken:</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="ObjectivesForTeam1TextBox" placeholder="Objectives For Team 1" required="true"></asp:TextBox>
            </div>
               <div class="form-group">
                <label class="control-label">Team 2 Objectives Taken:</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="ObjectivesForTeam2TextBox" placeholder="Objectives For Team 2" required="true"></asp:TextBox>
            </div>
             
               <div class="form-group">
                <label class="control-label">Number Of Spectators:</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="SpectatorsLoLTextBox" placeholder="Number Of Spectators" required="true"></asp:TextBox>
            </div>
               <div class="form-group">
                <label class="control-label">Winner:</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="WinnerLoLTextBox" placeholder="Winner" required="true"></asp:TextBox>
            </div>
              <%--<div class="form-group">
                <label class="control-label">Week:</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="WeekTextBox" placeholder="Winner" required="true"></asp:TextBox>
            </div>--%>
              <div class="form-group">
                <label class="control-label">Week:</label>
             <asp:TextBox type="week" runat="server" CssClass="form-control" ID="weekNumberLoL" required="true"></asp:TextBox>
            </div>
            
            <div>
                <asp:Button Text="Cancel" ID="CancelButton" CssClass="btn btn-warning btn-lg" runat="server" 
                        UseSubmitBehavior="false" CausesValidation="false" OnClick="CancelButton_Click"/>
                <asp:Button Text="Save" ID="SaveButton" CssClass="btn btn-primary btn-lg" runat="server" OnClick="SaveButton_Click"/>
            </div>
        </div>
    </div>
        </body>
</asp:Content>
