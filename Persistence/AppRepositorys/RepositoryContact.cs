using Domain;

namespace Persistence;
public class RepositoryContact:IRepositoryContact
{
    //Inyeccion de dependencias para definir el contexto con el que se va a trbajar
    private readonly AppContext _appContext;
    public RepositoryContact(AppContext appContext)
    {
        _appContext = appContext;
    }
    //Espacio de codigo  donde se implementaron los metodos de la interface
    Contact IRepositoryContact.AddContact(Contact contact) //metodo para agrgar un nuevo registro en la BD
    {
        var contactAdd = _appContext.Contacts.Add(contact);
        _appContext.SaveChanges();
        return contactAdd.Entity;
    }
    void IRepositoryContact.DeleteContact(int idContact) //metodo que va a elimar un registro segun el id ingresado.
    {
        var contactFound = _appContext.Contacts.FirstOrDefault(c => c.Id == idContact); // Con la ayuda de Linq se ubica el primer registro que tenga el id que se pasa por parametro.
        if (contactFound == null) return;
        _appContext.Contacts.Remove(contactFound);
        _appContext.SaveChanges();
    }
    IEnumerable<Contact> IRepositoryContact.GetAllContact() //metodo para obtener todos los registros
    {
        return _appContext.Contacts;
    }
    Contact IRepositoryContact.GetContact(int idContact) // metodo para obtener un registro segun su id
    {
        return  _appContext.Contacts.FirstOrDefault(c => c.Id == idContact);
    }
    Contact IRepositoryContact.UpdateContact(Contact contact) // metodo que actualiza el registro
    {
        var contactFound = _appContext.Contacts.FirstOrDefault(c => c.Id == contact.Id);
        if (contactFound != null)
        {
            contactFound.Name = contact.Name;
            // contactFound.CompanyId = contact.CompanyId;
            contactFound.ProfileImage = contact.ProfileImage;
            contactFound.Email = contact.Email;
            contactFound.BirthDate = contact.BirthDate;
            contactFound.PhoneNumber = contact.PhoneNumber;
            contactFound.Address = contact.Address;
            _appContext.SaveChanges();
           
        }
         return contactFound;
    }
}