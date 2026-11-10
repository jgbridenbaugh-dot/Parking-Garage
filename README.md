## Language Used

- C#

## How to Run

### Prequisites

- [.NET SDK](https://dotnet.microsoft.com/download/dotnet/8.0) (version 8.0 or later)
- Visual Studio 2022 or later

### Run in Viusal Studio

1. Clone the repository:
   ```
   git clone <repository-url>
   ```
2. Open `Parking Garage.sln` in Visual Studio.
3. Press F5 to run with debugging, or Ctrl+F5 to run without it.

## Project Structure

- **Classes:** This program uses three classes, a `ParkingGarage` class, a `Vehicle` class, and a 
  `Program` class for calling methods and creatings instances.

- **Enums:** The `ParkingGarage` class uses an enum to define three sizes of parking spaces: small, medium, and large. 
  The `Vehicle` class uses an enum to difine the three types of vehicles that can be created: bike, car, truck.

- **Methods:** The `ParkingGarage` and `Vehicle` classes both use a Constructor method so they can be initialized with their fields.
  Additionally The `Vehicle` class has the Methods; `Park`, `Unpark`, and `Status` along with two helper methods; 
- `GetRequiredSize`, and `GetSpaceSize`. 

## Design Choices

- **Car Parking:** To park a car in a parking space, it's type must match the space size. I chose this behavoir because 
it wouldn't make sense to allow vehicles into spaces that are either too large or too small.

- **String Return Type:** The `Park`, `Unpark`, and `Status` methods all use a string return type so what they return can be more descriptive 
  than true or false.

- **Parking Garage Fields:** The instance fields for the `ParkingGarage` class are initialized in `Program.Main` 
  so that the field values can be edited in one place.

- **Parking Space Numbers:** Parking spaces are numbered starting at 101 so the first digit can represent the floor number. 
  Since there are only 75 parking spaces per floor the space number jumps from 175 to 201 to represent the second floor.

## Things That I Could Extend

- **Status Method:** I could add to the ammount of information that the Status method returns
  so that it returns more than whether a vehicle is parked or not. For example I could return the money owed for a car.
