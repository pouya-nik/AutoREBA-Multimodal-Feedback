#include <SPI.h>
#include <WiFiNINA.h>

const int ledPin = 13;    // Pin 13 für die LED
const int udpPort = 8888; // UDP port
char ssid[] = "xxxxxxxx"; // your network SSID (name)
char pass[] = "xxxxxxxx"; // your network password
char hostName[] = "arduinoNanoIoT";
int status = WL_IDLE_STATUS; // the WiFi radio's status
WiFiUDP Udp;                 // UDP-Objekt für die Kommunikation

void setup()
{
  // Initialize serial and wait for the port to open:
  Serial.begin(9600);
  pinMode(ledPin, OUTPUT); // LED-Pin als Ausgang festlegen
  connectToWiFi();
  printCurrentNet();
  printWifiData();
  // UDP-Server starten
  Udp.begin(udpPort);
}

void loop()
{
  swapLED();
}

void swapLED()
{

  // Auf eingehende UDP-Pakete warten
  int packetSize = Udp.parsePacket();
  if (packetSize)
  {
    char packetData = Udp.read();
    if (packetData == '1')
    {
      digitalWrite(ledPin, HIGH); // LED einschalten
      Udp.beginPacket(Udp.remoteIP(), Udp.remotePort());
      Udp.write("LED eingeschaltet");
      Udp.endPacket();
    }
    else if (packetData == '0')
    {
      digitalWrite(ledPin, LOW); // LED ausschalten
      Udp.beginPacket(Udp.remoteIP(), Udp.remotePort());
      Udp.write("LED ausgeschaltet");
      Udp.endPacket();
    }
  }
}
void connectToWiFi()
{
  // Check if the WiFi module is working correctly
  if (WiFi.status() == WL_NO_MODULE)
  {
    Serial.println("Communication with WiFi module failed!");
    // don't continue
    while (true)
      ;
  }

  WiFi.setHostname(hostName); // Set the hostname

  // Attempt to connect to WiFi network
  while (status != WL_CONNECTED)
  {
    Serial.print("Attempting to connect to SSID: ");
    Serial.println(ssid);
    // Connect to WPA/WPA2 network. Change this line if using an open or WEP network:
    status = WiFi.begin(ssid, pass);

    // Wait 5 seconds for connection:
    delay(500);
  }
}

void printWifiData()
{
  // print your board's IP address:
  IPAddress ip = WiFi.localIP();
  Serial.print("IP Address: ");
  Serial.println(ip);
  Serial.println(String("Host name: ") + hostName);

  // print your MAC address:
  byte mac[6];
  WiFi.macAddress(mac);
  Serial.print("MAC address: ");
  printMacAddress(mac);
}

void printCurrentNet()
{
  // print the SSID of the network you're attached to:
  Serial.print("SSID: ");
  Serial.println(WiFi.SSID());

  // print the MAC address of the router you're attached to:
  byte bssid[6];
  WiFi.BSSID(bssid);
  Serial.print("BSSID: ");
  printMacAddress(bssid);

  // print the received signal strength:
  long rssi = WiFi.RSSI();
  Serial.print("signal strength (RSSI):");
  Serial.println(rssi);

  // print the encryption type:
  byte encryption = WiFi.encryptionType();
  Serial.print("Encryption Type:");
  Serial.println(encryption, HEX);
  Serial.println();
}

void printMacAddress(byte mac[])
{
  for (int i = 5; i >= 0; i--)
  {
    if (mac[i] < 16)
    {
      Serial.print("0");
    }
    Serial.print(mac[i], HEX);
    if (i > 0)
    {
      Serial.print(":");
    }
  }
  Serial.println();
}