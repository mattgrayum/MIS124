Imports System.Windows
Partial Class DisplayTaxReturn

    Inherits System.Web.UI.Page

    '*******************************************************************************************************************
    'ACTION ON PAGE LOAD
    '*******************************************************************************************************************
    Sub Page_Load(ByVal Sender As Object, ByVal E As EventArgs) Handles MyBase.Load

        'Try
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

                If taxReturn.DependentStatus(0) = "1" Then
                    chkYou.Checked = True
                End If
                If taxReturn.DependentStatus(1) = "1" Then
                    chkSpouse.Checked = True
                End If

                txtWages.Text = taxReturn.Wages.ToString("0.00")
                txtInterest.Text = taxReturn.TaxableInterest.ToString("0.00")
                txtUnemployment.Text = taxReturn.UnemploymentCompensation.ToString("0.00")
                txtWithholding.Text = taxReturn.IncomeTaxWithheld.ToString("0.00")
                txtEarnedIncome.Text = taxReturn.EIC.ToString("0.00")
                txtNontaxable.Text = taxReturn.CompatPay.ToString("0.00")

            End If

        'Catch ex As Exception
        '    Utlilties.showErrorMessage(lblMessage, pnlMessage, ex)
        'End Try

    End Sub

    '*******************************************************************************************************************
    'ACTION ON CLEAR BUTTON CLICK
    '*******************************************************************************************************************
    Protected Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click

        'Set Individual/Joint dropdown to Individual, hide Joint Tax Payer form, and clear all other controls
        lstIndividualOrJoint.SelectedIndex = 0
        jointTaxPayerForm.Visible = False
        txtWages.Text = ""
        txtInterest.Text = ""
        txtUnemployment.Text = ""
        txtWithholding.Text = ""
        txtEarnedIncome.Text = ""
        txtNontaxable.Text = ""
        chkYou.Checked = False
        chkSpouse.Checked = False

    End Sub

    '*******************************************************************************************************************
    'ACTION ON CALCULATE BUTTON CLICK
    '*******************************************************************************************************************
    Protected Sub btnCalculate_Click(sender As Object, e As EventArgs) Handles btnCalculate.Click

        Try
            Session("taxReturn") = CollectTaxReturnDataFromPage()

            If Session("taxReturn") Is Nothing Then
                Exit Sub
            Else
                'If the record exists, update it - otherwise insert a new record
                If clsTaxPayerDB.updateTaxReturn(Session("taxReturn")) = 0 Then
                    Dim updatedRows = clsTaxPayerDB.insertTaxReturn(Session("taxReturn"))
                End If
            End If

            ' Redirect to the Result Page
            Response.Redirect(url:="~/Result.aspx", endResponse:=False)

        Catch ex As Exception
            Utlilties.showErrorMessage(lblMessage, pnlMessage, ex)
        End Try

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
            DatabaseUpdate("update", "DB001")
        Catch ex As Exception
            Utlilties.showErrorMessage(lblMessage, pnlMessage, ex)
        End Try

    End Sub

    '*******************************************************************************************************************
    'ACTION ON TAX RETURN INSERT BUTTON CLICK
    '*******************************************************************************************************************
    Protected Sub btnInsert_Click(sender As Object, e As EventArgs) Handles btnInsert.Click

        Try
            DatabaseUpdate("insert", "DB002")
        Catch ex As Exception
            Utlilties.showErrorMessage(lblMessage, pnlMessage, ex)
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
            Utlilties.showErrorMessage(lblMessage, pnlMessage, ex)
        End Try

    End Function

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
            Utlilties.showErrorMessage(lblMessage, pnlMessage, ex)
        End Try

    End Function

    '*******************************************************************************************************************
    ' Method CollectTaxPayerDataFromPage
    '   This function collects the data from the tax payer form controls intstantiates a
    '   tax payer object with it.
    ' Returns:
    '   clsTaxPayer
    ' Parameters:
    '   None
    '*******************************************************************************************************************
    Public Function CollectTaxPayerDataFromPage() As clsTaxPayer

        Try
            Dim oldTaxPayer As clsTaxPayer = Session("taxPayer")
            Return New clsTaxPayer(Int(lblTaxPayerID.Text), txtLastName.Text, txtFirstName.Text, txtMI.Text, oldTaxPayer.Address, txtCity.Text, txtState.Text, txtZipCode.Text)

        Catch ex As Exception
            Utlilties.showErrorMessage(lblMessage, pnlMessage, ex)
        End Try

    End Function

    '*******************************************************************************************************************
    'ACTION ON ADD SPOUSE BUTTON CLICK
    '*******************************************************************************************************************
    Protected Sub btnAddSpouse_Click(sender As Object, e As EventArgs) Handles btnAddSpouse.Click

        Try
            Dim addedRows As Integer = clsTaxPayerDB.insertJointTaxPayer(CollectJointTaxPayerDataFromPage())

            If addedRows > 0 Then
                Utlilties.showSuccessMessage(lblMessage, pnlMessage, "Your Joint Tax Payer has been added to our records.")
            End If

        Catch ex As Exception
            Utlilties.showErrorMessage(lblMessage, pnlMessage, ex)
        End Try

    End Sub

    '*******************************************************************************************************************
    'ACTION ON UPDATE SPOUSE BUTTON CLICK
    '*******************************************************************************************************************
    Protected Sub btnUpdateSpouse_Click(sender As Object, e As EventArgs) Handles btnUpdateSpouse.Click

        Dim updatedRows As Integer = clsTaxPayerDB.updateJointTaxPayer(CollectJointTaxPayerDataFromPage())

        If updatedRows > 0 Then
            Utlilties.showSuccessMessage(lblMessage, pnlMessage, "Your Joint Tax Payer's information has been updated.")
        End If

    End Sub

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
            Utlilties.showErrorMessage(lblMessage, pnlMessage, ex)
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
            Utlilties.showErrorMessage(lblMessage, pnlMessage, ex)
        End Try

    End Sub

    Public Sub DatabaseUpdate(ByVal updateType As String, ByVal errorCode As String)

        Try
            'Collect the data from the page
            Dim taxReturn As clsTaxReturn = CollectTaxReturnDataFromPage()
            Dim taxPayer As clsTaxPayer = CollectTaxPayerDataFromPage()

            'Make sure these objects are set
            If taxReturn Is Nothing Or taxPayer Is Nothing Then
                Exit Sub
            Else
                'Update the database
                Dim updatedTaxReturnRows As Integer = 0
                If updateType = "update" Then
                    updatedTaxReturnRows = clsTaxPayerDB.updateTaxReturn(taxReturn)
                Else
                    updatedTaxReturnRows = clsTaxPayerDB.insertTaxReturn(taxReturn)
                End If

                Dim updatedTaxPayerRows As Integer = clsTaxPayerDB.updateTaxPayer(taxPayer)

                'Refresh Session variables with new Tax Return and Tax Payer data
                Session("taxReturn") = clsTaxPayerDB.getTaxReturn(Session("taxPayerID"), Session("Year"))
                Session("taxPayer") = clsTaxPayerDB.getTaxPayer(taxPayer.TaxPayerID)


                If updatedTaxReturnRows > 0 And updatedTaxPayerRows > 0 Then
                    Utlilties.showSuccessMessage(lblMessage, pnlMessage, "This Tax Return data has been saved to our records.")
                Else
                    Throw New Exception("ERROR " & errorCode & " - There was a problem saving this data. Contact the site administrator for assistance.")
                End If
            End If

        Catch ex As Exception
            Utlilties.showErrorMessage(lblMessage, pnlMessage, ex)
        End Try

    End Sub

End Class
