<%@ Page Title="Home Page" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.vb" Inherits="MIS124PracticeExam2._Default" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <p>
    MIS 124 Exam 2 - By Your Name</p>
</asp:Content>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <table style="width:100%;">
    <tr>
        <td class="auto-style5">Author ID</td>
        <td class="auto-style6">
            <asp:TextBox ID="txtAuthorID" runat="server" Width="81px"></asp:TextBox>
        </td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style5">Author First Name</td>
        <td class="auto-style6">
            <asp:TextBox ID="txtFirstName" runat="server" ReadOnly="True" Width="324px"></asp:TextBox>
        </td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style5">Author Last Name</td>
        <td class="auto-style6">
            <asp:TextBox ID="txtLastName" runat="server" Width="213px" ReadOnly="True"></asp:TextBox>
        </td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style9">Year Born</td>
        <td class="auto-style8">
            <asp:TextBox ID="txtYearBorn" runat="server"></asp:TextBox>
        </td>
        <td class="auto-style7"></td>
    </tr>
    <tr>
        <td class="auto-style5" colspan="3  ">
            <asp:Button ID="btnFind" runat="server" Text="Find" />
&nbsp;<asp:Button ID="btnUpdate" runat="server" Text="Update" />
            <br />
            <asp:Label ID="lblMessages" runat="server"></asp:Label>
        </td>
        <td class="auto-style6">&nbsp;</td>
    </tr>
</table>
</asp:Content>
<asp:Content ID="Content1" runat="server" contentplaceholderid="HeadContent">
    <style type="text/css">
    .auto-style3
    {
        width: 557px;
    }
    .auto-style4
    {
        width: 524px;
    }
    .auto-style5
    {
            width: 221px;
        }
        .auto-style6
        {
            width: 653px;
        }
        .auto-style7
        {
            height: 47px;
        }
        .auto-style8
        {
            width: 653px;
            height: 47px;
        }
        .auto-style9
        {
            height: 47px;
            width: 221px;
        }
    </style>
</asp:Content>

