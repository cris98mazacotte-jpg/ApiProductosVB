
Namespace Models

    Public Class Producto

        Public Property Id As Integer

        Public Property Nombre As String = String.Empty

        Public Property Precio As Decimal

        Public Property Stock As Integer

        ' Clave foranea
        Public Property CategoriaId As Integer?

        ' Propiedad de navegacion
        Public Property Categoria As Categoria

    End Class

End Namespace
