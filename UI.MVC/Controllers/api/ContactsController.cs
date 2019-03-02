using System.Collections.Generic;
using System.Linq;
using Contacts.BL;
using Contacts.BL.Models;
using Contacts.UI.MVC.Models.dto;
using Microsoft.AspNetCore.Mvc;

namespace Contacts.UI.MVC.Controllers.api
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactsController : ControllerBase
    {
        IContactManager mgr = new ContactManager();
        [HttpPost("{id}/blocked")]
        public IActionResult Block(int id, bool blocked)
        {
            Contact contact = mgr.GetContact(id);
            if (contact == null)
            {
                return NotFound();
            }

            contact.Blocked = blocked;
            mgr.ChangeContact(contact);
            return NoContent();
        }

        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Contact> contacts = mgr.GetAllContacts(OrderByFieldName.Id);
            if (!contacts.Any())
            {
                return NoContent();
            }
            List<ContactDto> contactDtos = new List<ContactDto>();
            foreach (Contact contact in contacts)
            {
                contactDtos.Add(new ContactDto()
                {
                    Name = contact.Name,
                    Adress = contact.Adress,
                    Birthday = contact.Birthday,
                    Blocked = contact.Blocked,
                    Gender = contact.Gender,
                    Mobile = contact.Mobile,
                    PersonId = contact.PersonId,
                    Phone = contact.Phone
                });
            }
            return Ok(contactDtos);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Contact contact = mgr.GetContact(id);
            if (contact == null)
            {
                return NotFound();
            }
            mgr.RemoveContact(id);
            return NoContent();
        }
        
        
    }
}