using System.Text;
using MusicPlayer.Models;
using MusicPlayer.Patterns.Composite;
using MusicPlayer.Patterns.Iterator;

Console.OutputEncoding = Encoding.UTF8;

// ============================================================
// ШАГ 1: Создаем треки (твой плейлист)
// ============================================================
var track1 = new TrackItem(new Track("It's Me, It's Verity", "Horror Skunx", 123)); // 2:03
var track2 = new TrackItem(new Track("Too Little Too Late", "Laufey", 233)); // 3:53
var track3 = new TrackItem(new Track("Master of Humanity (Lord Verity)", "Horror Skunx", 140)); // 2:20
var track4 = new TrackItem(new Track("1 Июня", "17 Seventeen", 112)); // 1:52
var track5 = new TrackItem(new Track("Сердце", "17 Seventeen", 144)); // 2:24
var track6 = new TrackItem(new Track("не опоздай на салют", "Sqwore", 141)); // ~2:21
var track7 = new TrackItem(new Track("Disney Channel", "Sqwore", 98)); // 1:38
var track8 = new TrackItem(new Track("quinn", "rizza", 121)); // 2:01
var track9 = new TrackItem(new Track("precious", "aldn", 114)); // 1:54
var track10 = new TrackItem(new Track("Утоли мою боль", "17 Seventeen", 180)); // Заглушка 3:00

// ============================================================
// ШАГ 2: Собираем плейлисты (паттерн Composite)
// ============================================================
var horrorPlaylist = new Playlist("Horror Skunx");
horrorPlaylist.Add(track1);
horrorPlaylist.Add(track3);

var seventeenPlaylist = new Playlist("17 Seventeen");
seventeenPlaylist.Add(track4);
seventeenPlaylist.Add(track5);
seventeenPlaylist.Add(track10);

var sqworePlaylist = new Playlist("Sqwore");
sqworePlaylist.Add(track6);
sqworePlaylist.Add(track7);

var chillPlaylist = new Playlist("Chill / Indie");
chillPlaylist.Add(track2); // Laufey
chillPlaylist.Add(track8); // rizza
chillPlaylist.Add(track9); // aldn

// Главный плейлист, в который вложены другие плейлисты
var mainPlaylist = new Playlist("Моя фонотека");
mainPlaylist.Add(horrorPlaylist);
mainPlaylist.Add(seventeenPlaylist);
mainPlaylist.Add(sqworePlaylist);
mainPlaylist.Add(chillPlaylist);

// ============================================================
// ДЕМО 1: Паттерн Composite (Дерево и подсчет времени)
// ============================================================
Console.WriteLine("╔══════════════════════════════════════════════════════════╗");
Console.WriteLine("║  ДЕМО 1: Паттерн Composite (Компоновщик)                 ║");
Console.WriteLine("║  Мы можем работать с плейлистом как с единым целым,      ║");
Console.WriteLine("║  даже если внутри него есть другие плейлисты.            ║");
Console.WriteLine("╚══════════════════════════════════════════════════════════╝");

Console.WriteLine("\nСтруктура нашей фонотеки:");
mainPlaylist.PrintStructure();

Console.WriteLine($"\nОбщая длительность всей фонотеки (одним вызовом GetDuration): {mainPlaylist.GetDuration():mm\\:ss}");

// ============================================================
// ДЕМО 2: Паттерн Iterator (Обход и проигрывание)
// ============================================================
Console.WriteLine("\n╔══════════════════════════════════════════════════════════╗");
Console.WriteLine("║  ДЕМО 2: Паттерн Iterator (Итератор)                     ║");
Console.WriteLine("║  Мы проходим по всем трекам сверху вниз, не заботясь     ║");
Console.WriteLine("║  о том, в каком плейлисте они лежат.                     ║");
Console.WriteLine("╚══════════════════════════════════════════════════════════╝\n");

var iterator = new DepthFirstIterator(mainPlaylist);
int trackNumber = 1;

while (iterator.HasNext())
{
    var item = iterator.Next();

    // Итератор возвращает только треки (плейлисты он раскрывает сам)
    if (item is TrackItem trackItem)
    {
        Console.WriteLine($"▶ Сейчас играет трек #{trackNumber}: {trackItem.Track}");
        Console.WriteLine($"  [Итератор] Достал трек из дерева. Играем {trackItem.Track.DurationSeconds} секунд...");

        Thread.Sleep(300); // Небольшая пауза, чтобы вывод выглядел реалистично (имитация проигрывания)

        Console.WriteLine("  [Плеер] Трек завершен. Переходим к следующему.\n");
        trackNumber++;
    }
}

Console.WriteLine("Воспроизведение завершено. Плейлист закончился.");
Console.WriteLine("\nНажмите Enter для выхода.");
Console.ReadLine();