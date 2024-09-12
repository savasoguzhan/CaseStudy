using CaseStudy.BusinessLayer.Abstract;
using CaseStudy.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace CaseStudy.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeetingController : ControllerBase
    {
        private readonly IMeetingService _meetingService;

        public MeetingController(IMeetingService meetingService)
        {
            _meetingService = meetingService;
        }

        [HttpGet]
        public  IActionResult MeetingList()
        {
            var values = _meetingService.TGetAll();
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateMeeting(Meeting meeting)
        {
           _meetingService.TInsert(meeting);
            return Ok("New Meeting Created");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMeeting(int id)
        {
            var value = _meetingService.TGetById(id);
            _meetingService.TDelete(value);
            return Ok("Meeting Deleted");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateMeeting(Meeting meeting)
        {
            _meetingService.TUpdate(meeting);
            return Ok("Meeting Updated");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMeeting(int id)
        {
            var value = _meetingService.TGetById(id);
            return Ok(value);
        }

    }
}
