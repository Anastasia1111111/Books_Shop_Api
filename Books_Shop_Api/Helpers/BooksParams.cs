using Books_Shop_Api.Entities;

namespace Books_Shop_Api.Helpers
{
        public class BooksParams
        {
        public int? bookAuthorId { get; set; }
        public int? fromBookPageNumber { get; set; }
        public int? toBookPageNumber { get; set; }
        public DateTime? fromBookDateOfPublication { get; set; }
        public DateTime? toBookDateOfPublication { get; set; }
        public string? bookBinding { get; set; }
        public string? bookGenre { get; set; }
        public decimal? fromBookPrice { get; set; }
        public decimal? toBookPrice { get; set; }
    }
}
