using com.csutil;
using LiteDB;
using PushupApi.Models.Helpers;
using Zio;

namespace PushupApi.Data;

public class DataContext : IDisposable {
    private readonly FileEntry dbFile;
    private ILiteDatabase database;

    public DataContext(FileEntry dbFile = null) {
        var curFolder = DirectoryHelpers.GetCurrentDirectoryEntry();
        dbFile = this.dbFile ?? curFolder.CreateSubdirectory("/Databse").GetChild("Database.db");
    }

    public void CreateDb() {
        database = new LiteDatabase(dbFile.GetFullFileSystemPath());
    }

    public void Dispose() {
        database.Dispose();
    }
}