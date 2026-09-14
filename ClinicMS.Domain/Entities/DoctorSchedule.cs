using System;
using System.Collections.Generic;
using System.Text;

namespace ClinicMS.Domain.Entities
{
    public class DoctorSchedule
    {
        public string? Id { get; set; }
        public string? DoctorId { get; set; }
        public DayOfWeek DayOfWeek { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public int  SlotDurationMinutes { get; set; } = 10;
        public bool IsActive { get; set; }
    }
}
