<%@ Page Title="Result Page" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Result.aspx.vb" Inherits="Result" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div style="color: #5c5536; text-align: center; margin-bottom: 10px; padding: 10px; width: 100%">
        <h2>2017 Tax Return 1040EZ Version 2.0 - Calculation Results</h2>
    </div>

    <asp:Panel ID="pnlMessage" runat="server" style="display: none; border-style: solid; border-width: thin; background-color: #e8f6ff; margin-top: 10px; padding: 5px; text-align: center;">
        <asp:Label ID="lblMessage" runat="server"></asp:Label>
    </asp:Panel>

    <div style="color: white; background-color: #497a63;">
        <div class="row" style="border-bottom: thin solid;  border-top: thin solid black;width: 100%; padding: 15px; margin:0; font-size: 18px;">
            <div id="taxpayerid" style="position:relative; left: 0; display: inline-block;">
                <asp:Label ID="Label2" runat="server" Text="Tax Payer ID: " style="display: inline-block;"></asp:Label>
                <asp:Label ID="lblTaxPayerID" runat="server" style="display: inline-block;" Enabled="False"></asp:Label>
            </div>
            <div id="taxyear" style="position:relative; left: 100px; display: inline-block;">
                <asp:Label ID="Label8" runat="server" Text="Tax Year: " style="display: inline-block;"></asp:Label>
                <asp:Label ID="lblTaxYear" runat="server" style="display: inline-block;" Enabled="False"></asp:Label>
            </div>
        </div>
        <div class="row" style="border-bottom: thin solid;  border-top: thin solid black;width: 100%; padding: 15px; margin:0;">
            <div class="col-md-4">
                <asp:Label ID="Label3" runat="server" Text="Tax Payer Last Name:" style="display:block; padding: 5px;"></asp:Label>
                <asp:TextBox ID="txtLastName" runat="server" style="display:block; width: 80%;" Enabled="False"></asp:TextBox>
                <asp:Label ID="Label5" runat="server" Text="Tax Payer City:" style="display:block; padding: 5px;"></asp:Label>
                <asp:TextBox ID="txtCity" runat="server" style="display:block; width: 80%;" Enabled="False"></asp:TextBox>
            </div>
            <div class="col-md-4">
                <asp:Label ID="Label4" runat="server" Text="Tax Payer First Name:" style="display:block; padding: 5px;"></asp:Label>
                <asp:TextBox ID="txtFirstName" runat="server" style="display:block; width: 80%;" Enabled="False"></asp:TextBox>
                <asp:Label ID="Label6" runat="server" Text="Tax Payer State:" style="display:block; padding: 5px;"></asp:Label>
                <asp:TextBox ID="txtState" runat="server" style="display:block; width: 80%;" Enabled="False"></asp:TextBox>
            </div>
            <div class="col-md-4">
                <asp:Label ID="Label7" runat="server" Text="Tax Payer MI:" style="display:block; padding: 5px;"></asp:Label>
                <asp:TextBox ID="txtMI" runat="server" style="display:block; width: 80%;" Enabled="False"></asp:TextBox>
                <asp:Label ID="Label9" runat="server" Text="Tax Payer Zip Code:" style="display:block; padding: 5px;"></asp:Label>
                <asp:TextBox ID="txtZipCode" runat="server" style="display:block; width: 80%;" Enabled="False"></asp:TextBox>
            </div>
        </div>
    </div>

    <asp:Panel ID="pnlPieChart" runat="server">
        <ajaxToolkit:PieChart ID="myPieChart" runat="server">

        </ajaxToolkit:PieChart>
    </asp:Panel>

    <div style="border-bottom: solid; border-width: thin; padding: 15px; background-color: #d0c697; color: #5c5536;">
        <div class="row" style="padding-top: 10px; padding-bottom: 10px">
            <div class="col-md-6">
                <asp:Label ID="lblIndivOrJoint" runat="server" Text="Individual or joint tax return?"></asp:Label>
            </div>
            <div class="col-md-6">
                <div class="row">
                    <div class="col-md-6">

                    </div>
                    <div class="col-md-6">
                        <asp:Label ID="lblIndividualOrJointResult" runat="server" Text="Individual/Joint"></asp:Label>
                    </div>
                </div>
            </div>
        </div>

        <div class="row" style="padding-top: 10px; padding-bottom: 10px">
            <div class="col-md-6">
                <asp:Label ID="lblWages" runat="server" Text="1. Wages, salaries, and tips"></asp:Label>
            </div>
            <div class="col-md-6">
                <asp:TextBox ID="txtWagesResult" runat="server" EnableViewState="true"></asp:TextBox>
            </div>
        </div>

        <div class="row" style="padding-top: 10px; padding-bottom: 10px">
            <div class="col-md-6">
                <asp:Label ID="lblInterest" runat="server" Text="2. Taxable interest"></asp:Label>
            </div>
            <div class="col-md-6">
                <asp:TextBox ID="txtInterestResult" runat="server" ReadOnly="True" Enabled="False"></asp:TextBox>
            </div>
        </div>

        <div class="row" style="padding-top: 10px; padding-bottom: 10px">
            <div class="col-md-6">
                <asp:Label ID="lblUnemployment" runat="server" Text="3. Unemployment compensation"></asp:Label>
            </div>
            <div class="col-md-6">
                <asp:TextBox ID="txtUnemploymentResult" runat="server" ReadOnly="True" Enabled="False"></asp:TextBox>
            </div>
        </div>

        <div class="row" style="padding-top: 10px; padding-bottom: 10px">
            <div class="col-md-6">
                <asp:Label ID="lblGrossIncome" runat="server" Text="4. Added lines 1, 2, and 3. This is your adjusted gross income."></asp:Label>
            </div>
            <div class="col-md-6">
                <div class="row">
                    <div class="col-md-6">

                    </div>
                    <div class="col-md-6">
                        <asp:Label ID="lblGrossIncomeResult" runat="server" Text="" style="color: green; font-weight: 700;"></asp:Label>
                    </div>
                </div>
            </div>
        </div>

        <div class="row" style="padding-top: 10px; padding-bottom: 10px">
            <div class="col-md-6">
                <asp:Label ID="lblDependent" runat="server" Text="5. Number of dependent tax payers."></asp:Label>
            </div>
            <div class="col-md-6">
                <div class="row">
                    <div class="col-md-6">
                        <asp:Label ID="lblNumDependents" runat="server" Text="Dependents"></asp:Label>
                    </div>
                    <div class="col-md-6">
                        <asp:Label ID="lblDependentResult" runat="server" Text="" style="color: green; font-weight: 700;"></asp:Label>
                    </div>
                </div>
           </div>
        </div>

        <div class="row" style="padding-top: 10px; padding-bottom: 10px">
            <div class="col-md-6">
                <asp:Label ID="Label1" runat="server" Text="6. Subtracted line 5 from line 4. This is your taxable income."></asp:Label>
            </div>
            <div class="col-md-6">
                <div class="row">
                    <div class="col-md-6">

                    </div>
                    <div class="col-md-6">
                        <asp:Label ID="lblTaxableIncome" runat="server" Text="" style="color: green; font-weight: 700;"></asp:Label>
                    </div>
                </div>
            </div>
        </div>

        <div class="row" style="padding-top: 10px; padding-bottom: 10px">
            <div class="col-md-6">
                <asp:Label ID="lblWithholding" runat="server" Text="7. Federal income tax whithheld from box 2 of your Form(s) W-2"></asp:Label>
            </div>
            <div class="col-md-6">
                <asp:TextBox ID="txtWithholdingResult" runat="server" ReadOnly="True" Enabled="False"></asp:TextBox>
            </div>
        </div>

        <div class="row" style="padding-top: 10px; padding-bottom: 10px">
            <div class="col-md-6">
                <asp:Label ID="lblEarnedIncome" runat="server" Text="8a. Earned income credit (EIC)"></asp:Label>
            </div>
            <div class="col-md-6">
                <asp:TextBox ID="txtEarnedIncomeResult" runat="server" ReadOnly="True" Enabled="False"></asp:TextBox>
            </div>
        </div>

        <div class="row" style="padding-top: 10px; padding-bottom: 10px">
            <div class="col-md-6">
                <asp:Label ID="lblNontaxable" runat="server" Text="8b. Nontaxable compay pay election"></asp:Label>
            </div>
            <div class="col-md-6">
                <asp:TextBox ID="txtNontaxableResult" runat="server" ReadOnly="True" Enabled="False"></asp:TextBox>
            </div>
        </div>

        <div class="row" style="padding-top: 10px; padding-bottom: 10px">
            <div class="col-md-6">
                <asp:Label ID="lblTotalPayments" runat="server" Text="9. Added lines 7, 8, and 8a. These are your total payments."></asp:Label>
            </div>
            <div class="col-md-6">
                <div class="row">
                    <div class="col-md-6">

                    </div>
                    <div class="col-md-6">
                        <asp:Label ID="lblTotalPaymentsResult" runat="server" Text="" style="color: green; font-weight: 700;"></asp:Label>
                    </div>
                </div>
            </div>
        </div>

        <div class="row" style="padding-top: 10px; padding-bottom: 10px">
            <div class="col-md-6">
                <asp:Label ID="lblCalculatedTax" runat="server" Text="10. Your tax."></asp:Label>
            </div>
            <div class="col-md-6">
                <div class="row">
                    <div class="col-md-6">

                    </div>
                    <div class="col-md-6">
                        <asp:Label ID="lblCalculatedTaxResult" runat="server" Text="" style="color: green; font-weight: 700;"></asp:Label>
                    </div>
                </div>
            </div>
        </div>

        <div class="row" style="padding-top: 10px; padding-bottom: 10px">
            <div class="col-md-6">
                <asp:Label ID="lblRefundMsg" runat="server" Text="" style="color: black; font-weight: 700;"></asp:Label>
                <asp:Label ID="lblTaxOwedMsg" runat="server" Text="" style="color: #b20000; font-weight: 700;"></asp:Label>
            </div>
            <div class="col-md-6">
                <div class="row">
                    <div class="col-md-6">

                    </div>
                    <div class="col-md-6">
                        <asp:Label ID="lblTaxRefund" runat="server" Text="" style="color: black; font-weight: 700;"></asp:Label>
                        <asp:Label ID="lblTaxOwed" runat="server" Text="" style="color: #b20000; font-weight: 700;"></asp:Label>
                    </div>
                </div>
            </div>
        </div>

        <div class="row" style="padding-top: 10px; padding-bottom: 10px;">
            <div class="col-md-6">
                <asp:Button ID="btnBack" runat="server" Text="<< Go Back" style="width: 100px" />
            </div>
            <div class="col-md-6"></div>
        </div>

    </div>

</asp:Content>
