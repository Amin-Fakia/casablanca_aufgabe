// ReSharper disable SuggestVarOrType_BuiltInTypes
namespace MergeSortAlgo;

internal abstract class Program
{
    private static void Main(string[] args)
    {
        List<int> array = [6, 2, 10, 2, 5, 3, 2];
        Console.WriteLine(string.Join(", ", array));
        List<int> sorted = MergeSort(array);
        Console.WriteLine(string.Join(", ", sorted));
 
    }

    private static List<int> MergeSort(List<int> arr)
    {
        try
        {
            int arrayCount = arr.Count;
            if (arrayCount <= 1)  return arr; // case: list has only 1 element
            int middle = arrayCount / 2;
            List<int> left = [];
            List<int> right = [];

            for (int i = 0; i < middle; i++)
            {
                left.Add(arr[i]);
            }

            for (int i = middle; i < arrayCount; i++)
            {
                right.Add(arr[i]);
            }
            // recursivly break down the list into smaller lists
            left = MergeSort(left);
            right = MergeSort(right);

            return Merge(left, right);

        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    private static List<int> Merge(List<int> left, List<int> right)
    {
        List<int> mergedList = [];
        while (left.Count > 0 || right.Count > 0)
        {
            if (left.Count > 0 && right.Count > 0)
            {
                if (left.First() <= right.First())
                {
                    mergedList.Add(left.First());
                    left.Remove(left.First());
                }
                else
                {
                    mergedList.Add(right.First());
                    right.Remove(right.First());
                }
                
            } else if (left.Count > 0)
            {
                mergedList.Add(left.First());
                left.Remove(left.First());
            } else if (right.Count  > 0)
            {
                mergedList.Add(right.First());
                right.Remove(right.First());
            }
          
        }
        return mergedList;
        
    }
    
}