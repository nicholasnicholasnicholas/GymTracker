# GymTracker

GymTracker is an interactive website where fitness enthusiasts or first time gym goers are able to track and store their workout data.

## Description

 This website allows users to visit past workouts and see their progression from previous sessions. On top of that there are features that allow them to create a workout plan or follow a preset plan. Overall this website is to keep people engaged and strive to visualize their progess numerically and hopefully push them to continue on.

## Getting Started

* GymTracker helps users visualize their fitness progression by storing past workouts and displaying performance trends over time. Users can:

- Log and track workouts  
- View previous sessions and monitor progress  
- Create custom workout plans  
- Follow preset workout templates
- Share your location to see local gyms
- See fitness events


### Requirememts

* GymTracker is a wesbite that allows users to access from any device.
* .NET SDK (8 or later recommended)
* A computer or mobile device with a web browser
* Understanding of running terminal commands

### Executing program

* How to run the program: From project root directory run:

```
dotnet ef database update
dotnet watch
```

## Help & Troubleshooting

* Make sure all NuGet packages are restored:

```
dotnet restore
```

* Migration issues

```
dotnet ef migrations add InitialCreate
dotnet ef database update
```

## Features

* User authentication (login & registration)
* Workout logging
* Workout plan creation
* Preset workout templates
* Event & fitness dashboard
* Light/Dark Mode UI support

## Authors

* Jerico Avila 
* Nicholas Legaspi
* Jaime Castillo

