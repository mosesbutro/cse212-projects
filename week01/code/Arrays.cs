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
        // TODO Problem 1 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        // PLAN:
        // 1. Create a new array of type double with a size equal to 'length'.
        // 2. Loop through the array using a for loop, with index i from 0 to length - 1.
        // 3. For each index i, assign number * (i + 1) to the array.
        // 4. After the loop ends, return the array.
        double[] multiples = new double[length];
        for (int i = 0; i < length; i++)
        {
            multiples[i] = number * (i + 1);
        }
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
        // TODO Problem 2 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        // PLAN:
        // 1. Determine the size of the list: data.Count.
        // 2. Use GetRange to get the last 'amount' elements (i.e., data.Count - amount to end).
        // 3. Use GetRange again to get the first part (i.e., 0 to data.Count - amount).
        // 4. Clear the original list (or overwrite it) and add the two parts in rotated order:
        //    - First add the last part (step 2), then the first part (step 3).
        // 5. This effectively rotates the list to the right.

        int count = data.Count;

        if (amount <= 0 || amount >= count)
            return; // Edge case: rotating by full length or 0 doesn't change the list.

        List<int> lastPart = data.GetRange(count - amount, amount);
        List<int> firstPart = data.GetRange(0, count - amount);

        data.Clear();
        data.AddRange(lastPart);
        data.AddRange(firstPart);
    }
}
