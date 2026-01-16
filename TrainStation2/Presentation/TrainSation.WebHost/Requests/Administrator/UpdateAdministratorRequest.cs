namespace TrainSation.WebHost.Requests.Administrator
{
    public record class UpdateAdministratorRequest(Guid Id, string AdministratorLastName, string AdministratorFirstName)
    {
    }
}
