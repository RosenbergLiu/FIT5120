using MainProject.Data;
using Microsoft.JSInterop;
using System.Text;

namespace MainProject.Pages
{
    public partial class Reminder
    {
        private async Task GenerateICS(ReminderViewModel args)
        {

            string formattedDate = args.ExpireDate.ToString("yyyyMMdd");
            string? foodName = args.FoodName;

            StringBuilder icsBuilder = new StringBuilder();
            icsBuilder.AppendLine("BEGIN:VCALENDAR");
            icsBuilder.AppendLine("VERSION:2.0");
            icsBuilder.AppendLine("BEGIN:VEVENT");
            icsBuilder.AppendLine($"DTSTART;VALUE=DATE:{formattedDate}"); // All-day event
            icsBuilder.AppendLine($"DTEND;VALUE=DATE:{formattedDate}");   // Same as DTSTART for all-day event
            icsBuilder.AppendLine($"SUMMARY:{foodName}");
            icsBuilder.AppendLine("BEGIN:VALARM");
            icsBuilder.AppendLine("TRIGGER:-P3D"); // 3 days before
            icsBuilder.AppendLine("ACTION:DISPLAY");
            icsBuilder.AppendLine($"DESCRIPTION:{foodName} expired");
            icsBuilder.AppendLine("END:VALARM");
            icsBuilder.AppendLine("END:VEVENT");
            icsBuilder.AppendLine("END:VCALENDAR");

            string icsContent = icsBuilder.ToString();

            await JSRuntime.InvokeVoidAsync("downloadICS", icsContent, "expire_reminder.ics");
        }
    }
}
