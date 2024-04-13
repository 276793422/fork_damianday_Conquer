namespace GamePackets.Client;

[PacketInfo(Source = PacketSource.Client, ID = 33, Length = 4, Description = "角色开关技能")]
public sealed class 角色开关技能 : GamePacket
{
    [FieldAttribute(Position = 2, Length = 2)]
    public ushort 技能编号;
}
