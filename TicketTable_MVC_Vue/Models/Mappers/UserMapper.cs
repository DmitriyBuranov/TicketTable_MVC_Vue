using TicketTable_MVC_Vue.Models;
using TicketTable_MVC_Vue.Models.Dto;

namespace UserTable_MVC_Vue.Models.Mappers
{
    public class UserMapper
    {
        public static User MapFromModel(UserDto request, User? user = null)
        {
            if (user == null)
            {
                user = new User();
            }

            user.Name = request.Name;
            user.Surname = request.Surname;
            user.Patronymic = request.Patronymic;


            return user;
        }

    }
}
