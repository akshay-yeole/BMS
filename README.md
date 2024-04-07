# EMS

# Library Management System

## Functionalities

### 1. Add a Book

This functionality allows users to add a new book to the library system. When adding a book, users typically input details such as the book title, author, publication year, ISBN, and category.

### 2. Add a Category

This feature enables administrators to add new categories to classify books. Categories can include genres like Fiction, Non-Fiction, Mystery, Science Fiction, etc. Proper categorization helps in organizing and searching for books efficiently.

### 3. Add a New Student

This functionality is used to add a new student to the library system. Information such as student name, ID, class, division, and contact details are usually collected during the student registration process.

### 4. Edit Student Details

Administrators can use this feature to edit or update student information. This includes modifying student names, contact details, class, or division changes, etc. It ensures that student records are accurate and up-to-date.

### 5. Get Details of All Books Belonging to a Specific Category

This functionality allows users to retrieve information about all books that belong to a particular category. Users can select a category (e.g., Fiction, History, Science) and view a list of books categorized under it, along with their details such as title, author, and availability status.

### 6. Get Details of Students from Specific Standard and Division

This feature enables users to fetch details of students based on specific criteria such as standard (grade) and division. For instance, users can input the standard (e.g., 9th grade) and division (e.g., A, B, C) to retrieve a list of students belonging to that specific class segment.

## Implementation Notes

- Use appropriate forms or input fields in the user interface for adding books, categories, and students.
- Implement validation checks to ensure data accuracy and prevent duplicate entries.
- Use database queries or API calls to fetch book and student details based on category, standard, and division criteria.
- Consider implementing authentication and authorization mechanisms to control access to these functionalities based on user roles (e.g., admin, librarian, student).
- Document API endpoints or function calls required for each functionality to assist developers in integrating these features into the system.

By following these guidelines, you can effectively implement and document the functionalities of a library management system.

## EntityFramework

### Creating a Migration

```shell
Add-Migration 'migration message' 
```
### Updating Database

```shell
Update-Database
```


