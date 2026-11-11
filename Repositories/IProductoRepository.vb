
Imports ApiProductosVB.Models

Namespace Repositories

    Public Interface IProductoRepository

        Function ObtenerPorCategoriaAsync(
            categoriaId As Integer) As Task(Of List(Of Producto))

    End Interface

End Namespace
