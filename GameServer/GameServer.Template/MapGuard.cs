using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace GameServer.Template;

public sealed class MapGuard
{
    public static HashSet<MapGuard> DataSheet;

    public ushort GuardID;
    public byte MapID;
    public string MapName;
    public Point Coordinates = Point.Empty;
    public GameDirection Direction;
    public string RegionName;

    public static void LoadData()
    {
        DataSheet = new HashSet<MapGuard>();

        if (Config.DBMethod == 0)
        {
            var path = Config.GameDataPath + "\\System\\GameMap\\Guards\\";
            if (!Directory.Exists(path))
                return;

            var array = Serializer.Deserialize<MapGuard>(path);
            foreach (var obj in array)
                DataSheet.Add(obj);
        }

        if (Config.DBMethod == 1)
        {
            if (!DBAgent.X.Connected)
                return;

            try
            {
                var qstr = "SELECT * FROM GuardZen";
                using (var connection = DBAgent.X.DB.GetConnection())
                {
                    using var command = DBAgent.X.DB.GetCommand(connection, qstr);

                    using var reader = command.ExecuteReader();
                    if (reader != null)
                    {
                        while (reader.Read() == true)
                        {
                            var guard = new MapGuard();
                            guard.GuardID = reader.GetUInt16("GuardID");
                            guard.MapID = reader.GetByte("MapID");
                            guard.MapName = reader.GetString("MapName");
                            guard.Coordinates.X = reader.GetInt32("MapPosX");
                            guard.Coordinates.Y = reader.GetInt32("MapPosY");
                            guard.Direction = (GameDirection)reader.GetUInt16("Direction");
                            guard.RegionName = reader.GetString("RegionName");

                            DataSheet.Add(guard);
                        }
                    }
                }
            }
            catch (Exception err)
            {
                SMain.AddSystemLog(err.ToString());
                return;
            }
        }
    }
}
