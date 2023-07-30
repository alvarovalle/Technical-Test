namespace Backend.State.Listing;

public class ListingRepository : IListingRepository, IDisposable
{
    private Context context { get; set; }
    private Listing Map(Model.Listing listing)
    {
        var _postalAddress = new PostalAddress();
        if (listing.PostalAddress != null)
        {
            _postalAddress.City = listing.PostalAddress.City;
            _postalAddress.Country = listing.PostalAddress.Country;
            _postalAddress.Postal_code = listing.PostalAddress.Postal_code;
            _postalAddress.Street_address = listing.PostalAddress.Street_address;
        }
        var _listing = new Listing(
            listing.Id,
            listing.Created_date,
            listing.Updated_date,
            listing.Name,
            _postalAddress,
            listing.Description,
            listing.Building_type,
            listing.Latest_price_eur,
            listing.Surface_area_m2,
            listing.Rooms_count,
            listing.Bedrooms_count,
            listing.Contact_phone_number);
        return _listing;
    }
    private Model.Listing Map(Listing listing)
    {
        Model.PostalAddress _postalAddress = null;
        if (listing.PostalAddress != null)
        {
            _postalAddress = new Model.PostalAddress(
            listing.PostalAddress.City,
            listing.PostalAddress.Country,
            listing.PostalAddress.Postal_code,
            listing.PostalAddress.Street_address);

        }
        var _listing = new Model.Listing(
            listing.Id,
            listing.Created_date,
            listing.Updated_date,
            listing.Name,
            _postalAddress,
            listing.Description,
            listing.Building_type,
            listing.Latest_price_eur,
            listing.Surface_area_m2,
            listing.Rooms_count,
            listing.Bedrooms_count,
            listing.Contact_phone_number);
        return _listing;
    }
    public ListingRepository(Context _context)
    {
        context = _context;
    }

    public bool Create(Model.Listing listing)
    {
        try
        {
            var _listing = Map(listing);
            context.Listing.Add(_listing);
            context.SaveChanges();
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"ListingRepository.Create {ex.Message}");
            return false;
        }
    }

    public IEnumerable<Model.Listing> GetAll()
    {
        var result = new List<Model.Listing>();
        try
        {
            var _result = context.Listing.ToList();
            foreach (var r in _result)
            {
                var _r = Map(r);
                result.Add(_r);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"ListingRepository.GetAll {ex.Message}");
        }
        return result;

    }

    public IEnumerable<Model.PriceHistory> GetListingPriceHistory(int id)
    {
        throw new NotImplementedException();
    }

    public bool Update(Model.Listing listing)
    {
        throw new NotImplementedException();
    }
    private bool disposed = false;

    protected virtual void Dispose(bool disposing)
    {
        if (!this.disposed)
        {
            if (disposing)
            {
                context.Dispose();
            }
        }
        this.disposed = true;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}