using Microsoft.AspNetCore.Mvc;

namespace ModelBindingSample.Models
{
    public class Book
    {
        //[FromQuery]
        // validate the property in model, not in controller
        public int? BookId { get; set; }
        // this can from Route or query
        public string? Author { get; set; }
        public override string ToString()
        {
            return $"BookObject - Book id: {BookId}, Author: {Author}";
        }
    }
}
