namespace RestSharp_Example.POCO;

public class Root
{
    public int page { get; set; }
    public int per_page { get; set; }
    public int total { get; set; }
    public int total_pages { get; set; }
    public List<Users> data { get; set; }
    public Support support { get; set; }
}