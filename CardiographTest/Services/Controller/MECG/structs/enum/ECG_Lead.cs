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
    ECG_Lead_I,
    ECG_Lead_II,
    ECG_Lead_V1,
    ECG_Lead_V2,
    ECG_Lead_V3,
    ECG_Lead_V4,
    ECG_Lead_V5,
    ECG_Lead_V6,
    ECG_Lead_None
  }
}
