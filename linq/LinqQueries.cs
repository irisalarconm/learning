public class LinqQueries
{
    private List<Book> librosCollection = new List<Book>();
    public LinqQueries()
    {
        using(StreamReader reader = new StreamReader("books.json"))
        {
            string json = reader.ReadToEnd();
            this.librosCollection = System.Text.Json.JsonSerializer.Deserialize<List<Book>>(json, new System.Text.Json.JsonSerializerOptions(){PropertyNameCaseInsensitive = true});
        }
    }

    public  IEnumerable<Book> TodaLaColeccion()
    {
        return librosCollection;
    }
    public IEnumerable<Book> Libros2000(){

        //EXTENSION METOD
        //return librosCollection.Where(p=> p.PublishedDate.Year > 2000);

        //query expresion

        return from l in librosCollection where l.PublishedDate.Year > 2000 select l;
    }

    public IEnumerable<Book> Libros250PaginaInAction(){
        
        //return librosCollection.Where(p=> p.PageCount > 250 && p.Title.Contains("in Action"));
        
        return from l in librosCollection where l.PageCount > 250 && l.Title.Contains("in Action") select l;
    }

    public bool TodosLosLibrosTienenStatus()
    {
        return librosCollection.All(p=> p.Status!= string.Empty);
    }

    public bool AlgunLibroDe2005()
    {
        return librosCollection.Any(p=> p.PublishedDate.Year == 2005);
    }

    public IEnumerable<Book> LibrosDePython(){
        return librosCollection.Where(p=> p.Categories.Contains("Python"));
        
        //return from l in librosCollection
    }

    public IEnumerable<Book> LibrosJavaOrdenados(){
       return librosCollection.Where(p=> p.Categories.Contains("Java")).OrderBy(p =>p.Title);
       //return from l in librosCollection where l.Categories.Contains("Java").OrderBy(l.Title);
    }

    public IEnumerable<Book> LibrosOrdenadosDescendente(){
        return librosCollection.Where(p=>p.PageCount > 450).OrderByDescending(p=>p.PageCount);
    }

    public IEnumerable<Book> librosJavaRecientes(){
        return librosCollection
        .Where(p=> p.Categories.Contains("Java"))
        .OrderByDescending(p=>p.PublishedDate)
        .Take(3);

        /*TakeLast =>t toma los ultimos elementos de la colección
        TakeWhile => toma los elementos que cumplan con esa condición.*/
    }

    public IEnumerable<Book> TercerYCuartoLibrode400Paginas(){
        return librosCollection
        .Where(p=>p.PageCount > 400)
        .Take(4).Skip(2);
    }

    public IEnumerable<Book> PrimerosTresLibros(){
        return librosCollection.Take(3)
        .Select(p=> new Book() {Title= p.Title, PCount= p.PageCount});
    }

     public int CantLibrosEntre400y500Paginas(){
        return librosCollection.Where(p=> p.PageCount >= 200 && p.PageCount <= 500).Count();
    }

    public IEnumerable<Book> Libros2005Masde500Paginas(){
        var librosDespues2005 = librosCollection.Where(p=> p.PublishedDate.Year > 2005);

        var librosConMasDe500Pag = librosCollection.Where(p=> p.PageCount > 500);

                                         //it should be for id not for title
        return librosDespues2005.Join(librosConMasDe500Pag, p=>p.Title, x=> x.Title, (p,x) =>p);
    }

}