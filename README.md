

# Recipe Management System

Recipe Management System is a personalized recipe platform that allows users to store recipes, define dietary preferences, track interactions, and get personalized recommendations based on health goals.

## Sample Endpoint

### Get All Recipes

Fetch all recipes, optionally filtered by tag.

**Endpoint:**

```
GET http://localhost:5000/api/Recipe?tag={tag}
```

**Response (JSON):**

```json
[
  {
    "id": "recipe-guid",
    "title": "Grilled Chicken Salad",
    "calories": 350,
    "protein": 30,
    "fat": 15,
    "carbs": 20,
    "tags": "healthy,low-carb"
  }
]
```

---

## Database Design & Relationships

Core tables:

* **Users** – store user information, dietary preferences, and health goals.
* **Recipes** – store recipe details and essential nutritional information.
* **UserRecipeInteractions** – track actions such as Liked, Disliked, or Saved recipes.

**Relationships:**

* A **User** can interact with multiple **Recipes**.
* A **Recipe** can have interactions from multiple **Users**.
* `UserRecipeInteractions` acts as a many-to-many link table between `Users` and `Recipes`.

---

## Technical Details

* ASP.NET Core Web API - v8
* Entity Framework Core - v8 (Code-First)
* CQRS pattern with MediatR
* Repository Pattern
* FluentValidation for request validation
* SQL Server
* Mapster for entity mapping
* Swagger for API documentation
* Dependency Injection for services and repositories

---

## Get Started

1. Clone the repository:

```bash
git clone https://github.com/yourusername/recipe-management.git
```

2. Configure SQL Server in `appsettings.json`:

```json
"ConnectionStrings": {
  "DefaultConnectionString": "Server=localhost;Database=RecipeDb;Trusted_Connection=True;"
}
```

3. Run the application:

```bash
dotnet run
```

4. Access Swagger UI:

```
http://localhost:5000/swagger/index.html
```