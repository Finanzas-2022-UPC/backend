namespace FinanzasGrupo2API.Users.Mapping
{
    public class ModelToResourceUser : User
    {
        public ModelToResourceUser()
        {
            CreateMap<User, AuthenticateResponse>();

            CreateMap<User, UserResource>();

        }
    }
}
