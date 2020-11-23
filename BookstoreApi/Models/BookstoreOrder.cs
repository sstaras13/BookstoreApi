using System;

namespace BookstoreApi.Models
{
    public class BookstoreOrder
    {
        public int Id { get; set; }
        public decimal Sum { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public DateTime Date { get; set; }
    }
}
