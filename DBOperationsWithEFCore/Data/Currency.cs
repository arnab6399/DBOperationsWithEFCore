namespace DBOperationsWithEFCore.Data
{
    public class Currency
    {
        public int CurrencyId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public ICollection<BookPrice> BookPrice { get; set; }
    }
}
