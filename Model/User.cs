namespace Authentication_api.Model;

public class User
{
    public required int Uid {get;set;}
    public required string Email {get;set;}
    public required string Pwd {get;set;}
    public required string Role {get;set;}
}
