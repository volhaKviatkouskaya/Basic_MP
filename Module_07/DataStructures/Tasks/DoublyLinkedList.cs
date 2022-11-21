using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Tasks.DoNotChange;

namespace Tasks
{
    public class Node<T>
    {
        public T Data { get; set; }
        public Node<T> Previous { get; set; }
        public Node<T> Next { get; set; }
        public Node(T value) => Data = value;

        public override bool Equals(object obj)
        {
            var toCompare = (Node<T>)obj;

            return Data.Equals(toCompare.Data);
        }
    }

    public class DoublyLinkedList<T> : IDoublyLinkedList<T>
    {
        public Node<T> HeadNode;
        public Node<T> TailNode;
        public int Length { get; set; }

        public DoublyLinkedList()
        {
            this.HeadNode = this.TailNode = null;
            this.Length = 0;
        }

        public void Add(T e)
        {
            if (HeadNode == null)
            {
                HeadNode = new Node<T>(e);
                Length++;
            }
            else
            {
                TailNode = new Node<T>(e)
                {
                    Previous = HeadNode
                };
                HeadNode.Next = TailNode;
                HeadNode = TailNode;
                TailNode = null;
                Length++;
            }
        }

        public void AddAt(int index, T e)
        {
            
        }

        private void FindNodeByIndex(int index, T e)
        {

        }

        public T ElementAt(int index)
        {
            var headNode = FindFirstNode(this.HeadNode);
            var count = 0;
            var element = headNode.Data;

            while (count!=index)
            {
                headNode = headNode.Next;
                count++;

                if (count == index)
                {
                    element = headNode.Data;
                    break;
                }
            }

            return element;
        }

        private Node<T> FindFirstNode(Node<T> node)
        {
            if (node.Previous == null)
            {
                return node;
            }

            return FindFirstNode(node.Previous);
        }

        private Node<T> FindNode(Node<T> headNode, T item)
        {
            if (item != null && headNode.Equals(new Node<T>(item)))
            {
                return headNode;
            }
            if (headNode.Next == null)
            {
                return null;
            }
            return FindNode(headNode.Next, item);
        }

        public void Remove(T item)
        {
            var firstNode = FindFirstNode(HeadNode);
            var removingNode = FindNode(firstNode, item);

            if (removingNode == null) return;

            var previousNode = removingNode.Previous;
            var nextNode = removingNode.Next;

            if (removingNode.Equals(firstNode))
            {
                firstNode = nextNode;
                firstNode.Previous = null;
                removingNode.Next = null;
                Length--;
                return;
            }

            if (nextNode == null)
            {
                previousNode.Next = null;
                Length--;
                return;
            }
            previousNode.Next = nextNode;
            nextNode.Previous = previousNode;

            Length--;
        }

        public T RemoveAt(int index)
        {
            throw new NotImplementedException();
        }


        public IEnumerator<T> GetEnumerator()
        {
            var firstNode = FindFirstNode(this.HeadNode);
            return new MyEnumerator<T>(firstNode, HeadNode);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    public class MyEnumerator<T> : IEnumerator<T>
    {
        private Node<T> _headNode;
        private Node<T> _currentNode;

        private int _position;

        public MyEnumerator(Node<T> headNode, Node<T> tailNode)
        {
            _headNode = headNode;
            _currentNode = null;
            _position = 0;
        }

        public T Current => _currentNode.Data;
        object IEnumerator.Current => _currentNode.Data;

        public void Dispose()
        {
            _headNode = null;
            _headNode = null;
        }
        public bool MoveNext()
        {
            if (_currentNode == null)
            {
                _currentNode = _headNode;
            }
            else
            {
                _currentNode = _currentNode.Next;
                _position++;
            }
            return _currentNode != null;
        }

        public void Reset()
        {
            _currentNode = _headNode;
            _position = 0;
        }
    }
}
