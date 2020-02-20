using System.Text.Json;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Bitmex.NET.UnitTests
{
    [TestClass]
    public class JsonStringEnumConverterTests
    {
        [TestMethod]
        public void Enum_String_CamelCase_Test()
        {
            var c = new MyClass()
            {
                MyEnum = MyEnum.TestValue
            };

            var str = BitmexJsonSerializer.Serialize(c);
            str.Should().Be("{\"myEnum\":\"testValue\"}");
        }

        [TestMethod]
        public void String_Enum_CamelCase_Test()
        {
            var str = "{\"myEnum\":\"testValue\"}";

            var cls = BitmexJsonSerializer.Deserialize<MyClass>(str);
            cls.MyEnum.Should().Be(MyEnum.TestValue);
        }

        public class MyClass
        {
            public MyEnum MyEnum { get; set; }
        }

        public enum MyEnum
        {
            Test,
            TestValue
        }
    }
}