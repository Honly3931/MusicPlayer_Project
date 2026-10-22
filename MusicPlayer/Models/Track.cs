namespace MusicPlayer.Models;

public sealed class Track
{
    public string Title { get; }
    public string Artist { get; }
    public int DurationSeconds { get; }

    public Track(string title, string artist, int durationSeconds)
    {
        Title = title;
        Artist = artist;
        DurationSeconds = durationSeconds;
    }

    public override string ToString() => $"{Artist} — {Title} ({DurationSeconds / 60}:{DurationSeconds % 60:D2})";
}