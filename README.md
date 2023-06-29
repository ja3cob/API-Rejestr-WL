# API-Rejestr-WL
A web application to retrieve data about companies from government API using NIP number.
I decided to use SQLite so the app is portable and doesn't require any environment preparation.
If the data is not present in the DB, it is first fetched from the API and saved. Next time the same data shall be requested, it is retrieved from the SQLite database.
