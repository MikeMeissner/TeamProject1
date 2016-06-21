<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CsgoDetails.aspx.cs" Inherits="comp2007TeamProject.WebForm3" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
            <br />
            <br />
            <br />
            <h1>Add CSGO match results</h1>
            <h5>Fill out all fields</h5>
            <br />
            <div class="form-group">
                <label class="control-label">Team 1:</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="Team1TextBox" placeholder="Team 1" required="true"></asp:TextBox>
            </div>
            <div class="form-group">
                <label class="control-label">Team 2:</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="Team2TextBox" placeholder="Team 2" required="true"></asp:TextBox>
            </div>
            <div class="form-group">
                <label class="control-label">Rounds Won For Team 1:</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="RoundsForTeam1TextBox" placeholder="Rounds Won For Team 1" required="true"></asp:TextBox>
            </div>
               <div class="form-group">
                <label class="control-label">Rounds Won For Team 2:</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="RoundsForTeam2TextBox" placeholder="Rounds Won For Team 2" required="true"></asp:TextBox>
            </div>
               <div class="form-group">
                <label class="control-label">Total Points For Team 1:</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="PointsForTeam1TextBox" placeholder="Total Points For Team 1" required="true"></asp:TextBox>
            </div>
               <div class="form-group">
                <label class="control-label">Total Points For Team 2:</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="PointsForTeam2TextBox" placeholder="Total Points For Team 2" required="true"></asp:TextBox>
            </div>
               <div class="form-group">
                <label class="control-label">Map Played:</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="MapPlayedTexBox" placeholder="Map Played" required="true"></asp:TextBox>
            </div>
               <div class="form-group">
                <label class="control-label">Number Of Spectators:</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="SpectatorsTextBox" placeholder="Number Of Spectators" required="true"></asp:TextBox>
            </div>
               <div class="form-group">
                <label class="control-label">Winner:</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="WinnerTextBox" placeholder="Winner" required="true"></asp:TextBox>
            </div>
              <%--<div class="form-group">
                <label class="control-label">Week:</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="WeekTextBox" placeholder="Winner" required="true"></asp:TextBox>
            </div>--%>
              <div class="form-group">
                <label class="control-label">Week:</label>
             <asp:TextBox type="week" runat="server" CssClass="form-control" ID="weekNumber" required="true"></asp:TextBox>
            </div>
            
            <div>
                <asp:Button Text="Cancel" ID="CancelButton" CssClass="btn btn-warning btn-lg" runat="server" 
                        UseSubmitBehavior="false" CausesValidation="false" OnClick="CancelButton_Click"/>
                <asp:Button Text="Save" ID="SaveButton" CssClass="btn btn-primary btn-lg" runat="server" OnClick="SaveButton_Click"/>
            </div>
        </div>
    </div>
</asp:Content>

