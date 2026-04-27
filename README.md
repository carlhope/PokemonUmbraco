# 🧩 Pokémon Umbraco Project

A small experimental Umbraco CMS project exploring hybrid routing, API‑driven content, and light Blazor integration.  
This project was used as a learning sandbox, but it demonstrates several real Umbraco concepts and ecosystem tools.

---

## 🎯 Overview

This project mixes **Umbraco CMS** with **Blazor components**, allowing both systems to handle different parts of the site:

- **Umbraco routes** power content‑driven pages (e.g., the Pokémon list)
- **Blazor routes** power dynamic Pokémon detail pages
- Both approaches coexist cleanly within the same application

The project also integrates with an external Pokémon API to fetch and render data.

---

## 🧪 Key Features

- **Hybrid routing (Umbraco + Blazor)**  
  - Umbraco handles the Pokémon list page  
  - Blazor generates dynamic routes for individual Pokémon  

- **External API integration**  
  Fetches Pokémon data and renders:
  - A list view (Umbraco node)
  - Dynamic detail pages (Blazor)

- **Custom contact form theme**  
  Uses **Umbraco Forms** with a lightly customised theme for styling.

- **Umbraco ecosystem integrations**  
  - **uSync** — configuration and schema stored in source control  
  - **ModelsBuilder** — strongly‑typed content models  
  - **Umbraco Forms** — form handling  
  - **SEO Toolkit** — metadata and search optimisation  

---

## 🧱 Purpose

This project was created as a **technical exploration**, focusing on:

- Mixing Umbraco and Blazor in a single application  
- Understanding custom routing and dynamic content  
- Experimenting with API‑driven content inside a CMS  
- Trying out Umbraco Forms theming  
- Learning how Umbraco behaves in more dynamic scenarios  

It is not intended as a production site, but it demonstrates a range of CMS and .NET techniques.

---

## 🚀 Running the Project

This is a standard Umbraco project.  
Restore dependencies and run via your IDE or:

```bash
dotnet run
```

### 🔄 Restoring Umbraco Configuration with uSync

This project uses **uSync** to store all Umbraco settings, document types, data types, and content structure in version control.

**Initial setup flow:**

1. Run the project  
2. Complete the Umbraco setup wizard  
   - Configure your database connection  
   - Let Umbraco initialise the site  
3. Once the site starts for the first time, use uSync to import  
   - Document types  
   - Data types  
   - Content structure  
   - Settings  
   - Forms configuration  

After this first‑run import, your local environment will match the repository’s configuration.

---

## 📦 Tech Used

- Umbraco CMS  
- Blazor (Server components for dynamic routes)  
- uSync  
- ModelsBuilder  
- Umbraco Forms  
- SEO Toolkit  
- External Pokémon API  

---

## 📌 Notes

This project remains intentionally small and experimental, but it demonstrates:

- CMS development  
- API integration  
- Hybrid routing  
- Light theming  
- Real Umbraco tooling  

It serves as a compact example of CMS‑driven development with a modern .NET twist.
