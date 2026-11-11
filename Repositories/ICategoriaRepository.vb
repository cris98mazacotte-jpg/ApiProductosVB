
Imports ApiProductosVB.Models

Namespace Repositories

    Public Interface ICategoriaRepository

        Function ObtenerPorIdAsync(id As Integer) As Task(Of Categoria)

        Function ExisteAsync(id As Integer) As Task(Of Boolean)

    End Interface

End Namespace
