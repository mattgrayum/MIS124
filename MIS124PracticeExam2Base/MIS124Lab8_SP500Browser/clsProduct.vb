Public Class clsProduct
    Private ReadOnly mintProductID As Integer
    Private ReadOnly mstrProductName As String
    Private ReadOnly mdecPurchasePrice As Decimal
    Private ReadOnly mintUnitsInStock As Integer
    Private ReadOnly mintUnitsOnOrder As Integer
    Private ReadOnly mintReorderLevel As Integer
    Private ReadOnly mstrDiscontinued As String
    Private ReadOnly mdecRetailPrice As Decimal



    Public ReadOnly Property ProductId As Integer
        Get
            Return mintProductID
        End Get
    End Property
    Public ReadOnly Property ProductName As String
        Get
            Return mstrProductName
        End Get
    End Property
    Public ReadOnly Property PurchasePrice As Decimal
        Get
            Return mdecPurchasePrice
        End Get
    End Property
    Public ReadOnly Property UnitsInStock As Integer
        Get
            Return mintUnitsInStock
        End Get
    End Property
    Public ReadOnly Property UnitsOnOrder As Integer
        Get
            Return mintUnitsOnOrder
        End Get
    End Property
    Public ReadOnly Property Discontinued As String
        Get
            Return mstrDiscontinued
        End Get
    End Property
    Public ReadOnly Property ReorderLevel As Integer
        Get
            Return mintReorderLevel
        End Get
    End Property
    Public ReadOnly Property RetailPrice As Decimal
        Get
            Return mdecRetailPrice
        End Get
    End Property
    Public Sub New()

    End Sub

    Public Sub New(ByVal intID As Integer,
                   ByVal strProductName As String,
                   ByVal decPurchasePrice As String,
                   ByVal intUnitsInStock As String,
                   ByVal intUnitsOnOrder As String,
                   ByVal intReorderLevel As String,
                   ByVal strDiscontinued As String,
                   ByVal decRetailPrice As String)

        mintProductID = intID
        mstrProductName = strProductName
        mdecPurchasePrice = decPurchasePrice
        mintUnitsInStock = intUnitsInStock
        mintUnitsOnOrder = intUnitsOnOrder
        mintReorderLevel = intReorderLevel
        mstrDiscontinued = strDiscontinued
        mdecRetailPrice = decRetailPrice
    End Sub
End Class
