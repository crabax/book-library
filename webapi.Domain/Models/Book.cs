using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Domain.Models
{
    [Table("books")]
    public class Book
    {
        public Book()
        {
            Title = "";
            FirstName = "";
            LastName = "";
        }

        [Column("book_id")]
        public int Id { get; set; }

        [Column("title", TypeName = "varchar(100)")]
        public string Title { get; set; }

        [Column("first_name", TypeName = "varchar(50)")]
        public string FirstName { get; set; }

        [Column("last_name", TypeName = "varchar(50)")]
        public string LastName { get; set; }

        [Column("total_copies")]
        public int TotalCopies { get; set; }

        [Column("copies_in_use")]
        public int CopiesInUse { get; set; }

        [Column("type", TypeName = "varchar(50)")]
        public string? Type { get; set; }

        [Column("isbn", TypeName = "varchar(80)")]
        public string? ISBN { get; set; }

        [Column("category", TypeName = "varchar(50)")]
        public string? Category { get; set; }
    }
}
