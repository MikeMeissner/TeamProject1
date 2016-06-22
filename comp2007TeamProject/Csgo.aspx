<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Csgo.aspx.cs" Inherits="comp2007TeamProject.WebForm4" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <body id="guestContent">
    <div class="container" id="csgo">
        <div class="row">
            <div class="jumbotron">
                   <div class="col-md-offset-2 col-md-8">
             

                <h1>CSGO Weekly Stats</h1>


                <asp:GridView runat="server" CssClass="table table-bordered table-striped table-hover"
                    ID="CsgoGridView" AutoGenerateColumns="False" OnRowDeleting="CsgoGridView_RowDeleting" DataKeyNames="gameID" >
                    <Columns>
                        <asp:BoundField DataField="gameID" HeaderText="Game ID" Visible="true" SortExpression="gameID" />
                        <asp:BoundField DataField="team1" HeaderText="Team 1" Visible="true" SortExpression="team1" />
                        <asp:BoundField DataField="team2" HeaderText="Team 2" Visible="true" SortExpression="team2" />
                        <asp:BoundField DataField="roundsWon" HeaderText="Rounds Won" Visible="true" SortExpression="roundsWon" />
                        <asp:BoundField DataField="roundsWonTeam2" HeaderText="Rounds Won Team 2" Visible="true" SortExpression="roundsWonTeam2" />
                        <asp:BoundField DataField="totalPoints" HeaderText="Total Points" Visible="true" SortExpression="totalPoints" />
                        <asp:BoundField DataField="totalPointsTeam2" HeaderText="Total Points Team 2" Visible="true" SortExpression="totalPointsTeam2" />
                        <asp:BoundField DataField="mapPlayed" HeaderText="Map Played" Visible="true" SortExpression="mapPlayed" />
                        <asp:BoundField DataField="winner" HeaderText="Winner" Visible="true" SortExpression="winner" />
                        <asp:BoundField DataField="spectators" HeaderText="Spectators" Visible="true" SortExpression="spectators" />
                        <%-- <asp:BoundField DataField="weekOfGame" HeaderText="Week" Visible="true" SortExpression="weekOfGame" />--%>
                           <asp:BoundField DataField="weekOfGame" HeaderText="Week" Visible="true" SortExpression="week" />
                    
                          <asp:HyperLinkField HeaderText="Edit" Text="<i class='fa fa-pencil-square-o fa-lg'></i> Edit" 
                            NavigateUrl="~/Admin/CsgoDetails.aspx.cs" ControlStyle-CssClass="btn btn-primary btn-sm" runat="server"
                            DataNavigateUrlFields="gameID" DataNavigateUrlFormatString="Admin/CsgoDetails.aspx?gameID={0}" />
                         <asp:CommandField HeaderText="Delete" DeleteText="<i class='fa fa-trash-o fa-lg'></i>'Delete" ShowDeleteButton="true" ButtonType="Link" ControlStyle-CssClass="btn btn-danger btn-sm" />

                    </Columns>
                </asp:GridView>
                 <div class="form-group">
                <label class="control-label">Sort Week:</label>
                     <asp:TextBox type="week" runat="server" CssClass="form-control" ID="weekNumberSort" required="true"></asp:TextBox>
                     <asp:Button Text="Sort" CssClass="btn btn-primary" runat="server" OnClick="csgoSort"/>
                </div>


                 <a href="Admin/CsgoDetails.aspx" class="btn btn-success btn-md">Add Game Stats</a>
            </div>
            </div>
         
        </div>
    </div>
    </body>


</asp:Content>
