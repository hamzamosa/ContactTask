using Microsoft.AspNetCore.Components;
using Shared;

namespace BlazorApp1.Pages
{
    public partial class ContactDetails
    {
        [Parameter]
        public string id { get; set; }
        public Contact Contact { get; set; }= new Contact();
        List<Contact> contacts = ContactStore.Contacts;

        protected override Task OnInitializedAsync()
        {
            IntializeContacts();
            Contact = contacts.FirstOrDefault(con => con.id == int.Parse(id));
            return base.OnInitializedAsync();
        }

        private void IntializeContacts()
        {

            List<Contact> contacts = ContactStore.Contacts;


        }
    }
}
