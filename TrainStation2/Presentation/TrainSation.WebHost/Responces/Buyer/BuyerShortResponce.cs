namespace TrainSation.WebHost.Responces.Buyer
{
    public record class BuyerShortResponce /* (
        Guid Id,
        string BuyerLastName,
        string BuyerFirstName,
        Guid AdministratorId) */
    {
        public Guid Id { get; init; }
        public string BuyerLastName { get; set; }
        public string BuyerFirstName { get; set; }
        public Guid AdministratorId { get; init; }
    }
}
