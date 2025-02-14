using System;
using Implementations.Interfaces;

namespace Implementations
{
    /// <summary>
    /// Represents a first-in, first-out (FIFO) collection of objects.  This implementation uses a singly linked list for storage.
    /// </summary>
    /// <typeparam name="T">The type of the elements in the queue. This type must implement <see cref="IEquatable{T}"/>.</typeparam>
    /// <remarks>
    /// TODO: **Key Improvements and Considerations:**
    /// * **IEquatable Constraint:** The `IEquatable<T>` constraint on the generic type `T` might be unnecessary for a basic queue implementation and should be removed unless required by the `IQueue<T>` interface or specific queue operations (like `Contains`).  If equality comparisons are needed, consider using `IComparer<T>` for more flexibility.
    /// * **Singly Linked List Efficiency:** The performance of this queue is entirely dependent on the underlying `SinglyLinkedList<T>` implementation.  Ensure that `InsertAtEnd`, `DeleteFromBeginning`, and `Get(0)` are all O(1) operations.  Critically, the `Size()` method *must* be O(1) by maintaining a count within the linked list.  Avoid iterating through the list to calculate the size.
    /// * **Naming Consistency:** Rename `IsEmptyQueue()` to `IsEmpty()` for consistency with .NET conventions.
    /// * **Thread Safety:** This implementation is *not* thread-safe.  For concurrent access, use `System.Collections.Concurrent.ConcurrentQueue<T>` or implement appropriate synchronization mechanisms.
    /// </remarks>
    public class Queue<T> : IQueue<T> where T : IEquatable<T>
    {
        private ILinkedList<T> _store = new SinglyLinkedList<T>();

        /// <summary>
        /// Enqueues an element to the end of the queue.
        /// </summary>
        /// <param name="data">The element to enqueue.</param>
        public void EnQueue(T data)
        {
            _store.InsertAtEnd(data);
        }

        /// <summary>
        /// Dequeues and returns the element at the front of the queue.
        /// </summary>
        /// <returns>The element removed from the front of the queue.</returns>
        /// <exception cref="InvalidOperationException">Thrown when the queue is empty.</exception>
        public T DeQueue()
        {
            if (IsEmptyQueue())
            {
                throw new InvalidOperationException("Cannot perform DeQueue operation on an Empty Queue");
            }
            return _store.DeleteFromBeginning();
        }

        /// <summary>
        /// Returns the element at the front of the queue without removing it.
        /// </summary>
        /// <returns>The element at the front of the queue.</returns>
        /// <exception cref="InvalidOperationException">Thrown when the queue is empty.</exception>
        public T Front()
        {
            if (IsEmptyQueue())
            {
                throw new InvalidOperationException("Cannot Get Front from an Empty Queue");
            }
            return _store.Get(0);
        }

        /// <summary>
        /// Gets the number of elements in the queue.
        /// </summary>
        /// <returns>The number of elements in the queue.</returns>
        public int Size()
        {
            return _store.Size();
        }

        /// <summary>
        /// Checks if the queue is empty.
        /// </summary>
        /// <returns><code>true</code> if the queue is empty; otherwise, <code>false</code>.</returns>
        public bool IsEmptyQueue()
        {
            return _store.IsEmpty();
        }
    }
}
