# KeyRegisterApplication käyttöohjeet

Tämä dokumentti sisältää ohjeet avainrekisteriohjelman käyttöön ja kääntämiseen.


## Kääntäminen (mono mcs)

Mono on avoimen lähdekoodin .NET implementaatio joka on saatavilla useille alustoille mukaan lukien linux, OSX ja Windows. Mcs on
monon tarjoama C#-kääntäjä (mcs = Mono C# compiler). Sivusto: http://www.mono-project.com/

### Käyttöliittymänä Gtk

```mcs -pkg:gtk-sharp-3.0 -reference:System.Xml *.cs UserInterfaceGtk/*.cs -out:KeyRegisterApp.exe```


### Käyttöliittymänä CLI

```mcs -reference:System.Xml *.cs UserInterfaceConsole/*.cs -out:KeyRegisterApp.exe```


## Kääntäminen (ms csc.exe)

...


## Käyttö (CLI)

...
