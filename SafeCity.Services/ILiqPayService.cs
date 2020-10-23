using SafeCity.Services.DTOs;

namespace SafeCity.Services
{
    public interface ILiqPayService
    {
        DataSignatureResponse GenerateDataAndSignature(LiqPayRequest requestParams);
    }
}
