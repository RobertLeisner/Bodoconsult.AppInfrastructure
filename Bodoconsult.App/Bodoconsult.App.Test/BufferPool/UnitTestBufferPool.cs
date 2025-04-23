﻿using Bodoconsult.App.BufferPool;

namespace Bodoconsult.App.Test.BufferPool;

internal class UnitTestBufferPool
{
    private const int NumberOfItems = 1000;

    [Test]
    public void TestAllocate()
    {
        // Arrange 
        var myPool = new BufferPool<byte[]>(() => new byte[65535]);

        // Act  
        myPool.Allocate(NumberOfItems);

        // Assert
        Assert.That(myPool.LengthOfQueue, Is.EqualTo(NumberOfItems));

    }

    [Test]
    public void TestDequeue()
    {
        // Arrange 
        var myPool = new BufferPool<byte[]>(() => new byte[65535]);
        myPool.Allocate(NumberOfItems);

        // Act  
        var buffer = myPool.Dequeue();

        // Assert
        Assert.That(buffer, Is.Not.Null);
        Assert.That(myPool.LengthOfQueue, Is.EqualTo(NumberOfItems - 1));


    }


    [Test]
    public void TestEnqueue()
    {
        // Arrange 
        var myPool = new BufferPool<byte[]>(() => new byte[65535]);
        myPool.Allocate(1000);

        var buffer = myPool.Dequeue();

        // Act  
        myPool.Enqueue(buffer);

        // Assert
        Assert.That(myPool.LengthOfQueue, Is.EqualTo(NumberOfItems));

    }

}