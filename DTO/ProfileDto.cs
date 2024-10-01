namespace AuthorizationMicroservice.DTO
{
    public class ProfileDto
    {
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string Nickname { get; set; }
        public DateOnly BirthDate { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string ImagePathName { get; set; }
        public bool IsEmailConfirmed { get; set; } = false;
        public bool IsPhoneConfirmed { get; set; } = false;
    }
}
