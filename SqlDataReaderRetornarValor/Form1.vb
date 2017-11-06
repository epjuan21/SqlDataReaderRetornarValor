Imports System.Data.SqlClient
Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ' Creacion de la Cadena de Conexion
        Dim builder As New SqlConnectionStringBuilder
        builder("Data Source") = "SERVIDOR01\SQLEXPRESS"
        builder("Integrated Security") = True
        builder("Initial Catalog") = "AdventureWorks2012"

        Dim sql As String = "Select Name From HumanResources.Department Where DepartmentID =@Id"

        ' Obtener un solo valor de la base de datos

        Using connection As New SqlConnection(builder.ConnectionString)

            Dim cmd As New SqlCommand(sql, connection)
            cmd.Parameters.Add("@Id", SqlDbType.Int)
            cmd.Parameters("@Id").Value = 2
            connection.Open()
            TextBox1.Text = cmd.ExecuteScalar()


        End Using

    End Sub
End Class
