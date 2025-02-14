using System;
using System.Collections.Generic;
using Implementations.Interfaces;

namespace Implementations
{
    public class SinglyLinkedListNode<T>
        where T : IEquatable<T>
    {
        public T Value { get; set; }
        public SinglyLinkedListNode<T>? Next;

        public SinglyLinkedListNode(T value, SinglyLinkedListNode<T>? next = null)
        {
            this.Value = value;
            this.Next = next;
        }
    }

    /// <summary>
    /// SingleLinkedList Implementation Summary:
    ///
    /// This class provides a basic singly linked list implementation with
    /// common operations.
    ///
    /// TODO: Potential Future Improvements:
    ///
    /// * Implement ICollection<T> for a richer API and better integration.
    /// * Explicitly implement IEnumerable<T> for clarity.
    /// * Allow more flexible comparisons (e.g., using IComparer or a delegate)
    ///   instead of relying solely on IEquatable<T>.
    /// * Optimize ToArray by populating the array directly during list traversal.
    /// </summary>
    public class SinglyLinkedList<T> : ILinkedList<T>
        where T : IEquatable<T>
    {
        /// <summary>Head node for Single Linked List</summary>
        private SinglyLinkedListNode<T>? _head;
        private SinglyLinkedListNode<T>? _tail;
        private int _count = 0;

        public SinglyLinkedList()
        {
            _head =null;
            _tail = null;
            _count = 0;
        }

        /// <summary>Inserts a new element at the beginning of the list.</summary>
        /// <param name="element">The element to insert.</param>
        public void InsertAtBeginning(T element)
        {
            var newNode = new SinglyLinkedListNode<T>(element, _head);
            _head = newNode;
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
            var newNode = new SinglyLinkedListNode<T>(element);
            if (_tail == null) {
                _head = newNode;
                _tail = newNode;
            } else {
                _tail.Next = newNode;
                _tail = newNode;
            }
            _count++;
        }

        /// <summary>Inserts a new element at a specified index.</summary>
        /// <param name="index">The index at which to insert the element.</param>
        /// <param name="element">The element to insert.</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the index is less than 0 or greater than the list's size.</exception>
        public void InsertAt(int index, T element)
        {
            if (index < 0)
            {
                throw new ArgumentOutOfRangeException("Cannot insert at index < 0");
            }
            if (index == 0)
            {
                InsertAtBeginning(element);
            }
            else if (index == _count)
            {
                InsertAtEnd(element);
            }
            else if (index > _count)
            {
                throw new ArgumentOutOfRangeException(
                    "Cannot insert at index beyond the length of the List"
                );
            }
            var refNode = _head!;
            var refCount = 0;
            while (refCount < index - 1)
            {
                refCount++;
                refNode = refNode.Next!;
            }
            refNode.Next = new SinglyLinkedListNode<T>(element, refNode.Next);
            _count++;
        }

        /// <summary>Removes the element from the beginning of the list.</summary>
        /// <returns>The removed element.</returns>
        /// <exception cref="InvalidOperationException">Thrown when the list is empty.</exception>
        public T DeleteFromBeginning()
        {
            if (_head == null)
            {
                throw new InvalidOperationException("Cannot remove from Empty List");
            }
            T toReturn = _head.Value;
            _head = _head.Next;
            if (_head == null)
            {
                _tail = null;
            }
            _count--;
            return toReturn;
        }

        /// <summary>Removes the element from the end of the list.</summary>
        /// <returns>The removed element.</returns>
        /// <exception cref="InvalidOperationException">Thrown when the list is empty.</exception>
        public T DeleteFromEnd()
        {
            if (_tail == null)
            {
                throw new InvalidOperationException("Cannot remove from Empty List");
            }
            T toReturn = _tail.Value;
            if (_head == _tail)
            {
                _head = null;
                _tail = null;
            }
            else
            {
                var refNode = _head!;
                while (refNode.Next != _tail)
                {
                    refNode = refNode.Next!;
                }
                refNode.Next = null;
                _tail = refNode;
            }
            _count--;
            return toReturn;
        }

        /// <summary>Removes the element at a specified index.</summary>
        /// <param name="index">The index of the element to remove.</param>
        /// <returns>The removed element.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the index is less than 0 or greater than or equal to the list's size.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the list is empty.</exception>
        public T DeleteAt(int index)
        {
            if (_count == 0) {
                throw new InvalidOperationException("cannot delete from empty list");
            }
            if (index < 0 || index >= _count)
            {
                throw new ArgumentOutOfRangeException(
                    "Cannot get element outside the range of List"
                );
            }
            if (index == 0)
            {
                return DeleteFromBeginning();
            }
            else if (index == _count - 1)
            {
                return DeleteFromEnd();
            }
            var refNode = _head!;
            int refIndex = 0;
            while (refIndex < index - 1)
            {
                refNode = refNode.Next!;
                refIndex++;
            }
            T toReturn = refNode.Next!.Value;
            refNode.Next = refNode.Next!.Next;
            _count--;
            return toReturn;
        }

        /// <summary>Checks if the list contains a given element.</summary>
        /// <param name="element">The element to search for.</param>
        /// <returns>True if the list contains the element, false otherwise.</returns>
        public bool Contains(T element)
        {
            if (_head == null)
            {
                return false;
            }
            SinglyLinkedListNode<T>? refNode = _head;
            while (refNode != null)
            {
                if (EqualityComparer<T>.Default.Equals(element, refNode.Value))
                {
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
            if (_head == null)
            {
                return -1;
            }
            SinglyLinkedListNode<T>? refNode = _head;
            int count = 0;
            while (refNode != null)
            {
                if (EqualityComparer<T>.Default.Equals(element, refNode.Value))
                {
                    return count;
                }
                refNode = refNode.Next;
                count++;
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
            if (_head == null) {
                throw new InvalidOperationException("Cannot get from Empty List");
            }
            if (index < 0 || index >= _count)
            {
                throw new ArgumentOutOfRangeException(
                    "Cannot get element outside the range of List"
                );
            }
            if (index == 0)
            {
                return _head!.Value;
            }
            if (index == _count - 1)
            {
                return _tail!.Value;
            }
            var refNode = _head!;
            var refCount = 0;
            while (refCount < index)
            {
                refNode = refNode.Next!;
                refCount++;
            }
            return refNode.Value;
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
            var enumerator = GetEnumerator();
            T[] toReturn = new T[_count];
            int index = 0;
            while (enumerator.MoveNext())
            {
                toReturn[index] = enumerator.Current;
                index++;
            }
            return toReturn;
        }

        /// <summary>Returns an enumerator that iterates through the list.</summary>
        /// <returns>An enumerator for the list.</returns>
        public IEnumerator<T> GetEnumerator()
        {
            var refNode = _head;
            while (refNode != null)
            {
                yield return refNode.Value;
                refNode = refNode.Next;
            }
        }
    }
}
