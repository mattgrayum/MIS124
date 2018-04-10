Imports System.Windows
Partial Class DisplayTaxReturn
    Inherits System.Web.UI.Page

    Sub Page_Load(ByVal Sender As Object, ByVal E As EventArgs) Handles MyBase.Load
        If Not IsPostBack Then
            Dim taxPayer As clsTaxPayer = Session("taxPayer")
            Dim taxReturn As clsTaxReturn = Session("taxReturn")

            lblTaxPayerID.Text = taxPayer.TaxPayerID.ToString
            txtFirstName.Text = taxPayer.FirstName
            txtLastName.Text = taxPayer.LastName
            txtState.Text = taxPayer.State
            txtCity.Text = taxPayer.City
            txtMI.Text = taxPayer.MidInitial
            txtZipCode.Text = taxPayer.Zip

            If taxReturn Is Nothing Then
                lblTaxYear.Text = Session("taxYear")
                MsgBox("A tax return does not exist for this tax payer and this year." & vbCrLf &
                       "Please enter the tax return information in the spaces provided here and click 'Insert'.")

            Else
                lblTaxYear.Text = taxReturn.Year
                lstIndividualOrJoint.SelectedIndex = 0
                If taxReturn.IsJointReturn Then
                    lstIndividualOrJoint.SelectedIndex = 1
                    jointTaxPayerName.Attributes.Add("style", "display: block")
                    Dim jointTaxPayer As JointTaxPayer = taxPayer.getJointTaxPayer()
                    txtSpouseLastName.Text = jointTaxPayer.lastName
                    txtSpouseFirstName.Text = jointTaxPayer.firstName
                    txtSpouseInitial.Text = jointTaxPayer.middleInitial
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

        Dim updatedRows As Integer = clsTaxPayerDB.updateTaxReturn(CollectTaxReturnDataFromPage())

        If updatedRows > 0 Then
            lblMessage.Text = "The database was successfully updated with a return value of " & updatedRows
        End If

    End Sub
    Protected Sub btnInsert_Click(sender As Object, e As EventArgs) Handles btnInsert.Click
        Dim insertedRows As Integer = clsTaxPayerDB.insertTaxReturn(CollectTaxReturnDataFromPage())

        If insertedRows > 0 Then
            lblMessage.Text = "Your tax return was successfully added to the database with a return value of " & insertedRows
        End If
    End Sub

    Public Function CollectTaxReturnDataFromPage() As clsTaxReturn
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


        Return New clsTaxReturn(Int(lblTaxPayerID.Text), lblTaxYear.Text, isJointReturn, CType(txtWages.Text, Decimal),
                                CType(txtInterest.Text, Decimal), CType(txtUnemployment.Text, Decimal), dependentStatus,
                                CType(txtWithholding.Text, Decimal), CType(txtEarnedIncome.Text, Decimal),
                                CType(txtNontaxable.Text, Decimal))
    End Function
End Class
