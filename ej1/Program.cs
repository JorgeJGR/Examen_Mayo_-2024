

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
record class Medicamento(string Nombre, double Precio, string Proveedor): IProducto
