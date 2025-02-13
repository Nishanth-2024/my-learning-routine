using System;
using System.Collections.Generic;

namespace LLs
{
    public interface ILinkedList<T>
    {
        /// <summary>Inserts a new element at the beginning of the list.</summary>
        /// <param name="element">The element to insert.</param>
        void InsertAtBeginning(T element);

        /// <summary>Inserts a new element at the end of the list.</summary>
        /// <param name="element">The element to insert.</param>
        void InsertAtEnd(T element);

        /// <summary>Inserts a new element at a specified index.</summary>
        /// <param name="index">The index at which to insert the element.</param>
        /// <param name="element">The element to insert.</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the index is less than 0 or greater than the list's size.</exception>
        void InsertAt(int index, T element);

        /// <summary>Removes the element from the beginning of the list.</summary>
        /// <returns>The removed element.</returns>
        /// <exception cref="InvalidOperationException">Thrown when the list is empty.</exception>
        T DeleteFromBeginning();

        /// <summary>Removes the element from the end of the list.</summary>
        /// <returns>The removed element.</returns>
        /// <exception cref="InvalidOperationException">Thrown when the list is empty.</exception>
        T DeleteFromEnd();

        /// <summary>Removes the element at a specified index.</summary>
        /// <param name="index">The index of the element to remove.</param>
        /// <returns>The removed element.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the index is less than 0 or greater than or equal to the list's size.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the list is empty.</exception>
        T DeleteAt(int index);

        /// <summary>Checks if the list contains a given element.</summary>
        /// <param name="element">The element to search for.</param>
        /// <returns>True if the list contains the element, false otherwise.</returns>
        bool Contains(T element);

        /// <summary>Returns the index of the first occurrence of a given element.</summary>
        /// <param name="element">The element to search for.</param>
        /// <returns>The index of the first occurrence, or -1 if the element is not found.</returns>
        int IndexOf(T element);

        /// <summary>Returns the element at a specified index.</summary>
        /// <param name="index">The index of the element to retrieve.</param>
        /// <returns>The element at the specified index.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the index is less than 0 or greater than or equal to the list's size.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the list is empty.</exception>
        T Get(int index);

        /// <summary>Returns the number of elements in the list.</summary>
        /// <returns>The number of elements.</returns>
        int Size();

        /// <summary>Checks if the list is empty.</summary>
        /// <returns>True if the list is empty, false otherwise.</returns>
        bool IsEmpty();

        /// <summary>Removes all elements from the list.</summary>
        void Clear();

        /// <summary>Returns an array representation of the list.</summary>
        /// <returns>An array containing the elements of the list.</returns>
        T[] ToArray();

        /// <summary>Returns an enumerator that iterates through the list.</summary>
        /// <returns>An enumerator for the list.</returns>
        IEnumerator<T> GetEnumerator();
    }
}
