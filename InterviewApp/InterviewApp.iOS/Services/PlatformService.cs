﻿using InterviewApp.Interfaces;

namespace InterviewApp.iOS.Services
{
    public class PlatformService : IPlatformService
    {
        public string GetPlatformSpecificString() => $"iOS";
    }
}
