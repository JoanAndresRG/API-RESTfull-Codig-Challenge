using Domain;

namespace Persistence;

public interface IRepositoryContact
{
    //Se crear una interfaz donde iran las firmas de los metodos que se implementaran en RepositoryContact
    IEnumerable<Contact> GetAllContact();
    Contact AddContact(Contact contact);
    Contact UpdateContact(Contact contact);
    void DeleteContact(string phoneContact);
    Contact GetContact(string phoneContact);
}