namespace N34_HT1.Service.Interfaces;

public interface ISafeQueue<TItem>
{
    void Enqueue(TItem item);
    TItem Dequeue();
}