Imports BMICalculator

Public Class _Default
    Inherits Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        processPageLoad()
    End Sub

    Protected Sub btnCalculate_Click(sender As Object, e As EventArgs) Handles btnCalculate.Click
        processCalculate()
    End Sub

    Private Sub processCalculate()
        Try
            Dim myCookie As New HttpCookie("UserName", txtName.Text)
            myCookie.Expires = DateTime.MaxValue
            Response.Cookies.Add(myCookie)

            Response.Redirect("Result.aspx?name=" & txtName.Text & "&weight=" & txtWeight.Text & "&height=" & txtHeight.Text)
        Catch ex As Exception
            lblErrorMessages.Text = ex.Message
        End Try
    End Sub

    Private Sub processPageLoad()
        If Not IsPostBack Then
            Dim myCookie As HttpCookie = Request.Cookies("UserName")
            If myCookie IsNot Nothing Then
                txtName.Text = myCookie.Value
            End If
        End If
    End Sub
End Class