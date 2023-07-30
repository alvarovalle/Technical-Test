namespace Backend.Model;

public class PostalAddress
{
    public string Street_address { get; private set; }
    public string Postal_code { get; private set; }
    public string City { get; private set; }
    public string Country { get; private set; }
    public PostalAddress(string street_address, string postal_code, string city, string country)
    {
        Street_address = street_address;
        Postal_code = postal_code;
        City = city;
        Country = country;
    }
}