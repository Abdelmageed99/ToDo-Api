# 📌 To-Do API Documentation  

## 🛠 **Setup Instructions**  
1. Clone the repository:  
   ```sh
   git clone https://github.com/your-username/todo-api.git
   cd todo-api
   ```

2. Install dependencies:  
   ```sh
   dotnet restore
   ```

3. Run the application:  
   ```sh
   dotnet run
   ```

4. The API will be available at:  
   ```sh
   http://localhost:5000
   ```

---

## 🚀 API Endpoints  

### 📝 **To-Do Endpoints**  

| Method | Endpoint             | Description                         |
|--------|----------------------|-------------------------------------|
| `GET`  | `/api/todo`          | Retrieve all to-do items           |
| `GET`  | `/api/todo/{id}`     | Retrieve a specific to-do item by ID |
| `POST` | `/api/todo`          | Create a new to-do item            |
| `PUT`  | `/api/todo/{id}`     | Update an existing to-do item      |
| `DELETE` | `/api/todo/{id}`   | Delete a to-do item                |

### 🔐 **Authentication Endpoints**  

| Method | Endpoint               | Description                |
|--------|------------------------|----------------------------|
| `POST` | `/api/auth/register`   | Register a new user        |
| `POST` | `/api/auth/login`      | User login (returns token) |

---

## 📌 **Request & Response Examples**  

### 🔹 **1. Get All To-Do Items**  
**Request:**  
```http
GET /api/todo
```
**Response:**
```json
[
  {
    "id": 1,
    "title": "Buy groceries",
    "description": "Milk, Bread, Eggs",
    "isCompleted": false
  },
  {
    "id": 2,
    "title": "Work on project",
    "description": "Finish API module",
    "isCompleted": true
  }
]
```

---

### 🔹 **2. Get To-Do Item by ID**  
**Request:**  
```http
GET /api/todo/1
```
**Response:**
```json
{
  "id": 1,
  "title": "Buy groceries",
  "description": "Milk, Bread, Eggs",
  "isCompleted": false
}
```

---

### 🔹 **3. Create a New To-Do Item**  
**Request:**  
```http
POST /api/todo
Content-Type: application/json
```
**Body:**
```json
{
  "title": "Read a book",
  "description": "Read a chapter from ASP.NET Core book",
  "isCompleted": false
}
```
**Response:**
```json
{
  "id": 3,
  "title": "Read a book",
  "description": "Read a chapter from ASP.NET Core book",
  "isCompleted": false
}
```

---

### 🔹 **4. Update a To-Do Item**  
**Request:**  
```http
PUT /api/todo/1
Content-Type: application/json
```
**Body:**
```json
{
  "title": "Buy groceries",
  "description": "Milk, Bread, Eggs, and Butter",
  "isCompleted": true
}
```
**Response:**
```json
{
  "id": 1,
  "title": "Buy groceries",
  "description": "Milk, Bread, Eggs, and Butter",
  "isCompleted": true
}
```

---

### 🔹 **5. Delete a To-Do Item**  
**Request:**  
```http
DELETE /api/todo/1
```
**Response:**  
```json
{
  "message": "To-Do item deleted successfully"
}
```

---

### 🔹 **6. User Registration**  
**Request:**  
```http
POST /api/auth/register
Content-Type: application/json
```
**Body:**
```json
{
  "username": "john_doe",
  "email": "johndoe@example.com",
  "password": "SecurePassword123!"
}
```
**Response:**
```json
{
  "message": "User registered successfully"
}
```

---

### 🔹 **7. User Login**  
**Request:**  
```http
POST /api/auth/login
Content-Type: application/json
```
**Body:**
```json
{
  "email": "johndoe@example.com",
  "password": "SecurePassword123!"
}
```
**Response:**
```json
{
  "token": "eyJhbGciOiJIUzI1..."
}
```

---

## 🔑 **Authentication & Authorization**  
- The `POST /api/auth/login` endpoint returns a **JWT token**.  
- Use this token in the `Authorization` header for protected requests:  
  ```
  Authorization: Bearer YOUR_ACCESS_TOKEN
  ```
