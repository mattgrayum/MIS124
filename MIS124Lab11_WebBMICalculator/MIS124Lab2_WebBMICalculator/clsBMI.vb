
'Project:           BMICalculator Ver. 1.0
'Date:              January 2016
'Programmer:        Spiros Velianitis
'Description:       This class calculates the Body Mass Index (BMI) which determines a person's 
'                   weight category. Based on the BMI, people are classified as Underweight,
'                   Normal, Overweight or Obese. 

Public Class clsBMI
    'Declaration of class module level variables (also called fields or attributes)
    'Notice that they are all private
    Private mstrUserName As String
    Private mintHeight As String
    Private mintWeight As String
    Private mdblBMI As Double

    'Declaration of the of the class properties (only read)
    ReadOnly Property UserName As String
        Get
            Return mstrUserName
        End Get
    End Property

    ReadOnly Property Height As String
        Get
            Return mintHeight
        End Get
    End Property

    ReadOnly Property Weight As String
        Get
            Return mintWeight
        End Get
    End Property

    ReadOnly Property BMI As Double
        Get
            Return mdblBMI
        End Get
    End Property

    Private Sub New()
        'I Hide the default constructor so the users cannot create an empty object
    End Sub

    'In the constructor, I check the parameters (business rules validation) and throw error messages

    Public Sub New(ByVal strName As String, ByVal intHeight As Integer, ByVal intWeight As Integer)
        If (intHeight > 100 Or intHeight < 48) Then
            Throw New ArgumentException("ERROR B001: A person's height cannot be more than 100 inches or less than 48 inches")
        End If
        If (intWeight < 50) Then
            Throw New ArgumentException("ERROR B002: A person's weight cannot be less than 50 pounds. ")
        End If
        If (intWeight > 500) Then
            Throw New ArgumentException("ERROR B003: If you are more than 500 pounds, you already know the answer.")
        End If

        'Assign the constructor parameters to your module variables
        mstrUserName = strName
        mintWeight = intWeight
        mintHeight = intHeight

        'Call the sub that calculates the BMI
        getBMI()
    End Sub

    Private Sub getBMI()
        ' BMI is calculates as Weight/Height/Height*703
        mdblBMI = mintWeight / mintHeight / mintHeight * 703
    End Sub

    Public Shared Function getRating(ByVal dblBMI As Double) As String
        'BMI    > 30 is Obese
        '       > 25 is Overweight
        '       > 19 is Normal
        '       < 19 is Underweight
        Dim strRating As String = Nothing

        If dblBMI > 30 Then
            strRating = "Obese"
        ElseIf dblBMI > 25 Then
            strRating = "Overweight"
        ElseIf dblBMI > 19 Then
            strRating = "Normal"
        ElseIf dblBMI > 15 Then
            strRating = "Underweight"
        Else
            Throw New ArgumentException("ERROR BMI005: Your BMI Rating is out of range. Perhaps, there is problem with our calculations.")
        End If
        Return strRating
    End Function
End Class

