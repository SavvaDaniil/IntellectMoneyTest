namespace IntellectMoneyTest.Models
{
    public class UserLite
    {
        public int id { get; set; }
        public string username { get; set; }
        public string name { get; set; }

        public UserLite(int id, string username, string name)
        {
            this.id = id;
            this.username = username;
            this.name = name;
        }
    }
}
