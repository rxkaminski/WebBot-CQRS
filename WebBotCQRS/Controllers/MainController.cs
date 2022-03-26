using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebBotCQRS.Controllers
{
    public class MainController : ControllerBase
    {
        protected readonly IMediator mediator;

        public MainController(IMediator mediator)
        {
            this.mediator = mediator;
        }
    }
}
