# LaboratorAPI
V2023

Swagger Endpoint: "http://localhost:5000/api/swagger"

Autorizarea nu functioneaza. Am incercat sa fac pe cat posibil cum era prezentat in laboratorul 8 de auth.
Primesc un JWT token cand ma inregistrez, dar cand trimit requestul cu POSTMAN (si cu header ul de auth atasat cum ati spus)
continui sa primesc NotAuth pe endpointurile securizate.

Am rezolvat cerintele temei chiar daca aceasta parte nu functioneaza complet.

Am creat o entitate User care inlocuieste pe cea Student. Cea Student va mosteni prorpietatile lui User si 
va adauga in plus doar notele obtinute de student.

AuthService si restul configurarii de authentificare sunt asa ca in laboratorul 8, in UserController am adaugat endpointuri
pentru a lua datele pentru toti studentii cat si pentru un singur student prin id (tot de catre profesor).

In StudentService am facut endpointul care retrage toate notele pentru un singur student (cel care face requestul, cu ajutorul idClaim).
