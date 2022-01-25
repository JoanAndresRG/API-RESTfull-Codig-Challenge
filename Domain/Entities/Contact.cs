namespace Domain
{

    public class Contact
    {
        // Los nombres de los atributos se escribiran en ingles con notación Pascal.
        public int Id { get; set; }
        public string Name { get; set; }
        public string ProfileImage { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
    }
}
