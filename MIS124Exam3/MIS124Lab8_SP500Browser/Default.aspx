<%@ Page Title="Home Page" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.vb" Inherits="MIS124Lab8_SP500Browser._Default" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <style>
    .mg-email-container{
            padding: 20px;
            text-align: center;
        }
       .mg-email-row{
           padding: 10px;
       }
       .mg-email-title{
           font-size: 18px;
           font-weight: 700;
       }
       .mg-popup{
           border: solid thin black; 
           background: linear-gradient(#5fa8dd, #fff); 
           z-index: 999;
           box-shadow: 10px 20px 8px #888888;
       }
</style>
    <section class="featured">
    </section>
</asp:Content>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <table style="width:100%;">
    <tr>
        <td class="auto-style5">Stock Ticker</td>
        <td>
            <asp:TextBox ID="txtStockTicker" runat="server" Width="81px"></asp:TextBox>
        &nbsp;(i.e., C, AIG, XOM, DD, DIS)</td>
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
        <td class="auto-style5">Price Earning Ratio</td>
        <td>
            <asp:TextBox ID="txtPE" runat="server"></asp:TextBox>
        </td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style5" colspan="3  ">
            <asp:Button ID="btnFind" runat="server" Text="Find" />
            <ajaxToolkit:BalloonPopupExtender ID="BalloonPopupExtender1" runat="server" BalloonPopupControlID="lblPopup" TargetControlID="btnFind" DisplayOnClick="False" DisplayOnMouseOver="True"></ajaxToolkit:BalloonPopupExtender>
            <asp:Label ID="lblPopup" runat="server" Text="Click me to Display the Stock Data"></asp:Label>

&nbsp;<asp:Button ID="btnEmail" runat="server" Text="Email Stock P/E" />
            <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender1" runat="server" TargetControlID="btnEmail" PopupControlID="pnlEmail" CancelControlID="btnCancel"></ajaxToolkit:ModalPopupExtender>
            <asp:Panel ID="pnlEmail" runat="server" class="mg-popup">
                <div class="mg-email-container">
                    <div class="row mg-email-row mg-email-title">
                        <p>Have this stock information sent to you by Email</p>
                    </div>
                    <div class="row mg-email-row">
                        <asp:Label ID="lblEmail" runat="server" Text="Enter your email address: "></asp:Label>
                        <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                    </div>
                        <div class="row mg-email-row"> 
                        <asp:Button ID="btnOk" class="mg-btn" runat="server" Text="Ok" />
                        <asp:Button ID="btnCancel" class="mg-btn" runat="server" Text="Cancel" />
                                                    
                    </div> 
                </div>
            </asp:Panel>
            
            <asp:Button ID="btnDisplayHideResults" runat="server" Text="Display/Hide Results" />
            <br />
            <ajaxToolkit:CollapsiblePanelExtender ID="CollapsiblePanelExtender1" runat="server" CollapseControlID="btnDisplayHideResults" TargetControlID="barchartContainer" AutoCollapse="False" Collapsed="True" ExpandControlID="btnDisplayHideResults" />
                <asp:Panel ID="barchartContainer" runat="server">

                    <ajaxToolkit:BarChart ID="stockBarChart" runat="server"></ajaxToolkit:BarChart>

                </asp:Panel>
            <asp:Label ID="lblMessages" runat="server"></asp:Label>
            <br />
        </td>
        <td>&nbsp;</td>
    </tr>
</table>

</asp:Content>



