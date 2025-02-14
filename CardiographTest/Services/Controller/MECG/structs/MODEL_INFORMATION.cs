using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CardiographTest.Services.Controller.MECG.structs
{
  /// <summary>
  /// Информация о модуле.
  /// </summary>
  [StructLayout(LayoutKind.Sequential)]
  public struct MODEL_INFORMATION
  {
    /// <summary>
    /// Имя продукта.
    /// </summary>
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
    public byte[] ProductName;

    /// <summary>
    /// SerialNumber
    /// </summary>
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
    public byte[] SerialNumber;
  }
}
