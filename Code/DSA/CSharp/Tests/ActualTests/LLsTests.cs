using Implementations.Interfaces;
using Implementations;
using System;
using System.Collections.Generic;

namespace Tests {
    public class LinkedListTests
    {
        // Generic test method to run tests on both SinglyLinkedList and DoublyLinkedList
        private void TestLinkedList<TLinkedList>()
            where TLinkedList : ILinkedList<int>, new()
        {
            ILinkedList<int> list = new TLinkedList();

            // InsertAtBeginning
            list.InsertAtBeginning(1);
            Assert.Equal(1, list.Size());
            Assert.Equal(1, list.Get(0));

            list.InsertAtBeginning(2);
            Assert.Equal(2, list.Size());
            Assert.Equal(2, list.Get(0));
            Assert.Equal(1, list.Get(1));

            // InsertAtEnd
            list.InsertAtEnd(3);
            Assert.Equal(3, list.Size());
            Assert.Equal(3, list.Get(2));

            // InsertAt
            list.InsertAt(1, 4);
            Assert.Equal(4, list.Size());
            Assert.Equal(4, list.Get(1));
            Assert.Equal(1, list.Get(2));

            Assert.Throws<ArgumentOutOfRangeException>(() => list.InsertAt(-1, 5));
            Assert.Throws<ArgumentOutOfRangeException>(() => list.InsertAt(list.Size() + 1, 5));

            // DeleteFromBeginning
            int deleted = list.DeleteFromBeginning();
            Assert.Equal(2, deleted);
            Assert.Equal(3, list.Size());
            Assert.Equal(4, list.Get(0));

            // DeleteFromEnd
            deleted = list.DeleteFromEnd();
            Assert.Equal(3, deleted);
            Assert.Equal(2, list.Size());
            Assert.Equal(4, list.Get(0));

            // DeleteAt
            deleted = list.DeleteAt(0);
            Assert.Equal(4, deleted);
            Assert.Equal(1, list.Size());

            Assert.Throws<ArgumentOutOfRangeException>(() => list.DeleteAt(-1));
            Assert.Throws<ArgumentOutOfRangeException>(() => list.DeleteAt(list.Size()));
            Assert.Throws<InvalidOperationException>(() => new TLinkedList().DeleteAt(0)); //delete from empty list

            // Contains
            list.InsertAtEnd(5);
            Assert.True(list.Contains(5));
            Assert.False(list.Contains(6));

            // IndexOf
            Assert.Equal(1, list.IndexOf(5));
            Assert.Equal(-1, list.IndexOf(6));

            // Get
            Assert.Equal(1, list.Get(0));
            Assert.Throws<ArgumentOutOfRangeException>(() => list.Get(-1));
            Assert.Throws<ArgumentOutOfRangeException>(() => list.Get(list.Size()));
            Assert.Throws<InvalidOperationException>(() => new TLinkedList().Get(0)); //get from empty list

            // Size & IsEmpty
            Assert.Equal(2, list.Size());
            Assert.False(list.IsEmpty());
            list.Clear();
            Assert.Equal(0, list.Size());
            Assert.True(list.IsEmpty());

            // ToArray
            list.InsertAtEnd(10);
            list.InsertAtEnd(20);
            int[] array = list.ToArray();
            Assert.Equal(2, array.Length);
            Assert.Equal(10, array[0]);
            Assert.Equal(20, array[1]);

            //Enumerator Test
            list.Clear();
            list.InsertAtEnd(10);
            list.InsertAtEnd(20);
            list.InsertAtEnd(30);
            List<int> intList = new List<int>();
            foreach (var item in list)
            {
                intList.Add(item);
            }
            Assert.Equal(3, intList.Count);
            Assert.Equal(10, intList[0]);
            Assert.Equal(20, intList[1]);
            Assert.Equal(30, intList[2]);
        }

        [Fact]
        public void SinglyLinkedList_Tests()
        {
            TestLinkedList<SinglyLinkedList<int>>();
        }

        [Fact]
        public void DoublyLinkedList_Tests()
        {
            TestLinkedList<DoublyLinkedList<int>>();
        }
    }
}