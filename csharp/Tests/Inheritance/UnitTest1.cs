using System.ComponentModel;

namespace Inheritance;

public class BaseB
{
    public string Name { get; set;}
}

public class BaseA
{
    public virtual BaseB BaseB{ get; set; }
}

public class classB : BaseB
{
    public string LongName {get; set;}
}

public class classA : BaseA
{
    public override classB BaseB {get;set;}
}


public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Test1()
    {
        var classB = new classB {LongName = "long name", Name = "name" };
        var classA = new classA {BaseB = classB};

        BaseA bbA = classA;

        Assert.AreEqual("name", bbA.BaseB.Name);
    }
}