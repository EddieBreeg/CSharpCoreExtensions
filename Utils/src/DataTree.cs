//using System;
using System.Collections.Generic;
using System.Linq;

namespace System
{
    public class InvalidPathException : Exception
    {
        public InvalidPathException() { }
        public InvalidPathException(string message) : base(message) { }
    }
    public class DataTree<T>: Collections.IEnumerable
    {
        public List<Node<T>> Nodes { get; set; }

        public DataTree() => Nodes = new List<Node<T>>();
        public DataTree(List<Node<T>> nodes) => Nodes = nodes;
        public DataTree(Node<T> node) => Nodes = new List<Node<T>>() { node };

        public Node<T> this[T key]
        {
            get
            {
                foreach (Node<T> n in Nodes)
                    if (n.Value.Equals(key)) return n;
                throw new KeyNotFoundException("Key doesn't match any Node");
            }
            set
            {
                bool assigned = false;
                value.Value = key;
                for(int i=0; i<Nodes.Count; i++)
                    if(Nodes[i].Value.Equals(key))
                        Nodes[i] = value;

                if (!assigned)
                    Nodes.Add(value);
            }
        }
        public Node<T> this[T[] path]
        {
            get
            {
                if (path.Length == 0) throw new InvalidPathException("Value path may not be empty");
                else if (path.Length == 1) return this[path[0]];
                return this[path[0]][path.GetRange(1, path.Length - 1)];
            }
            set
            {
                if (path.Length == 0) throw new InvalidPathException("Value path may not be empty");
                else if (path.Length == 1) this[path[0]] = value;
                this[path[0]][path.GetRange(1, path.Length - 1)] = value;
            }
        }
        public Node<T> this[List<T> path]
        {
            get
            {
                if (path.Count == 0) throw new InvalidPathException("Value path may not be empty");
                else if (path.Count == 1) return this[path[0]];
                return this[path[0]][path.GetRange(1, path.Count - 1)];
            }
            set
            {
                if (path.Count == 0) throw new InvalidPathException("Value path may not be empty");
                else if (path.Count == 1) this[path[0]] = value;
                this[path[0]][path.GetRange(1, path.Count - 1)] = value;
            }
        }
        public Collections.IEnumerator GetEnumerator() => Nodes.GetEnumerator();

        public int Depth() => Nodes.Select(n => n.Depth()).Max();
        public override string ToString()
        {
            var result = "";
            foreach (Node<T> n in Nodes)
                result += n.ToString();
            return result;
        }
    }
    public class Node<T>: Collections.IEnumerable
    {
        public T Value { get; set; }
        private Node<T> _parent;
        private List<Node<T>> _children;
        public Node<T> Parent 
        { 
            get=>_parent;
            set 
            {
                value[Value] = this;
            } 
        }
        public List<Node<T>> Children
        {
            get => _children;
        }
        public Node() => _children = new List<Node<T>>();
        public Node(T value)
        {
            Value = value;
            _children = new List<Node<T>>();
        }

        public bool IsLeaf() => Children == null;
        public bool IsRoot() => Parent == null;
        public int DistanceToRoot()
        {
            if (Parent == null) return 0;
            return 1 + Parent.DistanceToRoot();
        }
        public void Add(Node<T> newChild) => this[newChild.Value] = newChild;
        public void Add(T value) => Children.Add(new Node<T>(value));
        public Node<T> this[T key]
        {
            get
            {
                foreach (Node<T> c in Children)
                    if (c.Value.Equals(key)) return c;

                throw new KeyNotFoundException("Key doesn't match any Node");
            }
            set
            {
                var assigned = false;
                for(int i=0; i<Children.Count;i++)
                    if(Children[i].Value.Equals(key))
                    {
                        assigned = true;
                        value.Value = key;
                        value._parent = this;
                        Children[i] = value;
                    }
                if (!assigned)
                {
                    value.Value = key;
                    value._parent = this;
                    Children.Add(value);
                }
            }
        }
        public Node<T> this[List<T> path]
        {
            get
            {
                if (path.Count == 0) throw new ArgumentException("Value path may not be empty");
                if (path.Count == 1)
                    return this[path[0]];

                return this[path[0]][path.GetRange(1, path.Count-1)];
            }
            set
            {
                if (path.Count == 0) throw new ArgumentException("Value path must not be empty");
                else if (path.Count == 1)
                {
                    this[path[0]] = value;
                }
                else
                {
                    try
                    {
                        this[path[0]][path.GetRange(1, path.Count - 1)] = value;
                    }
                    catch(KeyNotFoundException)
                    {
                        this[path[0]] = new Node<T>(path[0]);
                        this[path[0]][path.GetRange(1, path.Count - 1)] = value;
                    }
                }
            }
        }
        public Node<T> this[T[] path]
        {
            get
            {
                if (path.Length == 0) throw new ArgumentException("Value path must not be empty");
                if (path.Length == 1)
                    return this[path[0]];

                return this[path[0]][path.GetRange(1, path.Length - 1)];
            }
            set
            {
                if (path.Length == 0) throw new ArgumentException("Value path must not be empty");
                else if (path.Length == 1)
                {
                    this[path[0]] = value;
                }
                else
                {
                    try
                    {
                        this[path[0]][path.GetRange(1, path.Length - 1)] = value;
                    }
                    catch (KeyNotFoundException)
                    {
                        this[path[0]] = new Node<T>(path[0]);
                        this[path[0]][path.GetRange(1, path.Length - 1)] = value;
                    }
                }
            }
        }
        public Collections.IEnumerator GetEnumerator() => Children.GetEnumerator();
        public int Depth()
        {
            if (Children.Count == 0) return 1;
            return 1+Children.Select(n => n.Depth()).Max();
        }
        public override string ToString()
        {
            var result = Value.ToString() + '\n';
            Children.ForEach(n => result += "    " + n.ToString());
            return result;
        }
    }
}
