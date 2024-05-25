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
class Farmacia
{
    private string Nombre { get; init; }
    private Almacen<IProducto> Almacen { get; init; }
    public Farmacia(string nombre)
    {
        Nombre = nombre;
        Almacen = new Almacen<IProducto>(100);
        Almacen.OnReponerStock += AvisoReposicionMedicamento;
    }
    public void AvisoReposicionMedicamento(IProducto producto)
        => Console.WriteLine($"AVISO: Mandando reposición stock {producto.Nombre} al proveedor {producto.Proveedor}");

    public void Alta(Medicamento medicamento)
        => Almacen.Alta(medicamento);

    public string MostrarInventario()
        => Almacen.ResumenInventario();

    public void Reponer(Medicamento medicamento, int unidades)
        => Almacen.AgregaStock(medicamento, unidades);

    public int Retirar(Medicamento medicamento, int unidades)
        => Almacen.RetiraStock(medicamento, unidades);

    public void Baja(Medicamento medicamento)
    => Almacen.Baja(medicamento);

    public IEnumerable<IProducto> MedicamentosAgotados()
    {
        return Almacen.Inventario
            .Where(par => par.Value.Unidades == 0)
            .Select(par => par.Key)
            .Cast<IProducto>();
    }

}