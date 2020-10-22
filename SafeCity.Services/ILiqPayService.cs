using System;
using System.Collections.Generic;
using System.Text;
using SafeCity.Services.DTOs;

namespace SafeCity.Services
{
    public interface ILiqPayService
    {
        DataSignatureResponse GenerateDataAndSignature(LiqPayRequest requestParams);
    }
}
