using System.Collections.Generic;
using System.IO;

namespace GameServer.Template;

public sealed class ItemSetInfo
{
    public static IDictionary<uint, ItemSetInfo> DataSheet;

    public ushort SetID;
    public string Name;
    public Stats Stats;

    public static void LoadData()
    {
        DataSheet = new Dictionary<uint, ItemSetInfo>();

        var path = Settings.GameDataPath + "\\System\\Items\\Sets\\";
        if (Directory.Exists(path))
        {
            var array = Serializer.Deserialize<ItemSetInfo>(path);
            foreach (var obj in array)
                DataSheet.Add(obj.SetID, obj);
        }
    }
}
