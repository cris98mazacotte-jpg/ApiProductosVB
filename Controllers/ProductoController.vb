
Imports Microsoft.AspNetCore.Mvc
Imports ApiProductosVB.Services
Imports System.Threading.Tasks

Namespace Controllers

    <ApiController>
    <Route("api/producto")>
    Public Class ProductoController
        Inherits ControllerBase

        Private ReadOnly _service As IProductoService

        Public Sub New(service As IProductoService)
            _service = service
        End Sub

        <HttpGet("categoria/{categoriaId}")>
        Public Async Function ObtenerPorCategoria(
            categoriaId As Integer) As Task(Of IActionResult)

            Dim productos = Await _service.
                ObtenerPorCategoriaAsync(categoriaId)

            If productos Is Nothing Then
                Return NotFound(New With {
                    .mensaje = "La categoría solicitada no existe."
                })
            End If

            Return Ok(productos)

        End Function

    End Class

End Namespace
