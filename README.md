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
- Unity (Version 2021.3.26f1)
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

## AutoREBA: Visuelles Feedback mit SAM

Das AutoREBA-Projekt zielt darauf ab, durch den Einsatz von Mixed Reality eine verbesserte Haltungsergonomie zu erzielen. Ein Schlüsselinstrument zur Kommunikation der Körperhaltung des Benutzers ist das visuelle Feedback.

### Überblick
Das `VisualFeedback`-Skript bietet dem Benutzer visuelle Hinweise zu seinem aktuellen REBA-Score. Es nutzt verschiedene visuelle Mechanismen, von Balken bis hin zu SVG-Bildern und Textanzeigen, die alle in Echtzeit aktualisiert werden, je nach aktuellem REBA-Score des Benutzers.

### SELF-ASSESSMENT MANIKIN (SAM)

Ein zentrales Feature im visuellen Feedback ist der Einsatz des **SELF-ASSESSMENT MANIKIN (SAM)**. SAM ist ein nicht-verbales Bewertungssystem, das genutzt wird, um affektive Reaktionen einer Person zu erfassen.

- **Visuelle Darstellung**: SAM verwendet Bilder von Figuren (Manikins) anstelle von Wörtern, um Emotionen darzustellen.

- **Fünf Gesichter**: SAM besteht aus fünf verschiedenen Gesichtern, die ein Spektrum von sehr negativen bis sehr positiven Emotionen abdecken.

- **Anwendung in AutoREBA**: Im Kontext von AutoREBA gibt SAM dem Benutzer ein intuitives Feedback über seine Körperhaltung.

### REBA Visualisierungen

#### RebaBar

Die RebaBar stellt den aktuellen REBA-Score des Benutzers dar, wobei Werte von 1 bis 15 möglich sind. Ein Score von 1 repräsentiert die ideale Haltung, während ein Score von 15 eine sehr schlechte Haltung anzeigt. Abhängig vom Score ändert sich die Farbe der Bar:

- 1: Grün
- 2-3: Gelb
- 4-7: Orange
- 8-10: Rot
- 11-15: Dunkelrot

#### RebaNumber

Je schlechter die Haltung, desto größer wird die Zahl auf dem Display dargestellt und die Farbe ändert sich entsprechend dem aktuellen REBA-Score, ähnlich wie bei der RebaBar.

#### RebaScore Text

Je nach REBA-Score wird dem Benutzer eine entsprechende Nachricht angezeigt:

- 1: "Negligible risk, no action required"
- 2-3: "Low risk, change may be needed"
- 4-7: "Medium risk, further investigation, change soon"
- 8-10: "High risk, investigate and implement change"
- 11-15: "Very high risk, implement change"

#### ExtraImage

Mit der Hauptfunktion `ExtraImage` können Benutzer ihr eigenes Bild anstelle der SAM-Bilder verwenden.

### Hauptfunktionen

- **RebaBar**: Ein Balkendiagramm, das den aktuellen REBA-Score des Benutzers repräsentiert.

- **SVGImage**: Hier wird SAM verwendet. Abhängig vom REBA-Score des Benutzers wird ein entsprechendes SAM-Bild angezeigt.

- **RebaScoreText** und **RebaScoreNumber**: Textuelle Rückmeldungen, die den aktuellen REBA-Score und zugehörige Informationen präsentieren.

- **ExtraImage**: Eine Funktion, mit der Benutzer ihre eigenen Bilder anstelle der SAM-Bilder verwenden können.

Es ist zu beachten, dass jede Hauptfunktion über das Unity-Interface **aktiviert** oder **deaktiviert** werden kann.

### Einrichtung und Verwendung

Nach dem Hinzufügen der Skripts `RebaBar` und `VisualFeedback` zu einem GameObject in der Unity-Szene müssen alle erforderlichen Referenzen im Unity-Editor bereitgestellt werden. Die verschiedenen Feedback-Elemente können über die öffentlichen Variablen des Skripts gesteuert werden. Es ist wichtig, sicherzustellen, dass die benötigten Sprites und Text-Referenzen korrekt zugewiesen sind.
