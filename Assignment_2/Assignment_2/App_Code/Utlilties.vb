Imports Microsoft.VisualBasic

Public Class Utlilties
    '*******************************************************************************************************************
    '  Method showErrorMessage
    '   This method displays an exception message in a panel with a red background
    '   and white text. 
    ' Returns:
    '   Nothing
    ' Parameters:
    '   lbl as Label
    '   pnl as Panel
    '   ex as Exception
    '*******************************************************************************************************************
    Public Shared Sub showErrorMessage(ByRef lbl As Label, ByRef pnl As Panel, ByRef ex As Exception)

        lbl.Text = ex.Message
        pnl.Attributes.Add("style", "background:#b20000; color:white; display: block; padding: 10px; text-align: center;")

    End Sub
    '*******************************************************************************************************************
    '  Method showErrorMessage
    '   This method displays an exception message in a panel with a red background
    '   and white text. 
    ' Returns:
    '   Nothing
    ' Parameters:
    '   lbl as Label
    '   pnl as Panel
    '*******************************************************************************************************************
    Public Shared Sub showErrorMessage(ByRef lbl As Label, ByRef pnl As Panel, ByVal errorMsg As String)

        lbl.Text = errorMsg
        pnl.Attributes.Add("style", "background:#b20000; color:white; display: block; padding: 10px; text-align: center;")

    End Sub

    '*******************************************************************************************************************
    ' Method showSuccessMessage
    '   This method displays a success message in a panel with a green background
    '   and white text. The message that is passed will be displayed in the panel.
    ' Returns:
    '   Nothing
    ' Parameters:
    '   lbl as Label
    '   pnl as Panel
    '   msg as String
    '*******************************************************************************************************************
    Public Shared Sub showSuccessMessage(ByRef lbl As Label, ByRef pnl As Panel, ByVal msg As String)

        lbl.Text = "SUCCESS!! " & msg
        pnl.Attributes.Add("style", "background:#ccffb2; display: block; padding: 10px; text-align: center;")

    End Sub
End Class
