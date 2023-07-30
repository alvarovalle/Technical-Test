namespace Backend.Model;

public class Listing
{
    public int Id { get; private set; }
    public DateTime Created_date { get; private set; }
    public DateTime Updated_date { get; private set; }
    public string Name { get; private set; }
    public PostalAddress PostalAddress { get; private set; }
    public string Description { get; private set; }
    public string Building_type { get; private set; }
    public int Latest_price_eur { get; private set; }
    public int Surface_area_m2 { get; private set; }
    public int Rooms_count { get; private set; }
    public int Bedrooms_count { get; private set; }
    public string Contact_phone_number { get; private set; }
    public Listing(int id,
       DateTime created_date,
       DateTime updated_date,
       string name,
       PostalAddress postalAddress,
       string description,
       string building_type,
       int latest_price_eur,
       int surface_area_m2,
       int rooms_count,
       int bedrooms_count,
        string contact_phone_number
     )
    {
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
}


