namespace TrainSation.WebHost.Requests.Route
{
    public record class CreateRouteRequest(string RouteName, Guid AdministratorId)
    {
    }
}
