public record class Pelicula
{
    public string Titulo { get; init; }
    public int Año { get; init; }
    public int Duracion { get; init; }
    public string Pais { get; init; }
    public Staff Staff { get; init; }
    public string[] Generos { get; init; }
    public double Valoracion { get; init; }
}
