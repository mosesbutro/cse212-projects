using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Adding three string items with different priorities, expecting the highest priority item to be removed first.
    // Expected Result: Dequeue returns "Bob" (priority 5).
    // Defect(s) Found: Original loop logic missed comparing the last item in the queue, causing incorrect item removal.
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Alice", 2);
        priorityQueue.Enqueue("Bob", 5);   // highest priority
        priorityQueue.Enqueue("Charlie", 3);

        var first = priorityQueue.Dequeue();
        Assert.AreEqual("Bob", first);
    }

    [TestMethod]
    // Scenario: Enqueue items A (2), B (2), C (2), Dequeue once
    // Expected Result: A is returned (FIFO for same priority)
    // Defect(s) Found: Initial loop may select last instead of first for equal priority

    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("A", 2);
        priorityQueue.Enqueue("B", 2);
        priorityQueue.Enqueue("C", 2);

        var result = priorityQueue.Dequeue();
        Assert.AreEqual("A", result);
    }

    // Add more test cases as needed below.

    [TestMethod]
    // Scenario: Dequeue from empty queue
    // Expected Result: Throws InvalidOperationException with message
    // Defect(s) Found: If queue is empty, no exception or wrong exception
    public void TestPriorityQueue_EmptyQueue()
    {
        var priorityQueue = new PriorityQueue();

        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Expected exception was not thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
    }

    [TestMethod]
    // Scenario: Adding four items, removing them one by one in order of highest priority.
    // Expected Result:
    // 1st Dequeue: "Bob"  (priority 5)
    // 2nd Dequeue: "Charlie" (priority 4)
    // 3rd Dequeue: "Alice" (priority 3)
    // 4th Dequeue: "Dave"  (priority 1)
    // Defect(s) Found: In original code, queue did not update correctly after multiple dequeues
    public void TestPriorityQueue_MultipleDequeues()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Alice", 3);
        priorityQueue.Enqueue("Bob", 5);       // highest priority
        priorityQueue.Enqueue("Charlie", 4);
        priorityQueue.Enqueue("Dave", 1);      // lowest priority

        Assert.AreEqual("Bob", priorityQueue.Dequeue());     // highest first
        Assert.AreEqual("Charlie", priorityQueue.Dequeue()); // next highest
        Assert.AreEqual("Alice", priorityQueue.Dequeue());   // next highest
        Assert.AreEqual("Dave", priorityQueue.Dequeue());    // lowest last
    }


}