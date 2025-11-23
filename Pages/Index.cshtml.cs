using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Unmanned_Surface_Vessel_Simulator.Models.DTO;
using Unmanned_Surface_Vessel_Simulator.Models.DTO.Request;
using Unmanned_Surface_Vessel_Simulator.Models.Entity;

namespace Unmanned_Surface_Vessel_Simulator.Pages
{
    public class IndexModel : PageModel
    {
        private static UnmannedSurfaceVessel USV = new UnmannedSurfaceVessel();

        [BindProperty]
        public DepartRequest DepartRequest { get; set; }

        public string Res { get; set; }

        public void OnGet()
        {
            Res = USV.HasDeparted ? USV.Status() : "Vessel has not yet departed";
        }

        public IActionResult OnPostDepart()
        {
            if (!ModelState.IsValid)
            {
                Res = "Invalid input";
                USV.reset();
                return Page();
            }
            bool success = USV.Depart(DepartRequest.X, DepartRequest.Y, DepartRequest.Facing);
            Res = success ? $"{USV.Status()}" : "Invalid departure coordinates";

            return Page();
        }

        public IActionResult OnPostSail()
        {
            if (!USV.HasDeparted)
            {
                Res = "Vessel has not yet departed";
                return Page();
            }

            USV.Sail();
            Res = USV.Status();
            return Page();
        }

        public IActionResult OnPostPort()
        {
            if (!USV.HasDeparted)
            {
                Res = "Vessel has not yet departed";
                return Page();
            }

            USV.Port();
            Res = USV.Status();
            return Page();
        }

        public IActionResult OnPostStarboard()
        {
            if (!USV.HasDeparted)
            {
                Res = "Vessel has not yet departed";
                return Page();
            }

            USV.Starboard();
            Res = USV.Status();
            return Page();
        }

        public IActionResult OnPostStatus()
        {
            Res = USV.Status();
            return Page();
        }
    }

   
}

