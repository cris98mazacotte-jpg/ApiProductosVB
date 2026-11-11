
Imports Microsoft.EntityFrameworkCore
Imports ApiProductosVB.Models

Namespace Data

    Public Class AppDbContext
        Inherits DbContext

        Public Sub New(options As DbContextOptions(Of AppDbContext))
            MyBase.New(options)
        End Sub

        Public Property Productos As DbSet(Of Producto)

        Public Property Categorias As DbSet(Of Categoria)

        Protected Overrides Sub OnModelCreating(
            modelBuilder As ModelBuilder)

            MyBase.OnModelCreating(modelBuilder)

            ' Mapear las entidades a las tablas existentes
            modelBuilder.Entity(Of Categoria)().
                ToTable("Categoria")

            modelBuilder.Entity(Of Producto)().
                ToTable("Productos")

            ' Configurar relacion uno a muchos
            modelBuilder.Entity(Of Categoria)().
                HasMany(Function(c) c.Productos).
                WithOne(Function(p) p.Categoria).
                HasForeignKey(Function(p) p.CategoriaId)

        End Sub

    End Class

End Namespace
