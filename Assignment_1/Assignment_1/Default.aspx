<%@ Page Title="Home Page" Language="VB" EnableViewState="true" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<asp:content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    
    <div style="background-color: #fff; border-bottom: solid; border-width: thin;">
        <img src="images/th.jpg" style="width: 167px; height: 163px" />
        <h1 style="display: inline-block; position: relative; left: -17px; top: 35px;">Sacramento State</h1>
        <p style="display: inline-block; position: relative; left: 2px; top: 38px;"><i>Redefine the Possible</i></p>
    </div>
    <div style="text-align: center; border-bottom: solid; border-width: thin; margin-bottom: 10px;"><h1>2017 Tax Return 1040EZ Calculator</h1></div>
    
    <div style="border-bottom: solid; border-width: thin; padding-bottom: 15px;">
        <div class="row" style="padding-top: 10px; padding-bottom: 10px">
            <div class="col-md-6">
                <asp:Label ID="lblIndivOrJoint" runat="server" Text="Is this an individual or joint tax return?"></asp:Label>
            </div>
            <div class="col-md-6">
                <asp:DropDownList ID="lstIndividualOrJoint" runat="server">
                    <asp:ListItem>Individual</asp:ListItem>
                    <asp:ListItem>Joint</asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>
        <div class="row" style="padding-top: 10px; padding-bottom: 10px">
            <div class="col-md-6">
                <asp:Label ID="lblWages" runat="server" Text="1. Wages, salaries, and tips"></asp:Label>
            </div>
            <div class="col-md-6">
                <asp:TextBox ID="txtWages" runat="server" EnableViewState="true"></asp:TextBox>
            </div>
        </div>
        <div class="row" style="padding-top: 10px; padding-bottom: 10px">
            <div class="col-md-6">
                <asp:Label ID="lblInterest" runat="server" Text="2. Taxable interest"></asp:Label>
            </div>
            <div class="col-md-6">
                <asp:TextBox ID="txtInterest" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="row" style="padding-top: 10px; padding-bottom: 10px">
            <div class="col-md-6">
                <asp:Label ID="lblUnemployment" runat="server" Text="3. Unemployment compensation"></asp:Label>
            </div>
            <div class="col-md-6">
                <asp:TextBox ID="txtUnemployment" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="row" style="padding-top: 10px; padding-bottom: 10px">
            <div class="col-md-6">
                <asp:Label ID="lblDependent" runat="server" Text="5. If someone can claim you (or your spouse) as a dependent, check the boxes"></asp:Label>
            </div>
            <div class="col-md-6">
                <div class="row">
                    <div class="col-md-2">
                        <asp:CheckBox ID="chkYou" runat="server" />
                        <asp:Label ID="lblYou" runat="server" Text="You"></asp:Label>
                    </div>
                    <div class="col-md-10">
                        <asp:CheckBox ID="chkSpouse" runat="server" />
                        <asp:Label ID="lblSpouse" runat="server" Text="Spouse"></asp:Label>
                    </div>
                </div>
            </div>
        </div>
        <div class="row" style="padding-top: 10px; padding-bottom: 10px">
            <div class="col-md-6">
                <asp:Label ID="lblWithholding" runat="server" Text="7. Federal income tax whithheld from box 2 of your Form(s) W-2"></asp:Label>
            </div>
            <div class="col-md-6">
                <asp:TextBox ID="txtWithholding" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="row" style="padding-top: 10px; padding-bottom: 10px">
            <div class="col-md-6">
                <asp:Label ID="lblEarnedIncome" runat="server" Text="8a. Earned income credit (EIC)"></asp:Label>
            </div>
            <div class="col-md-6">
                <asp:TextBox ID="txtEarnedIncome" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="row" style="padding-top: 10px; padding-bottom: 10px">
            <div class="col-md-6">
                <asp:Label ID="lblNontaxable" runat="server" Text="8b. Nontaxable compay pay election"></asp:Label>
            </div>
            <div class="col-md-6">
                <asp:TextBox ID="txtNontaxable" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="row" style="padding-top: 10px; padding-bottom: 10px;">
            <div class="col-md-6">
            </div>
            <div class="col-md-6">
                <asp:Button ID="btnCalculate" runat="server" Text="Calculate" style="width: 80px"/>
                <asp:Button ID="btnClear" runat="server" Text="Clear" style="display: inline-block; width: 80px; margin-left: 15px;"/>
            </div>
        </div>
    </div>
    <div style="border-style: solid; border-width: thin; background-color: antiquewhite; margin-top: 10px; padding: 5px;">
        <asp:Label ID="lblMessage" runat="server" Text="Enter your tax information and click calculate to view your results"></asp:Label>
    </div>

</asp:Content>
