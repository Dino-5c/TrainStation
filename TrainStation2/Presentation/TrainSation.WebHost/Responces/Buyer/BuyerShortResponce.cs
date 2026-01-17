namespace TrainSation.WebHost.Responces.Buyer
{
    public record class BuyerShortResponce(
        Guid Id,
        string BuyerLastName,
        string BuyerFirstName,
        Guid AdministratorId)
    {
    }
}
