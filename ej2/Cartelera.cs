public static class Cartelera
{
    public static IEnumerable<Pelicula> Peliculas
    {
        get
        {
            yield return new Pelicula()
            {
                Titulo = "Legado en los huesos",
                Año = 2019,
                Duracion = 99,
                Pais = "España",
                Staff = new Staff()
                {
                    Productora = "Atresmedia",
                    Director = "Fernando González",
                    Reparto = new string[] { "Marta Etura", "Leonardo Sbaraglia", "Elvira Mínguez", "Imanol Arias" }
                },
                Generos = new string[] { "intriga", "crimen" },
                Valoracion = 6.2
            };
            yield return new Pelicula()
            {
                Titulo = "El Niño",
                Año = 2014,
                Duracion = 135,
                Pais = "España",
                Staff = new Staff()
                {
                    Productora = "Telecinco Cinema",
                    Director = "Daniel Monzón",
                    Reparto = new string[] { "Jesús Castro", "Luis Tosar", "Eduard Fernández", "Jesús Carroza" }
                },
                Generos = new string[] { "intriga", "accion", "drama", "policiaca" },
                Valoracion = 6.0
            };
            yield return new Pelicula()
            {
                Titulo = "Ocho apellidos vascos",
                Año = 2014,
                Duracion = 98,
                Pais = "España",
                Staff = new Staff()
                {
                    Productora = "Telecinco Cinema",
                    Director = "Emilio Martínez-Lázaro",
                    Reparto = new string[] { "Dani Rovira", "Clara Lago", "Carmen Machi", "Karra Elejalde" }
                },
                Generos = new string[] { "comedia", "romance", "crimen" },
                Valoracion = 6.95
            };
            yield return new Pelicula()
            {
                Titulo = "Todos los caminos",
                Año = 2018,
                Duracion = 98,
                Pais = "España",
                Staff = new Staff()
                {
                    Productora = "Costas Films",
                    Director = "Paola García Costas",
                    Reparto = new string[] { "Dani Rovira", "Clara Lago" }
                },
                Generos = new string[] { "documental" },
                Valoracion = 5.15
            };
            yield return new Pelicula()
            {
                Titulo = "El pasajero",
                Año = 2018,
                Duracion = 105,
                Pais = "Estados Unidos",
                Staff = new Staff()
                {
                    Productora = "Lionsgate",
                    Director = "Jaume Collet-Serra",
                    Reparto = new string[] { "Liam Neeson", "Patrick Wilson" }
                },
                Generos = new string[] { "intriga", "accion" },
                Valoracion = 5.75
            };
            yield return new Pelicula()
            {
                Titulo = "Venganza bajo cero",
                Año = 2019,
                Duracion = 118,
                Pais = "Reino Unido",
                Staff = new Staff()
                {
                    Productora = "Lionsgate",
                    Director = "Hans Petter Moland",
                    Reparto = new string[] { "Liam Neeson", "Laura Dern", "Emmy Rossum" }
                },
                Generos = new string[] { "intriga", "comedia", "accion" },
                Valoracion = 4.7
            };
            yield return new Pelicula()
            {
                Titulo = "Desaparecido en Venice Beach",
                Año = 2017,
                Duracion = 94,
                Pais = "Estados Unidos",
                Staff = new Staff()
                {
                    Productora = "Voltage Pictures",
                    Director = "Marc Cullen, Robb Cullen",
                    Reparto = new string[] { "Bruce Willis", "Jason Momoa", "Famke Janssen" }
                },
                Generos = new string[] { "intriga", "comedia", "accion" },
                Valoracion = 4.8
            };
            yield return new Pelicula()
            {
                Titulo = "Aquaman",
                Año = 2018,
                Duracion = 139,
                Pais = "Estados Unidos",
                Staff = new Staff()
                {
                    Productora = "Warner Bros",
                    Director = "James Wan",
                    Reparto = new string[] { "Jason Momoa", "Amber Heard", "Patrick Wilson", "Willem Dafoe" }
                },
                Generos = new string[] { "accion", "fantastico" },
                Valoracion = 4.6
            };
            yield return new Pelicula()
            {
                Titulo = "El rey león",
                Año = 2019,
                Duracion = 118,
                Pais = "Estados Unidos",
                Staff = new Staff()
                {
                    Productora = "Walt Disney Pictures",
                    Director = "Jon Favreau",
                    Reparto = new string[] { "Donald Glover", "Beyoncé", "James Earl Jones", "Chiwetel Ejiofor" }
                },
                Generos = new string[] { "animacion", "aventuras", "drama" },
                Valoracion = 6.8
            };
            yield return new Pelicula()
            {
                Titulo = "Toy Story 4",
                Año = 2019,
                Duracion = 100,
                Pais = "Estados Unidos",
                Staff = new Staff()
                {
                    Productora = "Pixar Animation Studios",
                    Director = "Josh Cooley",
                    Reparto = new string[] { "Tom Hanks", "Tim Allen", "Annie Potts", "Tony Hale" }
                },
                Generos = new string[] { "animacion", "comedia", "aventuras" },
                Valoracion = 7.3
            };            
        }
    }
}
