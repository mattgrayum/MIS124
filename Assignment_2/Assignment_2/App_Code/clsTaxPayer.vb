Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.VisualBasic

Public Class clsTaxPayer

    '*******************************************************************************************************************
    'DECLARATION OF MODULE VARIABLES
    '*******************************************************************************************************************
    Private ReadOnly mintTaxPayerID As Integer
    Private ReadOnly mstrLastName As String
    Private ReadOnly mstrFirstName As String
    Private ReadOnly mstrMidInitial As String
    Private ReadOnly mstrAddress As String
    Private ReadOnly mstrCity As String
    Private ReadOnly mstrState As String
    Private ReadOnly mstrZip As String

    '*******************************************************************************************************************
    'CONSTRUCTORS
    '*******************************************************************************************************************
    Public Sub New()
        ' Empty default constructor
    End Sub

    Public Sub New(ByVal intID As Integer,
                   ByVal strLName As String,
                   ByVal strFName As String,
                   ByVal strMInit As String,
                   ByVal strAddr As String,
                   ByVal strCity As String,
                   ByVal strState As String,
                   ByVal strZip As String)

        mintTaxPayerID = intID
        mstrLastName = strLName
        mstrFirstName = strFName
        mstrMidInitial = strMInit
        mstrAddress = strAddr
        mstrCity = strCity
        mstrState = strState
        mstrZip = strZip
    End Sub

    '*******************************************************************************************************************
    'PROPERTIES
    '*******************************************************************************************************************
    ' -- Various properties to access data
    Public ReadOnly Property TaxPayerID As Integer
        Get
            Return mintTaxPayerID
        End Get
    End Property

    Public ReadOnly Property LastName As String
        Get
            Return mstrLastName
        End Get
    End Property

    Public ReadOnly Property FirstName As String
        Get
            Return mstrFirstName
        End Get
    End Property

    Public ReadOnly Property MidInitial As String
        Get
            Return mstrMidInitial
        End Get
    End Property

    Public ReadOnly Property Address As String
        Get
            Return mstrAddress
        End Get
    End Property

    Public ReadOnly Property City As String
        Get
            Return mstrCity
        End Get
    End Property

    Public ReadOnly Property State As String
        Get
            Return mstrState
        End Get
    End Property

    Public ReadOnly Property Zip As String
        Get
            Return mstrZip
        End Get
    End Property

    '*******************************************************************************************************************
    ' Function getJointTaxPayer
    '   This function gets the joint tax payer associated with this tax payer
    ' Returns:
    '   JointTaxPayer
    ' Parameters:
    '   None
    '*******************************************************************************************************************
    Public Function getJointTaxPayer() As JointTaxPayer

        'Set up a database connection, define the SELECT statement, set up a command object, and open the db connection
        Dim connection As SqlConnection = clsDBConnection.getConnection()
        Dim strSQL As String = "SELECT * FROM dbo.tblJointTaxPayer WHERE TaxPayerID = " & mintTaxPayerID & ";"
        Dim dbCommand As New SqlCommand(strSQL, connection)
        connection.Open()

        ' Execute the query
        Dim dbReader As SqlDataReader = dbCommand.ExecuteReader(CommandBehavior.SingleRow)

        'Read in the data and assign each data point to a member of jointTaxPayer
        Dim jointTaxPayer As JointTaxPayer = Nothing
        If dbReader.Read() Then
            jointTaxPayer.lastName = dbReader.GetString(0)
            jointTaxPayer.firstName = dbReader.GetString(1)
            jointTaxPayer.middleInitial = dbReader.GetString(2)
            jointTaxPayer.taxPayerID = mintTaxPayerID
        End If

        'If there is no middle initial, the database will have saved it as a single space
        'We remove that space so it will display as nothing in the single-character text box so the user can 
        'enter a value in there if they want
        If jointTaxPayer.middleInitial = " " Then
            jointTaxPayer.middleInitial = ""
        End If

        'Close the connection
        connection.Close()

        Return jointTaxPayer

    End Function

End Class
