using System;
using System.IO;
using System.Threading.Tasks;

namespace EventScheduler
{
    internal class Program
    {
        private static void Main() => new Program().MainAsync().GetAwaiter().GetResult();

        private async Task MainAsync()
        {
            Directory.CreateDirectory("Data");
            var watcher = new FileSystemWatcher
            {
                Path = @"Data/",
                NotifyFilter = NotifyFilters.LastWrite,
                EnableRaisingEvents = true,
                Filter = "*.*"
            };
            watcher.Changed += OnChanged;

            await Task.Delay(-1);
        }

        private static void OnChanged(object source, FileSystemEventArgs e)
        {
            if ((e.ChangeType & WatcherChangeTypes.Created) != 0) return;

        }
    }
}
