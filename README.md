# advertisementAPI

This API provides endpoints for performing CRUD operations on Adverts.
Prerequisites

    .NET Core 3.1 or later.
    An IDE such as Visual Studio or VSCode.
    A database management system such as SQL Server.

Authentication

Endpoints are only available to User rola for GET and Admin role for all. 
To access these endpoints, you need to include an Authorization header in your request with a valid JWT token.

Endpoints
Retrieve all Adverts

GET /Advert

Retrieves a list of all Adverts in the database.

Response

    200 OK on success, along with a list of Adverts.

Retrieve a single Advert

GET /Advert/{id}

Retrieves a single Advert by its id field.

Response

    200 OK on success, along with the Advert data.
    400 Bad Request if the Advert is not found.

Add an Advert

POST /Advert

Adds a new Advert to the database.

Response

    200 OK on success, along with the updated list of Adverts.

Update an Advert

PUT /Advert

Updates an existing Advert in the database.

Response

    200 OK on success, along with the updated list of Adverts.
    400 Bad Request if the Advert is not found.

Update part of an Advert

PATCH /Advert/{id}

Updates part of an existing Advert in the database.

Response

    200 OK on success, along with the updated list of Adverts.
    400 Bad Request if the Advert is not found.

Delete an Advert

DELETE /Advert/{id}

Deletes an existing Advert from the database.

Response

    200 OK on success, along with the updated list of Adverts.
    400 Bad Request if the Advert is not found.
