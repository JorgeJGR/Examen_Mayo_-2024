

class DatosAlmacenaje
{
    public int Unidades { get; set; }
    public int Ubicacion { get; init; }
    public DatosAlmacenaje(int ubicacion)
    {
        Ubicacion = ubicacion;
        Unidades = 0;
    }
}