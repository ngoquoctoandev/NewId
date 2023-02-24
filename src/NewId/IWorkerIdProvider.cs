namespace FSH.NewId;

public interface IWorkerIdProvider
{
    byte[] GetWorkerId(int index);
}
