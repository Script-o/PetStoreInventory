using System;
using Templates;

public class DogLeash : Product
{
    public int LengthInches = 60;
    public string Material = "Nylon";
    public void Class1()
    {
        Product p1 = new Product() { Name = "Dog Leash", Price = 4.5M, Quantity = 5, Description = "Doggo leashes." };
    }
}
