// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.


namespace Bodoconsult.App.Interfaces;

/// <summary>
/// A delegate for consumer task used in <see cref="IProducerConsumerQueue{TType}"/>. Supports many producers but only one consumer.
/// </summary>
/// <typeparam name="TType">A class type</typeparam>
/// <param name="type">Current instance of TType</param>
public delegate void ConsumerTaskDelegate<in TType>(TType type) where TType : class;


/// <summary>
/// Implements a thread-safe generic producer consumer based pattern using threads
/// </summary>
public interface IProducerConsumerQueue<TType>: IDisposable where TType: class
{

    /// <summary>
    /// The delegate to consume each item added to the queue
    /// </summary>
    ConsumerTaskDelegate<TType> ConsumerTaskDelegate { get; set; }

    /// <summary>
    /// Is the queue started?
    /// </summary>
    bool IsActivated { get; }

    /// <summary>
    /// Enqueue an item to the internal queue for processing as soon as possible
    /// </summary>
    /// <param name="item">Item to add to the queue</param>
    void Enqueue(TType item);

    /// <summary>
    /// Start the consumer thread
    /// </summary>
    void StartConsumer();

    /// <summary>
    /// Stop the consumer thread
    /// </summary>
    void StopConsumer();

}