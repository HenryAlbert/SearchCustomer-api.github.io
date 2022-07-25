# SearchCustomer-api.github.io

# CustomerSearchApp WebAPI
     * Open project in VStudio.
     * Restore nuget packages and rebuild.
     * Run the project. 
     * Run the api on http://localhost:58123 as defined in the  front-end proxy

Please note: 
  1. Since this is sample project,  it does not include validation/authentication 
  2. ASP.NET webApi has been used to build simple a API instead of nodejs/express
  3. For testing purpose, ennble CORS  for communication
  4. For this sample project, build a simple UI defined based on requirement
  5. MVC pattern & DI are used in both solutions
  5. Front-end layout was designed for various display device


API endpoint(s):

1. `GET /Customer?polno={policy number}&custno={customer number}` - finds all customer matching the specified policy number and customer number.

Sample Data Model:
**Customer:**
{
  "id": "1",
  "firstName": "Winne",
  "lastName": "Janc",
  "memberCardNumber": "0473128446",
  "policyNumber": "1405677686",
  "dataOfBirth": "26/07/1995"
}



