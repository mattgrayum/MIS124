
Public Class _Default
    Inherits Page

    '*******************************************************************************************************************
    'ACTION ON PAGE LOAD
    '*******************************************************************************************************************
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load

        lblMessages.Text = ""

        If Not Session("stock") Is Nothing Then

            Dim myDowStock As clsDowStock = Session("stock")

            Dim myBarChartSeries1 As New AjaxControlToolkit.BarChartSeries
            myBarChartSeries1.Name = "Market Average P/E"
            myBarChartSeries1.Data = {17}
            stockBarChart.Series.Add(myBarChartSeries1)

            Dim myBarChartSeries2 As New AjaxControlToolkit.BarChartSeries
            myBarChartSeries2.Name = myDowStock.StockName & " P/E"
            myBarChartSeries2.Data = {FormatCurrency(myDowStock.Dividend, 2)}
            stockBarChart.Series.Add(myBarChartSeries2)

        End If

    End Sub

    '*******************************************************************************************************************
    'ACTION ON FIND BUTTON CLICK
    '*******************************************************************************************************************
    Protected Sub btnFind_Click(sender As Object, e As EventArgs) Handles btnFind.Click

        Try
            Dim myDowStock As clsDowStock = clsDowStockDB.getDowStock(txtStockTicker.Text)
            txtStockName.Text = myDowStock.StockName
            txtPE.Text = myDowStock.Dividend

            Session("stock") = myDowStock

        Catch ex As Exception
            lblMessages.Text = ex.Message
        End Try


    End Sub

    '*******************************************************************************************************************
    'ACTION ON EMAIL OK BUTTON CLICK
    '*******************************************************************************************************************
    Protected Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click

        If Not Session("stock") Is Nothing Then
            ' Compose the email and send it
            Dim myMailServer As String = "smtp.saclink.csus.edu"
            Dim emailBody As String = "The Stock P/E for " & txtStockName.Text & " is " & txtPE.Text
            Dim objMyMailMessage As New System.Net.Mail.MailMessage("mattgrayum@gmail.com", txtEmail.Text, "Stock P/E Information", emailBody)
            Dim objMyWebServer As New System.Net.Mail.SmtpClient(myMailServer)
            objMyWebServer.Send(objMyMailMessage)
            lblMessages.Text = "Mail was sent"
        Else
            ' Hide the popup window and display an error message
            ModalPopupExtender1.Hide()
            lblMessages.Text = "You haven't selected a stock yet. Enter a stock ticker symbol, click Find, and then email yourself the results."
        End If

    End Sub
End Class