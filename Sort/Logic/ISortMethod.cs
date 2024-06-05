using Microsoft.Extensions.Caching.Memory;
using Sort.Model;

namespace Sort.Logic
{
    public interface ISortMethod
    {
        List<DllModel> SortedNums();
    }
}
