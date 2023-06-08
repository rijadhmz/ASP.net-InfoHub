## Info Hub for Volleyball Team - Web App Development

![Image Description](https://github.com/rijadhmz/ASP.net-InfoHub/blob/master/images/handball.png)

This GitHub repository contains an ASP.NET C# school project developed for the "Razvoj Web Aplikacija" (Web App Development) subject. The project aims to create an information hub for a volleyball team, providing a centralized platform for team members to access news and updates about the club.

To access the admin profile and explore the administrative features of this web project, you can use the following login credentials:

- Username: `ok7@gmail.com`
- Password: `admin`

Please note that these credentials are intended for testing and demonstration purposes only.
### Features

- **User Authentication**: The application begins with a login page to ensure secure access. Each user has a unique account with their credentials stored in the database.
- **Home Page and Post Creation**: Once authenticated, users are directed to a home page where they can create and view posts. The posts include essential information about training sessions, matches, and other relevant updates.
- **Admin Privileges**: Admin accounts have additional privileges, including creating new accounts for team members and deleting posts. This ensures efficient management of user accounts and content moderation.
- **Password Management**: All users, including admins and team members, have the ability to change their own passwords to enhance security and account customization.

### Database Structure

The application utilizes a database to store the necessary data. It consists of two custom objects: "Korisnik" and "Postovi."

- **Korisnik**: This object represents a user account and contains fields such as idKorisnik (user ID), ime (first name), prezime (last name), email, password, and priority. The "priority" field might indicate different access levels or roles assigned to users.
- **Postovi**: This object represents individual posts and includes fields such as idPost (post ID), text (post content), dateTime (timestamp), and korisnik (a lookup to the Korisnik object, representing the author of the post).

