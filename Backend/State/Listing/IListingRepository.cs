namespace Backend.State.Listing;
public interface IListingRepository
{
    IEnumerable<Backend.Model.Listing> GetAll();
    bool Create(Backend.Model.Listing listing);
    bool Update(Backend.Model.Listing listing);
    IEnumerable<Backend.Model.PriceHistory> GetListingPriceHistory(int id);
}