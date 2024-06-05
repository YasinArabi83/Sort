namespace BubbleSort
{
    public class BubbleSortClass
    {
        public void SortedNum(List<int> num)

        {
            List<int> result = num;
            var n = result.Count;


            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (result[j] > result[j + 1])
                    {
                        int tempVar = result[j];
                        result[j] = result[j + 1];
                        result[j + 1] = tempVar;
                    }
                }


            }

        }

    }
}

