namespace MergeSort
{
    public class MergeSort
    {
        public  void SortedNum(List<int> list)
        {
            if (list.Count <= 1)
                return;

            int middle = list.Count / 2;
            List<int> left = new List<int>(list.GetRange(0, middle));
            List<int> right = new List<int>(list.GetRange(middle, list.Count - middle));

            SortedNum(left);
            SortedNum(right);

            Merge(list, left, right);
        }

        private  void Merge(List<int> list, List<int> left, List<int> right)
        {
            int leftIndex = 0, rightIndex = 0, targetIndex = 0;

            while (leftIndex < left.Count && rightIndex < right.Count)
            {
                if (left[leftIndex] < right[rightIndex])
                    list[targetIndex++] = left[leftIndex++];
                else
                    list[targetIndex++] = right[rightIndex++];
            }

            while (leftIndex < left.Count)
                list[targetIndex++] = left[leftIndex++];

            while (rightIndex < right.Count)
                list[targetIndex++] = right[rightIndex++];
        }

      
    }
}

