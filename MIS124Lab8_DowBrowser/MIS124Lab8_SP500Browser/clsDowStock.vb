Public Class clsDowStock
    Private ReadOnly mstrTicker As String
    Private ReadOnly mstrStockName As String
    Private ReadOnly mdblDividend As Double

    Public ReadOnly Property Ticker As String
        Get
            Return mstrTicker
        End Get
    End Property
    Public ReadOnly Property StockName As String
        Get
            Return mstrStockName
        End Get
    End Property
    Public ReadOnly Property Dividend As Double
        Get
            Return mdblDividend
        End Get
    End Property
    Private Sub New()

    End Sub
    Public Sub New(ByVal strTicker As String, _
                    ByVal strStockName As String, _
                    ByVal dblDividend As Double)
        mstrTicker = strTicker
        mstrStockName = strStockName
        mdblDividend = dblDividend
    End Sub
End Class
