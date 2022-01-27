// See https://aka.ms/new-console-template for more information
using Domain;
using Persistence;

namespace Consola
{
    class Program
    {
        //Se crea una referencia a la interface de contact
        private static IRepositoryContact _repoContact = new RepositoryContact(new Persistence.AppContext());
        /*Este es en entry point de la API,  contiene todas las funcionalides de las operaciones CRUD sobre la capa Domain en la 
        * entidad Contact, aparte de esta entidad tambien se creo una entidad  Company que que su primary key se pasa como atributo
        * a la entidad Contact, se crearon unos registros quemados para Company, a continuacion se desplegara un menu con todas las
        * indicaciones para modificar, eliminar, agregar y buscar registros que se encuentran en una base de datos local (localdb) en la 
        * documentacionse especifica mas sobre su implemantacion. 
        * NOTA: la interface no implementa todas las verificaciones de entrada, se espera que el usuario ingrese los datos correctos 
        * el campo Id es autoincremeltal de typo int.
        * Gracias 
        */
        static void Main(string[] args)
        {
            Console.WriteLine("\n<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< Welcome Backend Coding Challenge >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
            Menu();
        }

        private static void Menu()
        {

            Console.WriteLine("SIAP management:\nWhat would you like to do?");
            Console.WriteLine("\n1_Create a new contact: (1)\n2_Edit a contact: (2)\n3_Search for a contact by phone number: (3)\n4_Delete a contact: (4)\n5_Show all contacts. (5)\n");
            try
            {
                Console.Write("Please choose an option: ");
                int option = Convert.ToInt32(Console.ReadLine());
                while (option < 0 || option > 5)
                {
                    // Console.Write("Please choose an option: ");
                    // Convert.ToInt32(Console.ReadLine());
                    Menu();
                }
                switch (option)
                {
                    case 1: AddContact(); break;
                    case 2:
                        {
                            Console.Write("Please enter a phone number: ");
                            var contactPhone = Console.ReadLine();
                            EditContact(contactPhone);
                            break;
                        }
                    case 3:
                        {
                            Console.Write("Please enter a phone number: ");
                            var contactNumber = Console.ReadLine();
                            SearchContact(contactNumber);
                            break;
                        }
                    case 4:
                        {
                            Console.Write("Please enter a phone number: ");
                            string contactNumber = Console.ReadLine();
                            DelateContacts(contactNumber);
                            break;
                        }
                    case 5: GetAllContact(); break;
                    default:
                        Console.WriteLine("Thank you..");
                        break;
                }

            }
            catch (System.Exception e)
            {

                Console.WriteLine("Error: " + e.Message);
                Menu();
            }

        }
        //Metodo para agrgar un nuevo contatcto
        private static void AddContact()
        {
            Console.Write("Enter contact name: ");
            string name = Console.ReadLine();
            Console.Write("Enter contact CompanyId (1,2,3,4... one number): ");
            string companyId = Console.ReadLine();
            Console.Write("Enter contact profileImage (url format): ");
            string profileImage = Console.ReadLine();
            Console.Write("Enter contact email: ");
            string email = Console.ReadLine();
            Console.Write("Enter contact birthDate ('YYYY-mm-dd' This format): ");
            string birthDate = Console.ReadLine();
            Console.Write("Enter contact phoneNumber: ");
            string phoneNumber = Console.ReadLine();
            Console.Write("Enter contact address: ");
            string address = Console.ReadLine();
            var contact = new Contact
            {
                Name = name,
                CompanyId = Convert.ToInt32(companyId),
                ProfileImage = profileImage,
                Email = email,
                BirthDate = Convert.ToDateTime(birthDate),
                PhoneNumber = phoneNumber,
                Address = address
            };
            _repoContact.AddContact(contact);
            Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
            Console.WriteLine($"Contact with the name { contact.Name } was created successfully ");
            Console.WriteLine("<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<");
            Menu();
        }
        //Metodo para modificar los valores de un contacto
        private static void EditContact(string contactNumP)
        {
            var contact = _repoContact.GetContact(contactNumP);
            if (contact != null)
            {
                Console.Write("Please enter new name: ");
                contact.Name = Console.ReadLine();
                Console.Write("Please enter new email: ");
                contact.Email = Console.ReadLine();
                Console.Write("Please enter new Address: ");
                contact.Address = Console.ReadLine();
                _repoContact.UpdateContact(contact);
                Menu();
            }
            else
            {
                Console.Write("Contact no found");
            }
            Menu();
        }
        //Metodo para buscar un contato por numero de telefono
        private static void SearchContact(string phoneContact)
        {
            var contact = _repoContact.GetContact(phoneContact);
            if (contact != null)
            {
                Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
                Console.WriteLine($"-Name: {contact.Name}\n-Email: {contact.Email}\n-BirthDate: {contact.BirthDate}");
                Console.WriteLine("<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<");
                Menu();
            }
            else
            {
                Console.WriteLine("<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<");
                Console.WriteLine("\nContact no found\n");
                Console.WriteLine("<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<");
                Menu();
            }
        }
        //Metodo para borrar registro
        private static void DelateContacts(string phoneContact)
        {
            _repoContact.DeleteContact(phoneContact);
            Console.WriteLine("<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<");
            Console.WriteLine("Contact deleted successfully");
            Console.WriteLine("<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<");
            Menu();
        }
        //Metodo para llamar todos los registros de Contact
        private static void GetAllContact()
        {
            var contacts = _repoContact.GetAllContact();
            foreach (var contact in contacts)
            {
                Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
                Console.WriteLine($"-Name: {contact.Name}\n-Email: {contact.Email}\n-BirthDate: {contact.BirthDate}");
                Console.WriteLine("<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<");
            }
            Menu();
        }
    }
}