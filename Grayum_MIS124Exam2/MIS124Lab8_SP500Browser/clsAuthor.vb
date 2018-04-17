Public Class clsAuthor

    '*******************************************************************************************************************
    'DECLARATION OF MODULE VARIABLES
    '*******************************************************************************************************************
    Private ReadOnly mintAuthorID As Integer
    Private ReadOnly mstrFirstName As String
    Private ReadOnly mstrLastName As String
    Private ReadOnly mstrYearBorn As String

    '*******************************************************************************************************************
    'CONSTRUCTORS
    '*******************************************************************************************************************
    Public Sub New()
        ' Empty default constructor
    End Sub

    Public Sub New(ByVal intID As Integer,
                   ByVal strFName As String,
                   ByVal strLName As String,
                   ByVal strYear As String)

        mintAuthorID = intID
        mstrFirstName = strFName
        mstrLastName = strLName
        mstrYearBorn = strYear

    End Sub

    '*******************************************************************************************************************
    'PROPERTIES
    '*******************************************************************************************************************
    ' -- Various properties to access data
    Public ReadOnly Property AuthorID As Integer
        Get
            Return mintAuthorID
        End Get
    End Property

    Public ReadOnly Property FirstName As String
        Get
            Return mstrFirstName
        End Get
    End Property

    Public ReadOnly Property LastName As String
        Get
            Return mstrLastName
        End Get
    End Property

    Public ReadOnly Property YearBorn As String
        Get
            Return mstrYearBorn
        End Get
    End Property
End Class
