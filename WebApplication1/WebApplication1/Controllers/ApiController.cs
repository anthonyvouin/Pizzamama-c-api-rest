﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data;
using WebApplication1.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ApiController : Controller
    {
        DataContext dataContext;
        public ApiController(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        [HttpGet]
        [Route("GetPizzas")]

        public IActionResult GetPizzas()
        {
            // var pizza = new Pizza() { nom="pizza test", prix=8, vegetarienne=false, ingredients="tomate, oigons, oeu" };

            var pizzas = dataContext.Pizzas.ToList();
         
           return Json(pizzas);
        }

    }
}
