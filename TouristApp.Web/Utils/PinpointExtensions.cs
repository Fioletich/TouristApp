using System.Globalization;
using TouristApp.Domain.Models.Pinpoint;

namespace TouristApp.Web.Utils;

public static class PinpointExtensions {
    public static JsPinpoint ConvertToJsPinpoint(this PinpointDto pinpoint) {
        var jsPinpoint = new JsPinpoint()
        {
            Coords = new[] { Convert.ToDecimal(pinpoint.XCoordinate, CultureInfo.InvariantCulture), Convert.ToDecimal(pinpoint.YCoordinate, CultureInfo.InvariantCulture) },
            Info = $"{pinpoint.Name}: {pinpoint.Description}",
            Images = new[] { "" }
        };

        return jsPinpoint;
    }
    public static JsPinpoint[] OrderByCoords(this JsPinpoint[] jsPinpoints) {
        var ordered = new List<JsPinpoint> { jsPinpoints[0] };

        var notOrdered = jsPinpoints.ToList();
        notOrdered.RemoveAt(0);

        var closestPointIndex = 0;
        var minDistance = decimal.MaxValue;

        for (int i = 0; i < ordered.Count; i++)
        {
            for (int j = 0; j < notOrdered.Count; j++)
            {
                var distance = SquareDistance(ordered[i], notOrdered[j]);

                if (distance != 0 && distance < minDistance)
                {
                    minDistance = distance;
                    closestPointIndex = j;
                }
            }

            if (notOrdered.Count == 0)
                continue;

            ordered.Add(notOrdered[closestPointIndex]);
            notOrdered.RemoveAt(closestPointIndex);
            minDistance = decimal.MaxValue;
        }

        return ordered.ToArray();
    }

    private static decimal SquareDistance(JsPinpoint point1, JsPinpoint point2) {
        if (point1.Coords != null && point2.Coords != null)
        {
            return ((point1.Coords[0] - point2.Coords[0]) * (point1.Coords[0] - point2.Coords[0])) +
                   ((point1.Coords[1] - point2.Coords[1]) * (point1.Coords[1] - point2.Coords[1]));
        }

        return 0;
    }
}