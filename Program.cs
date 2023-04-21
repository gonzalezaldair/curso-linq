// See https://aka.ms/new-console-template for more information
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
// ImprimirValores(queris.TercerYCuartoLibroMayoresA400Paginas());
// ImprimirValores(queris.SeleccionarTituloYNumPagPrimeros3Libros());
// Console.WriteLine($" Cantidad libros Que tienen entre 200 y 500 paginas  {queris.NumeroDeLibrosEntre200Y500Pag()}");
// Console.WriteLine($" Fecha de publicacion menor de los liros  {queris.MenorFechaLibroPublicado()}");
// Console.WriteLine($" Numero de paginas libro mayor  {queris.NumeroDePaginasLibroMayor()}");
// var libroMenorPAgina = queris.LibroConMenorNumeroPAginas();
// Console.WriteLine($" { libroMenorPAgina.Title } - { libroMenorPAgina.PageCount }");

// var libroReciente = queris.MayorFechaLibroPublicado();
// Console.WriteLine($" { libroReciente.Title } - { libroReciente.PublishedDate }");


// Console.WriteLine($" Suma de PAginas {queris.SumaPAginasLibrosEntre200y500()}");
// Console.WriteLine($"Libros publicados despues del 2015  \n{queris.TituloLibrosdespuesdel2015Concatenados()}");
// Console.WriteLine($"Promedio Caracteres Titulos de los libros {queris.PromedioCaracteresTitulosLibros()}");

// Console.WriteLine($"Promedio de PAginas libros {queris.PromedioNumeroPAginas()}");



ImprimirGrupo(queris.LibrosDespuesdel2000AgrupadosporAno());

void ImprimirGrupo(IEnumerable<IGrouping<int,Book>> ListadeLibros)
{
    foreach(var grupo in ListadeLibros)
    {
        Console.WriteLine("");
        Console.WriteLine($"Grupo: { grupo.Key }");
        Console.WriteLine("{0,-60} {1, 15} {2, 15}\n", "Titulo", "N. Paginas", "Fecha publicacion");
        foreach(var item in grupo)
        {
            Console.WriteLine("{0,-60} {1, 15} {2, 15}",item.Title,item.PageCount,item.PublishedDate.Date.ToShortDateString()); 
        }
    }
}



void ImprimirValores(IEnumerable<Book> listaLibros)
{
    Console.WriteLine("{0,-60} {1,15} {2,15} \n", "Titulo", "# PAginas", "Fecha Publicacion");

    foreach(var item in listaLibros)
    {
        Console.WriteLine("{0,-60} {1,15} {2,15} ", item.Title,item.PageCount,item.PublishedDate.ToShortDateString());
    }
}

