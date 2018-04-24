Imports BMICalculator

Public Class Result
    Inherits System.Web.UI.Page

    Private objMyBMI As clsBMI = Nothing
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Session.Count = 0 Then
            Response.Redirect("Default.aspx")
        Else
            Try
                'Alternate way of Session use
                'Dim objMyBMI As clsBMI = CType(Session("myBMI"), clsBMI)
                objMyBMI = Session("myBMI")
                lblName.Text = objMyBMI.UserName
                lblWeight.Text = objMyBMI.Weight
                lblHeight.Text = objMyBMI.Height
                lblBMI.Text = objMyBMI.BMI

                lblCategory.Text = clsBMI.getRating(objMyBMI.BMI)
            Catch ex As Exception
                Me.lblErrorMessages.Text = ex.Message
            End Try

        End If

    End Sub

    Protected Sub btnEmailResults_Click(sender As Object, e As EventArgs) Handles btnEmailResults.Click
        'write your e-mail implementation here

    End Sub

    Protected Sub btnGoBack_Click(sender As Object, e As EventArgs) Handles btnGoBack.Click
        Response.Redirect("Default.aspx")
    End Sub

    'Sends out an e-mail message
    Private Sub mailBMI()
        Try
            Dim myMailServer As String = "smtp.saclink.csus.edu"
            Dim objMyMailMessage As New System.Net.Mail.MailMessage(lblName.Text, lblName.Text, "BMI Results", "Your BMI is " & objMyBMI.BMI)
            Dim objMyWebServer As New System.Net.Mail.SmtpClient(myMailServer)
            objMyWebServer.Send(objMyMailMessage)
            lblErrorMessages.Text = "Mail was sent"
        Catch ex As Exception
            lblErrorMessages.Text = ex.Message()
        End Try
    End Sub


End Class