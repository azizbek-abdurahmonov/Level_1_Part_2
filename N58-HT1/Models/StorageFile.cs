using N58_HT1.Enums;

namespace N58_HT1.Models;

public class StorageFile : IStorageBase
{
    public string Name { get; set; } = string.Empty;

    public string Directory { get; set; } = string.Empty;

    public string Path { get; set; } = string.Empty;

    public string Extension { get; set; } = string.Empty;

    public long Size { get; set; }

    public EntryType EntryType { get; set; } = EntryType.File;
}
