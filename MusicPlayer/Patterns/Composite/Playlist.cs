namespace MusicPlayer.Patterns.Composite;

public sealed class Playlist : IPlayable
{
    private readonly List<IPlayable> _items = new();
    public string Name { get; }

    public Playlist(string name) => Name = name;

    public void Add(IPlayable item) => _items.Add(item);
    public void Remove(IPlayable item) => _items.Remove(item);
    public IReadOnlyList<IPlayable> Items => _items;

    public TimeSpan GetDuration()
    {
        var total = TimeSpan.Zero;
        foreach (var item in _items)
            total += item.GetDuration();
        return total;
    }

    // Печатает структуру плейлиста (дерево)
    public void PrintStructure(string indent = "")
    {
        Console.WriteLine($"{indent}📁 {Name} [{GetDuration():mm\\:ss}]");
        foreach (var item in _items)
        {
            if (item is Playlist p)
                p.PrintStructure(indent + "   ");
            else if (item is TrackItem t)
                Console.WriteLine($"{indent}   🎵 {t.Track}");
        }
    }
}