using InterviewApp.Interfaces;

namespace InterviewApp.Services
{
    public class PlatformService : IPlatformService
    {
        public string GetPlatformSpecificString() => $"Android";
    }
}
