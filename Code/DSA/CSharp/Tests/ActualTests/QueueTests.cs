using Xunit;
using Implementations.Interfaces; // Assuming your IQueue interface is here
using System;
using System.Collections.Generic; // For the test data

public class QueueTests
{
    // Test data (can be reused across different queue implementations)
    public static IEnumerable<object[]> QueueImplementations()
    {
        yield return new object[] { new Implementations.Queue<int>() }; // Your current Queue<int>
        //yield return new object[] { new AnotherQueueImplementation<int>() }; // Future implementation
        //yield return new object[] { new YetAnotherQueue<int>() }; // Another future implementation
    }

    [Theory]
    [MemberData(nameof(QueueImplementations))]
    public void Enqueue_AddsElementToQueue(IQueue<int> queue)
    {
        queue.EnQueue(10);
        Assert.Equal(1, queue.Size());
    }

    [Theory]
    [MemberData(nameof(QueueImplementations))]
    public void Dequeue_RemovesAndReturnsFrontElement(IQueue<int> queue)
    {
        queue.EnQueue(10);
        queue.EnQueue(20);
        var dequeuedElement = queue.DeQueue();
        Assert.Equal(10, dequeuedElement);
        Assert.Equal(1, queue.Size());
    }

    [Theory]
    [MemberData(nameof(QueueImplementations))]
    public void Dequeue_ThrowsExceptionWhenQueueIsEmpty(IQueue<int> queue)
    {
        Assert.Throws<InvalidOperationException>(() => queue.DeQueue());
    }

    [Theory]
    [MemberData(nameof(QueueImplementations))]
    public void Front_ReturnsFrontElementWithoutRemoving(IQueue<int> queue)
    {
        queue.EnQueue(10);
        queue.EnQueue(20);
        var frontElement = queue.Front();
        Assert.Equal(10, frontElement);
        Assert.Equal(2, queue.Size()); // Size should not change
    }

    [Theory]
    [MemberData(nameof(QueueImplementations))]
    public void Front_ThrowsExceptionWhenQueueIsEmpty(IQueue<int> queue)
    {
        Assert.Throws<InvalidOperationException>(() => queue.Front());
    }

    [Theory]
    [MemberData(nameof(QueueImplementations))]
    public void EnqueueDequeue_MultipleElements_MaintainsFIFOOrder(IQueue<int> queue)
    {
        queue.EnQueue(1);
        queue.EnQueue(2);
        queue.EnQueue(3);

        Assert.Equal(1, queue.DeQueue());
        Assert.Equal(2, queue.DeQueue());
        Assert.Equal(3, queue.DeQueue());
        Assert.True(queue.IsEmptyQueue()); // Use IsEmpty() consistently
    }

    [Theory]
    [MemberData(nameof(QueueImplementations))]
    public void StringQueueTest(IQueue<int> queue) // Note the IQueue<string>
    {
        queue.EnQueue(1);
        queue.EnQueue(2);
        queue.EnQueue(3);

        Assert.Equal(1, queue.DeQueue());
        Assert.Equal(2, queue.DeQueue());
        Assert.Equal(3, queue.DeQueue());
        Assert.True(queue.IsEmptyQueue());
    }

    [Theory]
    [MemberData(nameof(QueueImplementations))]
    public void LargeQueueTest(IQueue<int> queue)
    {
        int largeNumber = 100000;

        for (int i = 0; i < largeNumber; i++)
        {
            queue.EnQueue(i);
        }

        Assert.Equal(largeNumber, queue.Size());

        for (int i = 0; i < largeNumber; i++)
        {
            Assert.Equal(i, queue.DeQueue());
        }

        Assert.True(queue.IsEmptyQueue());
    }
}