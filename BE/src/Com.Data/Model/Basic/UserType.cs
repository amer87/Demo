using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Com.Repo")]
namespace Com.Data
{
    [Table("UserTypes")]
    internal class UserType : BaseType
    {
    }
}