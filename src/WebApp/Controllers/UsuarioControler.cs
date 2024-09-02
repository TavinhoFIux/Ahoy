using Application.UsuarioCommands.Commands;
using Application.UsuarioCommands.Query;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{

    public class UsuarioController : Controller
    {
        private readonly IMediator _mediator;

        public UsuarioController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            var query = new GetAllUsuariosQuery();
            var usuarios = await _mediator.Send(query);
            return View(usuarios);
        }

        public async Task<IActionResult> Details([FromBody] int id)
        {
            try
            {
                var query = new GetUsuarioByIdQuery(id);
                var usuario = await _mediator.Send(query);
                return View(usuario);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        public async Task<IActionResult> Create([FromBody]CreateUserCommand command)
        {

            await _mediator.Send(command);
            return View(command);
        }



        public async Task<IActionResult> Edit([FromBody] UpdateUserCommand command)
        {
       
            await _mediator.Send(command);
            return View(command);
        }

        public async Task<IActionResult> Delete([FromBody] int id)
        {
            var usuario = await _mediator.Send(new GetUsuarioByIdQuery(id));
            if (usuario == null)
            {
                return NotFound();
            }
            return View(usuario);
        }
    }
}
