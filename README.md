# Altkom.Motorola.MicroServices


## Docker


## Redis


### Instalacja

Uruchomienie Redis w dockerze
~~~
docker run --name my-redis -d -p 6379:6379 redis
~~~

Sprawdzenie czy Redis odpowiada
~~~
ping
~~~

Śledzenie Redisa
~~~
monitor
~~~

### Klucze

Dodanie wartości
~~~
set user1 Marcin
~~~
Kolejne wywołanie nadpisze poprzednią wartość (update).

Jeśli chcemy tego uniknąć należy dodać atrybut NX
~~~
set user1 Marcin NX
~~~

Pobranie wartości
~~~
get user1
~~~


Usuniecie klucza
~~~
DEL user1
~~~


### TTL

Dodanie wartości na określony czas (TTL)
~~~
set vehicle1 ready ex 120
~~~

Ustawienie czasu życia klucza
~~~
expire vehicle1 60
~~~



Pobranie czasu, który pozostał do wygaśnienia klucza
~~~
ttl vehicle1
~~~

Pobranie wszystkich kluczy wg szablonu
~~~
keys *
~~~

### Baza danych

Wybór bazy danych
~~~
select 1
~~~


###  Tablice asocjacyjne

Dodanie 
~~~
hmset person1 name Marcin surname Sulecki email marcin.sulecki@altkom.pl
~~~

Pobranie wszystich pól
~~~
hgetall
~~~

Pobranie wybranego pola
 ~~~
 hget person1 email
 ~~~
 
 
 ### Inkrementacja
 
 Dodanie 1 do klucza
 ~~~
 incr points
 ~~~
 
 Dodanie określonej liczby do klucza
 ~~~
  incrby points 10
 ~~~
 
 Odjęcie 1 od klucza
 ~~~
 decr points
 ~~~
 

### Listy

Dodanie wartości do listy
~~~ 
lpush temp1 23
lpush temp1 24
lpush temp1 23.5
~~~

Pobranie zakresu wartości z listy
~~~
lrange temp1 0 10
~~~

Pobranie wartości z listy na podstawie indeksu
~~~
lindex temp1 2
~~~

### Geo

Dodanie pozycji
~~~
geoadd locations 52.361389 19.115556 Vehicle1
geoadd locations 52.361389 19.115556 Vehicle2
geoadd locations 52.361389 19.115556 Vehicle3
geoadd locations 52.361389 19.115556 Vehicle4
~~~

Pobranie pozycji określonego klucza
~~~
geopos locations Vehicle2
~~~


Obliczenie dystansu pomiędzy dwoma pozycjami
~~~ 
geodist locations Vehicle1 Vehicle4 km
~~~


Wyszukanie pozycji w określonym promieniu
~~~
georadius locations 0 0 22000 km
~~~

### Czyszczenie 

Wyczyszczenie wszystkich kluczy ze wszystkich baz danych
~~~
flushall
~~~

Wyczyszczenie wszystkich kluczy z bieżącej bazy danych
~~~
flushdb
~~~


Wyczyszczenie wszystkich kluczy z określonej bazy danych
~~~
-n <database_number> flushdb
~~~






