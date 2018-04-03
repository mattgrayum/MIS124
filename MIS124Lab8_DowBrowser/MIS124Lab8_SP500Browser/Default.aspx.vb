Public Class _Default
    Inherits Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnFind_Click(sender As Object, e As EventArgs) Handles btnFind.Click
        'Write the implementation below

    End Sub

    Protected Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        'Write the implementation below

    End Sub

    Private Sub processFind()
        Try
            Dim myDowStock As clsDowStock = clsDowStockDB.getDowStock(txtStockTicker.Text)
            txtStockName.Text = myDowStock.StockName
            txtDividendPerShare.Text = myDowStock.Dividend
        Catch ex As Exception
            Me.lblMessages.Text = ex.Message
        End Try
    End Sub

    Private Sub processUpdate()
        Try
            Dim myDowStock As New clsDowStock(txtStockTicker.Text.Trim, txtStockName.Text.Trim, CDbl(txtDividendPerShare.Text))
            Dim intUpdateStatementResults As Integer = clsDowStockDB.updateStock(myDowStock)
            If intUpdateStatementResults = 0 Then
                Me.lblMessages.Text = "Update Failed....."
            End If
        Catch ex As Exception
            Me.lblMessages.Text = ex.Message
        End Try
    End Sub

End Class