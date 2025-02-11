using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.IO;

namespace CardiographTest.Services.Controller
{
  /// <summary>
  /// Кардиограф
  /// </summary>
  internal class Controller
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
        if(this.port == null)
          throw new ArgumentNullException("port");
        this.port = value;
      }
    }

    #endregion

    #region Методы

    public void 

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
      if(this.Port.IsOpen)
        this.Port.Close();
      else
        throw new IOException();
    }

    #endregion

    #endregion

    #region Конструкторы

    public Controller(SerialPort port)
    {
      this.Port = port;
    }

    public Controller() 
    {
      this.Port = new SerialPort();
    }

    #endregion
  }
}
