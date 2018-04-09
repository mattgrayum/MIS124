Imports Microsoft.VisualBasic

Public Class clsTaxPayer
    Private ReadOnly mstrTaxPayerID As Integer
    Private ReadOnly mstrLastName As String
    Private ReadOnly mstrFirstName As String
    Private ReadOnly mstrMidInitial As String
    Private ReadOnly mstrAddress As String
    Private ReadOnly mstrCity As String
    Private ReadOnly mstrState As String
    Private ReadOnly mstrZip As String
    Private ReadOnly mstrTimeCreated As Date

    Public ReadOnly Property TaxPayerID As Integer
        Get
            Return mstrTaxPayerID
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

    Public ReadOnly Property TimeCreated As Date
        Get
            Return mstrTimeCreated
        End Get
    End Property

    Public Sub New()

    End Sub

    Public Sub New(ByVal intID As Integer,
                   ByVal strLName As String,
                   ByVal strFName As String,
                   ByVal strMInit As String,
                   ByVal strAddr As String,
                   ByVal strCity As String,
                   ByVal strState As String,
                   ByVal strZip As String)

        mstrTaxPayerID = intID
        mstrLastName = strLName
        mstrFirstName = strFName
        mstrMidInitial = strMInit
        mstrAddress = strAddr
        mstrCity = strCity
        mstrState = strState
        mstrZip = strZip
    End Sub
End Class
