
Namespace Models

    Public Class Categoria

        Public Property Id As Integer

        Public Property Descripcion As String = String.Empty

        ' Relacion uno a muchos
        Public Property Productos As ICollection(Of Producto) =
            New List(Of Producto)()

    End Class

End Namespace
