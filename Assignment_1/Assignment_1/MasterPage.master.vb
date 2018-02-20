
Partial Class MasterPage
    Inherits System.Web.UI.MasterPage

    Sub Page_Load(ByVal Sender As Object, ByVal E As EventArgs) Handles MyBase.Load

        Dim myCookie As HttpCookie = Request.Cookies("UserName")

        If myCookie IsNot Nothing Then
            lblName.Text = "Welcome " & myCookie.Value
        End If
    End Sub

End Class

