<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Result.aspx.vb" Inherits="MIS124Lab2_WebBMICalculator.Result" %><%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .auto-style2
        {
            width: 79px;
        }
        .auto-style3
        {
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
        .auto-style6
        {
            height: 23px;
        }
        .auto-style8
        {
            width: 51px;
        }
        .auto-style9
        {
            width: 14px;
        }
        .auto-style10
        {
            height: 94px;
        }
        .auto-style11
        {
            height: 43px;
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
    <table class="newStyle1" style="width: 500px; margin-top: 0px; margin-right: 0px;">
        <tr>
            <td class="auto-style2" rowspan="9">
                <asp:Image ID="Image1" runat="server" Height="324px" ImageUrl="~/Images/BMI.jpg" Width="137px" />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
            </td>
            <td class="auto-style3" style="text-align: left">Your E-mail is</td>
            <td class="auto-style6">
                <asp:Label ID="lblEMail" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style6" style="text-align: left">Your Weight is</td>
            <td class="auto-style6">
                <asp:Label ID="lblWeight" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="text-align: left" class="auto-style3">Your Height is</td>
            <td class="auto-style8">
                <asp:Label ID="lblHeight" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="text-align: left" class="auto-style4">Your BMI is</td>
            <td class="auto-style5">
                <asp:Label ID="lblBMI" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="text-align: left" class="auto-style3">Your Weight Category is</td>
            <td class="auto-style8">
                <asp:Label ID="lblCategory" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="text-align: center" class="auto-style3" colspan="2">
                <ajaxToolkit:BarChart ID="BarChart" runat="server" CategoriesAxis="Comparisons" ChartHeight="250" ChartTitle="BMI Results Comparison" ChartWidth="500">
                    <Series>
                        <ajaxToolkit:BarChartSeries BarColor="" Data="15" Name="Underweight" />
                        <ajaxToolkit:BarChartSeries BarColor="" Data="19" Name="Normal" />
                        <ajaxToolkit:BarChartSeries BarColor="" Data="25" Name="Overweight" />
                        <ajaxToolkit:BarChartSeries BarColor="" Data="29" Name="Obese" />
                   </Series>
                </ajaxToolkit:BarChart>
            </td>
        </tr>
        <tr>
            <td class="auto-style11" colspan="2">
                <asp:Button ID="btnGoBack" runat="server" style="text-align: right" Text="Go Back" />
                &nbsp;&nbsp;<asp:Button ID="btnEmailResults" runat="server" Text="E-mail Results" />
            </td>
        </tr>
        <tr>
            <td class="auto-style10" colspan="2" style="line-height: =; height: 20px;">
                <asp:Label ID="lblErrorMessages" runat="server" CssClass="animated flip"></asp:Label>
                </td>
        </tr>
        <tr>
            <td class="auto-style6" colspan="2">
                <asp:Panel ID="Panel1" runat="server" BackColor="#333399" ForeColor="White">
                    <table style="padding: 30px; width:100%; height: 100px; margin-top: 30px;">
                        <tr>
                            <td class="auto-style9" rowspan="3">
                                <img alt="" src="http://www.printcnx.com/wp-content/uploads/EmailGraphic.jpg" style="height: 103px; width: 122px" />
                            </td>
                            <td>
                                <asp:Label ID="Label1" runat="server" ForeColor="White" Text="Type the recipient address"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:TextBox ID="txtEMail" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button ID="btnOk" runat="server" Text="Ok" UseSubmitBehavior="False" />
                                &nbsp;<asp:Button ID="btnCancel" runat="server" Text="Cancel" />
                            </td>
                        </tr>
                    </table>
                    
                </asp:Panel>
            </td>
        </tr>
    </table>
    <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender2" runat="server" TargetControlID="btnemailresults" PopupControlID="panel1" CancelControlID="btnCancel" OkControlID="btnOk"></ajaxToolkit:ModalPopupExtender>
</asp:Content>
