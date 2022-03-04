using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPagesWebAppDemo.Pages
{
    public class FormFieldControlsUsingTagHelpersModel : PageModel
    {
            //Define an auto-implemented property for feedback messages
            public string Message { get; set; }
            //Define an auto-implemented property for username

            [BindProperty] //Bindeproperty bind a HTML form field to this property
            public string Username { get; set; }
            //Define an auto-implemented property for password
            [BindProperty]
            public string Password { get; set; }
            //Define a auto-implemented property for confirmed password
            [BindProperty]
            public string ConfrimPassword { get; set; }

            //Add a method to handle a HTTP post request.
            //The method must start with On follow by the HTTP method(Get, Post, Put,Delete) to handle

            public void OnPost()
            {
                //Check if the password matches the confirmPassword
                if (Password == ConfrimPassword)
                {
                    Message = $"You submitted the following:{Username},{Password}";
                }
                else
                {
                Message = $"Password:{Password} do not match ConfrimPassword: {ConfrimPassword} ";
                }
            }
            public void OnGet()
            {
            }
        
    }
}
