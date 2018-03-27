<%@ Page Title="Home Page" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.vb" Inherits="MIS124Lab7_Grid_Details_View._Default" %>

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    </asp:Content>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <p>
        <table style="width:100%;">
            <tr>
                <td class="auto-style3" style="border-width: 1px 1px medium 1px; background-color: #9999FF; border-bottom-style: solid; border-top-style: solid;">Select a book rom the list below to view the details</td>
                <td class="auto-style2" style="border-width: 1px 1px medium 1px; background-color: #9999FF; border-bottom-style: solid; border-top-style: solid;">Below are your book details</td>
            </tr>
            <tr>
                <td class="auto-style3">
                    <asp:GridView ID="GridView1" runat="server"></asp:GridView>
                    &nbsp;</td>
                <td class="auto-style2">
                    <asp:DetailsView ID="DetailsView1" runat="server" Height="50px" Width="125px"></asp:DetailsView>
                    &nbsp;</td>
            </tr>
        </table>
    </p>
<p>
    &nbsp;</p>
</asp:Content>
<asp:Content ID="Content1" runat="server" contentplaceholderid="HeadContent">
    <style type="text/css">
        .auto-style2
        {
            width: 338px;
        }
        .auto-style3
        {
            width: 327px;
        }
    </style>
</asp:Content>

