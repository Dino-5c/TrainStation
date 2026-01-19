namespace TrainSation.WebHost.Requests.Buyer
{
    public record class CreateBuyerRequest /* (, , ) */
    {
        public string BuyerLastName { get; set; }
        public string BuyerFirstName { get; set; }
        public Guid AdministratorId { get; set; }
    }
}
