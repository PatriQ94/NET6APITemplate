# NET6APITemplate

## Auth


### Register

```js
POST {{host}}/auth/register
```

#### Register request

```json
{
	"firstName": "Patrik",
	"lastName": "Forever",
	"email": "Patrik.Forever@email.com",
	"password": "password123"
}
```

#### Register response

```json
200 OK
```


```json
{
	"id": "124e960e-690a-4468-8b81-3cbcbde6ab9d",
	"firstName": "Patrik",
	"lastName": "Forever",
	"email": "Patrik.Forever@email.com",
	"token": "eyJhb...hhQ"
}
```

### Login

```js
POST {{host}}/auth/login
```

#### Login request

```json
{
	"email": "Patrik.Forever@email.com",
	"password": "password123"
}
```

#### Login response

```json
200 OK
```


```json
{
	"id": "124e960e-690a-4468-8b81-3cbcbde6ab9d",
	"firstName": "Patrik",
	"lastName": "Forever",
	"email": "Patrik.Forever@email.com"
	"token": "eyJhb...hhQ"
}
```