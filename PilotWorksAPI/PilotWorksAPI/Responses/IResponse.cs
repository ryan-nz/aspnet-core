﻿using System;

namespace PilotWorksAPI.Responses
{
    public interface IResponse
    {
        string Message { get; set; }
        bool HadError { get; set; }
        string ErrorMessage { get; set; }
    }
}
