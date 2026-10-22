using MusicPlayer.Patterns.Composite;

namespace MusicPlayer.Patterns.Iterator;

/// <summary>Обход дерева в глубину: сначала заходим внутрь плейлиста, потом идем дальше.</summary>
public sealed class DepthFirstIterator : IPlaylistIterator
{
    private readonly Stack<IPlayable> _stack = new();

    public DepthFirstIterator(Playlist root)
    {
        // Кладем элементы в стек в обратном порядке, чтобы доставать в прямом
        for (int i = root.Items.Count - 1; i >= 0; i--)
            _stack.Push(root.Items[i]);
    }

    public bool HasNext() => _stack.Count > 0;

    public IPlayable Next()
    {
        if (!HasNext()) throw new InvalidOperationException("Элементы закончились");

        var current = _stack.Pop();

        // Если попался плейлист — раскрываем его (кладем его элементы в стек)
        if (current is Playlist playlist)
        {
            for (int i = playlist.Items.Count - 1; i >= 0; i--)
                _stack.Push(playlist.Items[i]);

            // Сам плейлист как элемент пропускаем, идем сразу к его содержимому
            return Next();
        }

        return current;
    }
}