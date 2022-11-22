using System;
using System.Collections;
using System.Collections.Generic;
using Tasks.DoNotChange;

namespace Tasks
{
    public class DoublyLinkedList<T> : IDoublyLinkedList<T>
    {
        private Node<T> HeadNode;
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
                AddToTail(e);
            }

            Length++;
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
                next.Previous = HeadNode;
            }
            else if (index == Length)
            {
                AddToTail(e);
            }
            else
            {
                var addedNode = new Node<T>(e);
                var next = FindNodeByIndex(index);
                var previous = next.Previous;

                addedNode.Next = next;
                addedNode.Previous = previous;

                next.Previous = addedNode;
                previous.Next = addedNode;
            }

            Length++;
        }

        private void AddToTail(T e)
        {
            var tailNode = FindNodeByIndex(Length - 1);

            var latestNode = new Node<T>(e)
            {
                Previous = tailNode
            };
            tailNode.Next = latestNode;
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
            var removedNode = FindNode(HeadNode, item);

            if (removedNode == null)
            {
                return;
            }

            if (removedNode.Equals(HeadNode))
            {
                RemoveHeadNode();
            }
            else
            {
                var previousNode = removedNode.Previous;
                var nextNode = removedNode.Next;
                if (nextNode == null)
                {
                    previousNode.Next = null;
                    Length--;
                    return;
                }

                previousNode.Next = nextNode;
                nextNode.Previous = previousNode;
            }

            Length--;
        }

        public T RemoveAt(int index)
        {
            if (index >= Length || index < 0)
            {
                throw new IndexOutOfRangeException();
            }

            var removedNode = FindNodeByIndex(index);

            if (removedNode.Equals(HeadNode))
            {
                RemoveHeadNode();
            }

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

        private void RemoveHeadNode()
        {
            HeadNode = HeadNode.Next;
            HeadNode.Previous = null;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new MyEnumerator<T>(HeadNode);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private class Node<T>
        {
            internal T Data;
            internal Node<T> Previous;
            internal Node<T> Next;
            internal Node(T value) => Data = value;

            public override bool Equals(object obj)
            {
                var node = (Node<T>)obj;

                return node != null && Data.Equals(node.Data);
            }
        }

        private class MyEnumerator<T> : IEnumerator<T>
        {
            private Node<T> _headNode;
            private Node<T> _currentNode;

            internal MyEnumerator(Node<T> headNode)
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
}
