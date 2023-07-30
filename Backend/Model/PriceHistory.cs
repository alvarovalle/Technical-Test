namespace Backend.Model;

public class PriceHistory
{
    public int ListingId { get; private set; }
    public int Price_eur { get; private set; }
    public DateTime Created_date { get; private set; }
    public PriceHistory(int price_eur, DateTime created_date)
    {
        Price_eur = price_eur;
        Created_date = created_date;
    }
}