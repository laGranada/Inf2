/**
 * Created by Markus Alpers on 20.10.2016.
 */

import javafx.application.Application;
import javafx.event.ActionEvent;
import javafx.event.EventHandler;
import javafx.geometry.HPos;
import javafx.geometry.Pos;
import javafx.geometry.Insets;
import javafx.scene.Scene;
import javafx.scene.control.Button;
import javafx.scene.layout.GridPane;
import javafx.scene.text.Font;
import javafx.scene.text.FontWeight;
import javafx.scene.text.Text;
import javafx.stage.Stage;

public class Textadventure extends Application {

    private int aktuellerAbschnitt;
    private String[] abschnitte;
    private String[][] beschriftungen;
    private int[][] naechsterAbschnitt;
    private Text beschreibung;
    private Button button1;
    private Button button2;

    @Override
    public void start(Stage primaryStage) {
        primaryStage.setTitle("Textadventure");

        int abenteuerlaenge = 10;
        aktuellerAbschnitt = 0;

        abschnitte = new String[abenteuerlaenge];
        beschriftungen = new String[abenteuerlaenge][2];
        naechsterAbschnitt = new int[abenteuerlaenge][2];

        // 0: Startpunkt
        abschnitte[0] = "Du erwachst. Es ist kalt und du hast einen Kater. Es riecht ein wenig muffig.";
        beschriftungen[0][0] = "Du siehst dich um.";
        naechsterAbschnitt[0][0] = 1;
        beschriftungen[0][1] = "Du stehst auf.";
        naechsterAbschnitt[0][1] = 2;

        // 1: Umsehen nach erfwachen
        abschnitte[1] = "Ich glaub, du stehst im Wald... nein, vielmehr liegst du im Wald. Muss eine üble Party gewesen sein.";
        beschriftungen[1][0] = "Du stehst auf.";
        naechsterAbschnitt[1][0] = 2;
        beschriftungen[1][1] = "Du schläfst lieber nochmal ne Runde.";
        naechsterAbschnitt[1][1] = 0;

        // 2: Aufstehen
        abschnitte[2] = "Schwankend kommst du auf die Füße. Der nächste Wald von deiner WG aus liegt in nördlicher Richtung. Wie war das doch noch?";
        beschriftungen[2][0] = "An Bäumen wächst das Moos auf der Südseite, denn Moos wächst im Sonnenlicht.";
        naechsterAbschnitt[2][0] = 3;
        beschriftungen[2][1] = "Quatsch, es ist genau umgekehrt.";
        naechsterAbschnitt[2][1] = 4;

        // 3: Nach Norden
        abschnitte[3] = "So soll es sein... Du schwankst durch einen unbekannten Wald in eine Richtung, die du für Süden hältst.";
        beschriftungen[3][0] = "Du bleibst bei deiner Entscheidung und gehst immer weiter in die Richtung.";
        naechsterAbschnitt[3][0] = 5;
        beschriftungen[3][1] = "Du bist dir nicht sicher und drehst nochmal um.";
        naechsterAbschnitt[3][1] = 6;

        // 4: Nach Süden
        abschnitte[4] = "So soll es sein... Du schwankst durch einen unbekannten Wald in eine Richtung, die du für Süden hältst.";
        beschriftungen[4][0] = "Du bleibst bei deiner Entscheidung und gehst immer weiter in die Richtung.";
        naechsterAbschnitt[4][0] = 9;
        beschriftungen[4][1] = "Du bist dir nicht sicher und drehst nochmal um.";
        naechsterAbschnitt[4][1] = 5;

        // 5: Weiter nach Norden
        abschnitte[5] = "Und du gehst ... und gehst ... und gehst...";
        beschriftungen[5][0] = "und drehst dann irgendwann um, weils so weit doch nicht sein kann.";
        naechsterAbschnitt[5][0] = 6;
        beschriftungen[5][1] = "und gehst immer weiter.";
        naechsterAbschnitt[5][1] = 8;

        // 6: Doch nach Süden
        abschnitte[6] = "Du kommst an der Stelle vorbei, an der du aufgewacht bist.";
        beschriftungen[6][0] = "Weiter geht's.";
        naechsterAbschnitt[6][0] = 9;
        beschriftungen[6][1] = "Nein, doch lieber umdrehen.";
        naechsterAbschnitt[6][1] = 5;

        //
        abschnitte[7] = "Testeintrag...";
        beschriftungen[7][0] = "Neustart";
        naechsterAbschnitt[7][0] = 0;
        beschriftungen[7][1] = "Neustart";
        naechsterAbschnitt[7][1] = 2;

        // 8: Game Over
        abschnitte[8] = "Du hast dich hoffnungslos verirrt.";
        beschriftungen[8][0] = "Nochmal von vorne.";
        naechsterAbschnitt[8][0] = 0;
        beschriftungen[8][1] = "Nochmal von vorne.";
        naechsterAbschnitt[8][1] = 0;

        // 9: Ende
        abschnitte[9] = "Nach fünf Minuten brichst du durch die Hecke auf das Gelände deines Wohnheims. Dann mal ran an Statistik 1 - Und mögest du alle Hoffnung verlieren.";
        beschriftungen[9][0] = "Nochmal von vorne.";
        naechsterAbschnitt[9][0] = 0;
        beschriftungen[9][1] = "Nochmal von vorne.";
        naechsterAbschnitt[9][1] = 0;

        GridPane grid = new GridPane();
        grid.setAlignment(Pos.CENTER);
        grid.setHgap(10);
        grid.setVgap(10);
        grid.setPadding(new Insets(25, 25, 25, 25));

        Scene scene = new Scene(grid, 1200, 400);
        primaryStage.setScene(scene);

        Text scenetitle = new Text("Kleines Textadventure");
        scenetitle.setFont(Font.font("Tahoma", FontWeight.NORMAL, 20));
        grid.add(scenetitle, 0, 0, 2, 1);

        beschreibung = new Text(abschnitte[aktuellerAbschnitt]);
        grid.add(beschreibung, 0, 1, 2, 2);

        button1 = new Button(beschriftungen[aktuellerAbschnitt][0]);
        grid.add(button1, 0, 3);
        grid.setHalignment(button1, HPos.RIGHT);

        button2 = new Button(beschriftungen[aktuellerAbschnitt][1]);
        grid.add(button2, 1, 3);
        grid.setHalignment(button2, HPos.LEFT);

        button1.setOnAction(new EventHandler<ActionEvent>() {
            @Override
            public void handle(ActionEvent e) {
                aktuellerAbschnitt = naechsterAbschnitt[aktuellerAbschnitt][0];
                rewriteEntries(aktuellerAbschnitt);
            }
        });

        button2.setOnAction(new EventHandler<ActionEvent>() {
            @Override
            public void handle(ActionEvent e) {
                aktuellerAbschnitt = naechsterAbschnitt[aktuellerAbschnitt][1];
                rewriteEntries(aktuellerAbschnitt);
            }
        });

        primaryStage.show();
    }

    private void rewriteEntries(int abschnnitt){
        beschreibung.setText(abschnitte[aktuellerAbschnitt]);
        button1.setText(beschriftungen[aktuellerAbschnitt][0]);
        button2.setText(beschriftungen[aktuellerAbschnitt][1]);
    }

    public static void main(String[] args) {
        launch(args);
    }

}

/**
 * Grundsätzlich nötig:
 * Textanzeige
 * Buttons für Auswahl der Antwort
 *
 * Texte aus Array von Abschnitten
 * Dazu Array mit Anzahl Buttons zum Abschnitt
 * Dazu Array mit Texten für jeden der Buttons
 */