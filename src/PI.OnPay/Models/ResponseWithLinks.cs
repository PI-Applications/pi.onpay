using System.Collections.Generic;

namespace PI.OnPay.Models
{
    public class ResponseWithLinks<T> where T : class
    {
        public T data { get; set; }
        public List<Link> links { get; set; }
        public List<Error> errors { get; set; }
    }
}
