
using Microsoft.AspNetCore.Components;
using Shared;


namespace BlazorApp1.Pages
{
    public partial class ContactEdit
    {

       


        [Parameter]
        public string id { get; set; }
        [Inject]
        public NavigationManager manager { get; set; }
        public Contact Contact { get; set; } = new Contact();
        List<Contact> contacts = ContactStore.Contacts;
        protected string Message = string.Empty;
        protected string StatusClass = string.Empty;
        protected bool Saved;
        
        protected override Task OnInitializedAsync()
        {
            IntializeContacts();

          
           
            return base.OnInitializedAsync();
        }

        private void IntializeContacts()
        {
            Saved = false;
            List<Contact> contacts = ContactStore.Contacts;
            int.TryParse(id, out var contactId);


            if (contactId == 0) 
            {



            }
            else 
            {
                Contact = contacts.FirstOrDefault(con => con.id == int.Parse(id));

            }


        }

        protected  void handleValidSubmit() 
        {
        

            if (Contact.id == 0) 
            {
                Contact.id=contacts.Count+1;
                contacts.Add(Contact);

                StatusClass = "alert-success";
                Message = "New Contact added successfully";
                Saved = true;
               // Contact = new Contact();
            }
            else 
            {
                var existingContact = contacts.FirstOrDefault(c => c.id == Contact.id);
                if (existingContact != null)
                {
                    existingContact.firstName = Contact.firstName;
                    existingContact.lastNmae = Contact.lastNmae;
                    existingContact.email = Contact.email;
                    existingContact.phoneNumber = Contact.phoneNumber;

                    StatusClass = "alert-success";
                    Message = "Contact updated successfully";
                    Saved = true;
                   // Contact = new Contact(); 
                }


            }
        
        }

         protected void handInleValidSubmit() 
        {
            StatusClass = "alert-danger";
            Message = "There are some thing errors, please try again.";

        }

        protected async void DeleteContact() 
        {
            var existingContact = contacts.FirstOrDefault(c => c.id == Contact.id);
            contacts.Remove(existingContact);
            StatusClass = "alert-success";
            Message = "Deleted  successfully";
            Saved = true;

            manager.NavigateTo("/ContactOverView");

        }
        protected void NavigateToOverView() 
        {
            manager.NavigateTo("/ContactOverView");
        
        }



    }
}
