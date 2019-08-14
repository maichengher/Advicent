using System;
using System.Collections.Generic;

namespace EFGetStarted.AspNetCore.ExistingDb.Models
{
    public partial class CollegeCost
    {
        public string College { get; set; }
        public int? TuitionInState { get; set; }
        public int? TuitionOutOfState { get; set; }
        public int? RoomBoard { get; set; }
        public int CollegeId { get; set; }
    }
}
