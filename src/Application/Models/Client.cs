namespace Application.Models
{
    public class Client
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Inn { get; set; }

        public List<Request> Requests { get; set; }
    }
}
