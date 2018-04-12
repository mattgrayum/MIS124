Imports System.Windows
Partial Class DisplayTaxReturn
    Inherits System.Web.UI.Page

    Sub Page_Load(ByVal Sender As Object, ByVal E As EventArgs) Handles MyBase.Load

        If Not IsPostBack Then
            Try
                Dim taxPayer As clsTaxPayer = Session("taxPayer")
                Dim taxReturn As clsTaxReturn = Session("taxReturn")

                lblTaxPayerID.Text = taxPayer.TaxPayerID.ToString
                txtFirstName.Text = taxPayer.FirstName
                txtLastName.Text = taxPayer.LastName
                txtState.Text = taxPayer.State
                txtCity.Text = taxPayer.City
                txtMI.Text = taxPayer.MidInitial
                txtZipCode.Text = taxPayer.Zip
                lblTaxYear.Text = Session("taxYear")

                If taxReturn Is Nothing Then
                    btnUpdate.Visible = False
                    btnInsert.Visible = True
                    lstIndividualOrJoint.SelectedIndex = 0
                    jointTaxPayerForm.Visible = False

                Else
                    btnUpdate.Visible = True
                    btnInsert.Visible = False
                    lstIndividualOrJoint.SelectedIndex = 0
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
                showErrorMessage(ex)
            End Try

        End If
    End Sub
    Protected Sub btnCalculate_Click(sender As Object, e As EventArgs) Handles btnCalculate.Click
        ' Redirect to the Result Page
        Response.Redirect(url:="~/Result.aspx", endResponse:=False)
    End Sub
    Protected Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        ' Redirect back to the Default Page
        Response.Redirect(url:="~/Default.aspx", endResponse:=False)
    End Sub
    Protected Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Try
            Dim taxReturn As clsTaxReturn = CollectTaxReturnDataFromPage()
            If taxReturn Is Nothing Then
                Exit Sub
            Else
                Dim updatedRows As Integer = clsTaxPayerDB.updateTaxReturn(taxReturn)
                If updatedRows > 0 Then
                    showSuccessMessage("The database was successfully updated with a return value of " & updatedRows)
                End If
            End If

        Catch ex As Exception
            showErrorMessage(ex)
        End Try
    End Sub
    Protected Sub btnInsert_Click(sender As Object, e As EventArgs) Handles btnInsert.Click
        Try
            Dim taxReturn As clsTaxReturn = CollectTaxReturnDataFromPage()
            If taxReturn Is Nothing Then
                Exit Sub
            Else
                Dim insertedRows As Integer = clsTaxPayerDB.insertTaxReturn(CollectTaxReturnDataFromPage())
                If insertedRows > 0 Then
                    showSuccessMessage("Your tax return was successfully added to the database with a return value of " & insertedRows)
                End If
            End If
        Catch ex As Exception
            showErrorMessage(ex)
        End Try

    End Sub

    Public Function CollectTaxReturnDataFromPage() As clsTaxReturn
        Try
            Dim isJointReturn As Boolean = False
            If lstIndividualOrJoint.SelectedIndex = 1 Then
                isJointReturn = True
            End If
            Dim dependentStatus As Char() = {"0", "0"}
            If chkYou.Checked = True Then
                dependentStatus(0) = "1"
            End If
            If chkSpouse.Checked = True Then
                dependentStatus(1) = "1"
            End If
            'If CType(txtWages.Text, Decimal) > 99999.99 Then
            '    Throw New Exception("You may not file a 1040EZ form if you earned wages of $100,000 or more.")
            '    Exit Function
            'End If

            Return New clsTaxReturn(Int(lblTaxPayerID.Text), lblTaxYear.Text, isJointReturn, CType(txtWages.Text, Decimal),
                                    CType(txtInterest.Text, Decimal), CType(txtUnemployment.Text, Decimal), dependentStatus,
                                    CType(txtWithholding.Text, Decimal), CType(txtEarnedIncome.Text, Decimal),
                                    CType(txtNontaxable.Text, Decimal))
        Catch ex As Exception
            showErrorMessage(ex)
        End Try

    End Function
    Protected Sub btnAddSpouse_Click(sender As Object, e As EventArgs) Handles btnAddSpouse.Click
        Try
            Dim addedRows As Integer = clsTaxPayerDB.insertJointTaxPayer(CollectJointTaxPayerDataFromPage())
            If addedRows > 0 Then
                showSuccessMessage("Your tax return was successfully added to the database with a return value of " & addedRows)
            End If
        Catch ex As Exception
            showErrorMessage(ex)
        End Try

    End Sub

    Protected Sub btnUpdateSpouse_Click(sender As Object, e As EventArgs) Handles btnUpdateSpouse.Click
        Dim updatedRows As Integer = clsTaxPayerDB.updateJointTaxPayer(CollectJointTaxPayerDataFromPage())
        If updatedRows > 0 Then
            showSuccessMessage("Your joint tax payer was successfully added to the database with a return value of " & updatedRows)
        End If
    End Sub
    Public Function CollectJointTaxPayerDataFromPage() As JointTaxPayer
        Try
            Dim jointTaxPayer As JointTaxPayer
            jointTaxPayer.lastName = txtSpouseLastName.Text
            jointTaxPayer.firstName = txtSpouseFirstName.Text
            jointTaxPayer.middleInitial = txtSpouseInitial.Text
            jointTaxPayer.taxPayerID = Int(lblTaxPayerID.Text)
            Return jointTaxPayer
        Catch ex As Exception
            showErrorMessage(ex)
        End Try

    End Function
    Protected Sub lstIndividualOrJoint_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstIndividualOrJoint.SelectedIndexChanged
        Try
            If lstIndividualOrJoint.SelectedIndex = 1 Then
                setupJointReturnForm(Session("taxPayer"))
            Else
                jointTaxPayerForm.Visible = False
            End If
        Catch ex As Exception
            showErrorMessage(ex)
        End Try

    End Sub

    Public Sub setupJointReturnForm(ByRef taxPayer As clsTaxPayer)
        Try
            lstIndividualOrJoint.SelectedIndex = 1
            jointTaxPayerForm.Visible = True
            Dim jointTaxPayer As JointTaxPayer = taxPayer.getJointTaxPayer()
            btnAddSpouse.Visible = False
            btnUpdateSpouse.Visible = True
            If jointTaxPayer.taxPayerID = 0 Then
                btnAddSpouse.Visible = True
                btnUpdateSpouse.Visible = False
            End If
            txtSpouseLastName.Text = jointTaxPayer.lastName
            txtSpouseFirstName.Text = jointTaxPayer.firstName
            txtSpouseInitial.Text = jointTaxPayer.middleInitial
        Catch ex As Exception
            showErrorMessage(ex)
        End Try


    End Sub

    Public Sub showErrorMessage(ByRef ex As Exception)
        lblMessage.Text = "** ERROR ** " & ex.Message
        pnlMessage.Attributes.Add("style", "background:red; color:white; display: block; padding: 10px; text-align: center;")
    End Sub
    Public Sub showSuccessMessage(ByVal msg As String)
        lblMessage.Text = "SUCCESS!! " & msg
        pnlMessage.Attributes.Add("style", "background:green; color:white; padding: 10px; text-align: center;")
    End Sub
End Class
