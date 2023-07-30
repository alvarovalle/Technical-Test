namespace Backend.State;

public class Listing
{
    public Listing(int id, DateTime created_date, DateTime updated_date, string name, PostalAddress postalAddress, string description, string building_type, int latest_price_eur, int surface_area_m2, int rooms_count, int bedrooms_count, string contact_phone_number)
    {
        Id = id;
        Created_date = created_date;
        Updated_date = updated_date;
        Name = name;
        PostalAddress = postalAddress;
        Description = description;
        Building_type = building_type;
        Latest_price_eur = latest_price_eur;
        Surface_area_m2 = surface_area_m2;
        Rooms_count = rooms_count;
        Bedrooms_count = bedrooms_count;
        Contact_phone_number = contact_phone_number;
    }

    public int Id { get; set; }
    public DateTime Created_date { get; set; }
    public DateTime Updated_date { get; set; }
    public string Name { get; set; }
    public PostalAddress PostalAddress { get; set; }
    public string Description { get; set; }
    public string Building_type { get; set; }
    public int Latest_price_eur { get; set; }
    public int Surface_area_m2 { get; set; }
    public int Rooms_count { get; set; }
    public int Bedrooms_count { get; set; }
    public string Contact_phone_number { get; set; }
}