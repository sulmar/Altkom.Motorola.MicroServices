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

Dodanie wartości na określony czas (TTL)
~~~
set vehicle1 ready ex 120
~~~

Pobranie czasu, który pozostał do wygaśnienia klucza
~~~
ttl vehicle1
~~~

Pobranie wszystkich kluczy wg szablonu
~~~
keys *
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






