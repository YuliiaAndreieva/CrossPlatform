using System.Globalization;
using Microsoft.Extensions.Primitives;

namespace App.Middlewares;

public class TimezoneMiddleware
{
    private readonly RequestDelegate _next;

    public TimezoneMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var query = context.Request.Query;

        if (query.ContainsKey("startDate") || query.ContainsKey("endDate"))
        {
            var newQuery = new Dictionary<string, StringValues>(query);

            if (query.TryGetValue("startDate", out var startDate))
            {
                newQuery["startDate"] = ConvertToUkrainianTime(startDate);
            }

            if (query.TryGetValue("endDate", out var endDate))
            {
                newQuery["endDate"] = ConvertToUkrainianTime(endDate);
            }
            
            var uri = new UriBuilder(context.Request.Scheme, context.Request.Host.Host, context.Request.Host.Port ?? 80)
            {
                Path = context.Request.Path,
                Query = string.Join("&", newQuery.Select(kvp => $"{kvp.Key}={kvp.Value}"))
            };
            context.Request.QueryString = new QueryString(uri.Query);
        }

        await _next(context);
    }

    private static string ConvertToUkrainianTime(string dateString)
    {
        if (DateTime.TryParse(dateString, null, DateTimeStyles.RoundtripKind, out var parsedDateTime))
        {
            if (parsedDateTime.Kind == DateTimeKind.Unspecified)
            {
                parsedDateTime = DateTime.SpecifyKind(parsedDateTime, DateTimeKind.Utc);
            }
            
            var ukrainianTimeZone = TimeZoneInfo.FindSystemTimeZoneById("FLE Standard Time");
            var ukrainianDate = TimeZoneInfo.ConvertTimeFromUtc(parsedDateTime.ToUniversalTime(), ukrainianTimeZone);
            return ukrainianDate.ToString("yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture);
        }
        return dateString;
    }
}
