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
                <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource1" DataTextField="TaxPayerLastName" DataValueField="TaxPayerID"></asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:TaxReturn2014ConnectionString %>" SelectCommand="SELECT [TaxPayerID], [TaxPayerLastName] FROM [tblTaxPayer] ORDER BY [TaxPayerLastName]"></asp:SqlDataSource>
            </div>
            <div class="col-md-6">
                <asp:DetailsView ID="dtlTaxPayer" runat="server" Height="50px" Width="125px"></asp:DetailsView>
            </div>
            <div class="col-md-3">
                <asp:TextBox ID="txtTaxYear" runat="server" value="2017"></asp:TextBox>
            </div>
        </div>

        <div class="row" style="border-bottom: thin solid; width: 100%; padding: 15px; margin:0;">
            <asp:Button ID="btnViewTaxReturn" runat="server" Text="View Tax Return" />
        </div>
    </div>





</asp:Content>
