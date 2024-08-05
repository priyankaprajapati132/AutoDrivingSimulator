using System;
using System.Collections.Generic;

public enum carDirection
{
    N, E, S, W
}

public class Car
{
    public string Name { get; private set; }
    public int X { get; private set; }
    public int Y { get; private set; }
    public carDirection carDirection { get; private set; }
    private string commands;
    private int currentCommandIndex;

    public Car(string name, int x, int y, carDirection direction, string commands)
    {
        Name = name;
        X = x;
        Y = y;
        carDirection = direction;
        this.commands = commands;
        currentCommandIndex = 0;
    }

    public void TurnLeft()
    {
        Direction = (Direction)(((int)Direction + 3) % 4);
    }

    public void TurnRight()
    {
        Direction = (Direction)(((int)Direction + 1) % 4);
    }

    public void MoveForward(int width, int height)
    {
        switch (Direction)
        {
            case Direction.N:
                if (Y < height - 1) Y++;
                break;
            case Direction.E:
                if (X < width - 1) X++;
                break;
            case Direction.S:
                if (Y > 0) Y--;
                break;
            case Direction.W:
                if (X > 0) X--;
                break;
        }
    }

    public void ExecuteNextCommand(int width, int height)
    {
        if (currentCommandIndex >= commands.Length) return;

        char command = commands[currentCommandIndex++];
        switch (command)
        {
            case 'L':
                TurnLeft();
                break;
            case 'R':
                TurnRight();
                break;
            case 'F':
                MoveForward(width, height);
                break;
        }
    }

    public bool HasCommandsLeft()
    {
        return currentCommandIndex < commands.Length;
    }
}

public class Field
{
    private int width;
    private int height;
    private List<Car> cars;

    public Field(int width, int height)
    {
        this.width = width;
        this.height = height;
        cars = new List<Car>();
    }

    public void AddCars(string name, int x, int y, Direction direction, string commands)
    {
        cars.Add(new Car(name, x, y, direction, commands));
    }

    public void RunSimulation()
    {
        bool commandsLeft;
        do
        {
            commandsLeft = false;
            foreach (var car in cars)
            {
                if (car.HasCommandsLeft())
                {
                    car.ExecuteNextCommand(width, height);
                    commandsLeft = true;
                }
            }

        } while (commandsLeft);

        foreach (var car in cars)
        {
            Console.WriteLine($"{car.Name} is at ({car.X}, {car.Y}) facing {car.Direction}");
        }
    }
}

public class Program
{
    public static void Main()
    {
        Console.WriteLine("Welcome to Auto Driving Car Simulation!");
        Console.Write("Please enter the width and height of the simulation field in x y format: ");
        var dimensions = Console.ReadLine().Split();
        int width = int.Parse(dimensions[0]);
        int height = int.Parse(dimensions[1]);

        Field field = new Field(width, height);
        Console.WriteLine($"You have created a field of {width} x {height}.");

        bool running = true;
        while (running)
        {
            Console.WriteLine("Please choose from the following options:");
            Console.WriteLine("[1] Add a car to field");
            Console.WriteLine("[2] Run simulation");
            Console.WriteLine("[3] Exit");
            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Please enter the name of the car: ");
                    string name = Console.ReadLine();
                    Console.Write("Please enter the initial position of the car in x y direction format (e.g., 1 2 N): ");
                    var carDetails = Console.ReadLine().Split();
                    int x = int.Parse(carDetails[0]);
                    int y = int.Parse(carDetails[1]);
                    Direction direction = Enum.Parse<Direction>(carDetails[2].ToUpper());
                    Console.Write("Please enter the commands for the car: ");
                    string commands = Console.ReadLine();

                    field.AddCars(name, x, y, direction, commands);
                    break;

                case "2":
                    field.RunSimulation();
                    break;

                case "3":
                    running = false;
                    break;
            }
        }

        Console.WriteLine("Thank you for running the simulation. Goodbye!");
    }
}
