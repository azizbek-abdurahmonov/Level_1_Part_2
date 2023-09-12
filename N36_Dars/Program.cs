using System.Net.Cache;

var tuple1 = Tuple.Create("Azizbek", "Abdurahmonov", 15, 2008);
Console.WriteLine(tuple1.Item2); //Abdurahmonov
Console.WriteLine(tuple1.Item4); //2008

var tuple2 = (FirstName: "Azizbek", LastName: "Abdurahmonov", Age: 15);
Console.WriteLine(tuple2.FirstName); //Azizbek
Console.WriteLine(tuple2.Age); //15
