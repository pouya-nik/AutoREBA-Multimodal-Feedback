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

    // Konstruktor für IP-Adresse
    public ArduinoCommunication(string arduinoIPAddress, int arduinoPort)
    {
        udpClient = new UdpClient();
        arduinoEndpoint = new IPEndPoint(IPAddress.Parse(arduinoIPAddress), arduinoPort);
    }

    // Konstruktor für Hostname
    public ArduinoCommunication(int arduinoPort, string arduinoHostname)
    {
        udpClient = new UdpClient();
        IPHostEntry hostEntry = Dns.GetHostEntry(arduinoHostname);
        IPAddress ipAddress = null;
        foreach (var address in hostEntry.AddressList)
        {
            if (address.AddressFamily == AddressFamily.InterNetwork) // IPv4 addresses only
            {
                ipAddress = address;
                break;
            }
        }
        if (ipAddress == null)
        {
            throw new Exception("Keine IPv4-Adresse für den Host gefunden");
        }
        arduinoEndpoint = new IPEndPoint(ipAddress, arduinoPort);
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
