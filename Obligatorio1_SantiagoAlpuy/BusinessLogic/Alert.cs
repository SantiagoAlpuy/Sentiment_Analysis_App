namespace BusinessLogic
{
    public class Alert
{
    public string Entity { get; set; }
    public CategoryType Category { get; set; }
    public int Posts { get; set; }
    public int Days { get; set; }
    public int Hours { get; set; }
    public bool Activated { get; set; }
}
}