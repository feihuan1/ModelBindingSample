using Microsoft.AspNetCore.Mvc;
using ModelBindingSample.Models;

namespace ModelBindingSample.Controllers
{
    public class HomeController : Controller
    {
        // book auto assigned bookid when bookid recieved from route data or query string
        [Route("bookstore/{bookid?}/{isloggedin?}")]
        public IActionResult Index(
            [FromQuery]int? bookid, // [FromRoute] // this can be set in model if object need data from diferent source
            [FromRoute]bool isloggedin,
            Book book // the property recieves value from query or route data(higher priority if no flag[]) automatically assigned to the instance of class if name matches(case in-sensative)
        )
        {
            if(bookid.HasValue == false) // validation of requested data
            {
                return BadRequest("Book id is not supplied or empty");// bookid in book can be null without this check
            }

            if(bookid <= 0)
            {
                return BadRequest("Bood id can't be less or equal than 0");
            }

            return Content($"Book id: {bookid}, Book: {book}", "text/plain");
        }

        // form fields 
        // form fields will add to request in either of these wo formats (same way to recieve data use model binding):
        // 1. form-urlencoded(default in html, small form)
        //      request headers: Content-Type: application/x-www-form-urlencoded (pre-defined fix name)
        //      request body: param1=value1&param2=value2

        // 2. form-data -> handle large form, contain files
        //      request headers: Content-Type: multipart/form-data
        //      request body --------------------d74496d6698873e
        //                   Content-Disposition: form-data; name="param1"
        //                   value1        
        //                   --------------------d74496d6698873e
        //                   Content-Disposition: form-data; name="param2"
        //                   value2

    }
}
