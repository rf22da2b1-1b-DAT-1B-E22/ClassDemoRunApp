using ClassDemoRunApp.services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RunLib.model;

namespace ClassDemoRunApp.Pages.runs
{
    public class DeleteModel : PageModel
    {
        private readonly IMedlemRepositoryService service;

        public DeleteModel(IMedlemRepositoryService repo)
        {
            service = repo;
        }


        /*
         * Properties
         */
        public Medlem Medlem { get; set; }

        public void OnGet(int id)
        {
            Medlem = service.GetById(id);
        }

        public IActionResult OnPostSlet(int id)
        {
            service.Delete(id);
            return RedirectToPage("Index");
        }

        public IActionResult OnPostFortryd()
        {
            return RedirectToPage("Index");
        }
    }
}
