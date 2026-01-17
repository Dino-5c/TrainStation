namespace TrainSation.WebHost.Requests.Buyer
{
    public record class UpdateBuyerRequest(Guid Id, string BuyerLastName, string BuyerFirstName, Guid AdministratorId)
    {
    }
}
