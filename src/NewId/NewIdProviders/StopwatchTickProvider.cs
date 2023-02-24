using System.Diagnostics;

namespace FSH.NewId.NewIdProviders;

public class StopwatchTickProvider :
    ITickProvider
{
    private readonly DateTime  _start;
    private readonly Stopwatch _stopwatch;

    public StopwatchTickProvider()
    {
        _start     = DateTime.UtcNow;
        _stopwatch = Stopwatch.StartNew();
    }

    public long Ticks => _start.AddTicks(_stopwatch.Elapsed.Ticks).Ticks;
}
