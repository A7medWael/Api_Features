using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cores.Interfaces
{
    public interface IResponseCashService
    {
        Task CashResponseAsync(string  CashKey, string Response,TimeSpan TimeToLive);
        Task<string> GetCashResponse(string CashKey);
    }
}
