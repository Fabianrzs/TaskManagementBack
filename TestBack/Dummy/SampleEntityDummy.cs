using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestBack.Dummy
{
    public static class SampleEntityDummy
    {
        public static List<SampleEntity> Samples()
        {
            return new List<SampleEntity>
            {
                new SampleEntity {  Name = "Entity 1", State = true },
                new SampleEntity {  Name = "Entity 2", State = true  },
                new SampleEntity {  Name = "Entity 3", State = true  }
            };
        }

        public static SampleEntity Sample()
        {
            return new SampleEntity { Name = "Entity 1", State = true };
        }
    }
}
