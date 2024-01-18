using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DataBaseContext;
using DatabaseEntityLib;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace ElektronskaUcionica.Pages.ZadaciPage
{
    public class CreateModel : PageModel
    {
        private readonly DataBaseContext.DB_Context_Class _context;

        private IWebHostEnvironment _environment;

        public CreateModel(DataBaseContext.DB_Context_Class context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }
        public IActionResult OnGet()
        {
            ViewData["IDPredmet"] = new SelectList(_context.Predmeti, "ID", "Name");
            ViewData["IDOblast"] = new SelectList(_context.Oblasti, "ID", "Name");
<<<<<<< HEAD
            // Assuming _context.Zadaci is a collection of objects with a property named "Nivo"
            var uniqueNivoValues = _context.Zadaci.Select(z => z.Nivo).Distinct().ToList();

            // Create a SelectList with unique Nivo values
=======
           
            var uniqueNivoValues = _context.Zadaci.Select(z => z.Nivo).Distinct().ToList();

           
>>>>>>> privremena_grana
            ViewData["Nivo"] = new SelectList(uniqueNivoValues);



            return Page();
        }

        [BindProperty]
        public Zadaci Zadaci { get; set; } = default!;
        
        [BindProperty]
        public IFormFile Upload { get; set; }

<<<<<<< HEAD
        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (/*!ModelState.IsValid ||*/ _context.Zadaci == null || Zadaci == null)
=======
     
        public async Task<IActionResult> OnPostAsync()
        {
            if ( _context.Zadaci == null || Zadaci == null)
>>>>>>> privremena_grana
            {
                return Page();
            }
           
            var file = Path.Combine(_environment.ContentRootPath, "wwwroot\\slike", Upload.FileName);
            using (var fileStream = new FileStream(file, FileMode.Create))
            {
                await Upload.CopyToAsync(fileStream);

                Zadaci.Slika = Upload.FileName;
            }
           
            _context.Zadaci.Add(Zadaci);
            await _context.SaveChangesAsync();

            return RedirectToPage("./zadatak");
        }
    }
}
