﻿// See https://aka.ms/new-console-template for more information
using curso_linq;
using curso_linq.Entidades;

LinqQueries queris = new LinqQueries();

// ImprimirValores(queris.TodaLaColeccion());
// ImprimirValores(queris.LibrosDespuesdel2000());
// ImprimirValores(queris.LibrosPaginasMayor250YCOnLaPalabraInAction());

// Console.WriteLine($"Todos los libros tienes status: {queris.TodosLosLibrosTienenStatus()}");
// Console.WriteLine($"libros Publicados en 2005: {queris.LibrosPublicados2005()}");



// ImprimirValores(queris.TodosLosLibrosQuePertenezcanAPython());
// ImprimirValores(queris.TodosLosLibrosQuePertenezcanAJavaOrdenadosPorNombre());
// ImprimirValores(queris.TodosLosLibrosQueTienenMas450Paginas());
// ImprimirValores(queris.TresLibrosRecientesCategorizadosEnJava());
ImprimirValores(queris.TercerYCuartoLibroMayoresA400Paginas());

void ImprimirValores(IEnumerable<Book> listaLibros)
{
    Console.WriteLine("{0,-60} {1,15} {2,15} {3,25}\n", "Titulo", "# PAginas", "Fecha Publicacion", "Categorias");

    foreach(var item in listaLibros)
    {
        Console.WriteLine("{0,-60} {1,15} {2,15} {3,25}", item.Title,item.PageCount,item.PublishedDate.ToShortDateString(), String.Join(",", item.Categories));
    }
}

