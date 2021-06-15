# InstantJob - simple freelancing app

## Table of Contents  

[1. Introduction](#introduction)  
[2. Architecture](#architecture)   
[3. Technologies](#technologies)  
 

<a name="introduction"/>

## 1. Introduction

This application was created as part of an engineering thesis for university. Its main purpose was to research and gain experience in technologies, libraries and architecture commonly used to create web applications. Many concepts were adapted from popular github repositories and other sources.

<a name="architecture"/>

## 2. Architecture

#### 2.1 High level view

* Frontend - a simple web application written in React.JS
* API, Jobs module, Users module - ASP.NET Core app
* Job offers data, Users data - PostgreSQL databases
* Event Bus - in memory event bus (RabbitMQ or any other broker could be used instead)

![architecture-Page-2](https://user-images.githubusercontent.com/31590651/121947567-76dcde80-cd56-11eb-8dd7-6070fa2af909.png)

#### 2.2 Solution level view

Solution and project structure is mainly based on [Clean Architecture](https://github.com/jasontaylordev/CleanArchitecture) and [Modular Monolith with DDD](https://github.com/kgrzybek/modular-monolith-with-ddd).
Modules consist of multiple projects with the following responsibilites:
* Domain - the Domain model of a module
* Application - logic responsible for processing incoming requests: use cases, event handlers etc.
* Infrastructure - code for accessing external resources such as database access
* IntegrationEvents - contracts published to EventBus

The solution is divided into 4 parts:
* Building blocks - base domain concepts and other commonly used types
* Modules - Users and Jobs modules which contain domain related data and logic
* Persistence - entities mappings for NHibernate
* Web - responsible for authentication and passing request to other modules

![obraz](https://user-images.githubusercontent.com/31590651/121942969-61b18100-cd51-11eb-9bde-9826c458677c.png)

<a name="technologies"/>

## 3. Technologies
The following technologies, frameworks and libraries were used for this project:

* [.NET Core 3.1](https://github.com/dotnet/core)
* [NHibernate](https://github.com/nhibernate/nhibernate-core)
* [Fluent NHibernate](https://github.com/nhibernate/fluent-nhibernate)
* [PostgreSQL](https://www.postgresql.org/)
* [FluentValidation](https://github.com/FluentValidation/FluentValidation)
* [MediatR](https://github.com/jbogard/MediatR)
* [NUnit](https://github.com/nunit)
* [Scrutor](https://github.com/khellang/Scrutor)
* [Swagger](https://github.com/domaindrivendev/Swashbuckle.AspNetCore)
* [Newtonsoft.Json](https://github.com/JamesNK/Newtonsoft.Json)
* [AutoMapper](https://github.com/AutoMapper/AutoMapper)
* [React.Js](https://github.com/facebook/react)
