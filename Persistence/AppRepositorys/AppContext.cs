using Microsoft.EntityFrameworkCore;
using Domain;


namespace Persistence;

public class AppContext : DbContext
{

    //Se crea la propiedad DbSet de la entidad Contact de la capa Domain que permite aplicar el CRUD sobre la DB
    public DbSet<Contact> Contacts { get; set; }

    // Se crea la función OnConfiguring que permite la conexión y configuración con la base de datos
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB; Initial Catalog=SIAPprojectData");
        }
    }

}