
Imports Microsoft.EntityFrameworkCore
Imports ApiProductosVB.Data
Imports ApiProductosVB.Models

Namespace Repositories

    Public Class ProductoRepository
        Implements IProductoRepository

        Private ReadOnly _context As AppDbContext

        Public Sub New(context As AppDbContext)
            _context = context
        End Sub

        Public Async Function ObtenerPorCategoriaAsync(
            categoriaId As Integer) As Task(Of List(Of Producto)) _
            Implements IProductoRepository.ObtenerPorCategoriaAsync

            Return Await _context.Productos.
                Include(Function(p) p.Categoria).
                Where(Function(p) p.CategoriaId.HasValue AndAlso
                  p.CategoriaId.Value = categoriaId).
            ToListAsync()

        End Function

    End Class

End Namespace
