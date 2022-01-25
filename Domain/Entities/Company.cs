namespace Domain;

public class Company
{
    /*Se implemento una nueva entidad Company con sus atributos propios y la primary key, 
    que se realaciona con la entidad de Contact */
    public int Id { get; set; }
    public string CompanyName { get; set; }
    public string Nit { get; set; }
    public string PhoneNumber { get; set; }
    public string Address { get; set; }
    //Propiedad navigacional hacia la tabla Contact
     public List<Contact> Contacts { get; set; }
}