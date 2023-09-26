var numbers = new List<int> { 1, 5, 4, 2, 6, 1 };

var res = numbers
    .AsParallel()
    .Select(num =>
    {
        Console.WriteLine($"{num} - bajarildi...");
        return num;
    });


res.ToList();