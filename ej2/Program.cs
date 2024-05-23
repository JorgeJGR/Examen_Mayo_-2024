class Program
{

    record Consulta3Dto(
        string Titulo,
        int Año,
        string Generos
    );

    static IEnumerable<Consulta3Dto> Consulta3() 
                                        => Cartelera.Peliculas
                                        .Where(p => p.Generos.Contains("drama") ||
                                                    p.Generos.Contains("romance") ||
                                                    p.Generos.Contains("fantastico"))
                                        .Select(p => new Consulta3Dto
                                        (
                                            p.Titulo,
                                            p.Año,
                                            $"[{string.Join(", ", p.Generos)}]"
                                        ));                                                                      
       
    static void Main()
    {
        Console.Clear();
        Console.WriteLine(
            "Consulta 1: Mostrar titulo, año, país y valoración"
            + "\nde las películas españolas del año 2014"
            + "\nordenados descendentemente por valoración");
        var peliculasEspañolas2014 = Cartelera.Peliculas
                                                    .Where(p => p.Pais == "España" && p.Año == 2014)
                                                    .OrderByDescending(p => p.Valoracion)
                                                    .Select(p => new
                                                    {
                                                        p.Titulo,
                                                        p.Año,
                                                        p.Pais,
                                                        p.Valoracion
                                                    });

        Console.WriteLine(string.Join("\n", peliculasEspañolas2014) + "\n");

        Console.WriteLine(
            "Consulta 2: Mostrar titulo, año, país y duración"
            + "\nde las películas con duración entre 100 y 120 minutos, es decir,"
            + "\ncon duración mayor o igual de 100 y menor o igual de 120.");
        var peliculasDuracion = Cartelera.Peliculas
                                                .Where(p => p.Duracion >= 100 && p.Duracion <= 120)
                                                .Select(p => new
                                                {
                                                    p.Titulo,
                                                    p.Año,
                                                    p.Pais,
                                                    p.Duracion
                                                });

        Console.WriteLine(string.Join("\n", peliculasDuracion) + "\n");

        Console.WriteLine(
            "Consulta 3: Mostrar titulo, año y géneros"
            + "\nde las películas que el genero sea de \"drama\", \"romance\" o \"fantástico\"");            
        Console.WriteLine(string.Join("\n", Consulta3()) + "\n");

        Console.WriteLine(
            "Consulta 4: Mostrar titulo, año y reparto"
            + "\nde las películas en las que conste un reparto con 2 actores");
        var peliculasReparto = Cartelera.Peliculas
                                            .Where(p => p.Staff.Reparto.Length == 2)
                                            .Select(p => new
                                            {
                                                p.Titulo,
                                                p.Año,
                                                Reparto = $"[ {string.Join(" ", p.Staff.Reparto)} ]"
                                            });

        Console.WriteLine(string.Join("\n", peliculasReparto) + "\n");

        Console.WriteLine(
            "Consulta 5: Calcular la duración media de las películas de cada país."
            + "\nMostrar: \"Pais: DuracionMedia\"");
        var duracionMedia = string.Join("", Cartelera.Peliculas
                                                        .GroupBy(p => p.Pais)
                                                        .Select(g => $"{g.Key}: {g.Average(p => p.Duracion):F1} \n"));

        Console.WriteLine(string.Join("\n", duracionMedia) + "\n");

        Console.WriteLine(
            "Consulta 6: Muestra sin repeticiones todos géneros de las peliculas en cartelera usando SelectMany.");
        var generos = Cartelera.Peliculas
                                    .SelectMany(p => p.Generos)
                                    .Distinct();
        Console.WriteLine($"[{string.Join(", ", generos)}]\n");            
    }
}