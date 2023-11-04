namespace GloboTicket.Catalog.Infrastructure;

internal static class Database
{
    static Database()
    {
        LoadSampleData();
    }
    
    public static List<Event> Events { get; } = new();
    public static List<Artist> Artists { get; } = new();
    
    public static void LoadSampleData()
    {
        Events.Clear();
        Artists.Clear();
        

        var johnEgbert = new Artist(Guid.Parse("{CFB88E29-4744-48C0-94FA-B25B92DEA320}"), "John Egbert", "Banjo virtuoso");
        var michaelJohnson = new Artist(Guid.Parse("{CFB88E29-4744-48C0-94FA-B25B92DEA322}"), "Michael Johnson", "Stand up comedian");
        var nickSailor = new Artist(Guid.Parse("{CFB88E29-4744-48C0-94FA-B25B92DEA321}"), "Nick Sailor", "Playwright");

        Artists.Add(johnEgbert);
        Artists.Add(michaelJohnson);
        Artists.Add(nickSailor);

        Events.Add(new Event
        {
            EventId = Guid.Parse("{CFB88E29-4744-48C0-94FA-B25B92DEA317}"),
            Name = "John Egbert Live",
            Price = 65,
            Artist = johnEgbert,
            Date = DateTime.Now.AddMonths(6),
            Description = "Join John for his farewell tour across 15 continents. John really needs no introduction since he has already mesmerized the world with his banjo.",
            ImageUrl = "/img/banjo.jpg",
        });

        Events.Add(new Event
        {
            EventId = Guid.Parse("{CFB88E29-4744-48C0-94FA-B25B92DEA319}"),
            Name = "The State of Affairs: Michael Live!",
            Price = 85,
            Artist = michaelJohnson,
            Date = DateTime.Now.AddMonths(9),
            Description = "Michael Johnson doesn't need an introduction. His 25 concert across the globe last year were seen by thousands. Can we add you to the list?",
            ImageUrl = "/img/michael.jpg",
        });

        Events.Add(new Event
        {
            EventId = Guid.Parse("{CFB88E29-4744-48C0-94FA-B25B92DEA318}"),
            Name = "To the Moon and Back",
            Price = 135,
            Artist = nickSailor,
            Date = DateTime.Now.AddMonths(8),
            Description = "The critics are over the moon and so will you after you've watched this sing and dance extravaganza written by Nick Sailor, the man from 'My dad and sister'.",
            ImageUrl = "/img/musical.jpg",
        });
    }
}