using CaseStudy.DTO.Meeting;
using CaseStudy.EntityLayer.Concrete;
using CaseStudy.WEBUI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Rotativa.AspNetCore;
using System.Text;

namespace CaseStudy.WEBUI.Controllers
{
    [Authorize]
    public class MeetingController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public MeetingController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult> Index()
        {
           var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7121/api/Meeting");
            if(responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<MeetingVM>>(jsonData);
                return View(values);
            }

            return View();
        }


       
        public async Task<IActionResult> PrintReport(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7121/api/Meeting/{id}");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var meeting = JsonConvert.DeserializeObject<Meeting>(jsonData);

                if (meeting != null)
                {
                    return new ViewAsPdf("MeetingReport", meeting)
                    {
                        FileName = meeting.MeetingName+".pdf",
                        PageSize = Rotativa.AspNetCore.Options.Size.A4
                    };
                }
            }
            return NotFound();
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateMeetingDto createMeetingDto)
        {
            if (createMeetingDto.Document != null && createMeetingDto.Document.Length > 0)
            {
                
                var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/documents");
                var uniqueFileName = Guid.NewGuid().ToString() + "_" + createMeetingDto.Document.FileName;
                var filePath = Path.Combine(uploadsFolder, uniqueFileName);

                
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await createMeetingDto.Document.CopyToAsync(fileStream);
                }

                
                createMeetingDto.DocumentPath = "/documents/" + uniqueFileName;
            }
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createMeetingDto);
            StringContent content = new StringContent(jsonData,Encoding.UTF8,"application/json");
            var responseMessage = await client.PostAsync("https://localhost:7121/api/Meeting", content);
            if(responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();

        }


        public async Task<IActionResult> Delete(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7121/api/Meeting/{id}");
            if(responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();

        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7121/api/Meeting/{id}");
            if(responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateMeetingDto>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UpdateMeetingDto updateMeetingDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateMeetingDto);
            StringContent content = new StringContent(jsonData,Encoding.UTF8,"application/json");
            var responseMessage = await client.PutAsync("https://localhost:7121/api/Meeting/",content);
            if(responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");   
            }
            return View(jsonData);
        }
    }
}
