using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    // This test verifies that the item with the highest priority
    // is removed first. Before fixing Dequeue, it failed because
    // the logic did not correctly select the highest priority item.
    [TestMethod]
    // Scenario: Add items A(1), B(3), C(2) and dequeue once
    // Expected Result: B is removed first
    // Defect(s) Found: Dequeue did not correctly identify the item with highest priority
    public void TestPriorityQueue_HighestPriority()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("A", 1);
        priorityQueue.Enqueue("B", 3);
        priorityQueue.Enqueue("C", 2);

        string removed = priorityQueue.Dequeue();
        Assert.AreEqual("B", removed);
    }

    // This test verifies FIFO behavior when multiple items have the same highest priority.
    // Before fixing Dequeue, it failed because the first inserted item with highest priority
    // might not have been removed first.
    [TestMethod]
    // Scenario: Add items A(2), B(2), C(1) and dequeue once
    // Expected Result: A is removed first (FIFO for same priority)
    // Defect(s) Found: Dequeue did not maintain FIFO for items with same highest priority
    public void TestPriorityQueue_FIFOForSamePriority()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("A", 2);
        priorityQueue.Enqueue("B", 2);
        priorityQueue.Enqueue("C", 1);

        string removed = priorityQueue.Dequeue();
        Assert.AreEqual("A", removed);
    }

    // This test verifies that trying to dequeue from an empty queue throws the correct exception.
    [TestMethod]
    // Scenario: Dequeue from an empty queue
    // Expected Result: InvalidOperationException with message "The queue is empty."
    // Defect(s) Found: Empty queue was not handled properly
    public void TestPriorityQueue_EmptyQueue()
    {
        var priorityQueue = new PriorityQueue();

        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
    }
}
