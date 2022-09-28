namespace AutomationPractice.Pages.ContactUs
{
    internal class InternalTeam
    {
        private string _name;
        private InternalTeam(string name) { _name = name; }
        public static InternalTeam Webmaster { get { return new InternalTeam("Webmaster"); } }
        public static InternalTeam CustomerService { get { return new InternalTeam("Customer Service"); } }
        public string Name { get => _name; }
    }
}
