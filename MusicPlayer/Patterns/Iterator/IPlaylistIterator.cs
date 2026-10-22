using MusicPlayer.Patterns.Composite;

namespace MusicPlayer.Patterns.Iterator;

public interface IPlaylistIterator
{
    bool HasNext();
    IPlayable Next();
}