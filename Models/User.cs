namespace AuthorizationMicroservice.Models
{
    public class User
    {
        public long Id { get; set; }
        public string FirstName {  get; set; }
        public string Surname { get; set; }
        public string? Nickname { get; set; }
        //public DateOnly? BirthDate { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string? PhoneNumber { get; set; }
        public string? ImagePathName {  get; set; }
        public bool IsEmailConfirmed {  get; set; }=false;
        public bool IsPhoneConfirmed { get; set;} =false;
        public bool IsAdmin { get; set; } = false;
        public bool IsDeleted { get; set; } = false;
    }
}
