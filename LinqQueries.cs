using curso_linq.Entidades;

namespace curso_linq
{
    public class LinqQueries
    {
        private List<Book> librosCollection = new List<Book>();

        public LinqQueries()
        {
            using (StreamReader reader = new StreamReader("books.json"))
            {
                string json = reader.ReadToEnd();
                this.librosCollection = System.Text.Json.JsonSerializer.Deserialize<List<Book>>(json, new System.Text.Json.JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            }
        }


        public IEnumerable<Book> TodaLaColeccion()
        {
            return librosCollection;
        }

        public IEnumerable<Book> LibrosDespuesdel2000()
        {
            // extension method
            // return librosCollection.Where( libro => libro.PublishedDate.Year > 2000  );

            return from l in librosCollection where l.PublishedDate.Year > 2000 select l;
        }

        public IEnumerable<Book> LibrosPaginasMayor250YCOnLaPalabraInAction()
        {
            return librosCollection.Where(libro => libro.PageCount > 250 && libro.Title.Contains("in Action"));
        }

        public bool TodosLosLibrosTienenStatus()
        {
            return librosCollection.All(libro => libro.Status != string.Empty);
        }

        public bool LibrosPublicados2005()
        {
            return librosCollection.Any(libro => libro.PublishedDate.Year == 2005);
        }

        public IEnumerable<Book> TodosLosLibrosQuePertenezcanAPython()
        {
            return librosCollection.Where(libro => libro.Categories.Contains("Python"));
        }

        public IEnumerable<Book> TodosLosLibrosQuePertenezcanAJavaOrdenadosPorNombre()
        {
            return librosCollection.Where(libro => libro.Categories.Contains("Java")).OrderBy(libro => libro.Title);
        }

        public IEnumerable<Book> TodosLosLibrosQueTienenMas450Paginas()
        {
            return librosCollection.Where(libro => libro.PageCount > 450).OrderByDescending(libro => libro.PageCount);
        }

        public IEnumerable<Book> TresLibrosRecientesCategorizadosEnJava()
        {
            return librosCollection.Where(libro => libro.Categories.Contains("Java")).OrderByDescending(libro => libro.PublishedDate).Take(3);
        }

        public IEnumerable<Book> TercerYCuartoLibroMayoresA400Paginas()
        {
            return librosCollection.Where(libro => libro.PageCount > 400).Take(4).Skip(2);
        }

        public IEnumerable<Book> SeleccionarTituloYNumPagPrimeros3Libros()
        {
            return librosCollection.Take(3).Select(libro => new Book { Title = libro.Title, PageCount = libro.PageCount });
        }

        public long NumeroDeLibrosEntre200Y500Pag()
        {
            // return librosCollection.Where( libro => libro.PageCount >= 200 && libro.PageCount <= 500).LongCount();
            return librosCollection.LongCount(libro => libro.PageCount >= 200 && libro.PageCount <= 500);
        }


        public DateTime MenorFechaLibroPublicado()
        {
            // return librosCollection.Where( libro => libro.PageCount >= 200 && libro.PageCount <= 500).LongCount();
            return librosCollection.Min(libro => libro.PublishedDate);
        }

        public int NumeroDePaginasLibroMayor()
        {
            // return librosCollection.Where( libro => libro.PageCount >= 200 && libro.PageCount <= 500).LongCount();
            return librosCollection.Max(libro => libro.PageCount);
        }

        public Book LibroConMenorNumeroPAginas()
        {
            return librosCollection.Where(p => p.PageCount > 0).MinBy(p => p.PageCount);
        }

        public Book MayorFechaLibroPublicado()
        {
            // return librosCollection.Where( libro => libro.PageCount >= 200 && libro.PageCount <= 500).LongCount();
            return librosCollection.MaxBy(libro => libro.PublishedDate);
        }

        public int SumaPAginasLibrosEntre200y500()
        {
            // return librosCollection.Where( libro => libro.PageCount >= 200 && libro.PageCount <= 500).LongCount();
            return librosCollection.Where(libro => libro.PageCount >= 0 && libro.PageCount <= 500).Sum(l => l.PageCount);
        }

        public string TituloLibrosdespuesdel2015Concatenados()
        {
            // return librosCollection.Where( libro => libro.PageCount >= 200 && libro.PageCount <= 500).LongCount();
            return librosCollection
            .Where(libro => libro.PublishedDate.Year > 2015)
            .Aggregate("", (TitulosLibros, next) =>
            {
                if (TitulosLibros != string.Empty)
                    TitulosLibros += " \n " + next.Title;
                else
                    TitulosLibros += next.Title;

                return TitulosLibros;
            });
        }


        public double PromedioCaracteresTitulosLibros()
        {
            return librosCollection.Average(l => l.Title.Length);
        }

        public double PromedioNumeroPAginas()
        {
            return librosCollection.Where(l => l.PageCount > 0).Average(l => l.PageCount);
        }

        public IEnumerable<IGrouping<int, Book>> LibrosDespuesdel2000AgrupadosporAno()
        {
            return librosCollection.Where(p => p.PublishedDate.Year >= 2000).GroupBy(p => p.PublishedDate.Year);
        }

        public ILookup<char, Book> DiccionariosDeLibrosPorLetra()
        {
            return librosCollection.ToLookup(p => p.Title[0], p => p);
        }

        public IEnumerable<Book> LibrosDespuesdel2005conmasde500Pags()
        {
            var LibrosDepuesdel2005 = librosCollection.Where(p => p.PublishedDate.Year > 2005);

            var LibrosConMasde500pag = librosCollection.Where(p => p.PageCount > 500);

            return LibrosDepuesdel2005.Join(LibrosConMasde500pag, p => p.Title, x => x.Title, (p, x) => p);
        }

    }
}