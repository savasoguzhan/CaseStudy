using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseStudy.DTO.Meeting
{
    public class UpdateMeetingDto
    {
        public int Id { get; set; }
        public string MeetingName { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string Description { get; set; }

        public IFormFile? Document { get; set; }
        public string DocumentPath { get; set; }
    }
}
