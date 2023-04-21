﻿// See https://aka.ms/new-console-template for more information
using curso_linq;
using curso_linq.Entidades;

LinqQueries queris = new LinqQueries();

// ImprimirValores(queris.TodaLaColeccion());
// ImprimirValores(queris.LibrosDespuesdel2000());
ImprimirValores(queris.LibrosPaginasMayor250YCOnLaPalabraInAction());

void ImprimirValores(IEnumerable<Book> listaLibros)
{
    Console.WriteLine("{0,-60} {1,15} {2,15}\n", "Titulo", "# PAginas", "Fecha Publicacion");

    foreach(var item in listaLibros)
    {
        Console.WriteLine("{0,-60} {1,15} {2,15}", item.Title,item.PageCount,item.PublishedDate.ToShortDateString());
    }
}

