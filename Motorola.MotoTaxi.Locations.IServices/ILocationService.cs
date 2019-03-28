using Motorola.MotoTaxi.Locations.DomainModels;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Motorola.MotoTaxi.Locations.IServices
{
    public interface ILocationService
    {
        void Add(VehicleLocation location);
        IEnumerable<LocationResult> Get(Location location, double radius = 5, int quantity = 10);
    }
}
