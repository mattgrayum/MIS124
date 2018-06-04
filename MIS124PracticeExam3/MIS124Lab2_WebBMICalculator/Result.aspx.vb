Imports BMICalculator

Public Class Result
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        processPageLoad()
    End Sub

    Protected Sub btnGoBack_Click(sender As Object, e As EventArgs) Handles btnGoBack.Click
        Response.Redirect("Default.aspx")
    End Sub

    Private Sub processPageLoad()
        Try
            If Request.QueryString("name") = Nothing _
                        Or Request.QueryString("weight") = Nothing _
                        Or Request.QueryString("height") = Nothing Then 'if no query strings are passed
                Response.Redirect("Default.aspx") 'go to the default page first
            Else
                Dim strName As String = Request.QueryString("name") 'retrieve each query string
                Dim intWeight As Integer = Request.QueryString("weight")
                Dim intHeight As Integer = Request.QueryString("height")

                Dim objMyBMI As clsBMI = New clsBMI(strName, intHeight, intWeight) 'build the clsBMI object

                lblName.Text = objMyBMI.UserName '  the clsBMI object's properties
                lblWeight.Text = objMyBMI.Weight
                lblHeight.Text = objMyBMI.Height
                lblBMI.Text = FormatNumber(objMyBMI.BMI)

                lblCategory.Text = clsBMI.getRating(objMyBMI.BMI) 'call the class shared method to get the BMI rating

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ' Instantiate a new BarChartSeries object
                Dim myBarChartSeries1 As New AjaxControlToolkit.BarChartSeries

                ' Give the Series a name
                myBarChartSeries1.Name = "National Average"

                ' Give the Series a value
                myBarChartSeries1.Data = {27}

                ' Add the Series to the BarChart that has already been added to the page
                BarChart1.Series.Add(myBarChartSeries1)
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Dim myBarChartSeries2 As New AjaxControlToolkit.BarChartSeries
                myBarChartSeries2.Name = "Your BMI"
                myBarChartSeries2.Data = {FormatNumber(objMyBMI.BMI, 2)}
                BarChart1.Series.Add(myBarChartSeries2)
            End If

        Catch ex As Exception
            Me.lblErrorMessages.Text = ex.Message
        End Try
    End Sub

    Protected Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click
        Dim myMailServer As String = "smtp.saclink.csus.edu"
        Dim emailBody As String = "Your BMI is " & lblBMI.Text
        Dim objMyMailMessage As New System.Net.Mail.MailMessage("mattgrayum@gmail.com", txtEmail.Text, "Tax Return Information", emailBody)
        objMyMailMessage.IsBodyHtml = True
        Dim objMyWebServer As New System.Net.Mail.SmtpClient(myMailServer)
        objMyWebServer.Send(objMyMailMessage)
        lblErrorMessages.Text = "Mail was sent"
    End Sub


End Class