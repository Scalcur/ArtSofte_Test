using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ArtSofte_Test.DataBase;
using ArtSofte_Test.Interfaces;

namespace ArtSofte_Test.Controllers
{
    public class InMemoryDbСontroller : Controller
    {
        private InMemoryDbСontext _DBContext { get; set; } 
    

    public InMemoryDbСontroller(InMemoryDbСontext DBСontext)
    {
        _DBContext = DBСontext;
    }

    

    }
}