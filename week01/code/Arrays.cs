public static class Arrays
{       
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // Step 1: Create an array of size 'length' to store the multiples
        double[] multiples = new double[length];

        // Step 2: Loop through the array indices from 0 to length-1
        for (int i = 0; i < length; i++)
        {
            // Step 3: Calculate the multiple for the current index
            // The first multiple is 'number', then 2*number, 3*number, ..., length*number
            multiples[i] = number * (i + 1);
        }

        // Step 4: Return the array with all the multiples
        return multiples;
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // Step 1: Calculate the index where we will "cut" the list.
        // We want the last 'amount' elements to move to the front.
        int cutIndex = data.Count - amount;

        // Step 2: Extract the last 'amount' elements using GetRange
        List<int> endPart = data.GetRange(cutIndex, amount);

        // Step 3: Extract the remaining elements at the start
        List<int> startPart = data.GetRange(0, cutIndex);

        // Step 4: Clear the original list to rebuild it
        data.Clear();

        // Step 5: Add the last 'amount' elements to the start
        data.AddRange(endPart);

        // Step 6: Add the remaining elements after them
        data.AddRange(startPart);
    }
}
