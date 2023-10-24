using N58_HT1.Enums;

namespace N58_HT1.Models;

public interface IStorageBase
{
    string Name { get; set; }

    string Path { get; set; }

    EntryType EntryType { get; set; }
}
