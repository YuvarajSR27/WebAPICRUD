namespace YuvarajAPI.Models
{
    public class Yuvaraj
    {
        //Entities - which will map with DTO in CRUD operations

        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }  
        public string Phone { get; set; }
        public string Address { get; set; }
    }
}
