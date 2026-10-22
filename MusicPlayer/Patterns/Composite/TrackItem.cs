using MusicPlayer.Models;

namespace MusicPlayer.Patterns.Composite;

public sealed class TrackItem : IPlayable
{
    public Track Track { get; }
    public string Name => Track.Title;

    public TrackItem(Track track) => Track = track;

    public TimeSpan GetDuration() => TimeSpan.FromSeconds(Track.DurationSeconds);
}