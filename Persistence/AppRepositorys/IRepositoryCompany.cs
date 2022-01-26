using Domain;

namespace Persistence;

public interface IRepositoryCompany
{
    //Se crear una interfaz donde iran las firmas de los metodos que se implementaran en RepositoryCompany
    IEnumerable<Company> GetAllCompany();
    Company AddCompany(Company company);
    Company UpdateCompany(Company company);
    void DeleteCompany(int idCompany);
    Company GetCompany(int idCompany);
}