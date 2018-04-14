Imports System.Windows
Partial Class DisplayTaxReturn

    Inherits System.Web.UI.Page

    '*******************************************************************************************************************
    'ACTION ON PAGE LOAD
    '*******************************************************************************************************************
    Sub Page_Load(ByVal Sender As Object, ByVal E As EventArgs) Handles MyBase.Load

        Try
            If Not IsPostBack Then

                Dim taxPayer As clsTaxPayer = Session("taxPayer")
                Dim taxReturn As clsTaxReturn = Session("taxReturn")

                'Populate tax payer form controls 
                lblTaxPayerID.Text = taxPayer.TaxPayerID.ToString
                lblTaxYear.Text = Session("taxYear")
                txtFirstName.Text = taxPayer.FirstName
                txtLastName.Text = taxPayer.LastName
                txtState.Text = taxPayer.State
                txtCity.Text = taxPayer.City
                txtMI.Text = taxPayer.MidInitial
                txtZipCode.Text = taxPayer.Zip

                'Hide the Joint Tax Payer form if this is a new tax return or an 
                'existing 'Individual' tax return
                'If taxReturn Is Nothing Or Not taxReturn.IsJointReturn Then

                '    jointTaxPayerForm.Visible = False

                'End If



                'Only make the 'Update' button visible if the tax return exists in the database
                btnUpdate.Visible = False
                btnInsert.Visible = True
                If clsTaxPayerDB.isTaxReturn(taxReturn.TaxPayerID, taxReturn.Year) Then
                    btnUpdate.Visible = True
                    btnInsert.Visible = False
                End If


                'Populate the tax return form controls
                lstIndividualOrJoint.SelectedIndex = 0
                    jointTaxPayerForm.Visible = False
                    If taxReturn.IsJointReturn Then
                        setupJointReturnForm(taxPayer)
                    End If

                    txtWages.Text = taxReturn.Wages.ToString("0.00")
                    txtInterest.Text = taxReturn.TaxableInterest.ToString("0.00")
                    txtUnemployment.Text = taxReturn.UnemploymentCompensation.ToString("0.00")

                    If taxReturn.DependentStatus(0) = "1" Then
                        chkYou.Checked = True
                    End If
                    If taxReturn.DependentStatus(1) = "1" Then
                        chkSpouse.Checked = True
                    End If

                    txtWithholding.Text = taxReturn.IncomeTaxWithheld.ToString("0.00")
                    txtEarnedIncome.Text = taxReturn.EIC.ToString("0.00")
                    txtNontaxable.Text = taxReturn.CompatPay.ToString("0.00")

            End If

        Catch ex As Exception
            showErrorMessage(lblMessage, pnlMessage, ex)
        End Try

    End Sub

    '*******************************************************************************************************************
    'ACTION ON CALCULATE BUTTON CLICK
    '*******************************************************************************************************************
    Protected Sub btnCalculate_Click(sender As Object, e As EventArgs) Handles btnCalculate.Click

        ' Redirect to the Result Page
        Response.Redirect(url:="~/Result.aspx", endResponse:=False)

    End Sub

    '*******************************************************************************************************************
    'ACTION ON BACK BUTTON CLICK
    '*******************************************************************************************************************
    Protected Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click

        ' Redirect back to the Default Page
        Response.Redirect(url:="~/Default.aspx", endResponse:=False)

    End Sub

    '*******************************************************************************************************************
    'ACTION ON UPDATE TAX RETURN BUTTON CLICK
    '*******************************************************************************************************************
    Protected Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click

        Try
            Dim taxReturn As clsTaxReturn = CollectTaxReturnDataFromPage()

            If taxReturn Is Nothing Then
                Exit Sub
            Else
                Dim updatedRows As Integer = clsTaxPayerDB.updateTaxReturn(taxReturn)
                Session("taxReturn") = clsTaxPayerDB.getTaxReturn(Session("taxPayerID"), Session("taxYear"))
                If updatedRows > 0 Then
                    showSuccessMessage(lblMessage, pnlMessage, "The database was successfully updated.")
                End If
            End If

        Catch ex As Exception
            showErrorMessage(lblMessage, pnlMessage, ex)
        End Try

    End Sub

    '*******************************************************************************************************************
    'ACTION ON TAX RETURN INSERT BUTTON CLICK
    '*******************************************************************************************************************
    Protected Sub btnInsert_Click(sender As Object, e As EventArgs) Handles btnInsert.Click

        Try
            Dim taxReturn As clsTaxReturn = CollectTaxReturnDataFromPage()

            If taxReturn Is Nothing Then
                Exit Sub
            Else
                Dim insertedRows As Integer = clsTaxPayerDB.insertTaxReturn(CollectTaxReturnDataFromPage())
                Session("taxReturn") = clsTaxPayerDB.getTaxReturn(Session("taxPayerID"), Session("Year"))
                If insertedRows > 0 Then
                    showSuccessMessage(lblMessage, pnlMessage, "Your tax return was successfully added to the database.")
                End If
            End If

        Catch ex As Exception
            showErrorMessage(lblMessage, pnlMessage, ex)
        End Try

    End Sub
    '*******************************************************************************************************************
    ' Method CollectTaxReturnDataFromPage
    '   This function collects the data from the tax return form controls intstantiates a
    '   tax return object with it.
    ' Returns:
    '   clsTaxReturn
    ' Parameters:
    '   None
    '*******************************************************************************************************************
    Public Function CollectTaxReturnDataFromPage() As clsTaxReturn

        Try
            'Set up joint return status
            Dim isJointReturn As Boolean = False
            If lstIndividualOrJoint.SelectedIndex = 1 Then
                isJointReturn = True
            End If

            'Set up dependent status
            Dim dependentStatus As Char() = {"0", "0"}
            If chkYou.Checked = True Then
                dependentStatus(0) = "1"
            End If
            If chkSpouse.Checked = True Then
                dependentStatus(1) = "1"
            End If

            Return New clsTaxReturn(Int(lblTaxPayerID.Text), lblTaxYear.Text, isJointReturn, CType(txtWages.Text, Decimal),
                                    CType(txtInterest.Text, Decimal), CType(txtUnemployment.Text, Decimal), dependentStatus,
                                    CType(txtWithholding.Text, Decimal), CType(txtEarnedIncome.Text, Decimal),
                                    CType(txtNontaxable.Text, Decimal))

        Catch ex As Exception
            showErrorMessage(lblMessage, pnlMessage, ex)
        End Try

    End Function

    '*******************************************************************************************************************
    'ACTION ON ADD SPOUSE BUTTON CLICK
    '*******************************************************************************************************************
    Protected Sub btnAddSpouse_Click(sender As Object, e As EventArgs) Handles btnAddSpouse.Click

        Try
            Dim addedRows As Integer = clsTaxPayerDB.insertJointTaxPayer(CollectJointTaxPayerDataFromPage())

            If addedRows > 0 Then
                showSuccessMessage(lblMessage, pnlMessage, "Your tax return was successfully added to the database.")
            End If

        Catch ex As Exception
            showErrorMessage(lblMessage, pnlMessage, ex)
        End Try

    End Sub

    '*******************************************************************************************************************
    'ACTION ON UPDATE SPOUSE BUTTON CLICK
    '*******************************************************************************************************************
    Protected Sub btnUpdateSpouse_Click(sender As Object, e As EventArgs) Handles btnUpdateSpouse.Click

        Dim updatedRows As Integer = clsTaxPayerDB.updateJointTaxPayer(CollectJointTaxPayerDataFromPage())

        If updatedRows > 0 Then
            showSuccessMessage(lblMessage, pnlMessage, "Your joint tax payer was successfully added to the database.")
        End If

    End Sub

    '*******************************************************************************************************************
    ' Method CollectJointTaxPayerDataFromPage
    '   This function collects the data from the joint tax payer form controls and builds a 
    '   jointTaxPayer structure with it.
    ' Returns:
    '   jointTaxPayer
    ' Parameters:
    '   None
    '*******************************************************************************************************************
    Public Function CollectJointTaxPayerDataFromPage() As JointTaxPayer

        Try
            Dim jointTaxPayer As JointTaxPayer
            jointTaxPayer.lastName = txtSpouseLastName.Text
            jointTaxPayer.firstName = txtSpouseFirstName.Text
            jointTaxPayer.middleInitial = txtSpouseInitial.Text
            jointTaxPayer.taxPayerID = Int(lblTaxPayerID.Text)
            Return jointTaxPayer

        Catch ex As Exception
            showErrorMessage(lblMessage, pnlMessage, ex)
        End Try

    End Function

    '*******************************************************************************************************************
    'ACTION ON lstIndividualOrJoint SELECTED INDEX CHANGE
    '*******************************************************************************************************************
    Protected Sub lstIndividualOrJoint_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstIndividualOrJoint.SelectedIndexChanged

        Try
            If lstIndividualOrJoint.SelectedIndex = 1 Then
                setupJointReturnForm(Session("taxPayer"))
            Else
                jointTaxPayerForm.Visible = False
            End If

        Catch ex As Exception
            showErrorMessage(lblMessage, pnlMessage, ex)
        End Try

    End Sub

    '*******************************************************************************************************************
    ' Method setupJointReturnForm
    '   This method sets up the joint tax payer form
    ' Returns:
    '   Nothing
    ' Parameters:
    '   taxPayer as clsTaxPayer
    '*******************************************************************************************************************
    Public Sub setupJointReturnForm(ByRef taxPayer As clsTaxPayer)

        Try
            Dim jointTaxPayer As JointTaxPayer = taxPayer.getJointTaxPayer()

            'Make sure that the tax return is set to 'joint' if we are showing this form
            lstIndividualOrJoint.SelectedIndex = 1

            'Make the joint tax payer form visible
            jointTaxPayerForm.Visible = True

            'If the tax return is a joint one, and a joint tax payer exists in the database, show the 'Update' button only.
            btnAddSpouse.Visible = False
            btnUpdateSpouse.Visible = True

            'If the tax return is a joint one, and there is no joint tax payer in the databse, only show the 'Add' button
            If jointTaxPayer.taxPayerID = 0 Then
                btnAddSpouse.Visible = True
                btnUpdateSpouse.Visible = False
            End If

            'Populate the form controls
            txtSpouseLastName.Text = jointTaxPayer.lastName
            txtSpouseFirstName.Text = jointTaxPayer.firstName
            txtSpouseInitial.Text = jointTaxPayer.middleInitial

        Catch ex As Exception
            showErrorMessage(lblMessage, pnlMessage, ex)
        End Try

    End Sub

    '*******************************************************************************************************************
    '  Method showSuccessMessage
    '   This method displays an exception message in a panel with a red background
    '   and white text. 
    ' Returns:
    '   Nothing
    ' Parameters:
    '   lbl as Label
    '   pnl as Panel
    '   ex as Exception
    '*******************************************************************************************************************
    Public Sub showErrorMessage(ByRef lbl As Label, ByRef pnl As Panel, ByRef ex As Exception)

        lblMessage.Text = ex.Message
        pnlMessage.Attributes.Add("style", "background:red; color:white; display: block; padding: 10px; text-align: center;")

    End Sub

    '*******************************************************************************************************************
    ' Method showSuccessMessage
    '   This method displays a success message in a panel with a green background
    '   and white text. The message that is passed will be displayed in the panel.
    ' Returns:
    '   Nothing
    ' Parameters:
    '   lbl as Label
    '   pnl as Panel
    '   msg as String
    '*******************************************************************************************************************
    Public Sub showSuccessMessage(ByRef lbl As Label, ByRef pnl As Panel, ByVal msg As String)

        lbl.Text = "SUCCESS!! " & msg
        pnl.Attributes.Add("style", "background:green; color:white; padding: 10px; text-align: center;")

    End Sub

End Class
