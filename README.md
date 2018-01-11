# PoolLeague
A web application to track success and failure at the pool table for my colleagues and myself. Also a chance to use various testing technologies with .netcore.


# Architecture
There are two core projects - the LeagueFrontEnd and the League API.

The first is an MVC application built in .netcore 2. 

The second is the back-end to the MVC application, a .netcore 2 web API.

# API 
The API was built using Domain Driven Design patterns and principles. This includes the data repository, the domain and appliation layer and the services which expose these to the front-end application.

# Test projects
The remaining two projects consist of three layers of testing for the two core projects - unit, integration and acceptance.
These tests contain code examples for:
xunit
Moq
FluentAssertions
Specflow (and BDD)


