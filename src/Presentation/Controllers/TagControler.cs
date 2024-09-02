using Application.TagCommands.Commands;
using Application.TagCommands.Query;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{

    public class TagController : Controller
    {
        private readonly IMediator _mediator;

        public TagController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            var query = new GetAllTagsQuery();
            var tags = await _mediator.Send(query);
            return View(tags);
        }

        public async Task<IActionResult> Details(int id)
        {
            try
            {
                var query = new GetTagByIdQuery(id);
                var tag = await _mediator.Send(query);
                return View(tag);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateTagCommand command)
        {
            var tagId = await _mediator.Send(command);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var tag = await _mediator.Send(new GetTagByIdQuery(id));
            if (tag == null)
            {
                return NotFound();
            }
            var command = new UpdateTagCommand
            {
                Id = tag.Id,
                Descricao = tag.Descricao
            };
            return View(command);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, UpdateTagCommand command)
        {
            if (id != command.Id)
            {
                return NotFound();
            }
 
            await _mediator.Send(command);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var tag = await _mediator.Send(new GetTagByIdQuery(id));
            if (tag == null)
            {
                return NotFound();
            }
            return View(tag);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _mediator.Send(new DeleteTagCommand { Id = id });
            return RedirectToAction(nameof(Index));
        }
    }
}
