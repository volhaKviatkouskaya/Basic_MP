using System;
using Tasks.DoNotChange;

namespace Tasks
{
    public class HybridFlowProcessor<T> : IHybridFlowProcessor<T>
    {
        private DoublyLinkedList<T> _flowProcessor;

        public HybridFlowProcessor()
        {
            _flowProcessor = new DoublyLinkedList<T>();
        }

        public T Dequeue()
        {
            if (_flowProcessor.Length == 0)
            {
                throw new InvalidOperationException();
            }
            return _flowProcessor.RemoveAt(0);
        }

        public void Enqueue(T item)
        {
            _flowProcessor.Add(item);
        }

        public T Pop()
        {
            if (_flowProcessor.Length == 0)
            {
                throw new InvalidOperationException();
            }
            return _flowProcessor.RemoveAt(_flowProcessor.Length - 1);
        }

        public void Push(T item)
        {
            _flowProcessor.Add(item);
        }
    }
}
