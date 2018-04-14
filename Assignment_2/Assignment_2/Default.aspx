<%@ Page Title="Home Page" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

        <div style="text-align: center; margin-bottom: 10px; padding: 10px; width: 100%">
                <h2>2017 Tax Return 1040EZ Version 2.0 - Main Page</h2>
        </div>
    <asp:Panel ID="pnlMessage" runat="server" style="display: none;">
        <asp:Label ID="lblMessage" runat="server"></asp:Label>
    </asp:Panel>
     <div style="background-color: oldlace;">
        <div class="row" style="border-bottom: thin solid;  border-top: thin solid black;width: 100%; padding: 15px; margin:0;">
            <div class="col-md-3">
                <p>Step 1: Select your Tax Payer ID</p>
            </div>
            <div class="col-md-6">
                <p>Step 2. Verify your Information. If your information has changed, please provide your current information.</p>
            </div>
            <div class="col-md-3">
                <p>Step 3: Type your Tax Year</p>
            </div>
        </div>

        <div class="row" style="border-bottom: thin solid; width: 100%; padding: 15px; margin:0;">
            <div class="col-md-3">
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
                    Width="500px" 
                    AutoGenerateRows="False" 
                    DataKeyNames="TaxPayerID" 
                    DataSourceID="SqlDataSource2" 
                    AutoGenerateEditButton="True"
                    cellpadding="5"
                    >
                    
                    <Fields>
                        <asp:BoundField ItemStyle-Width="300px" DataField="TaxPayerID" HeaderText="TaxPayerID" ReadOnly="True" SortExpression="TaxPayerID"/>
                        <asp:BoundField DataField="TaxPayerLastName" HeaderText="TaxPayerLastName" SortExpression="TaxPayerLastName" />
                        <asp:BoundField DataField="TaxPayerFirstName" HeaderText="TaxPayerFirstName" SortExpression="TaxPayerFirstName" />
                        <asp:BoundField DataField="TaxPayerInitial" HeaderText="TaxPayerInitial" SortExpression="TaxPayerInitial" />
                        <asp:BoundField DataField="TaxPayerAddress" HeaderText="TaxPayerAddress" SortExpression="TaxPayerAddress" />
                        <asp:BoundField DataField="TaxPayerCity" HeaderText="TaxPayerCity" SortExpression="TaxPayerCity" />
                        <asp:BoundField DataField="TaxPayerState" HeaderText="TaxPayerState" SortExpression="TaxPayerState" />
                        <asp:BoundField DataField="TaxPayerZip" HeaderText="TaxPayerZip" SortExpression="TaxPayerZip" />
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
            <div class="col-md-3">
                <asp:TextBox ID="txtTaxYear" runat="server"></asp:TextBox>
                <asp:RegularExpressionValidator ID="revTaxYear" runat="server" ErrorMessage="* Invalid Year" ControlToValidate="txtTaxYear" ValidationExpression="\d{4}" style="color: red; display: block;"></asp:RegularExpressionValidator>
                <asp:RangeValidator ID="rvTaxYear" runat="server" ErrorMessage="* Invalid Year" ControlToValidate="txtTaxYear" Type="Integer" MaximumValue="9999" MinimumValue="2007" style="color: red; position:relative; display:block; top:-20px;"></asp:RangeValidator>
                <asp:RequiredFieldValidator ID="rfvTaxYear" runat="server" ErrorMessage="* Required" ControlToValidate="txtTaxYear" style="color: red; position:relative; display:block; top:-40px;"></asp:RequiredFieldValidator>
            </div>
        </div>

        <div class="row" style="border-bottom: thin solid; width: 100%; padding: 15px; margin:0;">
            <asp:Button ID="btnViewTaxReturn" runat="server" Text="View Tax Return >>" />
        </div>
    </div>
    





</asp:Content>
