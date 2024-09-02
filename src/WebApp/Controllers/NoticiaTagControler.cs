using Application.NoticiaTagCommands.Commands;
using Application.NoticiaTagCommands.Query;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class NoticiaTagController : Controller
    {
        private readonly IMediator _mediator;

        public NoticiaTagController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            var query = new GetAllNoticiaTagsQuery();
            var noticiaTags = await _mediator.Send(query);
            return View(noticiaTags);
        }

        public async Task<IActionResult> Details(int id)
        {
            try
            {
                var query = new GetNoticiaTagByIdQuery(id);
                var noticiaTag = await _mediator.Send(query);
                return View(noticiaTag);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateNoticiaTagCommand command)
        {
            if (ModelState.IsValid)
            {
                var noticiaTagId = await _mediator.Send(command);
                return RedirectToAction(nameof(Index));
            }
            return View(command);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, UpdateNoticiaTagCommand command)
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

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _mediator.Send(new DeleteNoticiaTagCommand { Id = id });
            return RedirectToAction(nameof(Index));
        }
    }
}
