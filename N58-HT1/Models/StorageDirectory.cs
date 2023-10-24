using N58_HT1.Enums;

namespace N58_HT1.Models;

public class StorageDirectory : IStorageBase
{
    public string Name { get; set; } = string.Empty;

    public int ItemsCount { get; set; }

    public string Path { get; set; } = string.Empty;

    public EntryType EntryType { get; set; } = EntryType.Directory;
}
