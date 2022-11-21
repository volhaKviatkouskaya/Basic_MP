using System;
using System.Collections;
using System.Collections.Generic;
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
            var node = (Node<T>)obj;

            return Data.Equals(node.Data);
        }
    }

    public class DoublyLinkedList<T> : IDoublyLinkedList<T>
    {
        public Node<T> HeadNode;
        public int Length { get; set; }

        public DoublyLinkedList()
        {
            HeadNode = null;
            Length = 0;
        }

        public void Add(T e)
        {
            if (HeadNode == null)
            {
                HeadNode = new Node<T>(e);
            }
            else
            {
                var tailNode = FindTailNode(HeadNode);
                var latestNode = new Node<T>(e)
                {
                    Previous = tailNode
                };
                tailNode.Next = latestNode;
            }

            Length++;
        }

        private Node<T> FindTailNode(Node<T> headNode)
        {
            return headNode.Next == null ? headNode : FindTailNode(headNode.Next);
        }

        public void AddAt(int index, T e)
        {
            if (index == 0)
            {
                var next = HeadNode;
                HeadNode = new Node<T>(e)
                {
                    Next = next
                };
                Length++;
                return;
            }

            var addedNode = new Node<T>(e);
            if (index == Length)
            {
                var tail = FindTailNode(HeadNode);
                tail.Next = addedNode;
                addedNode.Previous = tail;
            }
            else
            {
                var next = FindNodeByIndex(index);
            }


            //var addedNode = new Node<T>(e);
            /*
            var next = FindNodeByIndex(index);

            if (next == null)
            {
                var tail = FindNodeByIndex(index - 1);
                tail.Next = addedNode;
                addedNode.Previous = tail;
            }
            else
            {
                var previous = next.Previous;

                if (previous != null)
                {
                    addedNode.Previous = previous;
                    previous.Next = addedNode;
                }

                addedNode.Next = next;
                next.Previous = addedNode;
            }
            */
            Length++;
        }

        private Node<T> FindNodeByIndex(int index)
        {
            var element = HeadNode;

            for (var count = 0; count <= Length; count++)
            {

                if (count == index)
                {
                    break;
                }

                element = element.Next;
            }

            return element;
        }

        public T ElementAt(int index)
        {
            if (index >= Length || index < 0)
            {
                throw new IndexOutOfRangeException();
            }

            return FindNodeByIndex(index).Data;
        }

        private Node<T> FindFirstNode(Node<T> node)
        {
            return node.Previous == null ? node : FindFirstNode(node.Previous);
        }

        private Node<T> FindNode(Node<T> headNode, T item)
        {
            if (item != null && headNode.Equals(new Node<T>(item)))
            {
                return headNode;
            }

            return headNode.Next == null ? null : FindNode(headNode.Next, item);
        }

        public void Remove(T item)
        {
            var firstNode = FindFirstNode(HeadNode);
            var removedNode = FindNode(firstNode, item);

            if (removedNode == null) return;

            var previousNode = removedNode.Previous;
            var nextNode = removedNode.Next;

            if (removedNode.Equals(firstNode))
            {
                firstNode = nextNode;
                firstNode.Previous = null;
                removedNode.Next = null;
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
            if (index >= Length || index < 0)
            {
                throw new IndexOutOfRangeException();
            }

            var removedNode = FindNodeByIndex(index);
            var previousNode = removedNode.Previous;

            var nextNode = removedNode.Next;
            previousNode.Next = nextNode;
            if (nextNode != null)
            {
                nextNode.Previous = previousNode;
            }

            Length--;
            return removedNode.Data;
        }


        public IEnumerator<T> GetEnumerator()
        {
            var firstNode = FindFirstNode(this.HeadNode);
            return new MyEnumerator<T>(firstNode);
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

        public MyEnumerator(Node<T> headNode)
        {
            _headNode = headNode;
        }

        public T Current => _currentNode.Data;
        object IEnumerator.Current => _currentNode.Data;
        public void Dispose() { }

        public bool MoveNext()
        {
            _currentNode = _currentNode == null ? _headNode : _currentNode.Next;
            return _currentNode != null;
        }

        public void Reset()
        {
            _currentNode = _headNode;
        }
    }
}
