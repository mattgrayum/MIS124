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
            End If
        Catch ex As Exception
            Me.lblErrorMessages.Text = ex.Message
        End Try
    End Sub
End Class