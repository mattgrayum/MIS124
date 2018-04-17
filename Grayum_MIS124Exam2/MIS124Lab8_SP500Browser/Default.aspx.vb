Public Class _Default
    Inherits Page

    '*******************************************************************************************************************
    'ACTION ON PAGE LOAD
    '*******************************************************************************************************************
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load

        Try

            'Find the firs author and display their data in the web form
            If Not IsPostBack Then

                If Session("author") Is Nothing Then
                    displayAuthor(clsAuthorDA.getAuthor(1))
                Else
                    displayAuthor(Session("author"))
                End If

            End If

        Catch ex As Exception
            lblMessages.Text = ex.Message
        End Try


    End Sub

    '*******************************************************************************************************************
    'ACTION ON FIND BUTTON CLICK
    '*******************************************************************************************************************
    Protected Sub btnFind_Click(sender As Object, e As EventArgs) Handles btnFind.Click

        Try

            'Find the author corresponding to the chosen ID and display their data in the web form
            Session("author") = clsAuthorDA.getAuthor(CType(txtAuthorID.Text, Integer))
            displayAuthor(Session("author"))

        Catch ex As Exception
            lblMessages.Text = ex.Message
        End Try

    End Sub

    '*******************************************************************************************************************
    'ACTION ON UPDATE BUTTON CLICK
    '*******************************************************************************************************************
    Protected Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click

        Try

            'Update the database with the author data currently in the web form and display success message if successful
            Dim result As Integer = clsAuthorDA.updateAuthor(New clsAuthor(CType(txtAuthorID.Text, Integer), txtFirstName.Text, txtLastName.Text, txtYearBorn.Text))
            If result > 0 Then
                lblMessages.Text = "Success!! This author has been updated in our records."
            End If

        Catch ex As Exception
            lblMessages.Text = ex.Message
        End Try

    End Sub

    '*******************************************************************************************************************
    ' Method displayAuthor
    '   This function populates the controls of a web form with an author's data
    ' Returns:
    '   Nothing
    ' Parameters:
    '   author as clsAuthor
    '*******************************************************************************************************************
    Public Sub displayAuthor(ByRef author As clsAuthor)

        Try

            txtAuthorID.Text = author.AuthorID.ToString
            txtFirstName.Text = author.FirstName
            txtLastName.Text = author.LastName
            txtYearBorn.Text = author.YearBorn

        Catch ex As Exception
            lblMessages.Text = ex.Message
        End Try

    End Sub

End Class