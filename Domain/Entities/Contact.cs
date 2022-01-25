namespace Domain;
public class Contact
{
    /* Los nombres de los atributos se escribiran en ingles con notación Pascal.
    Se añadio el atributo Id de typo int como Primary Key de la tabla
    */
    public int Id { get; set; }
    public string Name { get; set; }
    //Llave foranea de la entidad Company
    public int CompanyId { get; set; }
    public string ProfileImage { get; set; }
    public string Email { get; set; }
    public DateTime BirthDate { get; set; }
    public string PhoneNumber { get; set; }
    public string Address { get; set; }
}

