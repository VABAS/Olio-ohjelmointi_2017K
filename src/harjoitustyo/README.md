# KeyRegisterApplication käyttöohjeet

Tämä dokumentti sisältää ohjeet avainrekisteriohjelman käyttöön ja kääntämiseen.


## Kääntäminen (mono mcs)

Mono on avoimen lähdekoodin .NET implementaatio joka on saatavilla useille alustoille mukaan lukien linux, OSX ja Windows. Mcs on
monon tarjoama C#-kääntäjä (mcs = Mono C# compiler). Sivusto: http://www.mono-project.com/

```mcs -pkg:gtk-sharp-3.0 -reference:System.Xml *.cs */*.cs -out:KeyRegisterApp.exe```


## Käyttö (CLI)

```
Usage: KeyRegisterApp.exe [command] [arguments]

Available commands:

  listkeys - Lists all keys in register

  keydetails [keyDbId] - Shows information about key

  addkey [keyArgs] - Adds new key to register
    Where keyArgs are any combination of
    identifier=[value], name=[value] and description=[value]
    However, identifier and name are required for new key.

  editkey [keyDbId] [keyArgs] - Modifies key
    Where keyArgs are any combination of
    identifier=[value], name=[value] and description=[value]
    Any field value left out is considered not edited.

  setkeymissing [keyDbId] - Sets key to missing

  removekey [keyDbId] - Removes key from register

  loankey [keyDbId] [loanArgs] - Adds new loan for key
    Where loanArgs are any combination of
    datestart=[YYYY-mm-dd], datedue=[YYYY-mm-dd], loanedto=[value], isreturned=[true/false] and additional=[value]
    Only datestart must be provided.

  addloan - alias for loankey.

  listloans- lists all loans

  loandetails [loanDbId] - Shows details about loan

  editloan [loanDbId] [loanArgs] - Modifies loan
    Where loanArgs are any combination of
    datestart=[YYYY-mm-dd], datedue=[YYYY-mm-dd], loanedto=[value], isreturned=[true/false] and additional=[value]
    Any field value left out is considered not edited.

  returnloan [loanDbId] - Sets loan returned

  help - Display information about available operations.
```
