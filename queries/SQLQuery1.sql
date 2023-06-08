select top 10 text, dateTime, ime + ' ' + prezime as autor from Postovi inner join Korisnik on Postovi.korisnik = Korisnik.idKorisnik
