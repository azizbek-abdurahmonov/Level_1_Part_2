using System.Threading.Channels;
using N34_HT1.Service;

var queue = new SafeQueue<int>();

var tasks = new List<Task>()
{
    new(() => queue.Enqueue(5)),
    new(() => queue.Enqueue(35)),
    new(() => queue.Enqueue(14)),
    new(() => queue.Enqueue(28)),
};

Parallel.ForEach(tasks, task => task.Start());
await Task.WhenAll(tasks);

Console.WriteLine(queue.Dequeue()); //5
Console.WriteLine(queue.Dequeue()); //35