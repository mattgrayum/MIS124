﻿<%@ Page Title="Results Page" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Result.aspx.vb" Inherits="_Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div style="text-align: center; border-bottom: solid; border-width: thin; margin-bottom: 10px;"><h2>2017 Tax Return 1040EZ Calculator - Calculation Results</h2></div>

    <div style="border-bottom: solid; border-width: thin; padding: 15px; background-color: oldlace">
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
                <asp:TextBox ID="txtWagesResult" runat="server" EnableViewState="true" ReadOnly="True"></asp:TextBox>
            </div>
        </div>

        <div class="row" style="padding-top: 10px; padding-bottom: 10px">
            <div class="col-md-6">
                <asp:Label ID="lblInterest" runat="server" Text="2. Taxable interest"></asp:Label>
            </div>
            <div class="col-md-6">
                <asp:TextBox ID="txtInterestResult" runat="server" ReadOnly="True"></asp:TextBox>
            </div>
        </div>

        <div class="row" style="padding-top: 10px; padding-bottom: 10px">
            <div class="col-md-6">
                <asp:Label ID="lblUnemployment" runat="server" Text="3. Unemployment compensation"></asp:Label>
            </div>
            <div class="col-md-6">
                <asp:TextBox ID="txtUnemploymentResult" runat="server" ReadOnly="True"></asp:TextBox>
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
                <asp:TextBox ID="txtWithholdingResult" runat="server" ReadOnly="True"></asp:TextBox>
            </div>
        </div>

        <div class="row" style="padding-top: 10px; padding-bottom: 10px">
            <div class="col-md-6">
                <asp:Label ID="lblEarnedIncome" runat="server" Text="8a. Earned income credit (EIC)"></asp:Label>
            </div>
            <div class="col-md-6">
                <asp:TextBox ID="txtEarnedIncomeResult" runat="server" ReadOnly="True"></asp:TextBox>
            </div>
        </div>

        <div class="row" style="padding-top: 10px; padding-bottom: 10px">
            <div class="col-md-6">
                <asp:Label ID="lblNontaxable" runat="server" Text="8b. Nontaxable compay pay election"></asp:Label>
            </div>
            <div class="col-md-6">
                <asp:TextBox ID="txtNontaxableResult" runat="server" ReadOnly="True"></asp:TextBox>
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
                <asp:Label ID="lblCalculatedTax" runat="server" Text="10. Calculated your tax."></asp:Label>
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
                <asp:Label ID="lblTaxOwedMsg" runat="server" Text="" style="color: red; font-weight: 700;"></asp:Label>
            </div>
            <div class="col-md-6">
                <div class="row">
                    <div class="col-md-6">

                    </div>
                    <div class="col-md-6">
                        <asp:Label ID="lblTaxRefund" runat="server" Text="" style="color: black; font-weight: 700;"></asp:Label>
                        <asp:Label ID="lblTaxOwed" runat="server" Text="" style="color: red; font-weight: 700;"></asp:Label>
                    </div>
                </div>
            </div>
        </div>

        <div class="row" style="padding-top: 10px; padding-bottom: 10px;">
            <div class="col-md-6">
            </div>
            <div class="col-md-6">
                <asp:Button ID="btnBack" runat="server" Text="Go Back" style="width: 80px" />
            </div>
        </div>

    </div>

    <div style="border-style: solid; border-width: thin; background-color: oldlace; margin-top: 10px; padding: 5px; text-align: center;">
        <asp:Label ID="lblSuccessMessage" runat="server" Text="Your tax return has been succussfully calculated."></asp:Label>
    </div>

</asp:Content>
