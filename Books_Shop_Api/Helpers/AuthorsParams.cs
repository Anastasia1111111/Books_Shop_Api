namespace Books_Shop_Api.Helpers
{
    public class AuthorsParams
    {
        public DateTime? fromAuthorDateOfBirth { get; set; }
        public DateTime? toAuthorDateOfBirth { get; set; }
        public DateTime? fromAuthorDateOfDeath { get; set; }
        public DateTime? toAuthorDateOfDeath { get; set; }
    }
}
