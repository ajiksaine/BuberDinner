# Buber Dinner API

- [Buber Dinner API](#buber-dinner-api)
  - [Auth](#auth)
    - [Register](#register)
      - [Register Request](#register-request)
      - [Register Response](#register-response)
    - [Login](#login)
      - [Login Request](#login-request)
      - [Login Response](#login-response)

## Auth

### Register

```js
POST {{host}}/auth/register
```

#### Register Request

```json
{
  "firstName": "Aji Kumba",
  "lastName": "Saine",
  "email": "asaine@test.com",
  "password": "Test@password"
}
```

#### Register Response

```json
{
  "Id": "d89c2d9a-eb3e-4075-95ff-b920b55aa104",
  "firstName": "Aji Kumba",
  "lastName": "Saine",
  "email": "asaine@test.com",
  "password": "Test@password",
  "token": "eyJhb..z9dqcnXoY"
}
```
