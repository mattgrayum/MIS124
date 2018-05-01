Public Class _Error
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            If Request.QueryString("error") IsNot Nothing Then
                lblError.Text = Request.QueryString("error")
            End If
        End If

    End Sub
End Class