Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.VisualBasic
Public Class clsAuthorDA

    '*******************************************************************************************************************
    ' Function getAuthor
    '   This function queries the database for an Author record that matches the passed ID
    ' Returns:
    '   author as clsAuthor
    ' Parameters:
    '   ID as Integer - The author ID
    '*******************************************************************************************************************
    Public Shared Function getAuthor(ByVal ID As Integer) As clsAuthor

        'Set up a database connection, define the SELECT statement, set up a command object, and open the db connection
        Dim connection As SqlConnection = clsDBConnection.getConnection()
        Dim strSQL As String = "SELECT * FROM dbo.Authors WHERE AuthorID =" & ID & ";"
        Dim dbCommand As New SqlCommand(strSQL, connection)
        connection.Open()

        'Set up a reader object to read a single row from the database
        Dim dbReader As SqlDataReader = dbCommand.ExecuteReader(CommandBehavior.SingleRow)

        'Read in the data and populate a new clsAuthor object if a record was found
        Dim author As clsAuthor = Nothing
        If dbReader.Read() Then
            author = New clsAuthor(dbReader.GetInt32(0), dbReader.GetString(1), dbReader.GetString(2),
                                        dbReader.GetString(3))
        Else
            Throw New ArgumentException("ERROR: SQL103. The Author ID that you entered does not exist in the database." & vbCrLf & vbCrLf &
                                        "Please check your records and enter a valid Author ID")
        End If

        'Close the database connection
        connection.Close()

        Return author

    End Function

    '*******************************************************************************************************************
    ' Function updateAuthor
    '   This function updates the Author table with new data from a web form
    ' Returns:
    '   result as Integer - The number of rows affected by the operation.
    ' Parameters:
    '   author as clsAuthor
    '*******************************************************************************************************************
    Public Shared Function updateAuthor(ByRef author As clsAuthor) As Integer

        'Set up a database connection, define the SELECT statement, set up a command object, and open the db connection
        Dim connection As SqlConnection = clsDBConnection.getConnection()
        Dim strSQL As String = "UPDATE dbo.Authors SET [YearBorn]='" & author.YearBorn & "' WHERE [AuthorID] = " & author.AuthorID & ";"
        Dim dbCommand As New SqlCommand(strSQL, connection)
        connection.Open()

        'Execute the update
        Dim result As Integer = dbCommand.ExecuteNonQuery()

        'Close the database connection
        connection.Close()

        Return result

    End Function

End Class
