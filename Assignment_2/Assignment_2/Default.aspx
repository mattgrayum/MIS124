<%@ Page Title="Home Page" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

        <div style="text-align: center; margin-bottom: 10px; padding: 10px; width: 100%">
                <h2>2017 Tax Return 1040EZ Version 2.0 - Main Page</h2>
        </div>

     <div style="background-color: oldlace;">
        <div class="row" style="border-bottom: thin solid;  border-top: thin solid black;width: 100%; padding: 15px; margin:0;">
            <div class="col-md-3">
                <p>Step 1: Select your Tax Payer ID</p>
            </div>
            <div class="col-md-6">
                <p>Step 2. Verify your Information. If your information has changed, please provide your current information.</p>
            </div>
            <div class="col-md-3">
                <p>Step 3: Type your Tax Year</p>
            </div>
        </div>

        <div class="row" style="border-bottom: thin solid; width: 100%; padding: 15px; margin:0;">
            <div class="col-md-3">
                <asp:DropDownList ID="lstTaxPayers" runat="server" DataSourceID="SqlDataSource1" DataTextField="TaxPayerLastName" DataValueField="TaxPayerID" AutoPostBack="True"></asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:TaxReturn2014_Rodger %>" SelectCommand="SELECT [TaxPayerID], [TaxPayerLastName] FROM [tblTaxPayer]"></asp:SqlDataSource>
            </div>
            <div class="col-md-6">
                <asp:DetailsView ID="dtlTaxPayer" runat="server" Height="50px" Width="125px" AutoGenerateRows="False" DataKeyNames="TaxPayerID" DataSourceID="SqlDataSource2">
                    <Fields>
                        <asp:BoundField DataField="TaxPayerID" HeaderText="TaxPayerID" ReadOnly="True" SortExpression="TaxPayerID" />
                        <asp:BoundField DataField="TaxPayerLastName" HeaderText="TaxPayerLastName" SortExpression="TaxPayerLastName" />
                        <asp:BoundField DataField="TaxPayerFirstName" HeaderText="TaxPayerFirstName" SortExpression="TaxPayerFirstName" />
                        <asp:BoundField DataField="TaxPayerInitial" HeaderText="TaxPayerInitial" SortExpression="TaxPayerInitial" />
                        <asp:BoundField DataField="TaxPayerAddress" HeaderText="TaxPayerAddress" SortExpression="TaxPayerAddress" />
                        <asp:BoundField DataField="TaxPayerCity" HeaderText="TaxPayerCity" SortExpression="TaxPayerCity" />
                        <asp:BoundField DataField="TaxPayerState" HeaderText="TaxPayerState" SortExpression="TaxPayerState" />
                        <asp:BoundField DataField="TaxPayerZip" HeaderText="TaxPayerZip" SortExpression="TaxPayerZip" />
                    </Fields>
                </asp:DetailsView>
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:TaxReturn2014_Rodger %>" SelectCommand="SELECT [TaxPayerID], [TaxPayerLastName], [TaxPayerFirstName], [TaxPayerInitial], [TaxPayerAddress], [TaxPayerCity], [TaxPayerState], [TaxPayerZip] FROM [tblTaxPayer] WHERE ([TaxPayerID] = @TaxPayerID)">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="lstTaxPayers" Name="TaxPayerID" PropertyName="SelectedValue" Type="Int64" />
                    </SelectParameters>
                </asp:SqlDataSource>
            </div>
            <div class="col-md-3">
                <asp:TextBox ID="txtTaxYear" runat="server"></asp:TextBox>
            </div>
        </div>

        <div class="row" style="border-bottom: thin solid; width: 100%; padding: 15px; margin:0;">
            <asp:Button ID="btnViewTaxReturn" runat="server" Text="View Tax Return" />
        </div>
    </div>





</asp:Content>
