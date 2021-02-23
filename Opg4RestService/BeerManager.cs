using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using BeerClassLibrary;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace Opg4RestService
{
    public class BeerManager
    {
        private static int _nextId = 1;
        private static List<Beer> Data = new List<Beer>()
        {
            new Beer(_nextId++,"Carlsberg",12.5,4.5),
            new Beer(_nextId++,"Tuborg",14,4.5),
            new Beer(_nextId++,"Corona",11.5, 4.6),
            new Beer(_nextId++,"Guinness", 16, 4.2)
        };

        public List<Beer> GetAll()
        {
            return Data;
        }

        public Beer GetId(int id)
        {
            return Data.Find(beer => beer.Id == id);
        }

        public Beer PostBeer(Beer value)
        {
            value.Id = _nextId++;
            Data.Add(value);
            return value;
        }

        public Beer Delete(int id)
        {
            Beer beer = Data.Find(beer1 => beer1.Id == id);
            if (beer == null) return null;
            Data.Remove(beer);
            return beer;
        }

        public Beer Update(int id, Beer value)
        {
            Beer beer = Data.Find(beer1 => beer1.Id == id);
            if (beer == null) return null;
            beer.Navn = value.Navn;
            beer.Pris = value.Pris;
            beer.Abv = value.Abv;
            return beer;
        }
    }
}
