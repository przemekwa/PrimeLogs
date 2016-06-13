PrimeLogs
=========

Plugin do Notepad++ napisany w C#.

**Szybki start**

```PrimeLogs``` to plugin do notepad++ (do każdej wersji), który pomaga w organizacji i przegladaniu logów z różnych aplikacjii znajdujących się w różnych lokalizacjach.

##Instalacja

Aby uzyskać plugin można albo pobrać go z zakładki ```Realase``` z github-a albo samemu skompilować ze źródeł. Otrzymaną dll-klę należy wgrać do katalogu ```Plugin``` w katalogu z Notepad++.

##UWAGA

Aby udało się poprawnie skompilować ten plugin(jak i inne pluginy do Notepad++ do C# z szablonu ze strony Notepad++), trzeba do Visual Studio dodać pakiet od VC++. Bez tego dll się skompiluje ale w okienku Output będzie komuniakt, że brakuje programu lib.exe w pewnej lokalizacji. To powoduje, że nie da się dodać pluginu do Notepadd++, bo wyskakuje komunikat o tym, że jest niezgody z aktualną wersją Notepad++


##Model

Jedyne czego potrzebujemy aby coś zaprogramować to model! A wiec przedstawiam model danych. 
Mamy plik logu, który należy do aplikacji A. Aplikacja A jest zainstalowana na serwerach S, S1, S2 itd. Jeśli chcemy przegladać logi to musimy wejść na serwer S, otworzyć logi aplikacji A. I tak dla każdego serwera.

Więc, żeby było prosto zorganiowzałem te logi tak, aby było mozna je przeglądać w zależności od rodzaju aplikacji(aplikacja A) i od położenia (serwery S, S1, S2) właśnie w takiej kolejności.

Ponieważ logi mogą przyjmować różną formę - xml, json, txt - to można filtrować po nazwach plików tak aby było można się dostać do tego co nas interesuje.

##Konfiguracja

Do konfiguracji PrimeLogs służy plik konfiguracyjny xml. Poniżej przykład takiego właśnie pliku

```
<PrimeLogi>
  <log name="PrimeApi">
    <location name="zt2" path="\\wro67zt2\c$\inetpub\wwwroot\AlsbWebServices\PrimeApi\logs\" filter="log_2016-06*.txt" ></location>
  </log>
</PrimeLogi>
```

Węzeł ```log``` zawiera atrybut ```name```, który służy do rozróżnienia aplikacji, które tworzą logi. Węzeł ```log``` składa się z prawie dowolnej ilości węzłów ```location```, które to mają nastepujące atrybuty:

| Nazwa atrybutu  | Opis |
| ------------- | ------------- |
| ```name``` | Nazwa lokalizacji. Najlepiej aby była to nazwa serwera.  |
| ```path```  | Ścieżka do katalogu z logami.  |
| ```filter```  | Zwykły filtr plików w katalogu. Dozwolone są proste wyrażenia ```WildCards```  |

##Podsumowanie

Plugin pojawia się w zakładce ```Wtyczki->Prime Logs```. Z menu można wybrać ```Brower``` aby wczytać xml-a z konfiguracją i wybrać odpowiednie logi albo ```Settings``` aby móc edytować plik konfiguracyjny.

Można również korzystać ze skrótu ```Ctrl + L```, który to od razu prowadzi do przeglądania logów.

Więcej informacji można znaleść na moim blogu, gdzie opisałem jak tworzyć pluginy do Notepad++ w C#. http://blogprogramisty.net/plugin-do-notepad-w-c-sharp/







