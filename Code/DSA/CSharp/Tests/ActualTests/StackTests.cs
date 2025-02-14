using Xunit;
using Implementations.Interfaces;
using Implementations;
using System;
using System.Collections.Generic;

namespace Tests
{
    public class StackTests
    {
        public static IEnumerable<object[]> StackImplementations()
        {
            yield return new object[] { new ArrayBasedStack<int>() };
            // Add other stack implementations here as you create them
            // yield return new object[] { new AnotherStackImplementation<int>() };
        }

        [Theory]
        [MemberData(nameof(StackImplementations))]
        public void Push_AddsElementToStack(IStack<int> stack)
        {
            stack.Push(10);
            Assert.Equal(1, stack.Size());
        }

        [Theory]
        [MemberData(nameof(StackImplementations))]
        public void Pop_RemovesAndReturnsTopElement(IStack<int> stack)
        {
            stack.Push(10);
            stack.Push(20);
            var poppedElement = stack.Pop();
            Assert.Equal(20, poppedElement);
            Assert.Equal(1, stack.Size());
        }

        [Theory]
        [MemberData(nameof(StackImplementations))]
        public void Pop_ThrowsExceptionWhenStackIsEmpty(IStack<int> stack)
        {
            Assert.Throws<InvalidOperationException>(() => stack.Pop());
        }

        [Theory]
        [MemberData(nameof(StackImplementations))]
        public void Peek_ReturnsTopElementWithoutRemoving(IStack<int> stack)
        {
            stack.Push(10);
            stack.Push(20);
            var topElement = stack.Peek();
            Assert.Equal(20, topElement);
            Assert.Equal(2, stack.Size()); // Size should not change
        }

        [Theory]
        [MemberData(nameof(StackImplementations))]
        public void Peek_ThrowsExceptionWhenStackIsEmpty(IStack<int> stack)
        {
            Assert.Throws<InvalidOperationException>(() => stack.Peek());
        }

        [Theory]
        [MemberData(nameof(StackImplementations))]
        public void PushPop_MultipleElements_MaintainsLIFOOrder(IStack<int> stack)
        {
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);

            Assert.Equal(3, stack.Pop());
            Assert.Equal(2, stack.Pop());
            Assert.Equal(1, stack.Pop());
            Assert.True(stack.IsEmpty());
        }

        [Theory]
        [MemberData(nameof(StackImplementations))]
        public void IsEmpty_ReturnsTrueForEmptyStack(IStack<int> stack)
        {
            Assert.True(stack.IsEmpty());
        }

        [Theory]
        [MemberData(nameof(StackImplementations))]
        public void IsEmpty_ReturnsFalseForNonEmptyStack(IStack<int> stack)
        {
            stack.Push(1);
            Assert.False(stack.IsEmpty());
        }

        [Theory]
        [MemberData(nameof(StackImplementations))]
        public void Size_ReturnsCorrectSize(IStack<int> stack)
        {
            Assert.Equal(0, stack.Size());
            stack.Push(1);
            Assert.Equal(1, stack.Size());
            stack.Push(2);
            Assert.Equal(2, stack.Size());
            stack.Pop();
            Assert.Equal(1, stack.Size());
        }


        [Theory]
        [MemberData(nameof(StackImplementations))]
        public void Clear_EmptiesTheStack(IStack<int> stack)
        {
            stack.Push(1);
            stack.Push(2);
            stack.Clear();
            Assert.True(stack.IsEmpty());
            Assert.Equal(0, stack.Size());
            Assert.Throws<InvalidOperationException>(() => stack.Peek()); // Verify behavior after clear
            Assert.Throws<InvalidOperationException>(() => stack.Pop());  // Verify behavior after clear
        }

        [Theory]
        [MemberData(nameof(StackImplementations))]
        public void ToArray_ReturnsCorrectArray(IStack<int> stack)
        {
            Assert.Empty(stack.ToArray());
            stack.Push(1);
            stack.Push(2);
            var array = stack.ToArray();
            Assert.Equal(2, array.Length);
            Assert.Equal(2, array[0]);  // Top of stack is first in array
            Assert.Equal(1, array[1]);
        }

        [Theory]
        [MemberData(nameof(StackImplementations))]
        public void LargeStackTest(IStack<int> stack)
        {
            int largeNumber = 10000; // Reduced for faster test execution. Adjust as needed.

            for (int i = 0; i < largeNumber; i++)
            {
                stack.Push(i);
            }

            Assert.Equal(largeNumber, stack.Size());

            for (int i = largeNumber -1 ; i >= 0; i--)
            {
                Assert.Equal(i, stack.Pop());
            }

            Assert.True(stack.IsEmpty());
        }

    }
}