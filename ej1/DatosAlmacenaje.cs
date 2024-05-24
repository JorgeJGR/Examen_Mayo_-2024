

class DatosAlmacenaje
{
    public int Unidades { get; init; }
    public int Ubicacion { get; init; }
    public DatosAlmacenaje(int ubicacion)
    {
        Ubicacion = ubicacion;
        Unidades = 0;
    }
}