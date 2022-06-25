namespace FinanzasGrupo2API.Users.Mapping
{
    public class ResourceToModelUser : User
    {
        public ResourceToModelUser()
        {
            CreateMap<SaveUserResource, User>();
            CreateMap<RegisterRequest, User>();
            CreateMap<UpdateRequest, User>()
                .ForAllMembers(options => options.Condition(
                    (source, Target, property) =>
                    {
                        if (property == null) return false;
                        if (property.GetType() == typeof(string) && string.IsNullOrEmpty((string)property)) return false;
                        return true;
                    }));

        }
    }
}
