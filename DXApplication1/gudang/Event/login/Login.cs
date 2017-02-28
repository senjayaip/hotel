using DevExpress.XtraBars.Navigation;
using DevExpress.XtraEditors;

namespace gudang.Event.Login
{
    public class Login
    {
        public bool AuthLogin(string username, string password)
        {
            var userid  = "admin";
            var pwd     = "admin";

            var auth = false;

            if (username == userid && password == pwd)
            {
                auth = true;
            }
            
            return auth;
        }
        

    }
}
