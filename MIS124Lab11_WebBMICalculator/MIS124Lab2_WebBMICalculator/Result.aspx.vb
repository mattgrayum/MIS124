'Imports BMICalculator

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
                lblEMail.Text = objMyBMI.UserName
                lblWeight.Text = objMyBMI.Weight
                lblHeight.Text = objMyBMI.Height
                lblBMI.Text = objMyBMI.BMI

                'Note add one bar series at a time
                lblCategory.Text = clsBMI.getRating(objMyBMI.BMI)
                Dim myBarChart As New AjaxControlToolkit.BarChartSeries
                myBarChart.Name = "You"
                myBarChart.Data = {objMyBMI.BMI} 'this an array of data and  thus the { }
                BarChart.Series.Add(myBarChart) 'add this bar series to the bar chart
            Catch ex As Exception
                Response.Redirect("error.aspx?error=" & ex.Message)
            End Try
        End If
    End Sub

    Protected Sub btnGoBack_Click(sender As Object, e As EventArgs) Handles btnGoBack.Click
        Response.Redirect("Default.aspx")
    End Sub

    'Sends out an e-mail message
    Private Sub mailBMI()
        Try
            Dim myMailServer As String = "smtp.saclink.csus.edu"
            Dim objMyMailMessage As New System.Net.Mail.MailMessage(lblEMail.Text, txtEMail.Text, "BMI Results", "Your BMI is " & objMyBMI.BMI)
            Dim objMyWebServer As New System.Net.Mail.SmtpClient(myMailServer)
            objMyWebServer.Send(objMyMailMessage)
            lblErrorMessages.Text = "Mail was sent"
        Catch ex As Exception
            lblErrorMessages.Text = ex.Message()
        End Try
    End Sub

    Protected Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click
        'e-mail logic will go here
        mailBMI()
        displayAlert("E-mail was sent")
    End Sub

    Private Sub displayAlert(ByVal strMessageToDisplay As String)
        System.Web.HttpContext.Current.Response.Write("<SCRIPT LANGUAGE=""JavaScript"">alert('" & strMessageToDisplay & "')</SCRIPT>")
    End Sub

    Protected Sub btnEmailResults_Click(sender As Object, e As EventArgs) Handles btnEmailResults.Click

    End Sub
End Class