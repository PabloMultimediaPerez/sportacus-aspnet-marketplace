using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SPORTACUS_FRONT.Assemblers;
using SPORTACUS_FRONT.Models;
using SportacusGen.ApplicationCore.CEN.Sportacus;
using SportacusGen.ApplicationCore.CP.Sportacus;
using SportacusGen.ApplicationCore.EN.Sportacus;
using SportacusGen.Infraestructure.CP;
using SportacusGen.Infraestructure.EN.Sportacus;
using SportacusGen.Infraestructure.Repository.Sportacus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebSportacus.Controllers;

namespace SPORTACUS_FRONT.Controllers
{
    public class UsuarioController : BasicController
    {
        private readonly UsuarioCEN _usuarioCEN;

        public UsuarioController()
        {
            _usuarioCEN = new UsuarioCEN(new UsuarioRepository());
        }

        // GET: Usuario/Login
        public IActionResult Login()
        {
            return View();
        }

        // POST: Usuario/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(LoginViewModel loginVM)
        {
            try
            {
                // 1. Validamos que el Email y Password no estén vacíos
                if (ModelState.IsValid)
                {
                    // 2. Llamamos al método Login del CEN
                    var token = _usuarioCEN.Login(loginVM.Email, loginVM.Password);

                    // 3. Comprobamos si devolvió null
                    if (token == null)
                    {
                        // Si es null, los datos son incorrectos -> Mostramos error
                        ModelState.AddModelError("", "Error al introducir los datos del email o password");
                        return View(loginVM);
                    }
                    else
                    {
                        // Si NO es null, el login fue correcto
                        // Cargamos el usuario para saber si es administrador
                        UsuarioEN usuarioEN = _usuarioCEN.ReadOID(loginVM.Email);

                        // Guardamos el email del usuario y si es admin en sesión
                        HttpContext.Session.SetString("usuarioEmail", loginVM.Email);
                        if (usuarioEN != null && usuarioEN.EsAdministrador)
                            HttpContext.Session.SetString("usuarioEsAdmin", "true");
                        else
                            HttpContext.Session.SetString("usuarioEsAdmin", "false");

                        // Redirigimos a la Home
                        return RedirectToAction("Index", "Home");
                    }
                }

                // Si el modelo no es válido (campos vacíos), devolvemos la vista con errores
                return View(loginVM);
            }
            catch (Exception ex)
            {
                // Si ocurre un error inesperado, lo mostramos
                ModelState.AddModelError("", "Error al iniciar sesión: " + ex.Message);
                return View(loginVM);
            }
        }

        // GET: Usuario/Logout
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }

        // GET: Usuario
        // Muestra los ajustes del usuario actualmente logado
        public IActionResult Index()
        {
            try
            {
                // Email del usuario logado guardado en sesión
                var emailUsuario = HttpContext.Session.GetString("usuarioEmail");
                if (string.IsNullOrEmpty(emailUsuario))
                {
                    // Si no hay sesión de usuario, redirigimos a Login
                    return RedirectToAction("Login", "Usuario");
                }

                SessionInitialize();

                UsuarioRepository usuarioRepo = new UsuarioRepository(session);
                UsuarioCEN usuarioCEN = new UsuarioCEN(usuarioRepo);

                UsuarioEN usuarioEN = usuarioCEN.ReadOID(emailUsuario);
                UsuarioViewModel usuarioVM = UsuarioAssembler.ConvertENToViewModel(usuarioEN);

                SessionClose();

                // La vista espera IEnumerable<UsuarioViewModel>, le pasamos una lista con el usuario actual
                var listVM = new List<UsuarioViewModel>();
                if (usuarioVM != null)
                    listVM.Add(usuarioVM);

                return View(listVM);
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Error al cargar los datos del usuario: " + ex.Message;
                return View(new List<UsuarioViewModel>());
            }
        }

        // GET: Usuario/Details/email
        public IActionResult Details(string id)
        {
            SessionInitialize();

            UsuarioRepository usuarioRepo = new UsuarioRepository(session);
            UsuarioCEN usuarioCEN = new UsuarioCEN(usuarioRepo);

            UsuarioEN usuarioEN = usuarioCEN.ReadOID(id);
            UsuarioViewModel usuarioVM = UsuarioAssembler.ConvertENToViewModel(usuarioEN);

            SessionClose();

            return View(usuarioVM);
        }

        // GET: Usuario/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Usuario/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(UsuarioViewModel usuarioVM)
        {
            try
            {
                if (usuarioVM == null)
                    throw new ArgumentNullException(nameof(usuarioVM));

                UsuarioRepository usuarioRepo = new UsuarioRepository();
                UsuarioCEN usuarioCEN = new UsuarioCEN(usuarioRepo);
                usuarioCEN.New_(usuarioVM.Email, usuarioVM.Nombre, usuarioVM.Telefono,
                    usuarioVM.Direccion, usuarioVM.FechaRegistro, usuarioVM.EsAdministrador, usuarioVM.Pass);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Error al crear el usuario: " + ex.Message;
                return View(usuarioVM);
            }
        }

        // GET: Usuario/Edit/email
        public IActionResult Edit(string id)
        {
            SessionInitialize();

            UsuarioRepository usuarioRepo = new UsuarioRepository(session);
            UsuarioCEN usuarioCEN = new UsuarioCEN(usuarioRepo);

            UsuarioEN usuarioEN = usuarioCEN.ReadOID(id);
            UsuarioViewModel usuarioVM = UsuarioAssembler.ConvertENToViewModel(usuarioEN);

            SessionClose();

            return View(usuarioVM);
        }

        // POST: Usuario/Edit/email
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(string id, UsuarioViewModel usuarioVM)
        {
            try
            {
                if (usuarioVM == null)
                    return BadRequest();

                if (id != usuarioVM.Email)
                {
                    // Mostrar por qué falla en vez de devolver NotFound sin contexto
                    ModelState.AddModelError("", $"Id de ruta ({id}) no coincide con Id del modelo ({usuarioVM.Email}).");
                    return View(usuarioVM);
                }

                UsuarioRepository usuarioRepo = new UsuarioRepository();
                UsuarioCEN usuarioCEN = new UsuarioCEN(usuarioRepo);
                usuarioCEN.Modify(usuarioVM.Email, usuarioVM.Nombre, usuarioVM.Telefono,
                    usuarioVM.Direccion, usuarioVM.FechaRegistro, usuarioVM.EsAdministrador, usuarioVM.Pass);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Error al editar el favorito: " + ex.Message;
                return View(usuarioVM);
            }
        }

        // GET: Usuario/Delete/email
        public IActionResult Delete(string id)
        {
            UsuarioRepository usuarioRepo = new UsuarioRepository();
            UsuarioCEN usuarioCEN = new UsuarioCEN(usuarioRepo);

            usuarioCEN.Destroy(id);

            return RedirectToAction(nameof(Index));
        }

        // POST: Usuario/Delete/email
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(string id)
        {
            try
            {
                _usuarioCEN.Destroy(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Error al eliminar el usuario: " + ex.Message;
                return RedirectToAction(nameof(Index));
            }
        }
    }
}