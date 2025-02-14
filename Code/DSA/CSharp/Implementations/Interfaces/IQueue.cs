using System;

namespace Implementations.Interfaces
{
    public interface IQueue<T> where T: IEquatable<T>
    {
        /// <summary>
        /// Inserts data into Queue
        /// </summary>
        /// <param name="data"></param>
        void EnQueue(T data);

        /// <summary>
        /// Removes the first of the inserted elements in the Queue
        /// </summary>
        /// <returns>The removed element.</returns>
        /// <exception cref="InvalidOperationException">Thrown when the list is empty.</exception>
        T DeQueue();

        /// <summary>
        /// Extracts the first of the inserted elements in the Queue without removing it
        /// </summary>
        /// <returns>The first element.</returns>
        /// <exception cref="InvalidOperationException">Thrown when the list is empty.</exception>
        T Front();

        /// <summary>
        /// Returns the number of elements stored in the queue
        /// </summary>
        /// <returns>size of the queue</returns>
        int Size();

        /// <summary>
        ///  Checks if the list is empty.
        /// </summary>
        /// <returns>True if the list is empty, false otherwise.</returns>
        bool IsEmptyQueue();
    }
}
