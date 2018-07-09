using System.Collections.Generic;

namespace PI.OnPay.Models
{
    public class ResponseWithPagination<T> where T : class
    {
        public List<ResponseWithLinks<T>> data { get; set; }
        public MetaData meta { get; set; }
        public List<Error> errors { get; set; }
    }
}
