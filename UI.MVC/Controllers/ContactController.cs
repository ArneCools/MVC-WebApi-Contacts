using Contacts.BL;
using Contacts.BL.Models;
using Contacts.DAL;
using Contacts.UI.MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace Contacts.UI.MVC.Controllers
{
    public class ContactController : Controller
    {
        private IContactManager mgr = new ContactManager();
        [HttpGet]
        public IActionResult Index()
        {
            return View(mgr.GetAllContacts(OrderByFieldName.Id));
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            return View(mgr.GetContact(id));
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            return View(mgr.GetContact(id));
        }
        
        [HttpPost]
        public IActionResult Edit(int id,Contact contact)
        {
            if (!ModelState.IsValid)
            {
                return View(contact);
            }
            mgr.ChangeContact(contact);
            return RedirectToAction("Details", new {id = id});
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult Create(CreateContactViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            mgr.AddContact(vm.Name,vm.StreetAndNumber,vm.Zipcode,vm.City,vm.Gender,vm.Birthday,vm.Phone,vm.Mobile);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            return View(mgr.GetContact(id));
        }
        
        [HttpGet]
        public IActionResult DeleteConfirmed(int id)
        {
            mgr.RemoveContact(id);
            return View();
        }
        
        
        
        
    }
}