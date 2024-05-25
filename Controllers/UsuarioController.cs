using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using pc3.Integration;
using pc3.Integration.dto;

namespace pc3.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly ILogger<UsuarioController> _logger;
        private readonly ListarUsuariosApiIntegration _listUsers;
        private readonly ListarUnUsuarioApiIntegration _unUser;

        public UsuarioController(ILogger<UsuarioController> logger,
        ListarUsuariosApiIntegration listUsers,
        ListarUnUsuarioApiIntegration unUser)
        {
            _logger = logger;
            _listUsers = listUsers;
            _unUser = unUser;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<Usuario> users = await _listUsers.GetAllUser();
            return View(users);
        }

        [HttpGet]
        public async Task<IActionResult> Perfil(int Id)
        {
            Usuario user = await _unUser.GetUser(Id);
            return View(user);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}