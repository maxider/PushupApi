using com.csutil;
using Zio;

namespace PushupApi.Models.Helpers;

public static class DirectoryHelpers {
    public static DirectoryEntry GetCurrentDirectoryEntry() => new DirectoryInfo(Directory.GetCurrentDirectory()).ToRootDirectoryEntry();
}