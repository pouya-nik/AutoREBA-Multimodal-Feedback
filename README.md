# AutoREBA - Multimodal Feedback Group

## Projektbeschreibung

AutoREBA (Automatische Rapid Entire Body Assessment Score) ist ein großes Projekt im Bereich der Mensch-Computer-Interaktion. Das Ziel des Projekts ist es, eine Forschungsfrage im Bereich der Haltungsergonomie in Mixed Reality zu beantworten. Das übergeordnete Thema des Projekts ist "Multimodales Biofeedback zur Verbesserung der Haltungsergonomie in Mixed Reality".

Das Projekt umfasst insgesamt ca 13 Studierende, die in Teamarbeit an der Lösung der Forschungsfrage arbeiten. Das Team besteht aus vier Gruppen, von denen jede aus drei Mitgliedern und einem Projektmanager besteht. Die Gruppen sind wie folgt aufgeteilt:

1. Computation und Visualization
2. Multi Device Communication
3. Ground Truth
4. Multimodal Feedback (dieses Repository)

In der Multimodal Feedback Gruppe konzentrieren wir uns auf die Kommunikation zwischen dem Arduino Nano IoT und Unity. Unser Ziel ist es, mithilfe des Rapid Entire Body Assessment Scores dem Benutzer eines VR-Headsets durch visuelles, auditives und vibrationsbasiertes Feedback Informationen über seine Haltung zu geben.

## Repository-Inhalt

Dieses Repository enthält den Code und die Ressourcen, die von der Multimodal Feedback Gruppe entwickelt werden. Hier finden Sie die Implementierung der Kommunikation zwischen dem Arduino Nano IoT und Unity, um das Biofeedback zu ermöglichen.

Die Hauptkomponenten des Repositories sind:

- [`Arduino`](Arduino): Enthält den Arduino-Code, der auf dem Arduino Nano IoT ausgeführt wird. Dieser Code erfasst die Haltungsdaten und sendet sie an Unity.
- [`Unity`](Unity): Enthält den Unity-Code und die Szenen, die für die Visualisierung des Biofeedbacks und die Verarbeitung der Daten verwendet werden. Dieser Code kommuniziert mit dem Arduino Nano IoT und gibt das entsprechende Feedback an den Benutzer.

## Anforderungen

Um das Projekt ausführen zu können, werden folgende Komponenten benötigt:

- Arduino Nano IoT
- Unity (Version 2021.3.23f1)
- Weitere Abhängigkeiten werden im jeweiligen Verzeichnis der Komponente angegeben

## Installation und Verwendung

1. Klone das Repository auf deinen lokalen Computer:

   ```bash
   git clone https://github.com/DeinBenutzername/AutoREBA-Multimodal-Feedback.git
   ```

2. Öffne den `Arduino`-Ordner in der Arduino-Entwicklungsumgebung und lade den Code auf den Arduino Nano IoT.

3. Öffne das Unity-Projekt in Unity und navigiere zur entsprechenden Szene.

4. Verbinde den Arduino Nano IoT mit deinem Computer.

5. Starte das Unity-Projekt und teste die Kommunikation zwischen Arduino und Unity.

Weitere spezifische Anweisungen und Informationen finden Sie in den jeweiligen Unterordnern des Repositorys.

## Beitragende

- Patricia Bombik
- Pouya Nikbakhsh
- Albin Hoti

## Lizenz

Dieses Projekt ist unter der [MIT-Lizenz](https://opensource.org/licenses/MIT) lizenziert. Weitere Informationen finden Sie in der [`LICENSE`](LICENSE)-Datei.
## Taktiles Feedback
### Vibration
#### Überblick
Dieses Skript ermöglicht es, dem Benutzer taktiles Feedback bezüglich seines REBA-Scores zu geben. Der REBA (Rapid Entire Body Assessment) Score ist eine ergonomische Analyse, und dieses System wandelt ihn in ein Vibrationssignal um, um dem Benutzer ein physisches Feedback zu geben.

#### Funktionen
Anpassbare Vibrationseinstellungen
- Stufen: Der REBA-Score kann in 15 detaillierte oder 5 grobe Stufen eingeteilt werden.
- Intensität: Wählbar zwischen niedriger, mittlerer und hoher Intensität.
- Motoren: Verwendung von ein oder zwei Motoren für unterschiedliche Vibrationsstärken.
#### Flexibilität
Der Benutzer kann die Einstellungen je nach Bedarf anpassen, um ein optimales Feedback für seinen REBA-Score zu erhalten. Die Anpassungsfähigkeit ermöglicht es, die Vibration in feineren oder gröberen Schritten zu spüren und die Intensität oder die Anzahl der Motoren nach Bedarf zu ändern.

#### Implementierung
##### Verbindung
Das Skript verwendet UDP, um Daten an einen Arduino zu senden, der die Vibration steuert. Die IP-Adresse und der Port können im Code konfiguriert werden.

##### Vibration Arrays
Es gibt mehrere Arrays, die die Vibrationsstärken für verschiedene Kombinationen von Einstellungen definieren.

##### Steuerung und Timing
Das Skript aktualisiert das Vibrationssignal in regelmäßigen Abständen (standardmäßig jede Sekunde) und sendet die Daten über UDP.

##### Verwendung
Fügen Sie das Skript einer Unity-Komponente hinzu und konfigurieren Sie die Einstellungen im Inspektor oder im Code. Starten Sie das Programm, und das Skript wird automatisch Vibrationssignale basierend auf dem REBA-Score senden.

##### Anforderungen
- Unity
- Ein Gerät, das in der Lage ist, die Vibration zu interpretieren (z.B. Arduino)
- Konfigurierte IP-Adresse und Port für die Kommunikation mit dem Vibrationsgerät
#### Kalibrierung 
