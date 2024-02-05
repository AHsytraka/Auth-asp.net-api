// using System.Security.Claims;

// namespace Authentication_api;

// public class JwtMiddleware
// {
//     private readonly RequestDelegate _next;

//     public JwtMiddleware(RequestDelegate next)
//     {
//         _next = next;
//     }

//     public async Task InvokeAsync(HttpContext context)
//     {
//         if (context.User.Identity.IsAuthenticated)
//         {
//             var userIdClaim = context.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
//             if (userIdClaim != null)
//             {
//                 int userId = int.Parse(userIdClaim.Value);
//                 // Now you have the user's ID. You can use it here.
//             }
//         }

//         // Call the next middleware in the pipeline
//         await _next(context);
//     }
// }
