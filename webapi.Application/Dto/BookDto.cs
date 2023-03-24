namespace webapi.Application.Dto
{
    public class BookDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Publisher { get; set; }
        public string Authors { get; set; }
        public string Type { get; set; }
        public string ISBN { get; set; }
        public string Category { get; set; }
        public string AvailableCopies { get; set; }
    }
}
