using demoproject.Data;
using demoproject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace demoproject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactController : Controller
    {
        private readonly ContactAPIDbContext dbContext;

        //create constructor->ctor tab tab
        //inject ContactAPIDbContext ie data
        public ContactController(ContactAPIDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        public async Task<IActionResult> GetContact()
        {
            //database contacts
            return Ok(await dbContext.Contacts.ToListAsync());
            // return View();
        }

        //getting single contact
        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetSingleContact([FromRoute]Guid id)
        {
            var contact = await dbContext.Contacts.FindAsync(id);    
            if(contact==null)
            {
                return NotFound();
            }
            return Ok(contact);
        }
        [HttpPost]
        //adding contact functionality   
        //async method                                                //name of request
        public async Task<IActionResult> AddContact(AddContactRequest addContactRequest)
        {
            //using async method hence used task keyword
            //creating object
            var contact = new Contact()
            {
                Id = Guid.NewGuid(),
                Address = addContactRequest.Address,
                Email = addContactRequest.Email,
                Name = addContactRequest.Name,
                Phone = addContactRequest.Phone
            };
            await dbContext.Contacts.AddAsync(contact); //add contacts through database
            await dbContext.SaveChangesAsync();

            return Ok(contact); //return request ie contact
        }
        [HttpPut]
        //specify route ..guid ID
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateContact([FromRoute] Guid id, UpdateContactRequest updateContactRequest)
        //calling class
        {
            //implement method
            var contact = await dbContext.Contacts.FindAsync(id);
            //check contact is there or not
            if (contact != null)
            {
                //updating properties
                contact.Email = updateContactRequest.Email;
                contact.Name = updateContactRequest.Name;
                contact.Phone = updateContactRequest.Phone;
                contact.Address = updateContactRequest.Address;
                await dbContext.SaveChangesAsync();
                return Ok(contact); //updated contact is returned
            }
            return NotFound();
        }

        //delete function
        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteContact([FromRoute] Guid id)
        {
            var contact=await dbContext.Contacts.FindAsync(id);
            //if contact fouund delete it
            if(contact !=null)
            {
                dbContext.Contacts.Remove(contact);
                await dbContext.SaveChangesAsync();
                return Ok(contact);
            }
            return NotFound();
        }

    }
}
/*{
 * input:
  "name": "Aditya Shende",
  "email": "addy@gmail.com",
  "phone": 0123456789,
  "address": "Pune"
}*/