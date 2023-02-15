using ClassDemoRunApp.services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RunLib.model;

namespace ClassDemoRunApp.Pages.runs
{
    public class IndexModel : PageModel
    {
        private readonly IMedlemRepositoryService service;

        public IndexModel(IMedlemRepositoryService repo)
        {
            service = repo;
        }


        /*
         * Properties for the page
         */
        public List<Medlem> Medlemmer { get; private set; }

        
        public void OnGet()
        {
            Medlemmer = service.GetAll();
        }

    }
}
