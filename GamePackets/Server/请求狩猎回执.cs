namespace GamePackets.Server;

[PacketInfo(Source = PacketSource.Server, ID = 304, Length = 18, Description = "g2c_get_advanced_exercise_info_ack")]
public sealed class 请求狩猎回执 : GamePacket
{
	[FieldAttribute(Position = 2, Length = 4)]
	public int 回执结果;

	[FieldAttribute(Position = 6, Length = 4)]
	public int 狩猎编号;

	[FieldAttribute(Position = 10, Length = 4)]
	public int 刷新金币;

	[FieldAttribute(Position = 14, Length = 4)]
	public int 未知参数;
}
