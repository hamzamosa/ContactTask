using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Shared;

namespace BlazorApp1.Pages
{
    public partial class ContactOverView
    {

        private string _slectedSort = "new";

        public string slectedSort
        {
            get { return _slectedSort; }
            set { _slectedSort = value;
                _slectedSortdic[_slectedSort]();

            }
        }

        public Dictionary<string, Action> _slectedSortdic;

        [Inject]
        public NavigationManager manager { get; set; }
        public Contact Contact { get; set; } = new Contact();
        List<Contact> contacts = ContactStore.Contacts;
        protected string Message = string.Empty;
        protected string StatusClass = string.Empty;
        protected bool Saved;


        protected override Task OnInitializedAsync()
        {
            SortElement();
            IntializeContacts();
            Saved = false;
          
            return base.OnInitializedAsync();
        }

        private void IntializeContacts() 
        {

            List<Contact> contacts = ContactStore.Contacts;


        }
        protected void SortElement()
        {
            _slectedSortdic = new Dictionary<string, Action>
            {
                ["new"] = () => contacts = contacts.OrderByDescending(co => co.id).ToList(),
                ["old"] = () => contacts = contacts.OrderBy(co => co.id).ToList(),
            };

           
           
        }
        protected async void DeleteContact(int id)
        {
            var existingContact = contacts.FirstOrDefault(c => c.id == id);

            if (existingContact != null)
            {
                // Show confirmation dialog
                bool confirmed = await js.InvokeAsync<bool>("showConfirmation", "Are you sure you want to delete this contact?");
                Task.Delay(100);
                if (confirmed)
                {
                    // Remove the contact
                    contacts.Remove(existingContact);

                    // Update UI state after deletion
                    StatusClass = "alert-success";
                    Message = "Deleted successfully";
                    Saved = true;

                    // Navigate to ContactOverview after deletion
                    manager.NavigateTo("/ContactOverView");
                }
            }
        }




    }
}
