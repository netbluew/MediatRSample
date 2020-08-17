using System;
using System.Collections.Generic;
using FirstMediatR.CQRS.Models;
using System.Linq;

namespace FirstMediatR.Infrastructure
{
    public class CarRepository : ICarRepository
    {
        private readonly List<Car> cars;

        public CarRepository()
        {
            this.cars = new List<Car>();
            this.AddNewCar("Granduer", "Hyundai");
            this.AddNewCar("Avante", "Hyundai");
        }

        #region Commands
        public int AddNewCar(string name, string company)
        {
            int idx = this.cars.Count > 0 ? this.cars.Last().Idx + 1 : 1;
            this.cars.Add(new Car()
            {
                Idx = idx,
                Name = name,
                Company = company
            });
            return idx;
        }
        #endregion


        #region Queries
        public Car GetCarByIdx(int idx)
        {
            return this.cars.Where(x => x.Idx == idx).FirstOrDefault();
        }

        public Car GetCarByName(string name)
        {
            return this.cars.Where(x => x.Name.Equals(name, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
        }

        public IEnumerable<Car> GetAllCars()
        {
            return this.cars.Where<Car>(x => { return true; });
        }

        public IEnumerable<string> GetAllCompanies()
        {
            return this.cars.Select(x => x.Company);
        }

        public IEnumerable<Car> GetCarsByCompany(string company)
        {
            return this.cars.Where(x => x.Company.Equals(company, StringComparison.OrdinalIgnoreCase));
        }
        #endregion
    }
}