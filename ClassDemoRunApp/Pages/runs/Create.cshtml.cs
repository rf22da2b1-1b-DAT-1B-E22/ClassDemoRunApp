using ClassDemoRunApp.services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RunLib.model;
using System.ComponentModel.DataAnnotations;

namespace ClassDemoRunApp.Pages.runs
{
    public class CreateModel : PageModel
    {
        private readonly IMedlemRepositoryService service;

        public CreateModel(IMedlemRepositoryService repo)
        {
            service = repo;
        }

        /*
         * Properties to create a Member
         */
        [BindProperty]
        [Required(ErrorMessage = "Der skal være et Medlems Id")]
        [Range(0, int.MaxValue, ErrorMessage = "Medlems Id må ikke være negativ")]
        public int Id { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Der skal være et Navn")]
        [StringLength(1000, MinimumLength = 3, ErrorMessage = "Navn skal være mindst 3 tegn")]
        public String Navn { get; set; }

        [BindProperty]
        [StringLength(12, MinimumLength = 8, ErrorMessage = "Mobil nummer skal være mellem 8-12")]
        public String? Mobil { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Der skal være et Hold")]
        public String Hold { get; set; }


        [BindProperty]
        [Required(ErrorMessage = "Der skal være en pris")]
        [Range(50, 1000, ErrorMessage = "Prisen skal være over 50")]
        public double Price { get; set; }

        /*
         * Error
         */
        public String ErrorHold { get; private set; }
        //private static String msg = "";




        // når siden vises
        public void OnGet()
        {
        }


        // Når vi trykker på en knap
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            try
            {
                Medlem medlem = new Medlem(Navn, Id, Mobil, Hold, Price);

                service.Create(medlem);

                return RedirectToPage("Index");
            }
            catch (Exception ex)
            {
                ErrorHold = ex.Message;
                return Page();
            }
        }
    }
}
