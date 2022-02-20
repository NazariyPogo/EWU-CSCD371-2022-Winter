using GenericsHomework;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace GenericsHomeworkTests
{
    [TestClass]
    public class NodeTests
    {
        [TestMethod]
        public void Node_NodeCreatedGivenInt_Success()
        {
            Node<int> node = GetNodeInt42();
            Assert.AreEqual<int>(42, node.Value);
        }

        [TestMethod]
        public void Node_ToString_Overridden_Success()
        {
            Node<string> node = GetNodeStringInigoMontoya();
            Assert.AreEqual<string>("Inigo Montoya", node.ToString()!);
        }

        [TestMethod]
        public void Next_SingleItemInCollection_ReturnSelf()
        {
            Node<string> node = GetNodeStringInigoMontoya();
            Assert.AreEqual<Node<string>>(node, node.Next);
        }

        [TestMethod]
        public void Next_TwoItemsInCollection_Return2nd()
        {
            Node<string> node = GetNodeStringInigoMontoya();
            Node<string> next = new("Princess Buttercup");
            node.Insert(next);
            Assert.AreEqual<Node<string>>(next, node.Next);
            Assert.AreEqual<Node<string>>(node, next.Next);
        }

        [TestMethod]
        public void Next_ThreeItemsInCollection_Return2nd()
        {
            Node<string> node = GetNodeStringInigoMontoya();
            Node<string> node2 = new("Princess Buttercup");
            Node<string> node3 = new("Bob");
            node.Insert(node2);
            node.Insert(node3);
            Assert.AreEqual<Node<string>>(node3, node.Next);
            Assert.AreEqual<Node<string>>(node, node2.Next);
            Assert.AreEqual<Node<string>>(node2, node3.Next);
        }

        [TestMethod]
        public void Node_Append_OriginalValueStays()
        {
            Node<string> node = GetNodeStringInigoMontoya();
            node.Append("Princess Buttercup");
            Assert.AreEqual<string>("Inigo Montoya", node.Value);
        }

        [TestMethod]
        public void Node_Append_NewValueAppended()
        {
            Node<string> node = GetNodeStringInigoMontoya();
            node.Append("Princess Buttercup");
            Assert.AreEqual<string>("Princess Buttercup", node.Next.Value);
        }

        [TestMethod]
        public void Node_ClearMethodWorks()
        {
            Node<string> node = GetNodeStringInigoMontoya();
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
            Node<string> node = GetNodeStringInigoMontoya();

            Assert.ThrowsException<ArgumentException>(() =>
            {
                node.Append("Inigo Montoya");
            });
        }

        [TestMethod]
        public void Node_AppendArgumentException_SecondIF_ThrowsException()
        {
            Node<string> node = GetNodeStringInigoMontoya();
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

        [TestMethod]
        public void Iterator_IteratesThroughList()
        {
            Node<string> node = GetNodeStringInigoMontoya();
            Node<string> node2 = new("Princess Buttercup");
            Node<string> node3 = new("Bob");
            node.Insert(node2);
            node.Insert(node3);

            bool inside = false;
            foreach (Node<string> item in node)
            {
                inside = true;
            }
            Assert.IsTrue(inside);
        }

        public static Node<string> GetNodeStringInigoMontoya()
        {
            return new Node<string>("Inigo Montoya");
        }

        public static Node<int> GetNodeInt42()
        {
            return new Node<int>(42);
        }
    }
}
