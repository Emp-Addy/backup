namespace demoproject.Models
{
    public class UpdateContactRequest
    {
        //ID cant be updated hence copy other fields
        public string Name { get; set; }
        public string Email { get; set; }
        public long Phone { get; set; }
        public string Address { get; set; }
    }
}
