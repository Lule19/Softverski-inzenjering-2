using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DataBaseContext;
using DatabaseEntityLib;

namespace ElektronskaUcionica.Pages.ZadaciPage
{
    public class ZadaciModel : PageModel
    {
        private readonly DB_Context_Class _context;

        public ZadaciModel(DB_Context_Class context)
        {
            _context = context;
        }

        public IList<Zadaci> Zadaci { get; set; } = default!;

        [BindProperty]
        public string SearchText { get; set; }

        public void OnPost()
        {
<<<<<<< HEAD
            /*za search bitno je da ukljucuje i predmet i oblast */
=======
            
>>>>>>> privremena_grana
            if (SearchText == null)
            {
                Zadaci = _context.Zadaci
                    .Include(p => p.Predmet)
                    .Include(p => p.Oblast)
                    .ToList();
            }
            else
            {
                Zadaci = _context.Zadaci
                    .Where(x => x.Pitanje.Contains(SearchText) ||
<<<<<<< HEAD
                                x.Predmet.Name.Contains(SearchText) || // Dodajte uslov za pretragu po nazivu predmeta
                                x.Oblast.Name.Contains(SearchText))   // Dodajte uslov za pretragu po nazivu oblasti
=======
                                x.Predmet.Name.Contains(SearchText) || 
                                x.Oblast.Name.Contains(SearchText))   
>>>>>>> privremena_grana
                    .Include(p => p.Predmet)
                    .Include(p => p.Oblast)
                    .ToList();
            }
        }



        public void OnGet()
        {
            if (_context.Zadaci != null)
            {
                Zadaci = _context.Zadaci
               .Include(p => p.Predmet)
               .Include(p => p.Oblast).ToList();
            }
        }
    }
}
