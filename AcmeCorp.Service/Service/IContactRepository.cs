using AcmeCorp.Service.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AcmeCorp.Service.Service
{
    public interface IContactRepository
    {
        Task<IEnumerable<Contact>> GetAllContactAsync();
        Task<Contact> GetContactByContactIdAsync(int ContactId);
        Task<Contact> AddContactAsync(Contact Contact);
        Task<Contact> UpdateContactAsync(Contact Contact);
        Task<Contact> DeleteContactAsync(int ContactId);
    }
}
