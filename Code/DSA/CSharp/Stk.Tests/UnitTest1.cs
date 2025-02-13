﻿using System;
using System.Security.Cryptography.X509Certificates;
using Stk;
namespace Stk.Tests;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        IStack<int> stk = new ArrayBasedStack<int>();
        Assert.Empty(stk.ToArray());

        stk.Push(1);
        Assert.NotEmpty(stk.ToArray());

        Assert.Equal(1, stk.Peek());
        Assert.Equal(1, stk.ToArray()[0]);
        Assert.Equal(1, stk.Pop());
        Assert.Empty(stk.ToArray());

        stk.Push(1);
        stk.Push(2);
        stk.Push(3);
        stk.Push(4);
        stk.Push(5);

        stk.Push(11);
        stk.Push(12);
        stk.Push(13);
        stk.Push(14);
        stk.Push(15);

        stk.Push(21);
        stk.Push(22);
        stk.Push(23);
        stk.Push(24);
        stk.Push(25);

        Assert.Equal(25, stk.Peek());
        Assert.Equal(25, stk.Pop());
        Assert.Equal(24, stk.Peek());
        Assert.Equal(24, stk.Pop());
        Assert.Equal(23, stk.Peek());
        Assert.Equal(23, stk.Pop());
        Assert.Equal(22, stk.Peek());
        Assert.Equal(22, stk.Pop());
        Assert.Equal(21, stk.Peek());
        Assert.Equal(21, stk.Pop());

        Assert.Equal(15, stk.Peek());
        Assert.Equal(15, stk.Pop());
        Assert.Equal(14, stk.Peek());
        Assert.Equal(14, stk.Pop());
        Assert.Equal(13, stk.Peek());
        Assert.Equal(13, stk.Pop());
        Assert.Equal(12, stk.Peek());
        Assert.Equal(12, stk.Pop());
        Assert.Equal(11, stk.Peek());
        Assert.Equal(11, stk.Pop());

        Assert.Equal(5, stk.Peek());
        Assert.Equal(5, stk.Pop());
        Assert.Equal(4, stk.Peek());
        Assert.Equal(4, stk.Pop());
        Assert.Equal(3, stk.Peek());
        Assert.Equal(3, stk.Pop());
        Assert.Equal(2, stk.Peek());
        Assert.Equal(2, stk.Pop());
        Assert.Equal(1, stk.Peek());
        Assert.Equal(1, stk.Pop());

        Assert.Throws<InvalidOperationException>(() => stk.Peek());
        Assert.Throws<InvalidOperationException>(() => stk.Pop());
    }
}
