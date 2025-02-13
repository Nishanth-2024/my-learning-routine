using System;

namespace Implementations.Interfaces
{
    public interface IStack<T>
    {
        /// <summary>Pushes an element onto the top of the stack.</summary>
        /// <param name="element">The element to push.</param>
        void Push(T element);

        /// <summary>Removes and returns the element from the top of the stack.</summary>
        /// <returns>The element at the top of the stack.</returns>
        /// <exception cref="InvalidOperationException">Thrown when the stack is empty.</exception>
        T Pop();

        /// <summary>Returns the element at the top of the stack without removing it.</summary>
        /// <returns>The element at the top of the stack.</returns>
        /// <exception cref="InvalidOperationException">Thrown when the stack is empty.</exception>
        T Peek();

        /// <summary>Checks if the stack is empty.</summary>
        /// <returns>True if the stack is empty, false otherwise.</returns>
        bool IsEmpty();

        /// <summary>Returns the number of elements in the stack.</summary>
        /// <returns>The number of elements.</returns>
        int Size();

        /// <summary>Removes all elements from the stack.</summary>
        void Clear();

        /// <summary>Returns an array representation of the stack (top element will be the last element of array)</summary>
        /// <returns>An array containing the elements of the stack.</returns>
        T[] ToArray();
    }
}
