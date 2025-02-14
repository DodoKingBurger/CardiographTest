using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardiographTest.Properties;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Documents;
using CardiographTest.Services.Controller.MECG.structs;

namespace CardiographTest.Controller
{
  /// <summary>
  /// Многоканальная тест-система ЭКГ.
  /// </summary>
  internal class MECG
  {
    #region Поля и свойства 

    private SerialPort port;

    /// <summary>
    /// COM порт.
    /// </summary>
    public SerialPort Port
    {
      get { return port; }
      set
      {
        if (this.port == null)
          throw new ArgumentNullException("port");
        this.port = value;
      }
    }

    /// <summary>
    /// Делегат для функция вызывается при подключении или отключении устройства.
    /// </summary>
    /// <param name="connected"></param>
    /// <returns>true, если подключено; в противном случае false</returns>
    public delegate bool FPtrConnectedCallback(bool connected);

    #endregion

    #region Методы

    #region Методы импортированные из dll

    /// <summary>
    /// Вызывается при подключении или отключении устройства
    /// </summary>
    /// <param name="connected">true, если подключено; в противном случае false</param>
    [DllImport("MECG20x64.dll", CharSet = CharSet.Unicode, EntryPoint = "MECGCallback", CallingConvention = CallingConvention.Cdecl)]
    public static extern void ConnectedCallback(bool connected);

    /// <summary>
    /// Called back with sampling data
    /// </summary>
    /// <param name="time">Current position. Unit: second</param>
    /// <param name="voltage">ECG 12-lead signal voltage. Unit: mV</param>
    /// <param name="end"></param>
    [DllImport("MECG20x64.dll", CharSet = CharSet.Unicode)]
    public static extern void OutputSignalCallback(double time, 
      [MarshalAs(UnmanagedType.LPArray,SizeConst = 12)]double[] voltage, 
      bool end);

    /// <summary>
    /// Called back with sampling data
    /// </summary>
    /// <param name="totalTime">Total play time. Unit: second</param>
    /// <param name="time">Current position. Unit: second</param>
    /// <param name="voltage">ECG 12-lead signal voltage. Unit: mV</param>
    /// <param name="end"></param>
    [DllImport("MECG20x64.dll", CharSet = CharSet.Unicode)]
    public static extern void OutputSignalCallback(double totalTime, 
      double time, 
      [MarshalAs(UnmanagedType.LPArray, SizeConst = 12)] double[] voltage, 
      bool end);

    /// <summary>
    /// Called back with the delay time; 
    /// the delay is detected by the device during outputting signals
    /// </summary>
    /// <param name="time"> time         Unit: ms</param>
    [DllImport("MECG20x64.dll", CharSet = CharSet.Unicode)]
    public static extern void OutputDelayCallback(int time);

    /// <summary>
    /// Initialization
    /// Во время инициализации он попытается подключить устройство. 
    /// Если устройство найдено,будет вызвана функция cb. 
    /// После этого, если устройство отключено, cb будет вызвана снова, 
    /// чтобы уведомить о событии отключения.
    /// </summary>
    /// <param name="cb">ConnectedCallback - функция вызывается при подключении или отключении устройства</param>
    /// <returns>True, если метод был успешным. False в противном случае.</returns>
    [DllImport("MECG20x64.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    public static extern bool MECGInit (FPtrConnectedCallback cb);

    /// <summary>
    /// Подключите устройство.
    /// </summary>
    /// <param name="portNumber">Номер COM-порта устройства.-1 означает, что номер порта выбирается автоматически</param>
    /// <param name="millisecondsTimeout">Время ожидания подключения; количество миллисекунд для подключения или -1 для ожидания на неопределенный срок.</param>
    /// <returns>true, если устройство подключено; false, если истек интервал ожидания иустройство все еще не подключено.</returns>
    [DllImport("MECG20x64.dll", CharSet = CharSet.Unicode)]
    public static extern bool MECGConnect(
      uint portNumber, uint millisecondsTimeout);

    /// <summary>
    /// Отключите устройство и очистите библиотечный ресурс.
    /// </summary>
    [DllImport("MECG20x64.dll", CharSet = CharSet.Unicode)]
    public static extern void MECGFree();

    /// <summary>
    /// Get device serial number
    /// </summary>
    /// <returns>текст серийного номера; НЕ освобождайте возвращаемую строку.</returns>
    [DllImport("MECG20x64.dll", CharSet = CharSet.Unicode)]
    public static extern string MECGGetSerialNumber();

    /// <summary>
    /// Получить информацию о режиме устройства
    /// </summary>
    /// <param name="modelInfo">Указатель на структуру ::MODEL_INFORMATION</param>
    /// <returns>True, если метод был успешным. False в противном случае.</returns>
    [DllImport("MECG20x64.dll", CharSet = CharSet.Unicode)]
    public static extern bool MECGGetDeviceInformation(MODEL_INFORMATION modelInfo);

    /// <summary>
    /// Проверьте, выводит ли устройство MECG данные.
    /// </summary>
    /// <returns>True, если устройство выводит данные. False в противном случае.</returns>
    [DllImport("MECG20x64.dll", CharSet = CharSet.Unicode)]
    public static extern bool MECGIsOutputting();


    /// Загрузить заголовочный файл Physionet

    /// <summary>
    /// Вызывающая сторона несет ответственность за освобождение ресурса ECG_HEADER* путем вызова ::MECGFreeECGHeader ().
    /// </summary>
    /// <param name="filePath">Путь к файлу *.hea. Строка с нулевым символом в конце.</param>
    /// <returns>Указатель ::ECG_HEADER, если метод был успешным. NULL в противном случае.</returns>
    [DllImport("MECG20x64.dll", CharSet = CharSet.Unicode)]
    public static extern ECG_HEADER MECGLoadMITHeader(string filePath);


    /// \brief Загрузить базу данных Physionet 
    /// <summary>
    /// Загрузить связанный файл *.dat. Перед вызовом функции необходимо, чтобы все файлы *.dat
    /// были загружены и помещены в ту же папку, что и файл *.hea.
    /// </summary>
    /// <param name="header">заголовок A ::ECG_HEADER указатель, который возвращается из ::MECGLoadMITHeader ()</param>
    /// <returns></returns>
    [DllImport("MECG20x64.dll", CharSet = CharSet.Unicode)]
    public static extern bool MECGLoadMITDatabase(ECG_HEADER header);

    /// <summary>
    /// Изменить отображение Lead сигналов
    /// Вызывающий может изменить MappingLead 
    /// структуры ::ECG_SIGNAL, а затем вызвать эту функцию для обновления.
    /// </summary>
    /// <param name="header">заголовок A ::ECG_HEADER указатель</param>
    [DllImport("MECG20x64.dll", CharSet = CharSet.Unicode)]
    public static extern void MECGUpdateECGHeaderMappingLead(ECG_HEADER header);

    /// <summary>
    /// Освобождение ресурса
    /// Ответственность за освобождение ресурса ECG_HEADER* 
    /// лежит на вызывающем объекте.
    /// </summary>
    /// <param name="header">заголовок A ::ECG_HEADER указатель</param>
    [DllImport("MECG20x64.dll", CharSet = CharSet.Unicode)]
    public static extern void MECGFreeECGHeader(ECG_HEADER header);

    /// <summary>
    /// Загрузка базы данных AHA в формате *.txt или *.ecg. 
    /// Вызывающая сторона несет ответственность за освобождение ресурса
    /// ECG_HEADER* путем вызова ::MECGFreeECGHeader ().
    /// </summary>
    /// <param name="filePath">filePath Путь к файлу *.txt или *.ecg. Строка с нулевым символом в конце.</param>
    /// <returns>Указатель ::ECG_HEADER, если метод был успешным. NULL в противном случае</returns>
    [DllImport("MECG20x64.dll", CharSet = CharSet.Unicode)]
    public static extern ECG_HEADER MECGLoadDatabaseAHA(string filePath);

    /// <summary>
    /// Загрузка файла базы данных CSE формата *.dcd. 
    /// Вызывающая сторона несет ответственность 
    /// за освобождение ресурса
    /// ECG_HEADER* путем вызова ::MECGFreeECGHeader ().
    /// </summary>
    /// <param name="filePath">Путь к файлу *.dcd. Строка с нулевым завершением.</param>
    /// <returns>Указатель ::ECG_HEADER, если метод был успешным. NULL в противном случае.</returns>
    [DllImport("MECG20x64.dll", CharSet = CharSet.Unicode)]
    public static extern ECG_HEADER MECGLoadDatabaseCSE(string filePath);

    /// <summary>
    /// Загрузка файла базы данных в формате txt, 
    /// определенном WhaleTeq. 
    /// Вызывающая сторона несет ответственность 
    /// за освобождение ресурса
    /// </summary>
    /// <param name="filePath">Путь к файлу *.txt.</param>
    /// <returns>ECG_HEADER* путем вызова ::MECGFreeECGHeader (). Частота дискретизации, определенная в файле
    ///, должна находиться в диапазоне от 100 (Гц) до 1000 (Гц).</returns>
    [DllImport("MECG20x64.dll", CharSet = CharSet.Unicode)]
    public static extern ECG_HEADER MECGLoadDatabaseWhaleTeq(string filePath);

    /// <summary>
    /// Базы данных CTS/CSE встроены в SDK. Вызывающий может загрузить одну,
    /// указав ::CTSCSE_Database.
    /// </summary>
    /// <param name="database">CTSCSE_Database value.</param>
    /// <param name="noise">A ::CTSCSE_Noise value. Если значение равно CTSCSENoise_MAX, шум не применяется.</param>
    /// <returns>ECG_HEADER pointer, если метод был успешным. NULL в противном случае.</returns>
    [DllImport("MECG20x64.dll", CharSet = CharSet.Unicode)]
    public static extern ECG_HEADER MECGLoadDatabaseCTS_CSE(CTSCSE_Database database, CTSCSE_Noise noise);

    /// <summary>
    /// Загрузить периодическую форму сигнала
    /// Непрерывно выводить форму сигнала, пока не будет вызван MECGStopOutput.
    /// </summary>
    /// <param name="waveform"></param>
    /// <param name="frequency">Частота Единица измерения: Гц. Разрешение: 0,01 Гц. Диапазон: 0~100 Гц.</param>
    /// <param name="amplitude">амплитуда Амплитуда напряжение. Единица измерения: мВpp.
    ///</param>
    /// <returns>True, если метод был успешным. False в противном случае.</returns>
    [DllImport("MECG20x64.dll", CharSet = CharSet.Unicode)]
    public static extern bool MECGLoadWaveform(WAVEFORM_TYPE waveform, double frequency, double amplitude);

    /// <summary>
    /// Загрузить периодическую форму сигнала
    /// Непрерывно выводить форму сигнала, пока не будет вызван MECGStopOutput.
    /// </summary>
    /// <param name="waveform"></param>
    /// <param name="frequency">частота Частота. Единица: Гц. Разрешение: 0,01 Гц. Диапазон: 0~100 Гц.</param>
    /// <param name="amplitude">амплитуда Амплитуда напряжение. Единица: мВpp. 8 записей расположены в порядке LeadI, LeadII, V1~V6.</param>
    /// <returns>True, если метод был успешным. False в противном случае.</returns>
    [DllImport("MECG20x64.dll", CharSet = CharSet.Unicode)]
    public static extern bool MECGLoadWaveformEx(WAVEFORM_TYPE waveform, double frequency, [MarshalAs(UnmanagedType.LPArray, SizeConst = 8)] double[] amplitude);

    /// <summary>
    /// Загрузить треугольную форму сигнала 
    /// Непрерывно выводить форму сигнала, пока не будет вызван MECGStopOutput.
    /// </summary>
    /// <param name="pulseWidth">Ширина импульса. Единица: мс</param>
    /// <param name="frequency">частота Частота. Единица: Гц. Разрешение: 0,01 Гц. Диапазон: 0~100 Гц.</param>
    /// <param name="amplitude">амплитуда Амплитуда напряжение. Единица: мВpp</param>
    /// <returns>True, если метод был успешным. False в противном случае.</returns>
    [DllImport("MECG20x64.dll", CharSet = CharSet.Unicode)]
    public static extern bool MECGLoadWaveformRectanglePulse(int pulseWidth, double frequency, double amplitude);

    /// <summary>
    /// Загрузить сигнал режима калибровки 
    /// Загруженный сигнал имеет фиксированную длину 10 секунд. 
    /// Используется в процессе калибровки.
    /// </summary>
    /// <param name="frequency">частота Частота. Единица измерения: Гц. Разрешение: 0,01 Гц. Диапазон: 0~100 Гц.</param>
    /// <param name="amplitude">амплитуда Амплитуда напряжение. Единица измерения: мВpp</param>
    /// <returns>True, если метод был успешным. False в противном случае.</returns>
    [DllImport("MECG20x64.dll", CharSet = CharSet.Unicode)]
    public static extern bool MECGLoadWaveformCalibrationMode(double frequency, double amplitude);
    #endregion

    #region Методы подключения и отключения

    /// <summary>
    /// Подключение к Serial Port.
    /// </summary>
    public void Connected()
    {
      this.Port.Open();
      if (!this.Port.IsOpen)
        throw new IOException();
    }

    /// <summary>
    /// Отключение к Serial Port.
    /// </summary>
    public void Disconnected()
    {
      if (this.Port.IsOpen)
        this.Port.Close();
      else
        throw new IOException();
    }

    #endregion

    #endregion

    #region Конструкторы

    public MECG(SerialPort port)
    {
      this.Port = port;
    }

    public MECG()
    {
      this.Port = new SerialPort();
    }

    #endregion
  }
}
