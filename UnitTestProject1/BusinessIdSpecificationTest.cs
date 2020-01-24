using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace UnitTestProject
{
    [TestClass]
    public class BusinessIdSpecificationTest
    {
        [TestMethod]
        public void TestValidBusinessIds()
        {
            ClassLibrary.ISpecification<string> businessId = new ClassLibrary.BusinessIdSpecification();
            //ClassLibrary1.BusinessId businessIdClass = new ClassLibrary1.BusinessId();
            Assert.IsTrue(businessId.IsSatisfiedBy("5700875-9"));
            Assert.IsTrue(businessId.IsSatisfiedBy("737546-2"));
            //Assert.IsTrue(businessIdClass.IsSatisfiedBy("15700875-9"));
        }

        [TestMethod]
        public void TestInvalidBusinessIds()
        {
            ClassLibrary.ISpecification<string> businessId = new ClassLibrary.BusinessIdSpecification();
            //ClassLibrary1.BusinessId businessIdClass = new ClassLibrary1.BusinessId();
            Assert.IsFalse(businessId.IsSatisfiedBy("a700875-9"));
            //Assert.IsTrue(businessId.ReasonsForDisatisfaction.Count() > 0);
            //Assert.IsTrue(businessIdClass.IsSatisfiedBy("15700875-9"));
        }
    }
}
