using Books_Shop_Api.Entities;

namespace Books_Shop_Api.Helpers
{
    public class SalesRegistrationParams
    {
        public int? SaleRegistrationBookId { get; set; }
        public int? SaleRegistrationEmployeeId { get; set; }
        public int? SaleRegistrationClientId { get; set; }
        public DateTime? fromSaleRegistrationDateOfPurchase { get; set; }
        public DateTime? toSaleRegistrationDateOfPurchase { get; set; }
        public decimal? fromSaleRegistrationTheFinalPrice { get; set; }
        public decimal? toSaleRegistrationTheFinalPrice { get; set; }
    }
}
