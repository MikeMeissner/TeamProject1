<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Csgo.aspx.cs" Inherits="comp2007TeamProject.WebForm4" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="container">
        <div class="row">
            <div class="col-md-offset-2 col-md-8">
                < br/>
                 < br/>

                <h1>Student List</h1>
              

                <asp:GridView runat="server" CssClass="table table-bordered table-striped table-hover"
                    ID="CsgoGridView" AutoGenerateColumns="False">
                    <Columns>
                         <asp:BoundField DataField="gameID" HeaderText="Game #" Visible="true" SortExpression="gameID" />
                        <asp:BoundField DataField="team1" HeaderText="Team 1" Visible="true" SortExpression="team1" />
                        <asp:BoundField DataField="team2" HeaderText="Team 2" Visible="true" SortExpression="team2" />
                        <asp:BoundField DataField="roundsWon" HeaderText="Rounds Won" Visible="true" SortExpression="roundsWon" />
                        <asp:BoundField DataField="roundsWonTeam2" HeaderText="Rounds Won Team 2" Visible="true" SortExpression="roundsWonTeam2" />
                        <asp:BoundField DataField="totalPoints" HeaderText="Total Points" Visible="true" SortExpression="totalPoints" />
                        <asp:BoundField DataField="totalPointsTeam2" HeaderText="Total Points Team 2" Visible="true" SortExpression="totalPointsTeam2" />
                        <asp:BoundField DataField="mapPlayed" HeaderText="Map Played" Visible="true" SortExpression="mapPlayed" />
                        <asp:BoundField DataField="winner" HeaderText="Winner" Visible="true" SortExpression="winner" />
                        <asp:BoundField DataField="spectators" HeaderText="Spectators" Visible="true" SortExpression="spectators" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>


</asp:Content>
