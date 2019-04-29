namespace TravellerApi.Repository
{
    public interface IRepositoryWrapper
    {
        ICityRepository City { get; }
        ICountryRepository Country { get; }
        IInterestingPlaceRepository InterestingPlace { get; }
        ICommentRepository Comment { get; }
    }
}