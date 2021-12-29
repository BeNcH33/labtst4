using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingLab4
{
	[TestFixture]
	public class Tests
	{
		[Test]
		public void UnionTest()
		{
			Assert.AreEqual(new VersionsInterval(new Versions("0.7.7"), new Versions("1.5.2")).ToString(),VersionsInterval.Union(new VersionsInterval(">0.7.6"),new VersionsInterval("<=1.5.2"))[0].ToString());
			Assert.AreEqual(new VersionsInterval(new Versions("4.0.0"), new Versions("4.5.7")).ToString(),VersionsInterval.Union(new VersionsInterval(">3.1.1 <=4.5.7"),new VersionsInterval(">=4.0.0 <8.0.1"))[0].ToString());
			Assert.AreEqual(new VersionsInterval(new Versions("3.1.4"), new Versions("5.0.9")).ToString(),VersionsInterval.Union(new VersionsInterval(">0.0.0 <=9.3.1"),new VersionsInterval(new Versions("3.1.4"), new Versions("5.0.9")))[0].ToString());
			Assert.AreEqual((new VersionsInterval(new Versions("4.0.0"), new Versions("5.0.0")).ToString()), VersionsInterval.Union(new VersionsInterval(">=1.0.0 <=5.0.0"), new VersionsInterval(new Versions("4.0.0"), new Versions("7.0.0")))[0].ToString());
		}
		[Test]
		public void IntersectionTest()
		{
			Assert.AreEqual(new VersionsInterval(new Versions("0.0.0"), new Versions("2.4.1")).ToString(),VersionsInterval.Intersection(new VersionsInterval(">0.7.6 <=2.4.1"),new VersionsInterval("<=1.5.2")).ToString());
			Assert.AreEqual(new VersionsInterval(new Versions("3.1.2"), new Versions("8.0.0")).ToString(),VersionsInterval.Intersection(new VersionsInterval(">3.1.1 <=4.5.7"),new VersionsInterval(">=4.0.0 <8.0.1")).ToString());
			Assert.AreEqual(new VersionsInterval(new Versions("0.0.1"), new Versions("9.3.1")).ToString(), VersionsInterval.Intersection(new VersionsInterval(">0.0.0 <=9.3.1"),new VersionsInterval(new Versions("3.1.4"), new Versions("5.0.9"))).ToString());

			Assert.AreEqual(null,VersionsInterval.Intersection(new VersionsInterval("<1.0.0"),new VersionsInterval(">2.0.0")));
		}

		[Test]
		public void Equality()
        {
			Assert.IsTrue(new VersionsInterval(new Versions("1.6.1"), new Versions("3.1.3")) == new VersionsInterval(new Versions("1.6.1"), new Versions("3.1.3")));
			Assert.IsTrue(new VersionsInterval(new Versions("1.0.0"), new Versions("3.0.0")) != new VersionsInterval(new Versions("1.6.1"), new Versions("3.1.3")));
			Assert.IsFalse(new VersionsInterval(new Versions("1.6.0"), new Versions("3.1.3")) == new VersionsInterval(new Versions("1.6.1"), new Versions("3.1.3")));
			Assert.IsFalse(new VersionsInterval(new Versions("1.0.0"), new Versions("3.0.0")) != new VersionsInterval(new Versions("1.0.0"), new Versions("3.0.0")));
		}
	}
}
