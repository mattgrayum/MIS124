<%@ Page Title="Home Page" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.vb" Inherits="MIS124Lab2_WebBMICalculator._Default" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
   
    <section class="featured">
        <div class="content-wrapper">
            <hgroup class="title">
                <h1><%: Title %>BMI Calculator Version 6</h1>
            </hgroup>
        </div>
    </section>
</asp:Content>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
             <table class="newStyle1" style="width: 100%; margin-top: 0px; margin-right: 0px;">
        <tr>
            <td class="auto-style12" rowspan="6">
                <asp:Image ID="Image1" runat="server" Height="248px" ImageUrl="~/Images/BMI.jpg" Width="135px" />
            </td>
            <td class="auto-style5">Type Your Saclink e-mail</td>
            <td class="auto-style17">
                <asp:TextBox ID="txtName" runat="server">YourName@csus.edu</asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtName" ErrorMessage="RegularExpressionValidator" ValidationExpression="\w+([-+.']\w+)*@csus.edu">Must be in format YourName@csus.edu</asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style15">Type your Weight</td>
            <td class="auto-style16">
                <asp:TextBox ID="txtWeight" runat="server" CausesValidation="True">175</asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvWeight" runat="server" ControlToValidate="txtWeight" ErrorMessage="Height text field cannot be blank"></asp:RequiredFieldValidator>
                <br />
                <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txtWeight" ErrorMessage="Your Weight cannot be less than 50 pounds or more than the application allows" MaximumValue="600" MinimumValue="0" Type="Double"></asp:RangeValidator>
            </td>
        </tr>
        <tr>
            <td style="text-align: right" class="auto-style14">Type your Height</td>
            <td class="auto-style16">
                <asp:TextBox ID="txtHeight" runat="server" CausesValidation="True">69</asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvHeight" runat="server" ControlToValidate="txtHeight" ErrorMessage="Height text field cannot be blank"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Button ID="btnCalculate" runat="server" style="text-align: right" Text="Calculate" />
                &nbsp;<asp:Button ID="btnClear" runat="server" style="text-align: left" Text="Clear" />
            </td>
        </tr>
        <tr>
            <td class="auto-style10" colspan="2">
                <asp:Label ID="lblErrorMessages" runat="server" CssClass="animated flip"></asp:Label>
                <br />
            </td>
        </tr>
        <tr>
            <td class="auto-style11" colspan="2">
                <asp:Label ID="lblPopup" runat="server" Text=" Please type your e-mail address using format myemailname@csus.edu"></asp:Label>
            </td>
        </tr>
    </table>
  <ajaxToolkit:BalloonPopupExtender ID="BalloonPopupExtender1" runat="server" TargetControlID="txtName" BalloonPopupControlID="lblPopup" DisplayOnClick="False" DisplayOnMouseOver="True"></ajaxToolkit:BalloonPopupExtender>
</asp:Content>
<asp:Content ID="Content1" runat="server" contentplaceholderid="HeadContent">
    <style type="text/css">

            .newStyle1
            {
                background-color: #CCCCCC;
                height: auto;
                position: absolute;
                width: 600px;
            }
            .auto-style12
        {
            -webkit-animation-name: rotateIn;
            animation-name: rotateIn;
            width: 26px;
        }
            .auto-style5
        {
            height: 1px;
            width: 168px;
            text-align: right;
        }
        .auto-style10
        {
            height: 14px;
            text-align: left;
        }
        .auto-style14
        {
            width: 168px;
        }
        .auto-style15
        {
            width: 168px;
            text-align: right;
        }
        .auto-style16
        {
            text-align: left;
        }
        .auto-style17
        {
            height: 1px;
            text-align: left;
        }
        </style>
   
</asp:Content>

