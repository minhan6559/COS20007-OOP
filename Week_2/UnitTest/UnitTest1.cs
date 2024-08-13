namespace UnitTest;
using MinhAnNguyen;

public class TestMinhAnNguyen
{
    [Test]
    public void Test1()
    {
        Student a = new Student();
        Assert.AreEqual(a.GetName(), "Minh An Nguyen - 104844794");
    }
}
