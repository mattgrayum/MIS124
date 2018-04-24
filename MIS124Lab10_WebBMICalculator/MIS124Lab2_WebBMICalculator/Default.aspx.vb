Imports BMICalculator

Public Class _Default
    Inherits Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            If Session.Count > 0 Then
                Dim objMyBMI As clsBMI = Session("myBMI")
                txtName.Text = objMyBMI.UserName
                txtWeight.Text = objMyBMI.Weight
                txtHeight.Text = objMyBMI.Height
            End If
        End If
    End Sub

    Protected Sub btnCalculate_Click(sender As Object, e As EventArgs) Handles btnCalculate.Click
        Try
            Dim objMyBMI As New clsBMI(txtName.Text, CInt(txtHeight.Text), CInt(txtWeight.Text))

            Session.Add("myBMI", objMyBMI)
            Response.Redirect("Result.aspx")
        Catch ex As Exception
            lblErrorMessages.Text = ex.Message
        End Try

    End Sub
End Class