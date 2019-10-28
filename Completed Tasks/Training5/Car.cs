using System;
using System.Runtime.Serialization;

namespace Training5
{
    [Serializable]
    [DataContract]
    public class Car
    {
        [DataMember]
        public Int32 carld;

        [DataMember]
        public decimal price;

        [DataMember]
        public Int32 quantity;

        [DataMember]
        public decimal total;

        public override string ToString()
        {
            return $"car id = {carld}, price = {price}, quantity = {quantity}, total = {total}";
        }
    }
}