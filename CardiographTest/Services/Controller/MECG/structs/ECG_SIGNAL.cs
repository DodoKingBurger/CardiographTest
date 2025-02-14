using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CardiographTest.Services.Controller.MECG.structs
{
  /// <summary>
  /// ЭКГ Сигнал
  /// </summary>
  [StructLayout(LayoutKind.Sequential)]
  public struct ECG_SIGNAL
  {
    /// <summary>
    /// Signal description
    ///  Описание сигнала
    /// </summary>
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
    char[] Description;

    /// <summary>
    ///  По умолчанию отведение для сопоставления будет настроено соответствующим образом.
    ///  By default, the mapping lead will be configured appropriately.
    /// </summary>
    ECG_Lead MappingLead;               
  }
}
