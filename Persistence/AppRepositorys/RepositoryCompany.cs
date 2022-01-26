using Domain;

namespace Persistence;
public class RepositoryCompany:IRepositoryCompany
{
    //Inyeccion de dependencias para definir el contexto con el que se va a trbajar
    private readonly AppContext _appContext;
    public RepositoryCompany(AppContext appContext)
    {
        _appContext = appContext;
    }
    //Espacio de codigo  donde se implementaron los metodos de la interface
    Company IRepositoryCompany.AddCompany(Company company) //metodo para agrgar un nuevo registro en la BD
    {
        var companyAdd = _appContext.Companys.Add(company);
        _appContext.SaveChanges();
        return companyAdd.Entity;
    }
    void IRepositoryCompany.DeleteCompany(int idCompany) //metodo que va a elimar un registro segun el id ingresado.
    {
        var companyFound = _appContext.Companys.FirstOrDefault(c => c.Id == idCompany); // Con la ayuda de Linq se ubica el primer registro que tenga el id que se pasa por parametro.
        if (companyFound == null) return;
        _appContext.Companys.Remove(companyFound);
        _appContext.SaveChanges();
    }
    IEnumerable<Company> IRepositoryCompany.GetAllCompany() //metodo para obtener todos los registros
    {
        return _appContext.Companys;
    }
    Company IRepositoryCompany.GetCompany(int idCompany) // metodo para obtener un registro segun su id
    {
        return  _appContext.Companys.FirstOrDefault(c => c.Id == idCompany);
    }
    Company IRepositoryCompany.UpdateCompany(Company company) // metodo que actualiza el registro
    {
        var companyFound = _appContext.Companys.FirstOrDefault(c => c.Id == company.Id);
        if (companyFound != null)
        {
            companyFound.CompanyName = company.CompanyName;
            companyFound.Nit = company.Nit;
            companyFound.PhoneNumber = company.PhoneNumber;
            companyFound.Address = company.Address;
            _appContext.SaveChanges();
           
        }
         return companyFound;
    }
}