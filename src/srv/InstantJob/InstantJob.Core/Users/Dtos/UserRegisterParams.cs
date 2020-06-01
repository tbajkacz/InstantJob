namespace InstantJob.Core.Users.Dtos
{
    public class UserRegisterParams
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Type { get; set; }
    }
}
