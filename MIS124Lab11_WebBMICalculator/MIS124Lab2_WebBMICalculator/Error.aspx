<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Error.aspx.vb" Inherits="MIS124Lab2_WebBMICalculator._Error" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .auto-style2
        {
            width: 45px;
        }
        .auto-style3
        {
            font-size: xx-large;
            text-decoration: underline;
            height: 56px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <table style="width:100%;">
        <tr>
            <td class="auto-style2" rowspan="3">
                <img alt="" src="http://1.bp.blogspot.com/-F7Z9r35JrZE/UIQb90HarHI/AAAAAAAACbk/wNDv7oLVv40/s1600/baby-crying2.jpg" style="height: 222px; width: 285px" /></td>
            <td class="auto-style3"><strong>Error Page</strong></td>
        </tr>
        <tr>
            <td>Ooops! We know that this is devesting but if you tell us what happened, we promise to fix it.<br />
                <br />
                Click here to report the problem: <a href="mailto:somelink@saclink.csus.edu">somelink@saclink.csus.edu</a> </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblError" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>
