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

    #endregion

    #region Методы

    #region Методы импортированные из dll

    /// <summary>
    /// Вызывается при подключении или отключении устройства
    /// </summary>
    /// <param name="connected">true, если подключено; в противном случае false</param>
    [DllImport("MECG20x64.dll", CharSet = CharSet.Unicode)]
    public static extern void ConnectedCallback(bool connected);



    [DllImport("MECG20x64.dll", CharSet = CharSet.Unicode)]
    public static extern void OutputSignalCallback(double time, double[] voltage, bool end);

    [DllImport("MECG20x64.dll", CharSet = CharSet.Unicode)]
    public static extern void OutputSignalCallback(double totalTime, double time, double[] voltage, bool end);


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
