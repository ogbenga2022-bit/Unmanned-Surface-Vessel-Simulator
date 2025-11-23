using System.ComponentModel.DataAnnotations;

namespace Unmanned_Surface_Vessel_Simulator.Models.DTO.Request
{
    public class DepartRequest
    {
        [Required, Range(0, 4)]
        public int X { get; set; }

        [Required, Range(0, 4)]
        public int Y { get; set; }

        [Required, RegularExpression("NORTH|SOUTH|EAST|WEST", ErrorMessage = "Facing must be a cardinal direction NORTH, SOUTH, EAST, or WEST")]
        public string Facing { get; set; }
    }
}
