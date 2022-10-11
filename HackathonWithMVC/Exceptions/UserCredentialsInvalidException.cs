namespace HackathonWithMVC.Exceptions
{
    public class UserCredentialsInvalidException:ApplicationException
    {
        public UserCredentialsInvalidException()
        {

        }
        public UserCredentialsInvalidException(string msg) : base(msg)
        {

        }
    }
}
