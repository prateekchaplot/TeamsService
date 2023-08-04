namespace API.Models;

public class Team
{
    public string Name { get; set; }
    public Guid ID { get; set; }
    public ICollection<Member> Members { get; set; }

    public Team()
    {
        Members = new List<Member>();
    }

    public Team(string name) : this()
    {
        Name = name;
    }

    public Team(string name, Guid id) : this(name)
    {
        ID = id;
    }

    public override string ToString()
    {
        return Name;
    }
}