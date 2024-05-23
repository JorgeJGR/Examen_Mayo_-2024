
class Program
{

    record Consulta3Dto(
        string Titulo,
        int Año,
        string Generos
    );

    static IEnumerable<Consulta3Dto> Consulta3() => // TODO
       
    static void Main()
    {
        Console.WriteLine(
            "Consulta 1: Mostrar titulo, año, país y valoración"
            + "\nde las películas españolas del año 2014"
            + "\nordenados descendentemente por valoración");
        var peliculasEspañolas2014 = // TODO

        Console.WriteLine(string.Join("\n", peliculasEspañolas2014) + "\n");

        Console.WriteLine(
            "Consulta 2: Mostrar titulo, año, país y duración"
            + "\nde las películas con duración entre 100 y 120 minutos, es decir,"
            + "\ncon duración mayor o igual de 100 y menor o igual de 120.");
        var peliculasDuracion = // TODO

        Console.WriteLine(string.Join("\n", peliculasDuracion) + "\n");

        Console.WriteLine(
            "Consulta 3: Mostrar titulo, año y géneros"
            + "\nde las películas que el genero sea de \"drama\", \"romance\" o \"fantástico\"");            
        Console.WriteLine(string.Join("\n", Consulta3()) + "\n");

        Console.WriteLine(
            "Consulta 4: Mostrar titulo, año y reparto"
            + "\nde las películas en las que conste un reparto con 2 actores");
        var peliculasReparto = // TODO

        Console.WriteLine(string.Join("\n", peliculasReparto) + "\n");

        Console.WriteLine(
            "Consulta 5: Calcular la duración media de las películas de cada país."
            + "\nMostrar: \"Pais: DuracionMedia\"");
        var duracionMedia = // TODO

        Console.WriteLine(string.Join("\n", duracionMedia) + "\n");

        Console.WriteLine(
            "Consulta 6: Muestra sin repeticiones todos géneros de las peliculas en cartelera usando SelectMany.");
        var generos = // TODO
        
        Console.WriteLine($"[{string.Join(", ", generos)}]\n");            
    }
}