<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Result.aspx.vb" Inherits="MIS124Lab2_WebBMICalculator.Result" %><asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .auto-style2
        {
            width: 79px;
        }
        .auto-style3
        {
            width: 148px;
        }
        .auto-style4
        {
            width: 148px;
            height: 33px;
        }
        .auto-style5
        {
            height: 33px;
        }
        .auto-style6 {
            height: 30px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
            <section class="featured">
    <div class="content-wrapper">
        <hgroup class="title">
            <h1><%: Title %>BMI Calculator Version 2 - Result</h1>
        </hgroup>
    </div>
</section>
            </asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <table class="newStyle1" style="width: 100%; margin-top: 0px; margin-right: 0px;">
        <tr>
            <td class="auto-style2" rowspan="9">
                <asp:Image ID="Image1" runat="server" Height="324px" ImageUrl="~/Images/BMI.jpg" Width="137px" />
            </td>
            <td class="auto-style3" style="text-align: right">Your Name is</td>
            <td class="auto-style6">
                <asp:Label ID="lblName" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style3" style="text-align: right">Your Weight is</td>
            <td class="auto-style6">
                <asp:Label ID="lblWeight" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="text-align: right" class="auto-style3">Your Height is</td>
            <td class="auto-style8">
                <asp:Label ID="lblHeight" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="text-align: right" class="auto-style4">Your BMI is</td>
            <td class="auto-style5">
                <asp:Label ID="lblBMI" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="text-align: right" class="auto-style3">Your Weight Category is</td>
            <td class="auto-style8">
                <asp:Label ID="lblCategory" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style13" colspan="2">
                <asp:Button ID="btnGoBack" runat="server" style="text-align: right" Text="Go Back" />
                &nbsp;<asp:Button ID="btnDisplayResults" runat="server" Text="Display/Hide Results" />
&nbsp;<asp:Button ID="btnMailResults" runat="server" Text="Mail Results" />
&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style13" colspan="2">
                Place a panel here to show a Bar Graph</td>
        </tr>
        <tr>
            <td class="auto-style6" colspan="2">
                <asp:Label ID="lblErrorMessages" runat="server" CssClass="animated flip"></asp:Label>
                <br /></td>
        </tr>
        <tr>
            <td class="auto-style11" colspan="2">&nbsp;</td>
        </tr>
    </table>
</asp:Content>
