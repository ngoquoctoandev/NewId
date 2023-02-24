namespace FSH.NewId;

public static class NewIdExtensions
{
    public static NewId ToNewId(this Guid guid) => NewId.FromGuid(guid);

    public static NewId ToNewIdFromSequential(this Guid guid) => NewId.FromSequentialGuid(guid);
}
