namespace GuidToTwoInt64;

public class Tests
{
	[SetUp]
	public void Setup()
	{
	}

	[Test]
	public void Test1()
	{
		var guid = Guid.NewGuid();
		Span<byte> sp  = stackalloc byte[16];
		var b = guid.TryWriteBytes(sp);
		var l = BitConverter.ToInt64(sp);
		var l2 = BitConverter.ToInt64(sp.Slice(8,8));
		Span<byte> sp2 = stackalloc byte[16];

		BitConverter.TryWriteBytes(sp2, l);
		BitConverter.TryWriteBytes(sp2.Slice(8,8), l2);
		var gg = new Guid(sp2);
		Assert.IsTrue(guid == gg);


	//	var f = MemoryMarshal.Read<long>(sp.Slice(0, 4));
		//var f2 = MemoryMarshal.Read<long>(sp.Slice(5, 9));
	}
}