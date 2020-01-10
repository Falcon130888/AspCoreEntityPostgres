using System.ComponentModel.DataAnnotations;

namespace AspCoreEntityPostgres.ViewModel
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Не указан логин")]
        public string UserLogin { get; set; }

        [Required(ErrorMessage = "Не указан пароль")]
        [DataType(DataType.Password)]
        public string UserPassword { get; set; }
    }
}