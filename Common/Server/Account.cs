namespace AEFramework.Common.Server
{
    public class Account
    {
        public Account()
        {
            Username = "";
            Email = "";
            Password = "";
        }

        public Account(CSteamID id, string username, string email, string password)
        {
            ID = id;
            Username = username;
            Email = email;
            Password = password;
        }

        public CSteamID ID { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }


    }
}