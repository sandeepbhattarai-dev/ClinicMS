using System;
using System.Collections.Generic;
using System.Text;

namespace ClinicMS.Domain.Entities
{
    public class DoctorSchedule
    {
        public Guid Id { get; set; }
        public Guid DoctorId { get; set; }
        public int MyProperty { get; set; }
    }
}
