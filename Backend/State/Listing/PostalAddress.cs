namespace Backend.State.Listing;

public class PostalAddress
{
    public int Id { get; set; }
    public string Street_address { get; set; }
    public string Postal_code { get; set; }
    public string City { get; set; }
    public string Country { get; set; }
    public int ListingId { get; set; }
    
}