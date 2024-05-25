using System.Text;

class Almacen<T> where T : IProducto
{
    public Dictionary<T, DatosAlmacenaje> Inventario { get; init; }
    private bool[] Ubicaciones { get; init; }
    public event Action<T> OnReponerStock;
    public Almacen(int ubicacionesDisponibles)
    {
        Ubicaciones = new bool[ubicacionesDisponibles];
        for (int i = 0; i < ubicacionesDisponibles; i++)
            Ubicaciones[i] = false;
        Inventario = new Dictionary<T, DatosAlmacenaje>();
    }
    private bool EstaEnAlmacen(T producto) => Inventario.ContainsKey(producto);
    public void Alta(T producto)
    {
        bool estaEnAlmacen = EstaEnAlmacen(producto);
        if (estaEnAlmacen)
            throw new InvalidOperationException("El producto ya está dado de alta en el almacén");
        int ubicacionLibre = 0;
        bool encontradaUbicacion = false;
        for (int i = 0; i < Ubicaciones.Length; i++)
        {
            if (Ubicaciones[i] == false)
            {
                encontradaUbicacion = true;
                ubicacionLibre = i;
                break;
            }
        }
        if (!encontradaUbicacion)
            throw new InvalidOperationException("No hay ubicaciones libres en el almacén");
        Inventario[producto] = new DatosAlmacenaje(ubicacionLibre);
        Ubicaciones[ubicacionLibre] = true;
    }
    public void Baja(T producto)
    {
        bool estaEnAlmacen = EstaEnAlmacen(producto);
        if (!estaEnAlmacen)
            throw new InvalidOperationException("El producto no está en el almacén");
        Ubicaciones[Inventario[producto].Ubicacion] = false;
        Inventario.Remove(producto);
    }

    public void AgregaStock(T producto, int unidades)
    {
        bool estaEnAlmacen = EstaEnAlmacen(producto);
        if (!estaEnAlmacen)
            throw new InvalidOperationException("El producto no está en el almacén");
        Inventario[producto].Unidades += unidades;
    }

    public int RetiraStock(T producto, int unidades)
    {
        int unidadesRetiradas = 0;
        bool estaEnAlmacen = EstaEnAlmacen(producto);
        if (!estaEnAlmacen)
            throw new InvalidOperationException("El producto no está en el almacén");
        if (Inventario[producto].Unidades > unidades)
        {
            Inventario[producto].Unidades = Inventario[producto].Unidades - unidades;
            unidadesRetiradas = unidades;
        }
        else 
        {
            unidadesRetiradas = Inventario[producto].Unidades;
            Inventario[producto].Unidades = 0;
            OnReponerStock(producto);
        }
        return unidadesRetiradas;
    }
    public string ResumenInventario()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendFormat("{0,-20} {1,10} {2,10} {3,10}\n", "Nombre", "Ubicación", "Unidades", "Precio");
        string linea = "";
        for (int i = 0; i < sb.Length; i++)
            linea += "-";
        sb.AppendLine(linea);
        double total = 0;
        foreach (KeyValuePair<T, DatosAlmacenaje> par in Inventario)
        {
            sb.AppendLine($"{par.Key.Nombre,-20}{par.Value.Ubicacion,10}{par.Value.Unidades,12}{par.Key.Precio,11}");
            total += par.Key.Precio * par.Value.Unidades;
        }
        sb.AppendLine(linea);
        sb.AppendLine($"Valor total: {total:F2}");
        return sb.ToString();
    }
}