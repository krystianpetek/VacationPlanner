# VacationPlanner
Application for planning employee vacation in my company.
As the name suggests, I have created an application in which the employer (administrator) can create a company account, in which he defines the company name and his login details, he can add employees to his company, other side is the employee who can add a day off request.

 ## About application
- VacationPlanner application is written in .NET 6 in WPF following the MVVM pattern, with bindings instead of events, where the view is in a separate layer in the application. 
- Views are written in XAML that bind data to a ViewModel (an independent application layer). ViewModel already communicates with models, commands, stores and services. The view does not communicate directly from code behind
- In the application, I created custom controls, components, value converters, etc.
- The application connects to an external API, instead of directly to the database, as it is a day off management application so a local database would not make sense.

## Functionalities
Administrator functions: 
- company account registration
- logging in to the account
- logging out of the account
- viewing account information
- adding an employee to your company
- displaying all employees of your company and details related to their days off
- display of all vacation requests
- accepting leave request or rejecting

Employee functions:
- logging in to the account
- logging out of the account
- viewing account information
- add a day off request for approval
- view a list of day off requests with status

## To run applications in Visual Studio, you need to:
- Installed .NET 6 or later
- In Console Package Manager select `Default Project` as `VacationPlannerAPI`
- In Package Manager Console type `update-database` for apply Migration to Database
- RMB on Solution -> Properties -> Project -> Multiple startup projects 
- `VacationPlannerAPI` -> Start 
- `VacationPlannerWPFApp` -> Start
- Run - `F5`

## API
In the application has been implemented `API` with the `API Key` authorization

Branches API `https://localhost:7020/`:
- Company - `api/Company/`
- Employee - `api/Employee/`
- RequestDayOff - `api/RequestDayOff/`
- User - `api/User/`

### Usage example for using company:

|Path         | Action  |Descritpion| 
|-------------|:-------:|-------|
|api/Company/  | GET     |Returns a list of all companies registered in the application|
|api/Company/{id} | GET     |Returns a specific company with a specific id|
|api/Company/ByAdmin/{id}  | GET    |Returns a specific company based on the admin id|
|api/Company/ | POST     |Adds a company with the specified name along with an administrator account|
