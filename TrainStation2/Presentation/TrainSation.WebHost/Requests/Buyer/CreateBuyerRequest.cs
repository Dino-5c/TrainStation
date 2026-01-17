namespace TrainSation.WebHost.Requests.Buyer
{
    public record class CreateBuyerRequest(string BuyerLastName, string BuyerFirstName, Guid AdministratorId)
    {
    }
}
