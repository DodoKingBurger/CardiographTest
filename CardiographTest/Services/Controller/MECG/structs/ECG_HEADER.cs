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
  [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
  public struct ECG_HEADER
  {
    /// <summary>
    /// Имя записи формы волны ЭКГ
    /// </summary>
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
    public byte[] RecordName;

    /// <summary>
    /// Количество сигналов; размер массива Signal[]
    /// </summary>
    public Int32 NumberOfSignals;

    /// <summary>
    /// Выборок в секунду на сигнал.
    /// </summary>
    public Int32 SamplingFrequency;

    /// <summary>
    /// Количество выборок на сигнал.
    /// </summary>
    public Int32 NumberOfSamplesPerSignal;

    /// <summary>
    /// Внутреннее использование. Вызывающий не должен его изменять.
    /// </summary>
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
    public byte[] Reserved;

    /// <summary>
    /// Размер Signal[] задается NumberOfSignals is given by NumberOfSignals
    /// </summary>
    public IntPtr Signal;

    /// <summary>
    /// Метод для получения массива сигналов
    /// </summary>
    /// <returns>массива сигналов</returns>
    public ECG_SIGNAL[] GetSignalArray()
    {
      if (this.Signal == IntPtr.Zero || this.NumberOfSignals <= 0)
        return null;

      // Создаем массив сигналов
      ECG_SIGNAL[] signalArray = new ECG_SIGNAL[this.NumberOfSignals];

      // Размер структуры ECG_SIGNAL
      int signalSize = Marshal.SizeOf(typeof(ECG_SIGNAL));

      // Копируем данные из неуправляемой памяти в управляемый массив
      for (long i = 0; i < this.NumberOfSignals; i++)
      {
        IntPtr signalPtr = IntPtr.Add(this.Signal, (int)(i * signalSize));
        signalArray[i] = Marshal.PtrToStructure<ECG_SIGNAL>(signalPtr);
      }

      return signalArray;
    }
  }
}
