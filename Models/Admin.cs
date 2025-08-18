public class Admin
{
    public int AdminId { get; set; }
    public string Name { get; set; }
    public string Role { get; set; }
    public string Permissions { get; set; }
    
     public string? Email { get; set; }


    // [Required(ErrorMessage = "Password is required")]
    // [DataType(DataType.Password)]
    public string? Password { get; set; }
}