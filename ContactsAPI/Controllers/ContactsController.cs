using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using ContactsAPI.Models;

namespace ContactsAPI.Controllers
{

   public class Address
    {
        public int Id { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
    }
    
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private static List<Contact> _contacts = new List<Contact>();

        // GET: api/contacts
        [HttpGet]
        public ActionResult<IEnumerable<Contact>> GetContacts()
        {
            return _contacts;
        }

        // GET: api/contacts/5
        [HttpGet("{id}", Name = "GetContact")]
        public ActionResult<Contact> GetContact(int id)
        {
            var contact = _contacts.FirstOrDefault(c => c.Id == id);
            if (contact == null)
            {
                return NotFound();
            }
            return contact;
        }

        // POST: api/contacts
        [HttpPost]
        public ActionResult<Contact> PostContact(Contact contact)
        {
            contact.Id = _contacts.Count + 1;
            _contacts.Add(contact);
            return CreatedAtAction(nameof(GetContact), new { id = contact.Id }, contact);
        }

        // PUT: api/contacts/5
        [HttpPut("{id}")]
        public IActionResult PutContact(int id, Contact contact)
        {
            var existingContact = _contacts.FirstOrDefault(c => c.Id == id);
            if (existingContact == null)
            {
                return NotFound();
            }
            existingContact.Name = contact.Name;
            existingContact.Email = contact.Email;
            existingContact.Phone = contact.Phone;
            return NoContent();
        }

        // DELETE: api/contacts/5
        [HttpDelete("{id}")]
        public IActionResult DeleteContact(int id)
        {
            var contact = _contacts.FirstOrDefault(c => c.Id == id);
            if (contact == null)
            {
                return NotFound();
            }
            _contacts.Remove(contact);
            return NoContent();
        }
    }

    [Route("api/[controller]")]
    [ApiController]
    public class AddressesController : ControllerBase
    {
        private static List<Address> _addresses = new List<Address>();

        // GET: api/addresses
        [HttpGet]
        public ActionResult<IEnumerable<Address>> GetAddresses()
        {
            return _addresses;
        }

        // GET: api/addresses/5
        [HttpGet("{id}", Name = "GetAddress")]
        public ActionResult<Address> GetAddress(int id)
        {
            var address = _addresses.FirstOrDefault(a => a.Id == id);
            if (address == null)
            {
                return NotFound();
            }
            return address;
        }

        // POST: api/addresses
        [HttpPost]
        public ActionResult<Address> PostAddress(Address address)
        {
            address.Id = _addresses.Count + 1;
            _addresses.Add(address);
            return CreatedAtAction(nameof(GetAddress), new { id = address.Id }, address);
        }

        // PUT: api/addresses/5
        [HttpPut("{id}")]
        public IActionResult PutAddress(int id, Address address)
        {
            var existingAddress = _addresses.FirstOrDefault(a => a.Id == id);
            if (existingAddress == null)
            {
                return NotFound();
            }
            existingAddress.Street = address.Street;
            existingAddress.City = address.City;
            existingAddress.State = address.State;
            existingAddress.ZipCode = address.ZipCode;
            return NoContent();
        }

        // DELETE: api/addresses/5
        [HttpDelete("{id}")]
        public IActionResult DeleteAddress(int id)
        {
            var address = _addresses.FirstOrDefault(a => a.Id == id);
            if (address == null)
            {
                return NotFound();
            }
            _addresses.Remove(address);
            return NoContent();
        }
    }
}
