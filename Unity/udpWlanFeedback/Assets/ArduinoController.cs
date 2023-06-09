using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArduinoController : MonoBehaviour
{
    public enum ConnectionType
    {
        IPAddress,
        Hostname
    }

    public ConnectionType connectionType;
    public string arduinoIpAddress = "192.168.2.58";
    public string arduinoHostname = "ArduinoNanoIoT";
    public int arduinoPort = 8888;

    private ArduinoCommunication arduinoComm;

    // Vibrationsintensität, die an das Arduino-Gerät gesendet werden soll
    [Range(0, 255f)]
    public float vibrationIntensity;

    // REBA-Score, der zur Berechnung der Vibrationsintensität verwendet wird
    [Range(1, 15)]
    public int rebaScore;

    private const float IntensityScaleFactor = 155f / 15f;
    private const float IntensityOffset = 100f;

    // Wird aufgerufen, wenn das Spielobjekt aktiviert wird
    private void Start()
    {
        switch (connectionType)
        {
            case ConnectionType.IPAddress:
                arduinoComm = new ArduinoCommunication(arduinoIpAddress, arduinoPort);
                break;
            case ConnectionType.Hostname:
                arduinoComm = new ArduinoCommunication(arduinoPort, arduinoHostname);
                break;
        }
        Debug.Log("Server startet:");
    }

    // Wird jeden Frame aufgerufen
    private void Update()
    {
        // Senden von Befehlen an das Arduino-Gerät, wenn die Tasten Alpha1"1" oder Alpha0"0" gedrückt werden
        if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Alpha0))
        {
            string command = Input.GetKeyDown(KeyCode.Alpha1) ? "1" : "0";
            arduinoComm.SendCommandToArduino(command, response =>
            {
                Debug.Log("Arduino Antwort: " + response);
            });
        }
        // Aktualisieren der Vibrationsintensität
        vibrationIntensity = (IntensityScaleFactor * rebaScore) + IntensityOffset;
    }

    // Wird aufgerufen, wenn das Spielobjekt deaktiviert wird oder wenn das Spiel beendet wird
    private void OnDestroy()
    {
        arduinoComm?.Dispose();
    }
}
