# Autonomous Car Simulation

## Overview

This C# program simulates autonomous car movements on a rectangular field. Users can define the field size, add multiple cars with unique names, starting positions, and directions, and execute movement commands (`L` for left, `R` for right, `F` for forward). The program detects collisions and prints the final positions and directions of the cars.

## Usage

1. **Run the Program:** Open the project in a .NET IDE and run it.
2. **Define the Field:** Enter the width and height of the simulation field when prompted.
3. **Add Cars:** Choose option `[1]` to add a car by providing its name, initial position (x, y, direction), and movement commands.
4. **Run Simulation:** Choose option `[2]` to execute commands for all cars. The program will detect collisions and display the final positions and directions.
5. **Exit:** Choose option `[3]` to exit the program.

## Example

```plaintext
Welcome to Auto Driving Car Simulation!
Please enter the width and height of the simulation field in x y format: 10 10
Please choose from the following options:
[1] Add a car to field
[2] Run simulation
[3] Exit
Please enter the name of the car: A
Please enter the initial position of the car in x y direction format: 1 2 N
Please enter the commands for the car: FFRFFFRRLF
```