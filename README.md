# BrainHub-Web-App

## 🚀 Live Demo

Check the live application here:  
[https://brainhubwebapp.onrender.com/](https://brainhubwebapp.onrender.com/)

---

## 🌟 Overview

**BrainHub-Web-App** is a modern web application built with **.NET Core MVC** following the **Layer Architecture**.  
It demonstrates concepts including **custom authentication, authorization, Role-Based Access, database integration**, and **containerized deployment** using Docker.  

This project is hosted on **[Render.com](https://render.com/)** and currently uses an **in-memory database** for demonstration purposes.

---

## 🔑 Login Credentials

To explore the app, you can use the following accounts:

### Admin Access
- **Email:** admin@brainhub.com  
- **Password:** admin123  

### User Access
- **Email:** user@brainhub.com  
- **Password:** employee123  

> Admin users have full access, while normal users have limited permissions according to their role.

---

## 🐳 Docker

You can run this app as a Docker container:

- Docker Hub: [https://hub.docker.com/r/sagorahmedmunnabs23/brainhubwebapp](https://hub.docker.com/r/sagorahmedmunnabs23/brainhubwebapp)  
- Pull the image and run:

```bash
docker pull sagorahmedmunnabs23/brainhubwebapp
docker run -d -p 5000:80 sagorahmedmunnabs23/brainhubwebapp
