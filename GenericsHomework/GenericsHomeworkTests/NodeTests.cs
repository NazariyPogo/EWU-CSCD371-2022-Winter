using GenericsHomework;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace GenericsHomeworkTests
{
    [TestClass]
    public class NodeTests
    {
        [TestMethod]
        public void Node_ConstructorWorks()
        {
            Node<string> node = GetNode();
            Assert.AreEqual<string>("Inigo Montoya", node.Value);
        }

        [TestMethod]
        public void Node_ToString_Overridden()
        {
            Node<string> node = GetNode();
            Assert.AreEqual<string>("Inigo Montoya", node.ToString()!);
        }

        [TestMethod]
        public void Node_ListLoopsOnItself()
        {
            Node<string> node = GetNode();
            Assert.AreEqual<string>(node.Value, node.Next.Value);
        }

        [TestMethod]
        public void Node_Append_OriginalValueStays()
        {
            Node<string> node = GetNode();
            node.Append("Princess Buttercup");
            Assert.AreEqual<string>("Inigo Montoya", node.Value);
        }

        [TestMethod]
        public void Node_Append_NewValueAppended()
        {
            Node<string> node = GetNode();
            node.Append("Princess Buttercup");
            Assert.AreEqual<string>("Princess Buttercup", node.Next.Value);
        }

        [TestMethod]
        public void Node_ClearMethodWorks()
        {
            Node<string> node = GetNode();
            node.Append("Princess Buttercup");
            node.Append("Bob");
            node.Append("Joe");
            Assert.AreEqual<string>("Princess Buttercup", node.Next.Value);
            node.Clear();
            Assert.AreEqual<string>("Inigo Montoya", node.Next.Value);
        }

        [TestMethod]
        public void Node_AppendArgumentException_FirstIF_ThrowsException()
        {
            Node<string> node = GetNode();

            Assert.ThrowsException<ArgumentException>(() =>
            {
                node.Append("Inigo Montoya");
            });
        }

        [TestMethod]
        public void Node_AppendArgumentException_SecondIF_ThrowsException()
        {
            Node<string> node = GetNode();
            node.Append("Princess Buttercup");

            Assert.ThrowsException<ArgumentException>(() =>
            {
                node.Append("Princess Buttercup");
            });
        }

        [TestMethod]
        public void Node_ToStringReturnsNull()
        {
            string nullTest = null!;            //Used '!' to test null check in ToString
            Node<string> node = new(nullTest)!; //^
            Assert.IsNull(node.ToString());
        }

        public static Node<string> GetNode()
        {
            return new Node<string>("Inigo Montoya");
        }
    }
}
