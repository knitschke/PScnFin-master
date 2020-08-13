
namespace PScnFin
{
    public class UsersModel
    {
        public string pc_name { get; set; }
        public string ip { get; set; }

        public string full
        {
            get
            {
                return $"{pc_name} {ip}";
            }
        }
    }
}
