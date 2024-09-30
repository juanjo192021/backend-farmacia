
namespace api_fameza.Dtos
{
    public class UserDto
    {
        public int Id { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? Email { get; set; }

        public DateOnly? DateBirth { get; set; }

        public string? CellPhone { get; set; }

        public bool? Status { get; set; }

        public string Role { get; set; } = null!;
    }
}
