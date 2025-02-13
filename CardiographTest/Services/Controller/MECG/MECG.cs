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

    
    [DllImport("MECG20x64.dll", CharSet = CharSet.Unicode)]
    public static extern bool MECGLoadMITDatabase(ECG_HEADER header);

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
