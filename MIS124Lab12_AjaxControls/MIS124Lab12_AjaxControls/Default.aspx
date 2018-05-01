<%@ Page Title="Home Page" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.vb" Inherits="MIS124Lab12_AjaxControls._Default" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        MIS 124 Lab 12: Working with Ajax Controls<asp:Panel ID="Panel4" runat="server" BackColor="Aqua" Font-Size="Medium" GroupingText="E-Mail confirmation dialog">
            &nbsp;<asp:Label ID="Label1" runat="server" Text="Some explanation here"></asp:Label>
            &nbsp;<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
&nbsp;
            <asp:Button ID="Button1" runat="server" Text="Click me" />
        </asp:Panel>
    </div>

    <div class="row">
        <div class="col-md-4">
            <h2>Getting Started
                <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/Refresh.png" />
                <ajaxToolkit:BalloonPopupExtender ID="Image1_BalloonPopupExtender" runat="server" BalloonPopupControlID="lblToolTip" BehaviorID="Image1_BalloonPopupExtender" CustomCssUrl="" DisplayOnClick="False" DisplayOnMouseOver="True" DynamicServicePath="" ExtenderControlID="" TargetControlID="Image1">
                </ajaxToolkit:BalloonPopupExtender>
&nbsp;<asp:Label ID="lblToolTip" runat="server" Font-Size="Small" Text="Click on the image to display or hide additional information"></asp:Label>
            </h2>
            <asp:Panel ID="Panel1" runat="server" BackColor="#FFFFCC">
                ASP.NET Web Forms lets you build dynamic websites using a familiar drag-and-drop, event-driven model.
            A design surface and hundreds of controls and components let you rapidly build sophisticated, powerful UI-driven sites with data access.
            </asp:Panel>
            <ajaxToolkit:CollapsiblePanelExtender ID="Panel1_CollapsiblePanelExtender" runat="server" BehaviorID="Panel1_CollapsiblePanelExtender" CollapseControlID="Image1" Collapsed="True" CollapsedImage="~/Images/Down.png" CollapsedSize="20" ExpandControlID="Image1" ExpandedImage="~/Images/up.png" ImageControlID="Image1" TargetControlID="Panel1">
            </ajaxToolkit:CollapsiblePanelExtender>
        </div>
        <div class="col-md-4">
            <h2>Get more libraries
                <asp:Image ID="Image2" runat="server" ImageUrl="~/Images/Refresh.png" />
                <asp:Label ID="lblTooltip2" runat="server" Text="Click here to see panel content"></asp:Label>
            <asp:Panel ID="Panel2" runat="server" BackColor="#CCCCFF">
                NuGet is a free Visual Studio extension that makes it easy to add, remove, and update libraries and tools in Visual Studio projects.</asp:Panel>
        </div>
        <div class="col-md-4">
            <h2>Web Hosting
                <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Images/Refresh.png" />
                <ajaxToolkit:ModalPopupExtender ID="ImageButton1_ModalPopupExtender" runat="server" PopupControlID="panel4" TargetControlID="ImageButton1">
                </ajaxToolkit:ModalPopupExtender>
            </h2>
            <asp:Panel ID="Panel3" runat="server" BackColor="#CCCCCC">
                You can easily find a web hosting company that offers the right mix of features and price for your applications.
            </asp:Panel>
        </div>
    </div>

</asp:Content>
