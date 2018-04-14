<%@ Page Title="Home Page" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Default.aspx.vb" Inherits="_Default"%>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

        <div style="text-align: center; margin-bottom: 10px; padding: 10px; width: 100%">
                <h2>2017 Tax Return 1040EZ Version 2.0 - Main Page</h2>
        </div>
    <asp:Panel ID="pnlMessage" runat="server" style="display: none;">
        <asp:Label ID="lblMessage" runat="server"></asp:Label>
    </asp:Panel>
     <div style="background-color: #ffe8bf;">
        <div class="row" style="border-bottom: thin solid;  border-top: thin solid black;width: 100%; padding: 15px; margin:0; font-weight: 700; font-size: 16px">
            <div class="col-md-3" style="text-align: center">
                <p>Step 1: Select your Tax Payer ID</p>
            </div>
            <div class="col-md-6" style="text-align: center">
                <p>Step 2. Verify your Information and update anything that has changed.</p>
            </div>
            <div class="col-md-3" style="text-align: center;"">
                <p>Step 3: Enter your Tax Year</p>
            </div>
        </div>

        <div class="row" style="border-bottom: thin solid; width: 100%; padding: 15px; margin:0;">
            <div class="col-md-3" style="text-align: center">
                <asp:DropDownList ID="lstTaxPayers" runat="server" 
                    Width="200px"
                    DataSourceID="SqlDataSource1" 
                    DataTextField="TaxPayerLastName" 
                    DataValueField="TaxPayerID" 
                    AutoPostBack="True"
                    itempadding="0">
                    
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:TaxReturn2014_Rodger %>" SelectCommand="SELECT [TaxPayerID], [TaxPayerLastName] FROM [tblTaxPayer]"></asp:SqlDataSource>
            </div>
            <div class="col-md-6">
                <asp:DetailsView ID="dtlTaxPayer" runat="server" 
                    Height="50px" 
                     
                    AutoGenerateRows="False" 
                    DataKeyNames="TaxPayerID" 
                    DataSourceID="SqlDataSource2" 
                    AutoGenerateEditButton="True"
                    cellpadding="8"
                    style="width: 80%; margin: auto; background-color: oldlace"
                    >
                    
                    <Fields>
                        <asp:BoundField ItemStyle-Width="300px" DataField="TaxPayerID" HeaderText="ID Number" ReadOnly="True" SortExpression="TaxPayerID"/>
                        <asp:BoundField DataField="TaxPayerLastName" HeaderText="Last Name" SortExpression="TaxPayerLastName" />
                        <asp:BoundField DataField="TaxPayerFirstName" HeaderText="First Name" SortExpression="TaxPayerFirstName" />
                        <asp:BoundField DataField="TaxPayerInitial" HeaderText="Middle Initial" SortExpression="TaxPayerInitial" />
                        <asp:BoundField DataField="TaxPayerAddress" HeaderText="Street Address" SortExpression="TaxPayerAddress" />
                        <asp:BoundField DataField="TaxPayerCity" HeaderText="City" SortExpression="TaxPayerCity" />
                        <asp:BoundField DataField="TaxPayerState" HeaderText="State" SortExpression="TaxPayerState" />
                        <asp:BoundField DataField="TaxPayerZip" HeaderText="Zip Code" SortExpression="TaxPayerZip" />
                    </Fields>
                </asp:DetailsView>
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:TaxReturn2014_Rodger %>" SelectCommand="SELECT [TaxPayerID], [TaxPayerLastName], [TaxPayerFirstName], [TaxPayerInitial], [TaxPayerAddress], [TaxPayerCity], [TaxPayerState], [TaxPayerZip] FROM [tblTaxPayer] WHERE ([TaxPayerID] = @TaxPayerID)" ConflictDetection="CompareAllValues" DeleteCommand="DELETE FROM [tblTaxPayer] WHERE [TaxPayerID] = @original_TaxPayerID AND [TaxPayerLastName] = @original_TaxPayerLastName AND [TaxPayerFirstName] = @original_TaxPayerFirstName AND [TaxPayerInitial] = @original_TaxPayerInitial AND [TaxPayerAddress] = @original_TaxPayerAddress AND [TaxPayerCity] = @original_TaxPayerCity AND [TaxPayerState] = @original_TaxPayerState AND [TaxPayerZip] = @original_TaxPayerZip" InsertCommand="INSERT INTO [tblTaxPayer] ([TaxPayerID], [TaxPayerLastName], [TaxPayerFirstName], [TaxPayerInitial], [TaxPayerAddress], [TaxPayerCity], [TaxPayerState], [TaxPayerZip]) VALUES (@TaxPayerID, @TaxPayerLastName, @TaxPayerFirstName, @TaxPayerInitial, @TaxPayerAddress, @TaxPayerCity, @TaxPayerState, @TaxPayerZip)" OldValuesParameterFormatString="original_{0}" UpdateCommand="UPDATE [tblTaxPayer] SET [TaxPayerLastName] = @TaxPayerLastName, [TaxPayerFirstName] = @TaxPayerFirstName, [TaxPayerInitial] = @TaxPayerInitial, [TaxPayerAddress] = @TaxPayerAddress, [TaxPayerCity] = @TaxPayerCity, [TaxPayerState] = @TaxPayerState, [TaxPayerZip] = @TaxPayerZip WHERE [TaxPayerID] = @original_TaxPayerID AND [TaxPayerLastName] = @original_TaxPayerLastName AND [TaxPayerFirstName] = @original_TaxPayerFirstName AND [TaxPayerInitial] = @original_TaxPayerInitial AND [TaxPayerAddress] = @original_TaxPayerAddress AND [TaxPayerCity] = @original_TaxPayerCity AND [TaxPayerState] = @original_TaxPayerState AND [TaxPayerZip] = @original_TaxPayerZip">
                    <DeleteParameters>
                        <asp:Parameter Name="original_TaxPayerID" Type="Int64" />
                        <asp:Parameter Name="original_TaxPayerLastName" Type="String" />
                        <asp:Parameter Name="original_TaxPayerFirstName" Type="String" />
                        <asp:Parameter Name="original_TaxPayerInitial" Type="String" />
                        <asp:Parameter Name="original_TaxPayerAddress" Type="String" />
                        <asp:Parameter Name="original_TaxPayerCity" Type="String" />
                        <asp:Parameter Name="original_TaxPayerState" Type="String" />
                        <asp:Parameter Name="original_TaxPayerZip" Type="String" />
                    </DeleteParameters>
                    <InsertParameters>
                        <asp:Parameter Name="TaxPayerID" Type="Int64" />
                        <asp:Parameter Name="TaxPayerLastName" Type="String" />
                        <asp:Parameter Name="TaxPayerFirstName" Type="String" />
                        <asp:Parameter Name="TaxPayerInitial" Type="String" />
                        <asp:Parameter Name="TaxPayerAddress" Type="String" />
                        <asp:Parameter Name="TaxPayerCity" Type="String" />
                        <asp:Parameter Name="TaxPayerState" Type="String" />
                        <asp:Parameter Name="TaxPayerZip" Type="String" />
                    </InsertParameters>
                    <SelectParameters>
                        <asp:ControlParameter ControlID="lstTaxPayers" Name="TaxPayerID" PropertyName="SelectedValue" Type="Int64" />
                    </SelectParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="TaxPayerLastName" Type="String" />
                        <asp:Parameter Name="TaxPayerFirstName" Type="String" />
                        <asp:Parameter Name="TaxPayerInitial" Type="String" />
                        <asp:Parameter Name="TaxPayerAddress" Type="String" />
                        <asp:Parameter Name="TaxPayerCity" Type="String" />
                        <asp:Parameter Name="TaxPayerState" Type="String" />
                        <asp:Parameter Name="TaxPayerZip" Type="String" />
                        <asp:Parameter Name="original_TaxPayerID" Type="Int64" />
                        <asp:Parameter Name="original_TaxPayerLastName" Type="String" />
                        <asp:Parameter Name="original_TaxPayerFirstName" Type="String" />
                        <asp:Parameter Name="original_TaxPayerInitial" Type="String" />
                        <asp:Parameter Name="original_TaxPayerAddress" Type="String" />
                        <asp:Parameter Name="original_TaxPayerCity" Type="String" />
                        <asp:Parameter Name="original_TaxPayerState" Type="String" />
                        <asp:Parameter Name="original_TaxPayerZip" Type="String" />
                    </UpdateParameters>
                </asp:SqlDataSource>
            </div>
            <div class="col-md-3" style="text-align: center">
                <asp:DropDownList ID="lstTaxYear" runat="server" style="width: 100px;"></asp:DropDownList>
            </div>
        </div>

        <div class="row" style="border-bottom: thin solid; width: 100%; padding: 15px; margin:0;">
            <asp:Button ID="btnViewTaxReturn" runat="server" Text="View Tax Return >>" />
        </div>
    </div>
    





</asp:Content>
