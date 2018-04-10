'***********************************************************************************************************************
'Class Name:        clsTaxReturn.vb
'Version:           1.00
'Programmer/s:      Spiros Velianitis
'Date:              Jan 6, 2017
'Purpose:           Perform the necessary calculations for the 1040EZ tax return.
'***********************************************************************************************************************
Imports MIS124ClassLibrary

Public Class clsTaxReturn

    '*******************************************************************************************************************
    'DECLARATION OF CONSTANT VARIABLES
    '*******************************************************************************************************************
    ' -- Constants declared and values initialized
    Private Const mintSTANDARD_DEDUCTION As Integer = 6350, _
              mintEXCEMPTION_DEDUCTION As Integer = 4050, _
              mintMAX_TAXABLE_INCOME_ALLOWED As Integer = 100000, _
              mintMAX_INTEREST_INCOME_ALLOWED As Integer = 1500

    '*******************************************************************************************************************
    'DECLARATION OF MODULE VARIABLES
    '*******************************************************************************************************************
    ' -- Variables to keep track of various information needed to calculate taxes
    Private mintTaxPayerID As Integer,
            mstrYear As String,
            mboolIsJointReturn As Boolean,
            mdecWages As Decimal,
            mdecTaxableInterest As Decimal,
            mdecUnemploymentCompensation As Decimal,
            mchrDependentStatus As Char(),
            mdecIncomeTaxWithheld As Decimal,
            mdecEIC As Decimal,
            mdecCompatPay As Decimal,
            mdblAdjustedGrossIncome As Double,
            mdblExcemptionAmount As Double,
            mdblTaxableIncome As Double,
            mdblTotalPayments As Double,
            mdblTax As Double,
            mdblBalance As Double

    Private mintNumberOfTaxpayers As Integer,
            mintNumberOfDependentTaxpayers As Integer

    Private mstrServerPath As String 'String stores the location of the Tax

    '*******************************************************************************************************************
    'CONSTRUCTORS
    '*******************************************************************************************************************
    ' -- Creates a constructor and receives the values from the 1040EZ form in order to do the calculations
    Private Sub New()
        ' Empty default constructor
    End Sub

    Public Sub New(ByVal intTaxPayerID As Integer,
                   ByVal strYear As String,
                   ByVal boolIsJointReturn As Boolean,
                    ByVal decWages As Decimal,
                    ByVal decTaxableInterest As Decimal,
                    ByVal decUnemploymentCompensation As Decimal,
                   ByVal chrDependentStatus As Char(),
                    ByVal decIncomeTaxWithheld As Decimal,
                    ByVal decEIC As Decimal,
                    ByVal decCompatPay As Decimal)

        mintTaxPayerID = intTaxPayerID
        mstrYear = strYear
        IsJointReturn = boolIsJointReturn
        Wages = decWages
        TaxableInterest = decTaxableInterest
        UnemploymentCompensation = decUnemploymentCompensation
        mchrDependentStatus = chrDependentStatus
        IncomeTaxWithheld = decIncomeTaxWithheld
        EIC = decEIC
        mdecCompatPay = decCompatPay

    End Sub

    '*******************************************************************************************************************
    'PROPERTIES
    '*******************************************************************************************************************
    ' -- Various properties to set and access data

    Public ReadOnly Property TaxPayerID As Integer
        Get
            Return mintTaxPayerID
        End Get
    End Property
    Public ReadOnly Property Year As String
        Get
            Return mstrYear
        End Get
    End Property
    Public Property IsJointReturn() As Boolean
        Get
            Return mboolIsJointReturn
        End Get
        Set(ByVal Value As Boolean)
            mboolIsJointReturn = Value
        End Set
    End Property
    Public Property Wages() As Decimal
        Get
            Return mdecWages
        End Get
        Set(ByVal Value As Decimal)
            mdecWages = Value
        End Set
    End Property
    Public Property TaxableInterest() As Decimal
        Get
            Return mdecTaxableInterest
        End Get
        Set(ByVal Value As Decimal)
            If Value > mintMAX_INTEREST_INCOME_ALLOWED Then
                Throw New System.Data.InvalidConstraintException("ERROR TR002. Taxable interest must not be over $ 1,500.00")
            End If
            mdecTaxableInterest = Value
        End Set
    End Property
    Public Property UnemploymentCompensation() As Decimal
        Get
            Return mdecUnemploymentCompensation
        End Get
        Set(ByVal Value As Decimal)
            mdecUnemploymentCompensation = Value
        End Set
    End Property
    Public Property DependentStatus() As Char()
        Get
            Return mchrDependentStatus
        End Get
        Set(ByVal Value As Char())
            mchrDependentStatus = Value
        End Set
    End Property
    Public ReadOnly Property AdjustedGrossIncome() As Double
        Get
            Return mdblAdjustedGrossIncome
        End Get
    End Property
    Public ReadOnly Property ExcemptionAmount() As Double
        Get
            Return mdblExcemptionAmount
        End Get
    End Property
    Public ReadOnly Property TaxableIncome() As Double
        Get
            Return mdblTaxableIncome
        End Get
    End Property
    Public Property IncomeTaxWithheld() As Decimal
        Get
            Return mdecIncomeTaxWithheld
        End Get
        Set(ByVal Value As Decimal)
            mdecIncomeTaxWithheld = Value
        End Set
    End Property
    Public Property EIC() As Decimal
        Get
            Return mdecEIC
        End Get
        Set(ByVal Value As Decimal)
            mdecEIC = Value
        End Set
    End Property

    Public Property CompatPay() As Decimal
        Get
            Return mdecCompatPay
        End Get
        Set(ByVal Value As Decimal)
            mdecCompatPay = Value
        End Set
    End Property

    Public ReadOnly Property TotalPayments() As Double
        Get
            Return mdblTotalPayments
        End Get
    End Property
    Public ReadOnly Property Tax() As Double
        Get
            Return mdblTax
        End Get
    End Property

    Public Property NumberOfTaxpayers() As Integer
        Get
            Return mintNumberOfTaxpayers
        End Get
        Set(ByVal Value As Integer)
            mintNumberOfTaxpayers = Value
        End Set
    End Property
    Public Property NumberOfDependentTaxpayers() As Integer
        Get
            Return mintNumberOfDependentTaxpayers
        End Get
        Set(ByVal Value As Integer)
            mintNumberOfDependentTaxpayers = Value
        End Set
    End Property
    Public Property ServerPath() As String
        Get
            Return mstrServerPath
        End Get
        Set(ByVal Value As String)
            mstrServerPath = Value
        End Set
    End Property


    '*******************************************************************************************************************
    'CALCULATE ADJUSTED GROSS INCOME
    '*******************************************************************************************************************
    ' -- Calculates adjusted gross income
    Private Sub calculateAdjustedGrossIncome()
        Me.mdblAdjustedGrossIncome = Me.mdecWages + Me.mdecTaxableInterest + Me.mdecUnemploymentCompensation
    End Sub

    '*******************************************************************************************************************
    'CALCULATE EXCEMPTION AMOUNT
    '*******************************************************************************************************************
    ' -- Calculates excemption amount (information can be found on Form 1040EZ page 2)
    Private Sub calculateExcemptionAmount()
        If Me.mintNumberOfDependentTaxpayers = 0 Then
            mdblExcemptionAmount = mintNumberOfTaxpayers * (mintEXCEMPTION_DEDUCTION + mintSTANDARD_DEDUCTION)
        Else
            Dim decA As Double = Me.mdecWages + 350
            Dim decC As Double
            If decA > 1000 Then
                decC = decA
            Else
                decC = 1050
            End If
            Dim decD As Double = mintNumberOfTaxpayers * mintSTANDARD_DEDUCTION
            Dim decE As Double
            If decD > decC Then
                decE = decC
            Else
                decE = decD
            End If
            Dim decF As Double = 0
            If Me.mintNumberOfTaxpayers = 2 AndAlso Me.mintNumberOfDependentTaxpayers = 1 Then
                decF = mintEXCEMPTION_DEDUCTION
            End If
            mdblExcemptionAmount = decE + decF
        End If

    End Sub

    '*******************************************************************************************************************
    'CALCULATE TAXABLE INCOME
    '*******************************************************************************************************************
    ' -- Calculates taxable income
    Private Sub calculateTaxableIncome()
        If mdblExcemptionAmount > mdblAdjustedGrossIncome Then
            mdblTaxableIncome = 0
        Else
            mdblTaxableIncome = mdblAdjustedGrossIncome - mdblExcemptionAmount
        End If
    End Sub

    '*******************************************************************************************************************
    'CALCULATE TOTAL PAYMENTS
    '*******************************************************************************************************************
    ' -- Calculates total payments
    Private Sub calculateTotalPayments()
        Me.mdblTotalPayments = Me.mdecIncomeTaxWithheld + Me.mdecEIC + mdecCompatPay
    End Sub

    'Calculate LINE 10
    Private Sub calculateTax()
        Dim trsx As clsTaxRates = New clsTaxRates(mstrServerPath)
        Dim tts As TaxTableStructure = trsx.findTaxRow(Me.mdblTaxableIncome)
        If Me.mintNumberOfTaxpayers = 1 Then
            Me.mdblTax = tts.SingleTax
        Else
            Me.mdblTax = tts.MarriedFilingJointlyTax
        End If
    End Sub

    '*******************************************************************************************************************
    ' Function calculateTaxReturn
    '   This function calls all private sub procedures that calculate
    '   and change the appropriate module level variables (fields)
    ' Returns:
    '   The calculated tax balance
    ' Parameters:
    '   none
    '*******************************************************************************************************************
    Public Function calculateTaxReturn() As Double
        calculateAdjustedGrossIncome()
        calculateExcemptionAmount()
        calculateTaxableIncome()
        If Me.mdblTaxableIncome > mintMAX_TAXABLE_INCOME_ALLOWED Then
            Throw New System.InvalidOperationException("ERROR TR001. Taxable Income cannot exceed $100,000")
        End If
        calculateTotalPayments()
        calculateTax()
        Return Me.mdblTotalPayments - Me.mdblTax
    End Function

End Class
