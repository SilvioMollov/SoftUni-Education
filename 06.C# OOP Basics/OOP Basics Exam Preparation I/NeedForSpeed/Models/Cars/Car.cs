﻿using System.Text;

public abstract class Car
{
    protected Car(string brand, string model, int yearOfProduction, int horsepower, int acceleration, int suspension,
        int durability)
    {
        this.Brand = brand;
        this.Model = model;
        this.YearOfProduction = yearOfProduction;
        this.HorsePower = horsepower;
        this.Acceleration = acceleration;
        this.Suspension = suspension;
        this.Durability = durability;
    }

    private string brand;
    private string model;
    private int yearOfProduction;
    private int horsepower;
    private int acceleration;
    private int suspension;
    private int durability;

    public string Brand
    {
        get { return this.brand; }
        protected set { this.brand = value; }
    }

    public string Model
    {
        get { return this.model; }
        protected set { this.model = value; }
    }

    public int YearOfProduction
    {
        get { return this.yearOfProduction; }
        protected set { this.yearOfProduction = value; }
    }

    public int HorsePower
    {
        get { return this.horsepower; }
        protected set { this.horsepower = value; }
    }

    public int Acceleration
    {
        get { return this.acceleration; }
        protected set { this.acceleration = value; }
    }

    public int Suspension
    {
        get { return this.suspension; }
        protected set { this.suspension = value; }
    }

    public int Durability
    {
        get { return this.durability; }
        protected set { this.durability = value; }
    }

    public virtual void Tune(int tuneIndex, string tuneAddOn)
    {
        this.HorsePower += tuneIndex;
        this.Suspension += tuneIndex / 2;
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine($"{this.Brand} {this.Model} {this.YearOfProduction}");
        sb.AppendLine($"{this.HorsePower} HP, 100 m/h in {this.Acceleration} s");
        sb.AppendLine($"{this.Suspension} Suspension force, {this.Durability} Durability");
        return sb.ToString();
    }
}

