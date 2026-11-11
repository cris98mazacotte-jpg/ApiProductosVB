
Imports Microsoft.EntityFrameworkCore
Imports ApiProductosVB.Data
Imports ApiProductosVB.Models

Namespace Repositories

    Public Class CategoriaRepository
        Implements ICategoriaRepository

        Private ReadOnly _context As AppDbContext

        Public Sub New(context As AppDbContext)
            _context = context
        End Sub

        Public Async Function ObtenerPorIdAsync(
            id As Integer) As Task(Of Categoria) _
            Implements ICategoriaRepository.ObtenerPorIdAsync

            Return Await _context.Categorias.
                FirstOrDefaultAsync(Function(c) c.Id = id)

        End Function

        Public Async Function ExisteAsync(
            id As Integer) As Task(Of Boolean) _
            Implements ICategoriaRepository.ExisteAsync

            Return Await _context.Categorias.
                AnyAsync(Function(c) c.Id = id)

        End Function

    End Class

End Namespace
