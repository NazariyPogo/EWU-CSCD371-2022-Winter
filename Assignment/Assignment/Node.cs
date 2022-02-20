using System.Collections;

namespace GenericsHomework
{
    public class Node<T> : IEnumerable<Node<T>> where T : notnull
    {
        public T Value { get; private set; }
        public Node<T> Next { get; private set; }

        public Node(T value)
        {
            Value = value;
            Next = this;
        }

        public void Append(T value)
        {
            if (Exists(value))
            {
                throw new ArgumentException("This value already exists");
            }

            Node<T> node = new Node<T>(value);
            Node<T> tracer = this;

            while (tracer.Next != this) { tracer = tracer.Next; }

            tracer.Next = node;
            node.Next = this;
        }

        public void Insert(Node<T> nextNode)
        {
            if (Exists(nextNode.Value))
            {
                throw new ArgumentException("This value already exists");
            }

            Node<T> temp = this.Next;
            Next = nextNode;
            nextNode.Next = temp;
        }

        public void Clear()
        {
            Node<T> prev = this, next = this.Next;

            do
            {
                prev.Next = prev;
                prev = next;
                next = next.Next;
            } while (next != this);
            prev.Next = prev;
        }//Garbage collection is not an issue because all nodes that aren't referenced
         //to by main, will have no references after leaving the scope of this method.

        public bool Exists(T value)
        {
            if (this.Value.Equals(value)) { return true; }

            Node<T> tracer = this;

            for (; tracer.Next != this; tracer = tracer.Next)
            {
                if (tracer.Value.Equals(value)) { return true; }
            }

            if (tracer.Value.Equals(value)) { return true; }

            return false;
        }

        public override string? ToString()
        {
            return Value?.ToString();
        }

        public IEnumerable<Node<T>> ChildItems(int maximum)
        {
            throw new NotImplementedException();
        }
        
        public IEnumerator<Node<T>> GetEnumerator()
        {
            Node<T> cur = this.Next;
            do
            {
                yield return cur;
                cur = cur.Next;
            }
            while(cur != this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<Node<T>>)this).GetEnumerator();
        }
    }
}
