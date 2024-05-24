

using System.Text;

class Almacen<T> where T : IProducto
{
    private Dictionary<T, DatosAlmacenaje> Inventario { get; init; }
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
    private void Alta(T producto)
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
    private void Baja(T producto)
    {
        bool estaEnAlmacen = EstaEnAlmacen(producto);
        if (!estaEnAlmacen)
            throw new InvalidOperationException("El producto no está en el almacén");
        Ubicaciones[Inventario[producto].Ubicacion] = false;
        Inventario.Remove(producto);
    }

    private void AgregaStock(T producto, int unidades)
    {
        bool estaEnAlmacen = EstaEnAlmacen(producto);
        if (!estaEnAlmacen)
            throw new InvalidOperationException("El producto no está en el almacén");
        Inventario[producto].Unidades += unidades;
    }

    private int RetiraStock(T producto, int unidades)
    {
        int unidadesRetiradas;
        bool estaEnAlmacen = EstaEnAlmacen(producto);
        if (!estaEnAlmacen)
            throw new InvalidOperationException("El producto no está en el almacén");
        if (Inventario[producto].Unidades > unidades)
        {
            Inventario[producto].Unidades += unidades;
            unidadesRetiradas = unidades;
        }
        else
        {
            unidadesRetiradas = unidades - Inventario[producto].Unidades;
            Inventario[producto].Unidades = 0;
            OnReponerStock(producto);
        }
        return unidadesRetiradas;
    }
    private string ReumenInventario()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendFormat("{0,-20} {1,-10} {2,-10} {3,-10}", "Nombre", "Ubicación", "Unidades", "Precio");
        string linea = "";
        for (int i = 0; i < sb.Length; i++)
            linea += "-";
        sb.AppendLine(linea);
        for (int i = 0; i < Inventario.Count; i++)
        {
            sb.AppendLine($"{0,-20} {1,-10} {2,-10} {3,-10}", Inventario[i].)
        }

        return sb.ToString();
    }
}