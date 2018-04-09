﻿Imports System.Data
Imports System.Data.SqlClient
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

    Public Function getJointTaxPayer() As JointTaxPayer
        Dim connection As SqlConnection = clsDBConnection.getConnection()
        Dim strSQL As String = "SELECT * FROM dbo.tblJointTaxPayer WHERE TaxPayerID = 1;"
        Dim dbCommand As New SqlCommand(strSQL, connection)
        connection.Open()
        Dim dbReader As SqlDataReader = dbCommand.ExecuteReader(CommandBehavior.SingleRow)
        Dim joint As JointTaxPayer = Nothing
        If dbReader.Read() Then
            joint.lastName = dbReader.GetString(0)
            joint.firstName = dbReader.GetString(1)
            joint.middleInitial = dbReader.GetString(2)
        Else
            Throw New ArgumentException("ERROR: SQL103. The Joint Tax Payer for the Tax Payer ID that you entered does not exist in the database." & vbCrLf & vbCrLf &
                                       "Please check your records and enter a valid Tax Payer ID")
        End If

        Return joint
    End Function
End Class