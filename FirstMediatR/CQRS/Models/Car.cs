using System;
namespace FirstMediatR.CQRS.Models
{
    public class Car
    {
        public int Idx { get; set; }
        public string Name { get; set; }
        public string Company { get; set; }

        public Car()
        {
        }
    }
}
