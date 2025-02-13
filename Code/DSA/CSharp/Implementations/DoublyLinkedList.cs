using System;
using System.Collections.Generic;
using Implementations.Interfaces;

namespace Implementations
{
    public class DoublyLinkedListNode<T>
        where T : IEquatable<T>
    {
        public T Value { get; set; }
        public DoublyLinkedListNode<T>? Next;
        public DoublyLinkedListNode<T>? Previous;

        public DoublyLinkedListNode(
            T value,
            DoublyLinkedListNode<T>? prev = null,
            DoublyLinkedListNode<T>? next = null
        )
        {
            Value = value;
            Previous = prev;
            Next = next;
            if (Previous != null)
            {
                Previous.Next = this;
            }
            if (Next != null)
                Next.Previous = this;
        }
    }

    /// <summary>
    /// DoublyLinkedList Implementation Summary:
    ///
    /// This class provides a generic doubly linked list implementation with
    /// common operations such as insertion, deletion, searching, and traversal.
    /// It implements the ILinkedList<T> interface for consistency and supports
    /// efficient bidirectional traversal.
    ///
    /// TODO: Potential Future Improvements:
    ///
    /// * Implement ICollection<T> for a richer API and better integration
    ///   with other .NET collections.
    /// * Consider offering a read-only wrapper (ReadOnlyCollection<T>) to prevent
    ///   external modification of the list.
    /// * Explore more advanced optimizations if needed (e.g., custom allocators
    ///   for very high-performance scenarios, although unlikely to be necessary
    ///   in most common use cases).
    /// * Allow more flexible comparisons (e.g., using IComparer or a delegate)
    ///   instead of relying solely on IEquatable<T>.
    /// </summary>
    public class DoublyLinkedList<T> : ILinkedList<T>
        where T : IEquatable<T>
    {
        private DoublyLinkedListNode<T>? _head = null;
        private DoublyLinkedListNode<T>? _tail = null;
        private int _count = 0;

        /// <summary>Inserts a new element at the beginning of the list.</summary>
        /// <param name="element">The element to insert.</param>
        public void InsertAtBeginning(T element)
        {
            _head = new DoublyLinkedListNode<T>(element, null, _head);
            if (_tail == null)
            {
                _tail = _head;
            }
            _count++;
        }

        /// <summary>Inserts a new element at the end of the list.</summary>
        /// <param name="element">The element to insert.</param>
        public void InsertAtEnd(T element)
        {
            _tail = new DoublyLinkedListNode<T>(element, _tail, null);
            if (_head == null)
            {
                _head = _tail;
            }
            _count++;
        }

        /// <summary>Inserts a new element at a specified index.</summary>
        /// <param name="index">The index at which to insert the element.</param>
        /// <param name="element">The element to insert.</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the index is less than 0 or greater than the list's size.</exception>
        public void InsertAt(int index, T element)
        {
            if (index < 0 || index > _count)
            {
                throw new ArgumentOutOfRangeException("Insert Index out of acceptable range");
            }
            if (index == 0)
            {
                InsertAtBeginning(element);
            }
            else if (index == _count)
            {
                InsertAtEnd(element);
            }
            else if (index < _count / 2)
            {
                var refIndex = 0;
                var refNode = _head!;
                while (refIndex < index - 1)
                {
                    refIndex++;
                    refNode = refNode.Next!;
                }
                refNode.Next = new DoublyLinkedListNode<T>(element, refNode, refNode.Next);
                _count++;
            }
            else
            {
                var refIndex = _count - 1;
                var refNode = _tail!;
                while (refIndex > index)
                {
                    refIndex--;
                    refNode = refNode.Previous!;
                }
                refNode.Previous = new DoublyLinkedListNode<T>(element, refNode.Previous, refNode);
                _count++;
            }
        }

        /// <summary>Removes the element from the beginning of the list.</summary>
        /// <returns>The removed element.</returns>
        /// <exception cref="InvalidOperationException">Thrown when the list is empty.</exception>
        public T DeleteFromBeginning()
        {
            if(_head == null) {
                throw new InvalidOperationException("Cannot delete from an Empty List");
            }
            var toReturn = _head.Value;
            _head = _head.Next;
            if (_head != null) {
                _head.Previous = null;
            }
            _count--;
            if (_count == 0) {
                _tail = null;
            }
            return toReturn;
        }

        /// <summary>Removes the element from the end of the list.</summary>
        /// <returns>The removed element.</returns>
        /// <exception cref="InvalidOperationException">Thrown when the list is empty.</exception>
        public T DeleteFromEnd()
        {
            if(_tail == null) {
                throw new InvalidOperationException("Cannot delete from an Empty List");
            }
            var toReturn = _tail.Value;
            _tail = _tail.Previous;
            if (_tail != null) {
                _tail.Next = null;
            }
            _count--;
            if (_count == 0) {
                _head = null;
            }
            return toReturn;
        }

        /// <summary>Removes the element at a specified index.</summary>
        /// <param name="index">The index of the element to remove.</param>
        /// <returns>The removed element.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the index is less than 0 or greater than or equal to the list's size.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the list is empty.</exception>
        public T DeleteAt(int index)
        {
            if (index == 0) {
                return DeleteFromBeginning();
            }
            if (index == _count - 1) {
                return DeleteFromEnd();
            }
            if (_head == null) {
                throw new InvalidOperationException("Cannot delete from Empty List");
            }
            if (index < 0 || index >= _count) {
                throw new ArgumentOutOfRangeException("index out of valid range");
            }
            T toReturn;
            if (index < _count/2) {
                var refNode = _head;
                var refIndex = 0;
                while (refIndex < index) {
                    refIndex++;
                    refNode = refNode.Next!;
                }
                toReturn = refNode.Value;
                if (refNode.Previous != null) {
                    refNode.Previous.Next = refNode.Next;
                }
                if (refNode.Next != null) {
                    refNode.Next.Previous = refNode.Previous;
                }
            } else {
                var refNode = _tail;
                var refIndex = _count - 1;
                while (refIndex > index) {
                    refIndex--;
                    refNode = refNode.Previous!;
                }
                toReturn = refNode.Value;
                if (refNode.Previous != null) {
                    refNode.Previous.Next = refNode.Next;
                }
                if (refNode.Next != null) {
                    refNode.Next.Previous = refNode.Previous;
                }
            }
            _count--;
            if (_count == 0) {
                _head = null;
                _tail = null;
            }
            return toReturn;
        }

        /// <summary>Checks if the list contains a given element.</summary>
        /// <param name="element">The element to search for.</param>
        /// <returns>True if the list contains the element, false otherwise.</returns>
        public bool Contains(T element)
        {
            if (_head == null) {
                return false;
            }
            var refNode = _head;
            while (refNode != null) {
                if (EqualityComparer<T>.Default.Equals(refNode.Value, element)) {
                    return true;
                }
                refNode = refNode.Next;
            }
            return false;
        }

        /// <summary>Returns the index of the first occurrence of a given element.</summary>
        /// <param name="element">The element to search for.</param>
        /// <returns>The index of the first occurrence, or -1 if the element is not found.</returns>
        public int IndexOf(T element)
        {
            if (_head == null) {
                return -1;
            }
            var refNode = _head;
            int refIndex = 0;
            while (refNode != null) {
                if (EqualityComparer<T>.Default.Equals(refNode.Value, element)) {
                    return refIndex;
                }
                refNode = refNode.Next;
                refIndex++;
            }
            return -1;
        }

        /// <summary>Returns the element at a specified index.</summary>
        /// <param name="index">The index of the element to retrieve.</param>
        /// <returns>The element at the specified index.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the index is less than 0 or greater than or equal to the list's size.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the list is empty.</exception>
        public T Get(int index)
        {
            if (_head == null || _tail == null) {
                throw new InvalidOperationException("Cannot Get when List is Empty");
            }
            if (index < 0 || index >= _count) {
                throw new ArgumentOutOfRangeException("Index is Out of the range.");
            }
            int refIndex = 0;
            var refNode = _head;
            if (index < _count/2) {
                while (refIndex < index) {
                    refIndex++;
                    refNode = refNode.Next!;
                }
                return refNode.Value;
            } else {
                refIndex = _count - 1;
                refNode = _tail;
                while (refIndex > index) {
                    refIndex--;
                    refNode = refNode!.Previous;
                }
                return refNode!.Value;
            }
        }

        /// <summary>Returns the number of elements in the list.</summary>
        /// <returns>The number of elements.</returns>
        public int Size()
        {
            return _count;
        }

        /// <summary>Checks if the list is empty.</summary>
        /// <returns>True if the list is empty, false otherwise.</returns>
        public bool IsEmpty()
        {
            return _count == 0;
        }

        /// <summary>Removes all elements from the list.</summary>
        public void Clear()
        {
            _head = null;
            _tail = null;
            _count = 0;
        }

        /// <summary>Returns an array representation of the list.</summary>
        /// <returns>An array containing the elements of the list.</returns>
        public T[] ToArray()
        {
            var refNode = _head;
            T[] toReturn = new T[_count];
            var index = 0;
            while (refNode != null) {
                toReturn[index] = refNode.Value;
                index++;
                refNode = refNode.Next;
            }
            return toReturn;
        }

        /// <summary>Returns an enumerator that iterates through the list.</summary>
        /// <returns>An enumerator for the list.</returns>
        public IEnumerator<T> GetEnumerator()
        {
            var refNode = _head;
            while (refNode != null) {
                yield return refNode.Value;
                refNode = refNode.Next;
            }
        }
    }
}
