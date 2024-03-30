**Blazor Server Note-Taking App**

**Overview**

This Blazor Server application serves as a convenient platform for creating, managing, and storing notes. 
Designed with user experience in mind, it facilitates easy interaction for users to add, edit, view, and delete notes.

**Features**

Create Notes: Users can easily add new notes with a title and content.
View Notes: Provides an intuitive interface to browse through all the notes.
Edit Notes: Allows for the updating of note details.
Delete Notes: Enables users to remove notes they no longer need.
Search: Facilitates the quick finding of notes by searching for keywords in the title or content.

**Getting Started**

These instructions will guide you in setting up the project on your local machine for development and testing purposes.

**Prerequisites**

Ensure the following are installed on your system:
- .NET 6.0 SDK
- Visual Studio 2022 or newer with the ASP.NET and web development workload
- PostgreSQL

**Installation**

Clone the repository:
git clone https://github.com/Rogrigo/QuantumPMTestTask.git

Navigate to the project directory:
cd your-directory

**Database Setup**

For those preferring manual setup or needing to create the necessary table for the application, execute the following SQL command in PostgreSQL to set up the Notes table:
CREATE TABLE Notes (
    Id SERIAL PRIMARY KEY,
    NoteTitle TEXT NOT NULL,
    NoteText TEXT NOT NULL,
    CreatedDate DATE DEFAULT CURRENT_DATE,
    UpdatedDate DATE DEFAULT CURRENT_DATE
);

After creating the table, ensure your application's appsettings.json file is updated with your PostgreSQL credentials in the connection string:
"ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Port=5432;Database=YourDatabaseName;Username=YourUsername;Password=YourPassword"
}
