using AppButaca.Infraestructura.Datos.Contextos;


namespace AppButaca.Infraestructura.Datos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            

            Console.WriteLine("Creando la DB si no existe...");
            ButacasContexto db = new ButacasContexto();
            db.Database.EnsureCreated();
            Console.WriteLine("Listo!!");
            Console.ReadKey();




    }
    }
}