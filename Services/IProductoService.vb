
Imports ApiProductosVB.DTOs

Namespace Services

    Public Interface IProductoService

        Function ObtenerPorCategoriaAsync(
            categoriaId As Integer) As Task(Of List(Of ProductoDto))

    End Interface

End Namespace
