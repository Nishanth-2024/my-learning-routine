using System;
using Implementations.Interfaces;

namespace Implementations
{
    public class ArrayBasedStack<T> : IStack<T>
    {
        private T[] _store;
        private int _top = -1;
        private readonly int _initialCapacity;

        public ArrayBasedStack(int initialCapacity = 10)
        {
            _initialCapacity = initialCapacity;
            _store = new T[_initialCapacity];
        }

        /// <summary>
        /// Pushes an element onto the top of the stack.
        /// </summary>
        /// <param name="element">The element to push.</param>
        public void Push(T element)
        {
            if (_top == _store.Length - 1)
            {
                IncreaseCapacity();
            }
            _store[++_top] = element;
        }

        private void IncreaseCapacity()
        {
            int newCapacity = _store.Length * 2;
            T[] newStore = new T[newCapacity];
            Array.Copy(_store, 0, newStore, 0, _top + 1);
            _store = newStore;
        }

        /// <summary>
        /// Removes and returns the element from the top of the stack.
        /// </summary>
        /// <returns>The element at the top of the stack.</returns>
        /// <exception cref="InvalidOperationException">Thrown when the stack is empty.</exception>
        public T Pop()
        {
            if (_top < 0)
            {
                throw new InvalidOperationException("Cannot pop from an empty Stack");
            }
            T toReturn = _store[_top];
            _top--;
            return toReturn;
        }

        /// <summary>
        /// Returns the element at the top of the stack without removing it.
        /// </summary>
        /// <returns>The element at the top of the stack.</returns>
        /// <exception cref="InvalidOperationException">Thrown when the stack is empty.</exception>
        public T Peek()
        {
            if (_top < 0)
            {
                throw new InvalidOperationException("Cannot peek into an empty Stack");
            }
            return _store[_top];
        }

        /// <summary>
        /// Checks if the stack is empty.
        /// </summary>
        /// <returns>True if the stack is empty, false otherwise.</returns>
        public bool IsEmpty()
        {
            return _top == -1;
        }

        /// <summary>
        /// Returns the number of elements in the stack.
        /// </summary>
        /// <returns>The number of elements.</returns>
        public int Size()
        {
            return _top + 1;
        }

        /// <summary>
        /// Removes all elements from the stack.
        /// </summary>
        public void Clear()
        {
            _top = -1;
            _store = new T[_initialCapacity];
        }

        /// <summary>
        /// Returns an array representation of the stack (top element will be the last element of array).
        /// </summary>
        /// <returns>An array containing the elements of the stack.</returns>
        public T[] ToArray()
        {
            if (_top < 0) return Array.Empty<T>();
            T[] newArray = new T[_top + 1];
            Array.Copy(_store, 0, newArray, 0, _top + 1);
            return newArray;
        }
    }
}
