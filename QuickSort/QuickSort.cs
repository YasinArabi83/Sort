namespace QuickSort
{
    public class QuickSort
    {
        public  void SortedNum(List<int>arr)
        {
            QuickSortInternal(arr, 0, arr.Count - 1);
        }

        private void QuickSortInternal(List<int> arr, int left, int right)
        {
            if (left >= right)
            {
                return;
            }

            int partition = PartitionInternal(arr, left, right);
            QuickSortInternal(arr, left, partition - 1);
            QuickSortInternal(arr, partition + 1, right);
        }

        private  int PartitionInternal(List<int> arr, int left, int right)
        {
            int pivot = arr[right];
            int swapIndex = left;

            for (int i = left; i < right; i++)
            {
                if (arr[i] <= pivot)
                {
                    int temp = arr[i];
                    arr[i] = arr[swapIndex];
                    arr[swapIndex] = temp;
                    swapIndex++;
                }
            }

            arr[right] = arr[swapIndex];
            arr[swapIndex] = pivot;
            return swapIndex;
        }
    }
}
