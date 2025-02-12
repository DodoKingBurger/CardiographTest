/*! \file MECG.h

*/
#pragma once

#ifndef DOXYGEN_SHOULD_SKIP_THIS
#if defined(WIN32)
#ifdef WHALETEQ_API

#else
#define WHALETEQ_API extern "C" __declspec(dllimport)
#endif
#elif defined(LINUX) || defined(OSX) || defined(ANDROID)
#define WHALETEQ_API extern "C"
#endif


#endif // DOXYGEN_SHOULD_SKIP_THIS


typedef enum {
    CTSCSE_ANE20000,
    CTSCSE_ANE20001,
    CTSCSE_ANE20002,
    CTSCSE_CAL05000,
    CTSCSE_CAL10000,
    CTSCSE_CAL15000,
    CTSCSE_CAL20000,
    CTSCSE_CAL20002,
    CTSCSE_CAL20100,
    CTSCSE_CAL20110,
    CTSCSE_CAL20160,
    CTSCSE_CAL20200,
    CTSCSE_CAL20210,
    CTSCSE_CAL20260,
    CTSCSE_CAL20500,
    CTSCSE_CAL20502,
    CTSCSE_CAL30000,
    CTSCSE_CAL40000,
    CTSCSE_CAL50000,
    CTSCSE_PCTH001,  //!< MA1 series
    CTSCSE_PCTH002,
    CTSCSE_PCTH003,
    CTSCSE_PCTH004,
    CTSCSE_PCTH005,
    CTSCSE_PCTH007,
    CTSCSE_PCTH008,
    CTSCSE_PCTH009,
    CTSCSE_PCTH011,
    CTSCSE_PCTH012,
    CTSCSE_PCTH013,
    CTSCSE_PCTH014,
    CTSCSE_PCTH015,
    CTSCSE_PCTH016,
    CTSCSE_PCTH017,
    CTSCSE_PCTH019,
    CTSCSE_PCTH021,
    CTSCSE_PCTH022,
    CTSCSE_PCTH024,
    CTSCSE_PCTH025,
    CTSCSE_PCTH026,
    CTSCSE_PCTH027,
    CTSCSE_PCTH028,
    CTSCSE_PCTH029,
    CTSCSE_PCTH030,
    CTSCSE_PCTH031,
    CTSCSE_PCTH032,
    CTSCSE_PCTH033,
    CTSCSE_PCTH034,
    CTSCSE_PCTH035,
    CTSCSE_PCTH036,
    CTSCSE_PCTH037,
    CTSCSE_PCTH038,
    CTSCSE_PCTH039,
    CTSCSE_PCTH040,
    CTSCSE_PCTH041,
    CTSCSE_PCTH042,
    CTSCSE_PCTH043,
    CTSCSE_PCTH044,
    CTSCSE_PCTH046,
    CTSCSE_PCTH047,
    CTSCSE_PCTH048,
    CTSCSE_PCTH049,
    CTSCSE_PCTH051,
    CTSCSE_PCTH053,
    CTSCSE_PCTH055,
    CTSCSE_PCTH058,
    CTSCSE_PCTH059,
    CTSCSE_PCTH060,
    CTSCSE_PCTH061,
    CTSCSE_PCTH062,
    CTSCSE_PCTH063,
    CTSCSE_PCTH064,
    CTSCSE_PCTH065,
    CTSCSE_PCTH066,
    CTSCSE_PCTH068,
    CTSCSE_PCTH069,
    CTSCSE_PCTH071,
    CTSCSE_PCTH072,
    CTSCSE_PCTH073,
    CTSCSE_PCTH074,
    CTSCSE_PCTH075,
    CTSCSE_PCTH076,
    CTSCSE_PCTH077,
    CTSCSE_PCTH078,
    CTSCSE_PCTH079,
    CTSCSE_PCTH080,
    CTSCSE_PCTH081,
    CTSCSE_PCTH082,
    CTSCSE_PCTH083,
    CTSCSE_PCTH084,
    CTSCSE_PCTH085,
    CTSCSE_PCTH086,
    CTSCSE_PCTH087,
    CTSCSE_PCTH088,
    CTSCSE_PCTH090,
    CTSCSE_PCTH091,
    CTSCSE_PCTH095,
    CTSCSE_PCTH096,
    CTSCSE_PCTH097,
    CTSCSE_PCTH098,
    CTSCSE_PCTH099,
    CTSCSE_PCTH101,
    CTSCSE_PCTH102,
    CTSCSE_PCTH103,
    CTSCSE_PCTH104,
    CTSCSE_PCTH105,
    CTSCSE_PCTH106,
    CTSCSE_PCTH107,
    CTSCSE_PCTH108,
    CTSCSE_PCTH110,
    CTSCSE_PCTH112,
    CTSCSE_PCTH113,
    CTSCSE_PCTH114,
    CTSCSE_PCTH115,
    CTSCSE_PCTH116,
    CTSCSE_PCTH118,
    CTSCSE_PCTH123,
    CTSCSE_PCTH124,
    CTSCSE_PCTH125,
    CTSCSE_MAX
} CTSCSE_Database;

typedef enum {
    CTSCSENoise_50HZ,        //!< 50Hz noise 25uV peak
    CTSCSENoise_60HZ,        //!< 60Hz noise 25uV peak
    CTSCSENoise_BL,          //!< Baseline noise 0.3Hz 0.5mV peak
    CTSCSENoise_BL_HF,       //!< Baseline noise 0.3Hz 0.5mV peak + HF noise 15uVrms
    CTSCSENoise_HF_05,       //!< HF noise 05uVrms
    CTSCSENoise_HF_10,       //!< HF noise 10uVrms
    CTSCSENoise_HF_15,       //!< HF noise 15uVrms
    CTSCSENoise_HF_20,       //!< HF noise 20uVrms
    CTSCSENoise_HF_25,       //!< HF noise 25uVrms
    CTSCSENoise_HF_30,       //!< HF noise 30uVrms
    CTSCSENoise_HF_35,       //!< HF noise 35uVrms
    CTSCSENoise_HF_40,       //!< HF noise 40uVrms
    CTSCSENoise_HF_45,       //!< HF noise 45uVrms
    CTSCSENoise_HF_50,       //!< HF noise 50uVrms
    CTSCSENoise_MAX          //!< Noise Off
} CTSCSE_Noise;

/// \anchor ECG_Lead
typedef enum {
    ECG_Lead_I,
    ECG_Lead_II,
    ECG_Lead_V1,
    ECG_Lead_V2,
    ECG_Lead_V3,
    ECG_Lead_V4,
    ECG_Lead_V5,
    ECG_Lead_V6,
    ECG_Lead_None
} ECG_Lead;

/// \anchor WAVEFORM_TYPE
typedef enum {
    WaveformSine,
    WaveformTriangle,
    WaveformSquare
} WAVEFORM_TYPE;

/// \fn MECGCallback
/// \brief Called when the device is connected or disconnected
/// @param[in] connected       true if connected; otherwise, it's false
typedef void (*ConnectedCallback) (bool connected);

/// \fn OutputSignalCallback
/// \brief Called back with sampling data
/// @param[in] totalTime       Total play time. Unit: second
/// @param[in] time            Current position. Unit: second
/// @param[in] voltage         ECG 12-lead signal voltage. Unit: mV
typedef void (*OutputSignalCallback) (double time, double voltage[12], bool end);
typedef void (*OutputSignalExCallback) (double totalTime, double time, double voltage[12], bool end);

/// \fn OutputDelayCallback
/// \brief Called back with the delay time; the delay is detected by the device during outputting signals
/// The delay is occurred if the packet transfer is not smooth.
/// @param[in] time         Unit: ms
typedef void (*OutputDelayCallback) (int time);

#pragma pack (1)
typedef struct {
    UINT8           ProductName[16];
    UINT8           SerialNumber[16];
} MODEL_INFORMATION;

typedef struct {
    char            Description[16];           //!< Signal description
    ECG_Lead        MappingLead;               //!< By default, the mapping lead will be configured appropriately.
} ECG_SIGNAL;

typedef struct {
    char            RecordName[16];            //!< ECG waveform record name
    long            NumberOfSignals;           //!< Number of signals; the size of Signal[] array
    long            SamplingFrequency;         //!< Samples per second per signal
    long            NumberOfSamplesPerSignal;
    UINT8           Reserved[16];              //!< Internal use. The caller should not modify it.
    ECG_SIGNAL      Signal[1];                 //!< The size of the Signal[] is given by NumberOfSignals
} ECG_HEADER;
#pragma pack()

//
// Initialization & Cleanup
//

///
/// \brief Initialization
///
/// During initialization, it will try to connect a device. If a device is found,
/// the cb function will be called. After then, if a device is disconnected,
/// the cb will be called again to notify the disconnection event. 
///
/// @param[in] cb  a callback function to notify the connection or disconnection event
/// @return True if the method was successful. False otherwise. 
///
WHALETEQ_API 
bool 
MECGInit (
    ConnectedCallback cb
);

///
/// Connect the device.
/// @param[in] portNumber            Device COM port number; -1 means the port number is automatically selected
/// @param[in] millisecondsTimeout   Connection timeout; the number of milliseconds to connect, or -1 to wait indefinitely
/// @return true if the device is connected; false if the time-out interval elapsed and 
///         the device is still not connected
///
WHALETEQ_API
bool 
MECGConnect (
	unsigned int portNumber, 
	unsigned int millisecondsTimeout
);

///
/// Disconnect the device and clean up library resource
///
/// @return No return value.
///
WHALETEQ_API 
void 
MECGFree (
    void
);

//
// Device Configurations
//

///
/// Get device serial number
/// @returns serial number text; DO NOT free the returned string
///
WHALETEQ_API 
char*
MECGGetSerialNumber (
	void
);

///
/// \brief Get device mode information
/// 
/// @param[out] modelInfo     A pointer to a ::MODEL_INFORMATION structure
/// @return True if the method was successful. False otherwise. 
///
WHALETEQ_API 
bool
MECGGetDeviceInformation (
    MODEL_INFORMATION *modelInfo
);

///
/// \brief Check if the MECG device is outputting.
/// 
/// @return True if the device is outputting. False otherwise. 
///
WHALETEQ_API 
bool
MECGIsOutputting (
    void
);

///
/// \brief Load Physionet header file
/// 
/// It's caller's responsibility to free the ECG_HEADER* resource by calling ::MECGFreeECGHeader ().
/// 
/// @param[in] filePath    The file path of *.hea file. A null-terminated string.
///
/// @return A ::ECG_HEADER pointer if the method was successful. NULL otherwise. 
///
WHALETEQ_API
ECG_HEADER*
MECGLoadMITHeader (
    const char* filePath
);

///
/// \brief Load Physionet database
/// 
/// Load the related *.dat file. Before calling the function, it is required that all the *.dat file
/// must be downloaded and placed in the same folder as the *.hea file.
/// 
/// @param[in] header       A ::ECG_HEADER pointer which is returned from ::MECGLoadMITHeader ()
///
/// @return True if the method was successful, False otherwise. 
///
WHALETEQ_API
bool
MECGLoadMITDatabase (
	ECG_HEADER *header
);

///
/// \brief Modify the mapping lead of the signals
///
/// The caller can modify the MappingLead of the ::ECG_SIGNAL struct, and then call this function to update.
///
/// @param[in] header A ::ECG_HEADER pointer
///
/// @return No return value.
///
WHALETEQ_API
void
MECGUpdateECGHeaderMappingLead (
    ECG_HEADER *header
);

///
/// \brief Free resource
/// 
/// It's caller's responsibility to free the ECG_HEADER* resource.
/// 
/// @param[in] header A ::ECG_HEADER pointer
///
/// @return True if the method was successful. False otherwise. 
///
WHALETEQ_API
void
MECGFreeECGHeader (
    ECG_HEADER *header
);

///
/// \brief Load AHA database
///
/// Load AHA database in either *.txt or *.ecg format. It's caller's responsibility to free the 
/// ECG_HEADER* resource by calling ::MECGFreeECGHeader ().
///
/// @param[in] filePath       The file path of *.txt or *.ecg file. A null-terminated string.
///
/// @return A ::ECG_HEADER pointer if the method was successful. NULL otherwise. 
///
WHALETEQ_API
ECG_HEADER*
MECGLoadDatabaseAHA (
	const char* filePath
);

///
/// \brief Load CSE database
///
/// Load CSE database file of *.dcd format. It's caller's responsibility to free the 
/// ECG_HEADER* resource by calling ::MECGFreeECGHeader ().
/// 
/// @param[in] filePath       The file path of *.dcd file. A null-terminated string.
///
/// @return A ::ECG_HEADER pointer if the method was successful. NULL otherwise.
///
WHALETEQ_API
ECG_HEADER*
MECGLoadDatabaseCSE (
    const char* filePath
);

///
/// \brief Load WhaleTeq-format database
///
/// Load database file of WhaleTeq-defined txt format. It's caller's responsibility to free the 
/// ECG_HEADER* resource by calling ::MECGFreeECGHeader (). The sample rate defined in the file
/// should be in the range of 100 (Hz) and 1000 (Hz).
/// 
/// @param[in] filePath       The file path of *.txt file.
///
/// @return A ::ECG_HEADER pointer if the method was successful. NULL otherwise.
///
WHALETEQ_API
ECG_HEADER*
MECGLoadDatabaseWhaleTeq (
    const char* filePath
);

///
/// \brief Load CTS/CSE database
///
/// The CTS/CSE databases are embedded in the SDK. The caller can load one by
/// specifying ::CTSCSE_Database.
///
/// @param[in] database      A ::CTSCSE_Database value.
/// @param[in] noise         A ::CTSCSE_Noise value. If the value is CTSCSENoise_MAX, noise is not applied.
///
/// @return A ::ECG_HEADER pointer if the method was successful. NULL otherwise.
///
WHALETEQ_API
ECG_HEADER*
MECGLoadDatabaseCTS_CSE (
    CTSCSE_Database database,
    CTSCSE_Noise noise
);

///
/// \brief Load periodic waveform
///
/// Continuously output the waveform until MECGStopOutput is called.
///
/// @param[in] frequency      Frequency. Unit: Hz. Resolution: 0.01 Hz. Range: 0~100 Hz.
/// @param[in] amplitude      Amplitude voltage. Unit: mVpp.
///
/// @return True if the method was successful. False otherwise. 
///
WHALETEQ_API
bool
MECGLoadWaveform (
    WAVEFORM_TYPE waveform,
    double frequency,
    double amplitude
);

///
/// \brief Load periodic waveform
///
/// Continuously output the waveform until MECGStopOutput is called.
///
/// @param[in] frequency      Frequency. Unit: Hz. Resolution: 0.01 Hz. Range: 0~100 Hz.
/// @param[in] amplitude      Amplitude voltage. Unit: mVpp. The 8 entries are in the order of LeadI, LeadII, V1~V6.
///
/// @return True if the method was successful. False otherwise. 
///
WHALETEQ_API
bool
MECGLoadWaveformEx (
	WAVEFORM_TYPE waveform,
	double frequency,
	double amplitude[8]
);

///
/// \brief Load triangle waveform
///
/// Continuously output the waveform until MECGStopOutput is called.
///
/// @param[in] pulseWidth     Pulse width. Unit: ms
/// @param[in] frequency      Frequency. Unit: Hz. Resolution: 0.01 Hz. Range: 0~100 Hz.
/// @param[in] amplitude      Amplitude voltage. Unit: mVpp
///
/// @return True if the method was successful. False otherwise. 
///
WHALETEQ_API
bool
MECGLoadWaveformRectanglePulse (
    int pulseWidth,
    double frequency,
    double amplitude
);

///
/// \brief Load calibration-mode waveform 
///
/// The loaded waveform is fixed to 10-seconds length. Used in the calibration process.
///
/// @param[in] frequency      Frequency. Unit: Hz. Resolution: 0.01 Hz. Range: 0~100 Hz.
/// @param[in] amplitude      Amplitude voltage. Unit: mVpp
///
/// @return True if the method was successful. False otherwise. 
///
WHALETEQ_API
bool
MECGLoadWaveformCalibrationMode (
    double frequency,
    double amplitude
);

///
/// \brief Load auto calibration-mode waveform
///
/// The loaded waveform is fixed to 10-seconds length. Used in the calibration process.
///
/// @return True if the method was successful. False otherwise. 
///
WHALETEQ_API
bool
MECGLoadWaveformAutoCalibrationMode (
	void
);

///
/// \brief Get waveform signals
///
/// The caller can get the current waveform signals for viewer use.
///
/// @param[in] start          The start position of the expected signals. Unit: second
/// @param[in] duration       The duration of the expected signals. Unit: second
/// @param[in] outputSignalCB A callback function which will be called with the returned signals.
///
/// @return True if the method was successful. False, if the outputSignalCB is NULL or the waveform data is empty
///
WHALETEQ_API
bool
MECGGetWaveformSignal (
    int start,
    int duration,
    OutputSignalCallback outputSignalCB
);

///
/// \brief Enable/disable looping mode
///
/// @param[in] enable  True if looping mode is expected. False otherwise.
///
/// @return No return value.
///
WHALETEQ_API
void
MECGEnableLoop (
    bool enable
);

///
/// \brief Enable/disable noise signal
///
/// The noise signal is only effective if the loading waveform is CTS/CSE.
///
/// @param[in] enable  True if the noise is expected. False otherwise.
///
/// @return No return value.
///
WHALETEQ_API
void
MECGEnableNoise (
    bool enable
);

///
/// \brief Notify device to start outputting
///
/// @param[in] startPosition    The start position to play. Unit: second
/// @param[in] outputSignalCB   A callback function which returns the ECG 12-lead signals
/// @param[in] outputDelayCB    A callback function which returns the delay time if the packet-transfer delay is occurred
///
/// @return True if the method was successful. False otherwise. 
///
WHALETEQ_API
bool
MECGOutputWaveform (
	int startPosition,
    OutputSignalExCallback outputSignalCB=NULL,
    OutputDelayCallback outputDelayCB=NULL
);

///
/// \brief Stop the device outputting
///
/// @return No return value.
///
WHALETEQ_API
void
MECGStopOutput (
    void
);

///
/// \brief Get DLL file version
///
/// @return The version is 4-digits and are saved in each byte of unsigned int value.\n
///         For example, if the return value is 0x01020304, the dll version is 1.2.3.4.
///
WHALETEQ_API
unsigned int
MECGGetVersion (
    void
);
