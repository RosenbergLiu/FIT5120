using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text;

namespace FoodSaver.Pages
{
    public class ReminderModel : PageModel
    {
        public string ProductName { get; set; }
        public string ProductDate { get; set; }
        public void OnGet()
        {
        }

        public void OnPost()
        {
        }

        public IActionResult OnPostDownload()
        {
            StringBuilder icsBuilder = new StringBuilder();
            icsBuilder.AppendLine("BEGIN:VCALENDAR");
            icsBuilder.AppendLine("VERSION:2.0");
            icsBuilder.AppendLine("BEGIN:VEVENT");
            icsBuilder.AppendLine($"DTSTART;VALUE=DATE:{ProductDate}"); // All-day event
            icsBuilder.AppendLine($"DTEND;VALUE=DATE:{ProductName}");   // This seems incorrect as DTEND usually should be a date. Maybe you meant something else.
            icsBuilder.AppendLine($"SUMMARY:Reminder of {ProductName}");
            icsBuilder.AppendLine("BEGIN:VALARM");
            icsBuilder.AppendLine("TRIGGER:-P3D"); // 3 days before
            icsBuilder.AppendLine("ACTION:DISPLAY");
            icsBuilder.AppendLine($"DESCRIPTION:{ProductName} Best Before {ProductDate}");
            icsBuilder.AppendLine("END:VALARM");
            icsBuilder.AppendLine("END:VEVENT");
            icsBuilder.AppendLine("END:VCALENDAR");

            string icsContent = icsBuilder.ToString();

            var byteArray = Encoding.UTF8.GetBytes(icsContent);
            var stream = new MemoryStream(byteArray);

            // Set the content type to "text/calendar" for .ics files
            return new FileStreamResult(stream, "text/calendar")
            {
                FileDownloadName = "reminder.ics"
            };
        }
    }
}
