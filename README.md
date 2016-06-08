PrimeLogs
=========

Notepad++ plugin do Notepad++.

**Szybki start**

PrimeLogs to plugin do notepad++, który pomaga w organizacji i przegladaniu logów z różnych aplikacji znajdujących się w róznych lokalizacjach.

##Instalacja

Aby uzuskać plugin można albo pobrac go z Relasa z github-a albo samemu skompilować. Otrzymaną dll-klę nalezy wgrac do katalogu Plugin w katalogu z Notepad++.

##Model

Jedyne czego potrzebujemy aby coś zaprogramować to model. A wiec przedstawim model danych. Mamy plik logu, który nalezy do aplikacji A. Aplikacja A jest zainstalowana na serwerach S, S1, S2 itd. Jeśli chcemy przegladać logi to musimy wejść na serwer S, otworzyć logi aplikacji A. I tak dla każdego serwera.

Więz żeby było prosto zorganiowzałem te logi tak, aby było mozna jest przegladać w zależności od rodzaju aplikacji(aplikacja A) i od połazenia (serwery S, S1, S2) właśnie w takij kolejności.

Ponieważ logi moga przyjmować różną formę, xml, json, txt to można filtrować po nazwach plików tak aby było mozna się dostać do tego co nas interesuje

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
| ```name``` | Nazwa lokalizacji. Najlepiej aby była to zanwa serwera.  |
| ```path```  | Ścieżka do katalogu z logami.  |
| ```filter```  | Zwykły filtr plików w katalogu. Dozwolone są proste wyrażenia ```WildCards```  |

##Podsumowanie

Plugin pojawia się w zakładce ```Wtyczki->Prime Logs```. Z menu można wybrać ```Brower``` aby wczytać xml-a z konfiguracją i wybrac odpowiednie logi albo ```Settings``` aby móc edytować plik konfiguracyjny.

Mozna również korzystać ze skrótu ```Ctrl + L```, który to od razu prowadzi do przeglądania logów.





