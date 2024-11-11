namespace LibraryManagerAPI.Comunication.Request;

public class RequestUpdateBookJson
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;
    public string Genre { get; set; } = string.Empty;
    public float Price { get; set; }
}
