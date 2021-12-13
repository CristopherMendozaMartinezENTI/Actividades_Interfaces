namespace Code.Model.Repositories.User
{
    public interface UserDataAccess
    {
        UserEntity GetLocalUser();
        void SetLocalUser(UserEntity userEntity);
    }
}