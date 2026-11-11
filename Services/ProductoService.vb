
Imports ApiProductosVB.DTOs
Imports ApiProductosVB.Repositories

Namespace Services

    Public Class ProductoService
        Implements IProductoService

        Private ReadOnly _productoRepository As IProductoRepository
        Private ReadOnly _categoriaRepository As ICategoriaRepository

        Public Sub New(
            productoRepository As IProductoRepository,
            categoriaRepository As ICategoriaRepository)

            _productoRepository = productoRepository
            _categoriaRepository = categoriaRepository

        End Sub

        Public Async Function ObtenerPorCategoriaAsync(
            categoriaId As Integer) As Task(Of List(Of ProductoDto)) _
            Implements IProductoService.ObtenerPorCategoriaAsync

            ' Verificar si existe la categoria
            Dim existeCategoria As Boolean =
                Await _categoriaRepository.ExisteAsync(categoriaId)

            If Not existeCategoria Then
                Return Nothing
            End If

            ' Obtener productos de la categoria
            Dim productos = Await _productoRepository.
                ObtenerPorCategoriaAsync(categoriaId)

            ' Convertir entidades a DTO
            Return productos.Select(
                Function(p) New ProductoDto With {
                    .Id = p.Id,
                    .Nombre = p.Nombre,
                    .Precio = p.Precio,
                    .Stock = p.Stock,
                    .CategoriaId = p.CategoriaId,
                    .CategoriaDescripcion = p.Categoria.Descripcion
                }).ToList()

        End Function

    End Class

End Namespace
