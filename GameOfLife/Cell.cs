using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace GameOfLife
{
    [Serializable()]
    public struct Cell : ISerializable
    {
        public Cell(Status newStatus, uint newNeighbors)
        {
            status = newStatus;
            neighbors = newNeighbors;
        }
        public enum Status { Empty = 0, Alive, Dead }

        public static uint MinNeighbors = 2;
        public static uint MaxNeighbors = 3;

        public Status status;
        public uint   neighbors;

        public Cell(SerializationInfo info, StreamingContext ctxt)
        {
            status = (Status)info.GetValue("CellStatus", typeof(Status));
            neighbors = (uint)info.GetValue("Neighbors", typeof(uint));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
            info.AddValue("CellStatus", status);
            info.AddValue("Neighbors", neighbors);
        }
    }

}
