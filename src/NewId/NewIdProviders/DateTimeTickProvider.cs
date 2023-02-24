namespace FSH.NewId.NewIdProviders;

public class DateTimeTickProvider :
    ITickProvider
{
    public long Ticks => DateTime.UtcNow.Ticks;
}
