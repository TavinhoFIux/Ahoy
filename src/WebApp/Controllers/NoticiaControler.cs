using Application.NoticiaCommands.Commands;
using Application.NoticiaCommands.Query;
using Application.TagCommands.Query;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp.Controllers
{
    public class NoticiaController : Controller
    {
        private readonly IMediator _mediator;

        public NoticiaController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            var query = new GetAllNoticiasQuery();
            var noticias = await _mediator.Send(query);
            return View(noticias);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateNoticiaCommand command)
        {
            if (ModelState.IsValid)
            {
                var noticiaId = await _mediator.Send(command);
                return RedirectToAction(nameof(Index));
            }
            return View(command);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, UpdateNoticiaCommand command)
        {
            if (id != command.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _mediator.Send(command);
                return RedirectToAction(nameof(Index));
            }
            return View(command);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var noticia = await _mediator.Send(new GetNoticiaByIdQuery(id));
            if (noticia == null)
            {
                return NotFound();
            }
            return View(noticia);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _mediator.Send(new DeleteNoticiaCommand { Id = id });
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.Tags = new SelectList(await _mediator.Send(new GetAllTagsQuery()), "Id", "Descricao");
            return View();
        }

        public async Task<IActionResult> Edit(int id)
        {
            var noticia = await _mediator.Send(new GetNoticiaByIdQuery(id));
            if (noticia == null)
            {
                return NotFound();
            }
            ViewBag.Tags = new SelectList(await _mediator.Send(new GetAllTagsQuery()), "Id", "Descricao", noticia.NoticiaTags.Select(nt => nt.TagId));
            return View(new UpdateNoticiaCommand
            {
                Id = noticia.Id,
                Titulo = noticia.Titulo,
                Texto = noticia.Texto,
                TagIds = noticia.NoticiaTags.Select(nt => nt.TagId).ToList()
            });
        }

        public async Task<IActionResult> Details(int id)
        {
            try
            {
                var query = new GetNoticiaByIdQuery(id);
                var result = await _mediator.Send(query);
                if (result == null)
                {
                    return NotFound();
                }
                return View(result);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
