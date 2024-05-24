

class Program
{
    static void Main()
    {
        Farmacia miFarmacia = new Farmacia("Mi Farmacia");

        miFarmacia.Alta(new Medicamento("Paracetamol", 5.99, "Proveedor A"));
        miFarmacia.Alta(new Medicamento("Ibuprofeno", 7.49, "Proveedor B"));
        miFarmacia.Alta(new Medicamento("Amoxicilina", 9.99, "Proveedor C"));

        Console.WriteLine("Inventario inicial:");
        Console.WriteLine(miFarmacia.MostrarInventario());

        miFarmacia.Reponer(new Medicamento("Paracetamol", 5.99, "Proveedor A"), 20);
        miFarmacia.Reponer(new Medicamento("Amoxicilina", 9.99, "Proveedor C"), 10);

        Console.WriteLine("\nInventario después de reponer unidades:");
        Console.WriteLine(miFarmacia.MostrarInventario());

        int retiradas = miFarmacia.Retirar(new Medicamento("Paracetamol", 5.99, "Proveedor A"), 10);

        Console.WriteLine($"\nInventario después de intentar retirar 10 unidades de Paracetamol de las que se han podido retirar {retiradas}:");
        Console.WriteLine(miFarmacia.MostrarInventario());

        miFarmacia.Baja(new Medicamento("Ibuprofeno", 7.49, "Proveedor B"));

        Console.WriteLine("\nInventario después de dar de baja un medicamento:");
        Console.WriteLine(miFarmacia.MostrarInventario());

        retiradas = miFarmacia.Retirar(new Medicamento("Paracetamol", 5.99, "Proveedor A"), 12);

        Console.WriteLine($"\nInventario después de intentar retirar 12 unidades de Paracetamol de las que se han podido retirar {retiradas}:");
        Console.WriteLine(miFarmacia.MostrarInventario());

        Console.WriteLine($"\nMedicamentos agotados: {string.Join(", ", miFarmacia.MedicamentosAgotados().Select(m => m.Nombre))}");
    }
}
class Almacen<T> where T : IProducto
{
    private Dictionary<T, DatosAlmacenaje> Inventario { get; init; }
    private bool[] Ubicaciones { get; init; }
    public event Action<int> OnReponerStock;
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
}