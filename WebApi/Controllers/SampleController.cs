﻿using Aplication.Interfaces;
using Aplication.Mappers;
using Domain.Entities;
using Site.Commons;

namespace Site.Controllers
{
    public class SampleController : CrudControllerBase<SampleEntity, SampleDto>
    {
        public SampleController(ISampleService service) : base(service)
        {
        }
    }
}
