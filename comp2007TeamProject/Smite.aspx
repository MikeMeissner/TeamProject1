﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Smite.aspx.cs" Inherits="comp2007TeamProject.WebForm10" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container" id="csgo">
        <div class="row">
            <div class="col-md-offset-2 col-md-8">
             

                <h1>Smite Weekly Stats</h1>


                <asp:GridView runat="server" CssClass="table table-bordered table-striped table-hover"
                    ID="SmiteGridView" AutoGenerateColumns="False" OnRowDeleting="SmiteGridView_RowDeleting" DataKeyNames="gameID" >
                    <Columns>
                        <asp:BoundField DataField="gameID" HeaderText="Game ID" Visible="true" SortExpression="gameID" />
                        <asp:BoundField DataField="team1" HeaderText="Team 1" Visible="true" SortExpression="team1" />
                        <asp:BoundField DataField="team2" HeaderText="Team 2" Visible="true" SortExpression="team2" />
                        <asp:BoundField DataField="killsTeam1" HeaderText="kills team 1" Visible="true" SortExpression="roundsWon" />
                        <asp:BoundField DataField="killsTeam2" HeaderText="kills team 2" Visible="true" SortExpression="roundsWonTeam2" />
                        <asp:BoundField DataField="PointsTeam1" HeaderText="Total Points" Visible="true" SortExpression="totalPoints" />
                        <asp:BoundField DataField="PointsTeam2" HeaderText="Total Points Team 2" Visible="true" SortExpression="totalPointsTeam2" />
                  
                        <asp:BoundField DataField="winner" HeaderText="Winner" Visible="true" SortExpression="winner" />
                        <asp:BoundField DataField="spectators" HeaderText="Spectators" Visible="true" SortExpression="spectators" />
                        <%-- <asp:BoundField DataField="weekOfGame" HeaderText="Week" Visible="true" SortExpression="weekOfGame" />--%>
                           <asp:BoundField DataField="weekOfGame" HeaderText="Week" Visible="true" SortExpression="week" />
                    
                          <asp:HyperLinkField HeaderText="Edit" Text="<i class='fa fa-pencil-square-o fa-lg'></i> Edit" 
                            NavigateUrl="~/Admin/SmiteDetails.aspx.cs" ControlStyle-CssClass="btn btn-primary btn-sm" runat="server"
                            DataNavigateUrlFields="gameID" DataNavigateUrlFormatString="Admin/SmiteDetails.aspx?gameID={0}" />
                         <asp:CommandField HeaderText="Delete" DeleteText="<i class='fa fa-trash-o fa-lg'></i>'Delete" ShowDeleteButton="true" ButtonType="Link" ControlStyle-CssClass="btn btn-danger btn-sm" />

                    </Columns>
                </asp:GridView>
                 <a href="Admin/SmiteDetails.aspx" class="btn btn-success btn-md">Add Game Stats</a>
            </div>
        </div>
    </div>
</asp:Content>
