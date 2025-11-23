using System.ComponentModel.DataAnnotations;

namespace Unmanned_Surface_Vessel_Simulator.Models.Entity
{
    public class UnmannedSurfaceVessel
    {
        [Required(ErrorMessage = "Vessel requires an X coordinate")]
        public int X { get; private set; }

        [Required(ErrorMessage = "Vessel requires a Y coordinate")]
        public int Y { get; private set; }

        [Required(ErrorMessage = "Vessel requires a direction")]
        public string Facing { get; private set; }

        public bool HasDeparted { get; private set; } = false;

        private int MaxWidth = 4;

        private int MaxLength = 4;

        public bool Depart(int x, int y, string facing)
        {
            if (x < 0 || x > MaxWidth || y < 0 || y > MaxLength)
                return false;

            X = x;
            Y = y;
            Facing = facing;
            HasDeparted = true;
            return true;
        }

        public bool Sail()
        {
            if (!HasDeparted)
                return false;
             switch(Facing)
            {
               case "NORTH":
                    if (Y > 0) Y -= 1;
               break;
                case "SOUTH":
                    if (Y < MaxLength) Y += 1;
               break;
                case "EAST":
                    if (X < MaxWidth) X += 1;
               break;
                case "WEST":
                    if (X > 0) X -= 1;
               break;
                default:
                    return false;
            }
            return true;
        }

        public bool Port()
        {
            if (!HasDeparted)
                return false;
            switch (Facing)
            {
                case "NORTH": 
                    Facing = "WEST"; 
                    break;
                case "WEST": 
                    Facing = "SOUTH"; 
                    break;
                case "SOUTH": 
                    Facing = "EAST"; 
                    break;
                case "EAST": 
                    Facing = "NORTH"; 
                    break;
            }

            return true;
        }
        public bool Starboard()
        {
            if (!HasDeparted)
                return false;
            switch (Facing)
            {
                case "NORTH": 
                    Facing = "EAST"; 
                    break;
                case "EAST": 
                    Facing = "SOUTH"; 
                    break;
                case "SOUTH": 
                    Facing = "WEST"; 
                    break;
                case "WEST": 
                    Facing = "NORTH"; 
                    break;
            }
            return true;
        }

        public string Status()
        {
            if (!HasDeparted)
                return "Vessel has not yet departed";
            return $"{X},{Y},{Facing}";
        }
        public void reset()
        {
            X = 0;
            Y = 0;
            Facing = string.Empty;
            HasDeparted = false;
        }
    }
}
