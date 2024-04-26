namespace Books_Shop_Api.Helpers
{
    public class ClientsParams
    {
        public DateTime? fromClientsDateOfBirth { get; set; }
        public DateTime? toClientsDateOfBirth { get; set; }
        public decimal? fromClientPersonalDiscount { get; set; }
        public decimal? toClientPersonalDiscount { get; set; }
        public DateTime? fromClientRegistrationDate { get; set; }
        public DateTime? toClientRegistrationDate { get; set; }
    }
}
