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
            Node<int> node = GetNodeInt(42);
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

        [TestMethod]
        public void ChildItems_MethodReturnsProperSizedIEnumerableList()
        {
            Node<int> node42 = GetNodeInt(42);
            Node<int> node43 = GetNodeInt(43);
            Node<int> node44 = GetNodeInt(44);
            Node<int> node45 = GetNodeInt(45);
            Node<int> node46 = GetNodeInt(46);

            node42.Append(node43.Value);
            node42.Append(node44.Value);
            node42.Append(node45.Value);
            node42.Append(node46.Value);

            //node42.Insert(node46);
            //node42.Insert(node45);
            //node42.Insert(node44);
            //node42.Insert(node43);

            IEnumerable<Node<int>> nodeList = node42.ChildItems(7);

            Assert.AreEqual<int>(7, nodeList.Count());
            Assert.AreEqual<int>(43, nodeList.First().Value);
            Assert.AreEqual<int>(44, nodeList.Last().Value);
        }

        public static Node<string> GetNodeStringInigoMontoya()
        {
            return new Node<string>("Inigo Montoya");
        }

        public static Node<int> GetNodeInt(int num)
        {
            return new Node<int>(num);
        }
    }
}
