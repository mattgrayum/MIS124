<%@ Page Title="Home Page" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Default.aspx.vb" Inherits="_Default"%>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

        <div style="color: #5c5536; text-align: center; margin-bottom: 10px; padding: 10px; width: 100%">
                <h2>2017 Tax Return 1040EZ Version 2.0 - Main Page</h2>
        </div>
    <asp:Panel ID="pnlMessage" runat="server" style="display: none;">
        <asp:Label ID="lblMessage" runat="server"></asp:Label>
    </asp:Panel>
     <div style="color: #5c5536; background-color: #d0c697;">
        <div class="row" style="color: white; background-color: #497a63; border-bottom: thin solid;  border-top: thin solid black;width: 100%; padding: 15px; margin:0; font-weight: 700; font-size: 16px">
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
                    style="font-size: 20px;">
                    
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:TaxReturn2014_Rodger %>" SelectCommand="SELECT [TaxPayerID], [TaxPayerLastName] FROM [tblTaxPayer]"></asp:SqlDataSource>
            </div>
            <div class="col-md-6">
                <asp:DetailsView ID="dtlTaxPayer" runat="server" 
                    Height="50px" 
                    AutoGenerateRows="False" 
                    DataKeyNames="TaxPayerID" 
                    DataSourceID="SqlDataSource2"
                    cellpadding="8"
                    style="width: 100%; margin: auto; background-color: #f6f2db; font-size: 20px;">
                    
                    <Fields>
                        <asp:BoundField ItemStyle-Width="300px" DataField="TaxPayerID" HeaderText="ID Number" ReadOnly="True" SortExpression="TaxPayerID">
                            
                        </asp:BoundField>
                        <asp:BoundField DataField="TaxPayerLastName" HeaderText="Last Name" SortExpression="TaxPayerLastName" />
                        <asp:BoundField DataField="TaxPayerFirstName" HeaderText="First Name" SortExpression="TaxPayerFirstName" />
                        <asp:TemplateField HeaderText="Middle Initial" SortExpression="TaxPayerInitial">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtEditTaxPayerInitial" runat="server" Text='<%# Bind("TaxPayerInitial") %>' MaxLength="1"></asp:TextBox>
                            </EditItemTemplate>
                            <InsertItemTemplate>
                                <asp:TextBox ID="txtInsertTaxPayerInitial" runat="server" Text='<%# Bind("TaxPayerInitial") %>'></asp:TextBox>
                            </InsertItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("TaxPayerInitial") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="TaxPayerAddress" HeaderText="Street Address" SortExpression="TaxPayerAddress" />
                        <asp:BoundField DataField="TaxPayerCity" HeaderText="City" SortExpression="TaxPayerCity" />
                        <asp:TemplateField HeaderText="State" SortExpression="TaxPayerState">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtEditState" runat="server" Text='<%# Bind("TaxPayerState") %>'></asp:TextBox>
                                <asp:CustomValidator ID="cvState" runat="server" 
                                    ErrorMessage="* Invalid State"
                                    ControlToValidate="txtEditState"  
                                    ValidationGroup="myValidationGroup"
                                    style="display:block;color:red;" 
                                    OnServerValidate="ValidateStateName">

                                </asp:CustomValidator>
                            </EditItemTemplate>
                            <InsertItemTemplate>
                                <asp:TextBox ID="txtInsertState" runat="server" Text='<%# Bind("TaxPayerState") %>'></asp:TextBox>
                            </InsertItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label3" runat="server" Text='<%# Bind("TaxPayerState") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Zip Code" SortExpression="TaxPayerZip">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtEditZipCode" runat="server" Text='<%# Bind("TaxPayerZip") %>'></asp:TextBox>
                                <asp:RegularExpressionValidator ID="revZipCode" runat="server" 
                                    ErrorMessage="* Invalid Zip Code" 
                                    ControlToValidate="txtEditZipCode" 
                                    ValidationExpression="(\d{5})([\-]\d{4})?\s*" 
                                    ValidationGroup="myValidationGroup"
                                    style="display:block;color:red;">
                                </asp:RegularExpressionValidator>
                            </EditItemTemplate>
                            <InsertItemTemplate>
                                <asp:TextBox ID="txtInsertZipCode" runat="server" Text='<%# Bind("TaxPayerZip") %>'></asp:TextBox>
                            </InsertItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("TaxPayerZip") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Button runat="server" Text="Edit" CommandName="Edit" style="width: 100px;"/>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:Button runat="server" Text="Update" CommandName="Update" ValidationGroup="myValidationGroup" style="width: 100px;"/>
                                <asp:Button runat="server" Text="Cancel" CommandName="Cancel" style="width: 100px; float: right;"/>
                            </EditItemTemplate>
                        </asp:TemplateField>
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
                <asp:DropDownList ID="lstTaxYear" runat="server" style="width: 100px; font-size: 20px;"></asp:DropDownList>
            </div>
        </div>

        <div class="row" style="border-bottom: thin solid; width: 100%; padding: 15px; margin:0;  font-size: 20px;">
            <div style="float: right;">
                <asp:Button ID="btnViewTaxReturn" runat="server" Text="View Tax Return >>" />
            </div>
        </div>
    </div>
    <div id="noTaxReturnMsg" runat="server" style="text-align:center; background-color: #497a63; color: white; width: 100%; margin: auto; height: 500px; padding: 30px; box-shadow: 5px 10px 8px 10px #888888; position: relative; top: -500px;">
        <p style="margin: 40px 0; font-size: 40px;">We couldn't find that tax return.</p>
        <p style="font-size: 30px; margin-bottom: 30px;">Click Ok to enter a new tax return or go back to the Home page.</p>
        <asp:Button ID="btnModalBack" runat="server" Text="<< Back" style="display:inline-block; margin: 30px; font-size: 30px; padding: 0 40px;"/>
        <asp:Button ID="btnModalOk" runat="server" Text="Ok >>" style="display:inline-block;margin: 30px; font-size: 30px; padding: 0 40px;"/>
    </div>
</asp:Content>
