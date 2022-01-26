// See https://aka.ms/new-console-template for more information
using Domain;
using Persistence;
using System;
using System.Collections.Generic;

namespace Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Conexion Ok");
            AddContact();
        }
        //Se crea una referencia a la interface de contact
        private static IRepositoryContact _repoContact = new RepositoryContact(new Persistence.AppContext());
        private static void AddContact()
        {
            console.WriteLine("Call method ok");
            var contact = new Contact
            {
                Name = "Joan",
                ProfileImage = "img",
                Email = "joan@example.com",
                BirthDate = Convert.ToDateTime("2020-05-04"),
                PhoneNumber = "12345678",
                Address = "Cll 22-45"
            };
            _repoContact.AddContact(contact);
        }
    }
}



