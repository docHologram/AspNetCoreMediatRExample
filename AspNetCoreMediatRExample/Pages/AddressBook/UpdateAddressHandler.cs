using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace AspNetCoreMediatRExample.Pages.AddressBook
{
	public class UpdateAddressHandler : IRequestHandler<UpdateAddressRequest, AddressBookEntry>
	{
		public async Task<AddressBookEntry> Handle(UpdateAddressRequest request, CancellationToken cancellationToken)
		{
			var entry = AddressBookEntry.Update(request.Id, request.Line1, request.Line2, request.City, request.State,
				request.PostalCode);
			var addressToUpdateIndex = AddressDb.Addresses.FindIndex(a => a.Id == entry.Id);
			AddressDb.Addresses[addressToUpdateIndex] = entry;
			return await Task.FromResult(entry);
		}
	}
}
