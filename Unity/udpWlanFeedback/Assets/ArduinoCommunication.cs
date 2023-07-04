using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

public class ArduinoCommunication : IDisposable
{
    private UdpClient udpClient;
    private IPEndPoint arduinoEndpoint;
    private bool isDisposed;
    private bool isReceiving;

    // Konstruktor: initialisiert den UdpClient und die Arduino-Endpunktinformationen
    public ArduinoCommunication(string arduinoIPAddress, int arduinoPort)
    {
        udpClient = new UdpClient();
        arduinoEndpoint = new IPEndPoint(IPAddress.Parse(arduinoIPAddress), arduinoPort);
    }

    // Sendet einen Befehl an das Arduino-Gerät und empfängt eine Antwort
    public void SendCommandToArduino(string command, Action<string> callback)
    {
        if (isDisposed)
            return;

        byte[] commandBytes = Encoding.ASCII.GetBytes(command);
        udpClient.Send(commandBytes, commandBytes.Length, arduinoEndpoint);
        ReceiveResponse(callback);
    }

    // Empfängt eine Antwort vom Arduino-Gerät-Nano Iot
    private async void ReceiveResponse(Action<string> callback)
    {
        if (isDisposed)
            return;

        isReceiving = true;
        try
        {
            var result = await udpClient.ReceiveAsync();
            string response = Encoding.ASCII.GetString(result.Buffer);
            callback(response);
        }
        catch (SocketException ex)
        {
            UnityEngine.Debug.LogError("Fehler beim Empfangen der Antwort vom Arduino: " + ex.Message);
        }
        finally
        {
            isReceiving = false;
        }
    }

    // Freigeben von Ressourcen
    public void Dispose()
    {
        if (isReceiving)
        {
            Task.Delay(100).ContinueWith(t => Dispose());
            return;
        }

        isDisposed = true;
        udpClient?.Close();
        udpClient = null;
    }
}
