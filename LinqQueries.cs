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
            return librosCollection.Where( libro => libro.PageCount > 250 && libro.Title.Contains("in Action")  );
        }

        public bool TodosLosLibrosTienenStatus()
        {
            return librosCollection.All( libro => libro.Status != string.Empty );
        }

        public bool LibrosPublicados2005()
        {
            return librosCollection.Any( libro => libro.PublishedDate.Year == 2005 );
        }

        public IEnumerable<Book> TodosLosLibrosQuePertenezcanAPython()
        {
            return librosCollection.Where( libro => libro.Categories.Contains("Python")  );
        }
    }
}