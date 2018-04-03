<%@ Page Title="Home Page" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.vb" Inherits="MIS124Lab8_SP500Browser._Default" %>

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <section class="featured">
    </section>
</asp:Content>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <table style="width:100%;">
    <tr>
        <td class="auto-style5">Stock Ticker</td>
        <td>
            <asp:TextBox ID="txtStockTicker" runat="server" Width="81px"></asp:TextBox>
        </td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style5">Stock Name</td>
        <td>
            <asp:TextBox ID="txtStockName" runat="server" Width="320px"></asp:TextBox>
        </td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style5">Dividend Per Share</td>
        <td>
            <asp:TextBox ID="txtDividendPerShare" runat="server"></asp:TextBox>
        </td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style5" colspan="2">
            <asp:Button ID="btnFind" runat="server" Text="Find" />
&nbsp;<asp:Button ID="btnUpdate" runat="server" Text="Update" />
            <br />
            <asp:Label ID="lblMessages" runat="server"></asp:Label>
        </td>
        <td>&nbsp;</td>
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
    }
</style>
</asp:Content>

