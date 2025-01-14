using Pizza4Ps.CustomerService.Domain.Enums;

namespace Pizza4Ps.CustomerService.Application.DTOs.Customers
{
    public class CreateCustomerDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public GenderEnum Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Avatar { get; set; }
        public Guid StreetId { get; set; }
    }
}
