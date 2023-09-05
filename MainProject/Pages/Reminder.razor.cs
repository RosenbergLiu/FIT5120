using Microsoft.JSInterop;
using System.Text;

namespace MainProject.Pages
{
    public partial class Reminder
    {
        private async Task GenerateICS()
        {
            string eventName = "example name";
            string startDate = "20230907T120000"; // YYYYMMDDTHHMMSS
            string endDate = "20230907T140000"; // YYYYMMDDTHHMMSS

            StringBuilder icsBuilder = new StringBuilder();
            icsBuilder.AppendLine("BEGIN:VCALENDAR");
            icsBuilder.AppendLine("VERSION:2.0");
            icsBuilder.AppendLine("BEGIN:VEVENT");
            icsBuilder.AppendLine($"SUMMARY:{eventName}");
            icsBuilder.AppendLine($"DTSTART:{startDate}");
            icsBuilder.AppendLine($"DTEND:{endDate}");
            icsBuilder.AppendLine("BEGIN:VALARM");
            icsBuilder.AppendLine("TRIGGER:-P3D"); // 3 days before
            icsBuilder.AppendLine("ACTION:DISPLAY");
            icsBuilder.AppendLine($"DESCRIPTION:{eventName}");
            icsBuilder.AppendLine("END:VALARM");
            icsBuilder.AppendLine("END:VEVENT");
            icsBuilder.AppendLine("END:VCALENDAR");

            string icsContent = icsBuilder.ToString();

            await JSRuntime.InvokeVoidAsync("downloadICS", icsContent, "event.ics");
        }
    }
}
