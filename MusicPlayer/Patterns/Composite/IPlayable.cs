namespace MusicPlayer.Patterns.Composite;

public interface IPlayable
{
    string Name { get; }
    TimeSpan GetDuration();
}