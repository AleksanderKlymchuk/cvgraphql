using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;

namespace UnitTestGraphQL
{
    [TestClass]
    public class PropertyTest
    {
        [TestMethod]
        public void StructTestMethod()
        {
			PersonProperties n = new PersonProperties();
			n.LastName = "aaa";
            Property<int?> a = null;
			


			Assert.AreEqual(false, n.Age.IsSet);
			Assert.AreEqual(false, n.FirstName.IsSet);
			Assert.AreEqual(true, n.LastName.IsSet);
			Assert.AreEqual(true, a.IsSet);


			var d = Get(n);
			Assert.AreEqual(false, d.Age.IsSet);
			Assert.AreEqual(false, d.FirstName.IsSet);
			Assert.AreEqual(true, d.LastName.IsSet);


		}
		public PersonProperties Get(PersonProperties d) {
			return d;

		}
	}
}
