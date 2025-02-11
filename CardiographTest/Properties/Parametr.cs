using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardiographTest.Properties
{
  public static class Parametr
  {
    #region Коды команд USB

    public static readonly int USB_RX_DATA_LEN_MAX = 70000;

    public static readonly int USB_TX_DATA_LEN_MAX = 20000;

    public static readonly byte USB_CMD_DEV = 0x00;       // 0
                                                          // Управление потоковой выдачей результатов по USB [r/w]:
    public static readonly byte USB_CMD_DEV_USB_STREAM = 0x0B;  // 11 w+ r+

    // Префикс:
    public static readonly byte USB_BYTE_START = 0xDB;//219
                                                      // Постфикс:
    public static readonly byte USB_BYTE_STOP = 0xDC;//220
                                                     // Символ признака esc последовательности:
    public static readonly byte USB_BYTE_ESC = 0x1B;//27
    public static readonly byte USB_BYTE_DUMMY0 = 0x00;//0
    public static readonly byte USB_BYTE_DUMMY1 = 0xFF;//255              struct USB_RX_Packet

    //-------------КОды функций кардиографа------------------

    /// <summary>
    /// Получить серийный номер кардиографа.
    /// </summary>
    public static readonly byte USB_TAKE_SERIAL_NUMBER = 0x21;//33

    /// <summary>
    /// Установить серийный номер кардиографа.
    /// </summary>
    public static readonly byte USB_SET_SERIAL_NUMBER = 0x22;//34

    /// <summary>
    /// Получить измерения в реальном времени.
    /// </summary>
    public static readonly byte USB_START_TAKE_DATA_STREAM = 0x5A;//90

    /// <summary>
    /// Начать сеанс работы с внутренней памятью.
    /// </summary>
    public static readonly byte USB_START_WORK_ITERNAL_MEMORY = 0x60;//96

    /// <summary>
    /// Получить список имен файла из внутренней памяти. 
    /// </summary>
    public static readonly byte USB_ITERNAL_MEMORY_LIST_FILE_NAME = 0x62;//98

    /// <summary>
    /// Получить файл из внутренней памяти.
    /// </summary>
    public static readonly byte USB_ITERNAL_MEMORY_TAKE_FILE = 0x65;//101

    /// <summary>
    /// Удалить файл из внутренней памяти.
    /// </summary>
    public static readonly byte USB_ITERNAL_MEMORY_DEL_FILE = 0x66;//102

    /// <summary>
    /// Получить список доступных устройств.
    /// </summary>
    public static readonly byte USB_ITERNAL_MEMORY_TAKE_LIST_AVAILABLE_DEVICES = 0x69;//105

    /// <summary>
    /// Завершить сеанс работы с внутренней памятью.
    /// </summary>
    public static readonly byte USB_STOP_WORK_ITERNAL_MEMORY = 0x61;//97

    /// <summary>
    /// Начать сеанс работы с модемом.
    /// </summary>
    public static readonly byte USB_START_WORK_MODEM = 0x01;//1

    /// <summary>
    /// Получить общие данные о модеме.
    /// </summary>
    public static readonly byte USB_TAKE_GENERAL_DATA_MODEM = 0x71;//113

    /// <summary>
    /// Получить номер телефона диспетчера.
    /// </summary>
    public static readonly byte USB_TAKE_NUMB_PHONE = 0x14;//20

    /// <summary>
    /// Установить номер телефона диспетчера.
    /// </summary>
    public static readonly byte USB_SET_NUMB_PHONE = 0x24;//36

    /// <summary>
    /// Получить параметры GPRS соединения.
    /// </summary>
    public static readonly byte USB_TAKE_GPRS_COMPOUND = 0x13;//19

    /// <summary>
    /// Установить параметры GPRS соединения.
    /// </summary>
    public static readonly byte USB_SET_GPRS_COMPOUND = 0x23;//35

    /// <summary>
    /// Получить параметры GPRS сокета.
    /// </summary>
    public static readonly byte USB_TAKE_GPRS_SOCKET = 0x15;//21

    /// <summary>
    /// Установить параметры GPRS сокета.
    /// </summary>
    public static readonly byte USB_SET_GPRS_SOCKET = 0x25;//37
   
    /// <summary>
    /// Получить параметры Email.
    /// </summary>
    public static readonly byte USB_TAKE_EMAIL = 0x16;//22

    /// <summary>
    /// Установить параметры Email.
    /// </summary>
    public static readonly byte USB_SET_EMAIL = 0x26;//38

    /// <summary>
    /// Завершить сеанс работы с модемом.
    /// </summary>
    public static readonly byte USB_STOP_WORK_MODEM = 0x02;//2
    #endregion

    #region Peremen        

    public static byte[] usb_tx_cmd_packet = new byte[200000];

    public static byte[] buffer = new byte[70000];

    public static int offset;

    public static int count = 70000;

    #endregion
  }
}
