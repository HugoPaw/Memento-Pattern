using System;

// 1. Memento: speichert den Zustand
public class TextMemento
{
    public string Text { get; }

    public TextMemento(string text)
    {
        Text = text;
    }
}

// 2. Originator: erstellt und benutzt Mementos
public class TextEditor
{
    private string _text = "";

    public void Schreiben(string neuerText)
    {
        _text = neuerText;
        Console.WriteLine("Aktueller Text: " + _text);
    }

    public TextMemento Speichern()
    {
        return new TextMemento(_text);
    }

    public void Wiederherstellen(TextMemento memento)
    {
        _text = memento.Text;
        Console.WriteLine("Zurückgesetzt auf: " + _text);
    }
}

// 3. Caretaker: verwaltet Mementos
public class Speicher
{
    public TextMemento GespeicherterZustand { get; set; }
}

// 4. Benutzung
class Program
{
    static void Main(string[] args)
    {
        TextEditor editor = new TextEditor();
        Speicher speicher = new Speicher();

        editor.Schreiben("Hallo Welt!");
        speicher.GespeicherterZustand = editor.Speichern();  // Zustand speichern

        editor.Schreiben("Neuer Text...");
        
        editor.Wiederherstellen(speicher.GespeicherterZustand);  // Zustand zurückholen
      }
}