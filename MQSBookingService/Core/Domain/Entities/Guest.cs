using Domain.DomainException;
using Domain.ValueObjects;
using Domain.UtilsTools;
using Domain.Ports;

namespace Domain.Entities
{
	public class Guest
	{
		public Guest()
		{
		}
		public int Id { get; set; }
		public string Name { get; set; }
		public string Surname { get; set; }
		public string Email { get; set; }
        public PersonId DocumentId { get; set; }	

		private void ValidaState()
		{
			if(DocumentId == null ||
				string.IsNullOrEmpty(DocumentId.IdNumber) ||
			   DocumentId.IdNumber.Length <= 3 ||
			   DocumentId.DocumentType == 0)
			{
				throw new InvalidPersonDocumentIdExcepptions();
            }
			if(string.IsNullOrEmpty(Name) || 
			   string.IsNullOrEmpty(Surname) || 
			   string.IsNullOrEmpty(Email))
			{
				throw new MissingRequeredInformation();
			}
			if (Utils.ValidatoEmail(this.Email) == false)
			{
				throw new InvalidEmailException();

            }
		}

		public async Task Save(IGuestRepository guestRepository)
		{
			this.ValidaState();
			if(this.Id == 0)
			{
				this.Id = await guestRepository.Create(this);
			}
			else
			{
                //await guestRepository.Update(this);
            }
        }
    }
}

