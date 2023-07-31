namespace Backend.Model;

public class PostalAddress
{
    public int Id { get; private set;}
    public string Street_address { get; private set; }
    public string Postal_code { get; private set; }
    public string City { get; private set; }
    public string Country { get; private set; }
    public int ListingId { get; private set;}
    public PostalAddress(int id, int listingId, string street_address, string postal_code, string city, string country)
    {
        Id = id;
        ListingId = listingId;
        Street_address = street_address;
        Postal_code = postal_code;
        City = city;
        Country = country;
    }
}