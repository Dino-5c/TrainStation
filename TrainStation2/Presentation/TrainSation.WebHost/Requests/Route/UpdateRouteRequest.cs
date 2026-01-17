namespace TrainSation.WebHost.Requests.Route
{
    public record class UpdateRouteRequest(Guid Id, string RouteName, Guid AdministratorId)
    {
    }
}
