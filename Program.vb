
Imports ApiProductosVB.Data
Imports ApiProductosVB.Repositories
Imports ApiProductosVB.Services
Imports Microsoft.AspNetCore.Builder
Imports Microsoft.EntityFrameworkCore
Imports Microsoft.Extensions.Configuration
Imports Microsoft.Extensions.DependencyInjection
Imports Microsoft.Extensions.Hosting

Module Program

    Sub Main(args As String())

        Dim builder = WebApplication.CreateBuilder(args)

        ' Registrar controladores
        builder.Services.AddControllers()

        ' Configurar conexion con SQL Server
        Dim cadenaConexion As String =
            builder.Configuration.GetConnectionString("ConexionSQL")

        builder.Services.AddDbContext(Of AppDbContext)(
            New System.Action(Of DbContextOptionsBuilder)(
                Sub(options As DbContextOptionsBuilder)
                    options.UseSqlServer(cadenaConexion)
                End Sub))

        ' Registrar repositorios
        builder.Services.AddScoped(Of ICategoriaRepository, CategoriaRepository)()
        builder.Services.AddScoped(Of IProductoRepository, ProductoRepository)()

        ' Registrar servicios
        builder.Services.AddScoped(Of IProductoService, ProductoService)()

        ' Configurar Swagger
        builder.Services.AddEndpointsApiExplorer()
        builder.Services.AddSwaggerGen()

        Dim app = builder.Build()

        ' Habilitar Swagger
        If app.Environment.IsDevelopment() Then
            app.UseSwagger()
            app.UseSwaggerUI()
        End If

        app.UseHttpsRedirection()
        app.UseAuthorization()
        app.MapControllers()

        app.Run()

    End Sub

End Module
