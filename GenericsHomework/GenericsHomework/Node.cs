namespace GenericsHomework
{
    public class Node<T> where T : notnull
    {
        public Node(T value)
        {
            Value = value;
            Next = this;
        }

        public T Value { get; private set; }
        public Node<T> Next { get; private set; }

        public void Append(T value)
        {
            if (Exists(value))
            {
                throw new ArgumentException("This value already exists");
            }

            Node<T> node = new Node<T>(value);
            Node<T> tracer = this;

           while(tracer.Next != this) { tracer = tracer.Next; }

            tracer.Next = node;
            node.Next = this;
        }

        public void Clear()
        {
            this.Next = this;
        }   //Not sure what is meant by 'current node' in instructions

        public bool Exists(T value)
        {
            if (this.Value.Equals(value)) { return true; }

            Node<T> tracer = this;

            for (; tracer.Next != this; tracer = tracer.Next)
            {
                if(tracer.Value.Equals(value)) { return true; }
            }

            if (tracer.Value.Equals(value)) { return true; }

            return false;
        }

        public override string? ToString()
        {
            if(this.Value is null)
            {
                return null;
            }

            return this.Value.ToString();
        }
    }
}
