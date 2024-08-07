using System.ComponentModel.DataAnnotations;

public class LoginRequestModel
{
    [Required]
    [MinLength(1)]
    public string Username { get; set; }
}