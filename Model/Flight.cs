using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Flight:BaseEntity
    {
        private Airports originId;
        private Airports destenationId;
        private DateTime departureTime;
        private DateTime arrivalTime;
        private Planes planeId;
        private bool isCanceled;
        private int priceInDolar;

        public Airports OriginId { get => originId; set => originId = value; }
        public Airports DestenationId { get => destenationId; set => destenationId = value; }
        public DateTime DepartureTime { get => departureTime; set => departureTime = value; }
        public DateTime ArrivalTime { get => arrivalTime; set => arrivalTime = value; }
        public Planes PlaneId { get => planeId; set => planeId = value; }
        public bool IsCanceled { get => isCanceled; set => isCanceled = value; }
        public int PriceInDolar { get => priceInDolar; set => priceInDolar = value; }
    }
}
