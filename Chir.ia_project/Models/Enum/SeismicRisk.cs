using System.ComponentModel;

namespace Chir.ia_project.Models.Enum
{
    public enum SeismicRisk
    {
        None = 0,
        Low = 1,
        Medium = 2,
        High = 3
    }

    public static class SeismicRiskExtension
    {
        public static string ToFriendlyString(this SeismicRisk me)
        {
            switch (me)
            {
                case SeismicRisk.None:
                    return "none";
                case SeismicRisk.Low:
                    return "low";
                case SeismicRisk.Medium:
                    return "medium";
                case SeismicRisk.High:
                    return "high";
                default:
                    return "unknown";
            }
        }
    }

}


