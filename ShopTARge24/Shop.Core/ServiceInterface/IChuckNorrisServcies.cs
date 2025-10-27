﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop.Core.Dto;

namespace Shop.Core.ServiceInterface
{
    public interface IChuckNorrisServcies
    {
        Task<ChuckJokeDto> FetchRandomJoke();
    }
}
