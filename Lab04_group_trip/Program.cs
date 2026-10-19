﻿/*
* Name: Zack Racz
* Course: CSCI 1250, Section 001
* Assignment: Lab 04, The Group Trip
* Date: October 18, 2026
* Description: Rebuilds the trip calculator with methods and arrays so it
* reports on a whole group instead of one person.
*/

//Part 1
System.Console.WriteLine("How many miles for your trip?");
double tripMiles = Convert.ToDouble(Console.ReadLine());

System.Console.WriteLine("How many miles per gallon can your car go??");
double milesPerGallon = Convert.ToDouble(Console.ReadLine());

System.Console.WriteLine("How much did you pay for gas?");
double pricePerGallon = Convert.ToDouble(Console.ReadLine());

double fuelCost = FuelCost(tripMiles, milesPerGallon, pricePerGallon);

string[] names = { "Ada", "Grace", "Alan", "Katherine" };
double[] hoursWorked = { 22, 15, 30, 18 };
double[] hourlyRates = { 13.50, 16.00, 11.20, 14.80 };

const double Number_of_slices = 8;

Console.WriteLine("How many pizzas did you order?");
double pizzaNumber = Convert.ToDouble(Console.ReadLine());

Console.WriteLine("How much did you pay per pizza?");
double pizzaCost = Convert.ToDouble(Console.ReadLine());

double totalPizzaCost = pizzaNumber * pizzaCost;
double tripTotal = totalPizzaCost + fuelCost;

Console.WriteLine("=== Part 1: The Trip ===");
Console.WriteLine("Fuel Cost: " + fuelCost.ToString("C"));
Console.WriteLine("Pizza Cost: " +  totalPizzaCost.ToString("C"));
Console.WriteLine("Trip Total: " + tripTotal.ToString("C"));

//Part 2
double costPerPerson = tripTotal / names.Length;
double totalSlices = pizzaNumber * Number_of_slices;
double slicesNeeded = totalSlices / names.Length;

Console.WriteLine("=== Part 2: The Group ===");
Console.WriteLine("People going: " + names.Length);
Console.WriteLine("Slices Each: " + slicesNeeded);
Console.WriteLine("Cost per person: " + costPerPerson.ToString("C"));

//Part 3 
const double Tax_Rate = 0.18;

Console.WriteLine("=== Part 3: Who Works How Long ===");

double totalHours = 0;
double totalTakeHomePay = 0;
double longestHoursWorked = 0;

for(int i = 0; i < names.Length; i++)
{
    double takeHomePay = TakeHomePay(hoursWorked[i], hourlyRates[i], Tax_Rate);
    double takeHomePayPerHour = takeHomePay / hoursWorked[i];
    totalTakeHomePay = totalTakeHomePay + takeHomePay;
    totalHours = totalHours + hoursWorked[i];
    longestHoursWorked = Math.Max(longestHoursWorked, hoursWorked[i]);
    Console.WriteLine(names[i] + ": takes home " + takeHomePay.ToString("C") + " for " + hoursWorked[i] + " hours, " + takeHomePayPerHour.ToString("C") + " per hour, must work " + HoursToCover(costPerPerson, takeHomePayPerHour).ToString("F2") + " hours");
}
Console.WriteLine("Total hours worked: " + totalHours);
Console.WriteLine("Total take home pay: " + totalTakeHomePay.ToString("C"));
Console.WriteLine("Longest anyone must work: " + longestHoursWorked);

static double FuelCost(double miles, double milesPerGallon, double pricePerGallon)
{
    double gallons = miles / milesPerGallon;
    return gallons * pricePerGallon;
}

static double TakeHomePay(double hours, double hourlyRate, double taxRate)
{
    double grossPay = hours * hourlyRate;
    double taxAmount = grossPay * taxRate;
    return grossPay - taxAmount;
}

static double HoursToCover(double amountOwed, double takeHomePerHour)
{
    double HoursToCover = amountOwed / takeHomePerHour;
    return HoursToCover;
}
