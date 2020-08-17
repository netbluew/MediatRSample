using System;
using System.Collections;
using System.Collections.Generic;
using FirstMediatR.CQRS.Models;

namespace FirstMediatR.Infrastructure
{
    public interface ICarRepository
    {
        #region Command
        public int AddNewCar(string name, string company);
        #endregion

        #region Queries
        public Car GetCarByName(string name);
        public Car GetCarByIdx(int idx);

        public IEnumerable<Car> GetCarsByCompany(string company);
        public IEnumerable<Car> GetAllCars();
        public IEnumerable<string> GetAllCompanies();
        #endregion
    }
}
