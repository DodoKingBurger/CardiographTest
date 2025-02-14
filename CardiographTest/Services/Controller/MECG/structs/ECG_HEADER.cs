using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CardiographTest.Services.Controller.MECG.structs
{
  /// <summary>
  /// ЭКГ_ ЗАГОЛОВОК
  /// </summary>
  [StructLayout(LayoutKind.Sequential)]
  public struct ECG_HEADER
  {
    /// <summary>
    /// Имя записи формы волны ЭКГ
    /// </summary>
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
    public char[] RecordName;

    /// <summary>
    /// Количество сигналов; размер массива Signal[]
    /// </summary>
    public long NumberOfSignals;

    /// <summary>
    /// Выборок в секунду на сигнал.
    /// </summary>
    public long SamplingFrequency;

    /// <summary>
    /// Количество выборок на сигнал.
    /// </summary>
    public long NumberOfSamplesPerSignal;

    /// <summary>
    /// Внутреннее использование. Вызывающий не должен его изменять.
    /// </summary>
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
    public byte[] Reserved;

    /// <summary>
    /// Размер Signal[] задается NumberOfSignals is given by NumberOfSignals
    /// </summary>
    public ECG_SIGNAL[] Signal;
  }
}
