namespace Parviz.JwtApp.Back.Core.Domain
{
    public class AppRole
    {
        public int Id { get; set; }
        public string? Definition { get; set; }
        public List<AppUser>? AppUsers { get; set; }

        //Biz burada kanstraktrdan ona gore istifade etdik ki, null qaytarmasin ve bos ornek yaratsin.

        //public AppRole()
        //{
        //    AppUsers=new List<AppUser>();
        //}
        //public AppRole(List<AppUser> appUsers)
        //{
        //    AppUsers = appUsers;
        //}
    }
}
