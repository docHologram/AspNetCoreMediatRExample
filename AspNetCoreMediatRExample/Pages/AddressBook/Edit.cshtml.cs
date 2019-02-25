using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AspNetCoreMediatRExample.Pages.AddressBook
{
    public class EditModel : PageModel
    {
	    private readonly IMediator _mediator;

	    public EditModel(IMediator mediator) => _mediator = mediator;

		[BindProperty] public UpdateAddressRequest UpdateAddressRequest { get; set; }

        public ActionResult OnGet(string id)
		{
			var address = AddressDb.Addresses.Find(a => a.Id == Guid.Parse(id));
			this.UpdateAddressRequest = new UpdateAddressRequest
			{
				Id = address.Id.ToString(),
				City = address.City,
				Line1 = address.Line1,
				Line2 = address.Line2,
				PostalCode = address.PostalCode,
				State = address.State
			};
	        return Page();
        }

        public async Task<ActionResult> OnPost()
        {
			_ = await _mediator.Send(UpdateAddressRequest);
			return Page();
        }
    }
}