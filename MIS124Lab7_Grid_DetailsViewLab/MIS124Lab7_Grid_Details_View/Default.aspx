<%@ Page Title="Home Page" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.vb" Inherits="MIS124Lab7_Grid_Details_View._Default" %>

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    </asp:Content>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <p>
        <table style="width:100%;">
            <tr>
                <td style="border-width: 1px 1px medium 1px; background-color: #9999FF; border-bottom-style: solid; border-top-style: solid;">Select a book rom the list below to view the details</td>
                <td class="auto-style2" style="border-width: 1px 1px medium 1px; background-color: #9999FF; border-bottom-style: solid; border-top-style: solid;">Below are your book details</td>
            </tr>
            <tr>
                <td>
                    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="ISBN" DataSourceID="dsGridView" PageSize="5">
                        <Columns>
                            <asp:BoundField DataField="ISBN" HeaderText="ISBN" SortExpression="ISBN" />
                            <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title" />
                            <asp:CommandField ShowSelectButton="True" />
                        </Columns>
                        <SelectedRowStyle BackColor="#9999FF" />
                    </asp:GridView>
                    <asp:SqlDataSource ID="dsGridView" runat="server" ConnectionString="<%$ ConnectionStrings:SacRetailConnectionString3 %>" SelectCommand="SELECT [ISBN], [Title] FROM [Titles] ORDER BY [ISBN]"></asp:SqlDataSource>
                    &nbsp;</td>
                <td class="auto-style2">
                    <asp:DetailsView ID="DetailsView1" runat="server" Height="50px" Width="500px" AutoGenerateRows="False" DataSourceID="dsDetailView">
                        <Fields>
                            <asp:BoundField DataField="ISBN" HeaderText="ISBN" SortExpression="ISBN" />
                            <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title" />
                            <asp:BoundField DataField="EditionNumber" HeaderText="EditionNumber" SortExpression="EditionNumber" />
                            <asp:BoundField DataField="YearPublished" HeaderText="YearPublished" SortExpression="YearPublished" />
                            <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />
                            <asp:BoundField DataField="PublisherID" HeaderText="PublisherID" SortExpression="PublisherID" />
                        </Fields>
                    </asp:DetailsView>
                    <asp:SqlDataSource ID="dsDetailView" runat="server" ConnectionString="<%$ ConnectionStrings:SacRetailConnectionString3 %>" SelectCommand="SELECT [ISBN], [Title], [EditionNumber], [YearPublished], [Description], [PublisherID] FROM [Titles] WHERE ([ISBN] = @ISBN)">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="GridView1" Name="ISBN" PropertyName="SelectedValue" Type="String" />
                        </SelectParameters>
                    </asp:SqlDataSource>
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
        </style>
</asp:Content>

