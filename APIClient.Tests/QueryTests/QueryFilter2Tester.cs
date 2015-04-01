using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace VersionOne.SDK.APIClient.Tests.QueryTests
{
    [TestClass]
    public class QueryFilter2Tester : MetaTesterBase
    {
        protected override string MetaTestKeys
        {
            get { return "QueryFilterTester"; }
        }

        [TestMethod]
        public void NullToken()
        {
            Assert.AreEqual(null, new NoOpTerm().Token);
            Assert.AreEqual(null, new AndFilterTerm().Token);
            Assert.AreEqual(null, new OrFilterTerm().Token);
            Assert.AreEqual(null, new FilterTerm(WorkitemToDo).Token);
        }

        [TestMethod]
        public void Complex1()
        {
            var termA = new FilterTerm(WorkitemParent);
            termA.Equal(Oid.FromToken("Theme:5", Meta));
            termA.Equal(Oid.FromToken("Theme:6", Meta));

            var termB = new FilterTerm(WorkitemScope);
            termB.Equal(Oid.FromToken("Scope:0", Meta));

            var termC = new FilterTerm(WorkitemParent);
            termC.NotEqual(Oid.FromToken("Theme:7", Meta));
            termC.NotEqual(Oid.FromToken("Theme:8", Meta));

            var termD = new FilterTerm(WorkitemScope);
            termD.NotEqual(Oid.FromToken("Scope:1", Meta));

            var and1 = new AndFilterTerm(termA, termB);
            var and2 = new AndFilterTerm(termC, termD);

            var o = new OrFilterTerm(and1, and2);
            Assert.AreEqual(
                "((Workitem.Parent='Theme%3a5','Theme%3a6';Workitem.Scope='Scope%3a0')|(Workitem.Parent!='Theme%3a7','Theme%3a8';Workitem.Scope!='Scope%3a1'))",
                o.Token);
        }

        [TestMethod]
        public void Complex2()
        {
            var termA = new FilterTerm(WorkitemToDo);
            termA.Greater(5);

            var termB = new FilterTerm(WorkitemToDo);
            termB.Less(10);

            var termC = new FilterTerm(WorkitemToDo);
            termC.GreaterOrEqual(20);

            var termD = new FilterTerm(WorkitemToDo);
            termD.LessOrEqual(30);

            var and1 = new AndFilterTerm(termA, termB);
            var and2 = new AndFilterTerm(termC, termD);

            var o = new OrFilterTerm(and1, and2);

            Assert.AreEqual("((Workitem.ToDo>'5';Workitem.ToDo<'10')|(Workitem.ToDo>='20';Workitem.ToDo<='30'))",
                            o.Token);
        }

        [TestMethod]
        public void NestedEmptyResult()
        {
            var o1 = new OrFilterTerm();
            var o2 = new OrFilterTerm();
            var a1 = new AndFilterTerm(o1, o2);
            var a2 = new AndFilterTerm(a1);

            Assert.AreEqual(null, a2.Token);
        }

        [TestMethod]
        public void SingleNestedTerm()
        {
            var f1 = new FilterTerm(WorkitemToDo);
            f1.Greater(5);
            var o1 = new OrFilterTerm(f1);
            var o2 = new OrFilterTerm();
            var a1 = new AndFilterTerm(o1, o2);
            var a2 = new AndFilterTerm(a1);

            Assert.AreEqual("Workitem.ToDo>'5'", a2.Token);
        }
    }
}
