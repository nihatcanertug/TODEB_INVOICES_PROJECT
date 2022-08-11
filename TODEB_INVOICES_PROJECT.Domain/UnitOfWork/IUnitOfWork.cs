using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TODEB_INVOICES_PROJECT.Domain.Repositories.EntityTypeRepo;

namespace TODEB_INVOICES_PROJECT.Domain.UnitOfWork
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        //Repository'lerde açtığımız ve kullanmak istediğimiz interfaceleri ekliyoruz.
        IInvoiceRepository InvoiceRepository { get; }
        IAddressRepository AddressRepository { get; }
        IInvoiceLineRepository InvoiceLineRepository { get; }
        IUserRepository UserRepository { get; }
        IUserPermissionRepository UserPermissionRepository { get; }
        IUserPasswordRepository UserPasswordRepository { get; }

        Task Commit(); //Başarılı bir işlemin sonucunda çalıştırılır. İşlemin başlamasından itibaren tüm değişikliklerin veri tabanına uygulanmasını temin eder.

        Task ExecuteSqlRaw(string sql, params object[] paramters); //Mevcut sql sorgularımızı doğrudan veri tabanında yürütmek için kullanılan bir method.Saf sql sorgusu atmak için kullanıyoruz.
    }
}
