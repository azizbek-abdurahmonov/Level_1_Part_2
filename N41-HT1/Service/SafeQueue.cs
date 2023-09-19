using N34_HT1.Service.Interfaces;

namespace N34_HT1.Service;

public class SafeQueue<TItem> : ISafeQueue<TItem>
{
    private List<TItem> _items;
    private readonly object _locker = new();

    public SafeQueue()
    {
        _items = new List<TItem>();
    }

    public void Enqueue(TItem item)
    {
        lock (_locker)
        {
            if (item == null)
                throw new ArgumentException("item is null");
            _items.Add(item);
        }
    }

    public TItem Dequeue()
    {
        lock (_locker)
        {
            var target = _items.FirstOrDefault();
            if (target is not null)
            {
                _items.Remove(target);
                return target;
            }

            throw new InvalidOperationException("Collections has 0 element");
        }
    }
}