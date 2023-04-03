using AcmeCorp.Service.Data;
using AcmeCorp.Service.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AcmeCorp.Service.Service
{
   public class ContactRepository : IContactRepository
    {
        private readonly AcmeCorpDbContext _appDbContext;
        public ContactRepository(AcmeCorpDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<IEnumerable<Contact>> GetAllContactAsync()
        {
            var ContactList = await _appDbContext.Contacts.ToListAsync();
            return ContactList;
        }

        public async Task<Contact> GetContactByContactIdAsync(int ContactId)
        {
            var result = await _appDbContext.Contacts.FirstOrDefaultAsync(x => x.ContactId == ContactId);
            if (result == null)
            {
                return null;
            }

            return result;
        }

        public async Task<Contact> AddContactAsync(Contact Contact)
        {
            _appDbContext.Contacts.Add(Contact);
            await _appDbContext.SaveChangesAsync();
            return Contact;
        }


        public Task<Contact> DeleteContactAsync(int ContactId)
        {
            throw new NotImplementedException();
        }
        public async Task<Contact> UpdateContactAsync(Contact Contact)
        {
            _appDbContext.Contacts.Update(Contact);
            await _appDbContext.SaveChangesAsync();
            return Contact;

        }
    }
}
