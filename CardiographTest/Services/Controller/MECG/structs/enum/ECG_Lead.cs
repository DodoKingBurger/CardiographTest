using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardiographTest.Services.Controller.MECG.structs
{
  /// <summary>
  /// Отведения ЭКГ.
  /// </summary>
  internal enum ECG_Lead
  {
    ECG_Lead_I = 0,
    ECG_Lead_II = 1,
    ECG_Lead_V1 = 2,
    ECG_Lead_V2 = 3,
    ECG_Lead_V3 = 4,
    ECG_Lead_V4 = 5,
    ECG_Lead_V5 = 6,
    ECG_Lead_V6 = 7,
    ECG_Lead_None = 8
  }
}
