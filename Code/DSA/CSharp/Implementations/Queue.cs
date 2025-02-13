using System;
using Implementations.Interfaces;

namespace Implementations
{
    public class Queue<T>: IQueue<T> where T: IEquatable<T>
    {
        /// <summary>
        /// Inserts data into Queue
        /// </summary>
        /// <param name="data"></param>
        public void EnQueue(T data) {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Removes the first of the inserted elements in the Queue
        /// </summary>
        /// <returns>The removed element.</returns>
        /// <exception cref="InvalidOperationException">Thrown when the list is empty.</exception>
        public T DeQueue() {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Extracts the first of the inserted elements in the Queue without removing it
        /// </summary>
        /// <returns>The first element.</returns>
        /// <exception cref="InvalidOperationException">Thrown when the list is empty.</exception>
        public T Front() {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns the number of elements stored in the queue
        /// </summary>
        /// <returns>size of the queue</returns>
        public int Size() {
            throw new NotImplementedException();
        }

        /// <summary>
        ///  Checks if the list is empty.
        /// </summary>
        /// <returns>True if the list is empty, false otherwise.</returns>
        public bool IsEmptyQueue() {
            throw new NotImplementedException();
        }
    }
}
