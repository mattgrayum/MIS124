<%@ Page Title="Display Tax Return" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="DisplayTaxReturn.aspx.vb" Inherits="DisplayTaxReturn" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div style="text-align: center; margin-bottom: 10px; padding: 10px; width: 100%">
                <h2>2017 Tax Return 1040EZ Version 2.0 - Tax Return Information</h2>
    </div>
    <asp:Panel ID="pnlMessage" runat="server" style="display: none; border-style: solid; border-width: thin; background-color: #e8f6ff; margin-top: 10px; padding: 5px; text-align: center;">
        <asp:Label ID="lblMessage" runat="server"></asp:Label>
    </asp:Panel>

    <div style="background-color: #ffe8bf;">
        <div class="row" style="border-bottom: thin solid;  border-top: thin solid black;width: 100%; padding: 15px; margin:0; font-size: 18px;">
            <div id="taxpayerid" style="position:relative; left: 0; display: inline-block;">
                <asp:Label ID="Label1" runat="server" Text="Tax Payer ID: " style="display: inline-block;"></asp:Label>
                <asp:Label ID="lblTaxPayerID" runat="server" style="display: inline-block;"></asp:Label>
            </div>
            <div id="taxyear" style="position:relative; left: 100px; display: inline-block;">
                <asp:Label ID="Label8" runat="server" Text="Tax Year: " style="display: inline-block;"></asp:Label>
                <asp:Label ID="lblTaxYear" runat="server" style="display: inline-block;"></asp:Label>
            </div>
        </div>
        <div class="row" style="border-bottom: thin solid;  border-top: thin solid black;width: 100%; padding: 15px; margin:0;">
            <div class="col-md-4">
                <asp:Label ID="Label2" runat="server" Text="Tax Payer Last Name:" style="display:block; padding: 5px;"></asp:Label>
                <asp:TextBox ID="txtLastName" runat="server" style="display:block; width: 80%;"></asp:TextBox>
                <asp:Label ID="Label5" runat="server" Text="Tax Payer City:" style="display:block; padding: 5px;"></asp:Label>
                <asp:TextBox ID="txtCity" runat="server" style="display:block; width: 80%;"></asp:TextBox>
            </div>
            <div class="col-md-4">
                <asp:Label ID="Label3" runat="server" Text="Tax Payer First Name:" style="display:block; padding: 5px;"></asp:Label>
                <asp:TextBox ID="txtFirstName" runat="server" style="display:block; width: 80%;"></asp:TextBox>
                <asp:Label ID="Label6" runat="server" Text="Tax Payer State:" style="display:block; padding: 5px;"></asp:Label>
                <asp:TextBox ID="txtState" runat="server" style="display:block; width: 80%;"></asp:TextBox>
            </div>
            <div class="col-md-4">
                <asp:Label ID="Label4" runat="server" Text="Tax Payer MI:" style="display:block; padding: 5px;"></asp:Label>
                <asp:TextBox ID="txtMI" runat="server" style="display:block; width: 80%;"></asp:TextBox>
                <asp:Label ID="Label7" runat="server" Text="Tax Payer Zip Code:" style="display:block; padding: 5px;"></asp:Label>
                <asp:TextBox ID="txtZipCode" runat="server" style="display:block; width: 80%;"></asp:TextBox>
            </div>
        </div>
    </div>
        
    <div style="background-color: oldlace; padding: 25px; border-bottom: thin solid;">
        <div class="row" style="padding-top: 10px; padding-bottom: 10px">
            <div runat="server" id="taxReturnDisplay" class="col-md-6" style="display: block;">
                <div class="row" style="padding-top: 10px; padding-bottom: 10px">
                    <div class="col-md-6">
                        <asp:Label ID="lblIndivOrJoint" runat="server" Text="Is this an individual or joint tax return?"></asp:Label>
                    </div>
                    <div class="col-md-6">
                        <asp:DropDownList ID="lstIndividualOrJoint" runat="server" AutoPostBack="True">
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
                        <asp:TextBox ID="txtWages" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvWages" runat="server" ControlToValidate="txtWages" ErrorMessage="* Required" style="display: block; color: red; position: relative;"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="revWages" runat="server" ControlToValidate="txtWages" ErrorMessage="* Invalid dollar amount" ForeColor="Red" SetFocusOnError="True" ValidationExpression="^\d+(\.\d\d)?$" style="display: block; position: relative; top: -20px;" ViewStateMode="Disabled" EnableViewState="False"></asp:RegularExpressionValidator>
                    </div>
                </div>
                <div class="row" style="padding-top: 10px; padding-bottom: 10px">
                    <div class="col-md-6">
                        <asp:Label ID="lblInterest" runat="server" Text="2. Taxable interest"></asp:Label>
                    </div>
                    <div class="col-md-6">
                        <asp:TextBox ID="txtInterest" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvInterest" runat="server" ControlToValidate="txtInterest" ErrorMessage="* Required" style="display: block; color: red;"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtInterest" ErrorMessage="* Invalid dollar amount" ForeColor="Red" SetFocusOnError="True" ValidationExpression="^\d+(\.\d\d)?$" style="position: relative; display: block;  top: -20px;" ViewStateMode="Disabled" EnableViewState="False"></asp:RegularExpressionValidator>
                    </div>
                </div>
                <div class="row" style="padding-top: 10px; padding-bottom: 10px">
                    <div class="col-md-6">
                        <asp:Label ID="lblUnemployment" runat="server" Text="3. Unemployment compensation"></asp:Label>
                    </div>
                    <div class="col-md-6">
                        <asp:TextBox ID="txtUnemployment" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvUnemployment" runat="server" ControlToValidate="txtUnemployment" ErrorMessage="* Required" style="display: block; color: red;"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtUnemployment" ErrorMessage="* Invalid dollar amount" ForeColor="Red" SetFocusOnError="True" ValidationExpression="^\d+(\.\d\d)?$" style="display: block; position: relative; top: -20px;" ViewStateMode="Disabled" EnableViewState="False"></asp:RegularExpressionValidator>
                    </div>
                </div>
                <div class="row" style="padding-top: 10px; padding-bottom: 10px">
                    <div class="col-md-6">
                        <asp:Label ID="lblDependent" runat="server" Text="5. If someone can claim you (or your spouse) as a dependent, check the boxes"></asp:Label>
                    </div>
                    <div class="col-md-6">
                        <div class="row">
                            <div class="col-md-4">
                                <asp:CheckBox ID="chkYou" runat="server" />
                                <asp:Label ID="lblYou" runat="server" Text="You"></asp:Label>
                            </div>
                            <div class="col-md-8">
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
                        <asp:RequiredFieldValidator ID="rfvWithholding" runat="server" ControlToValidate="txtWithholding" ErrorMessage="* Required" style="display: block; color: red;"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtWithholding" ErrorMessage="* Invalid dollar amount" ForeColor="Red" SetFocusOnError="True" ValidationExpression="^\d+(\.\d\d)?$" style="display: block; position: relative; top: -20px;" ViewStateMode="Disabled" EnableViewState="False"></asp:RegularExpressionValidator>
                    </div>
                </div>
                <div class="row" style="padding-top: 10px; padding-bottom: 10px">
                    <div class="col-md-6">
                        <asp:Label ID="lblEarnedIncome" runat="server" Text="8a. Earned income credit (EIC)"></asp:Label>
                    </div>
                    <div class="col-md-6">
                        <asp:TextBox ID="txtEarnedIncome" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvEarnedIncome" runat="server" ControlToValidate="txtEarnedIncome" ErrorMessage="* Required" style="display: block; color: red;"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txtEarnedIncome" ErrorMessage="* Invalid dollar amount" ForeColor="Red" SetFocusOnError="True" ValidationExpression="^\d+(\.\d\d)?$" style="display: block; position: relative; top: -20px;" ViewStateMode="Disabled" EnableViewState="False"></asp:RegularExpressionValidator>
                    </div>
                </div>
                <div class="row" style="padding-top: 10px; padding-bottom: 10px">
                    <div class="col-md-6">
                        <asp:Label ID="lblNontaxable" runat="server" Text="8b. Nontaxable compay pay election"></asp:Label>
                    </div>
                    <div class="col-md-6">
                        <asp:TextBox ID="txtNontaxable" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvNontaxable" runat="server" ControlToValidate="txtNontaxable" ErrorMessage="* Required" style="display: block; color: red;"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="txtNontaxable" ErrorMessage="* Invalid dollar amount" ForeColor="Red" SetFocusOnError="True" ValidationExpression="^\d+(\.\d\d)?$" style="display: block; position: relative; top: -20px;" ViewStateMode="Disabled" EnableViewState="False"></asp:RegularExpressionValidator>
                    </div>
                </div>
                <div class="row" style="padding-top: 10px; padding-bottom: 10px; margin:auto 10px;">
                    
                    
                    <asp:Button ID="btnBack" runat="server" Text="<< Go Back" style="width: 20%; display: inline-block; margin: 0 5px;" />

                    <asp:Button ID="btnCalculate" runat="server" Text="Calculate" style="width: 20%; display: inline-block; margin: 0 5px;"/>
                   
                    <asp:Button ID="btnUpdate" runat="server" Text="Update" style="width: 20%; display: inline-block; margin: 0 5px;" />
                    
                    <asp:Button ID="btnInsert" runat="server" Text="Save" style="width: 20%; display: inline-block; margin: 0 5px;" />
                 
                    <asp:Button ID="btnClear" runat="server" Text="Clear" style="display: inline-block; width: 20%; margin: 0 5px;"/>
                    
                   
                </div>
             </div>


           
            <div runat="server" class="col-md-6" id="jointTaxPayerForm" style="margin-top: 10px;">
                <asp:Label ID="Label18" runat="server" Text="Spouse Last Name:" style="margin-top: 10px; display:block; padding: 5px;"></asp:Label>
                <asp:TextBox ID="txtSpouseLastName" runat="server" style="display:block; width: 80%;"></asp:TextBox>
                <asp:Label ID="Label19" runat="server" Text="Spouse First Name:" style="margin-top: 10px; display:block; padding: 5px;"></asp:Label>
                <asp:TextBox ID="txtSpouseFirstName" runat="server" style="display:block; width: 80%;"></asp:TextBox>
                <asp:Label ID="Label20" runat="server" Text="Spouse Initial:" style="margin-top: 10px; display:block; padding: 5px;"></asp:Label>
                <asp:TextBox ID="txtSpouseInitial" runat="server" style="display:block; width: 80%;"></asp:TextBox>
                <asp:Button ID="btnAddSpouse" runat="server" Text="Add" style="margin: 15px 10px 0 0; width: 80px;"/>
                <asp:Button ID="btnUpdateSpouse" runat="server" Text="Update" style="margin: 15px 10px; width: 80px;" />    
            </div>

        </div>
        
    </div>
 


</asp:Content>