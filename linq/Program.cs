LinqQueries queries = new LinqQueries();

//Toda la colección
//PrintValues(queries.TodaLaColeccion());

//Libros después del 2000
//PrintValues(queries.Libros2000());

//Libros de 250 paginas y titulo contenga in action
//PrintValues(queries.Libros250PaginaInAction());

//All los libros tienen status
//Console.WriteLine($"Todos los libros tienen status? {queries.TodosLosLibrosTienenStatus()}");

//Algun libro fue publicado en 2005
//Console.WriteLine($"Algun libro fue publicado en 2005? : {queries.AlgunLibroDe2005()}");

//Libros de Python
//PrintValues(queries.LibrosDePython());

//Libros de JAVA Ordenados por titulo
//PrintValues(queries.LibrosJavaOrdenados());

//Libros de mas 450 pag ordenados descendientemente
//PrintValues(queries.LibrosOrdenadosDescendente());

//Primeros tres libros de la colección de Java +  recientes
//PrintValues(queries.librosJavaRecientes());

//dos libros mayores de 400 - tercer y cuarto libro.
//PrintValues(queries.TercerYCuartoLibrode400Paginas());

//tres primeros libros titulo y paginas no mas SELECT
//PrintValues(queries.PrimerosTresLibros());

//cantidad de libros entre 200 y 500 paginas
//Console.WriteLine(queries.CantLibrosEntre400y500Paginas());

//colección que tenga libros con + de 500 paginas y publicados luego de 2005 --> retorna con un //??JOIN
 