using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TODEB_INVOICES_PROJECT.Domain.Repositories.EntityTypeRepo;
using TODEB_INVOICES_PROJECT.Domain.UnitOfWork;
using TODEB_INVOICES_PROJECT.Infrastructure.Context;
using TODEB_INVOICES_PROJECT.Infrastructure.Repositories.EntityTypeRepo;

namespace TODEB_INVOICES_PROJECT.Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;

        public UnitOfWork(ApplicationDbContext db) => this._db = db ?? throw new ArgumentNullException("Database can not to be null");


        private IUserRepository _userRepository;
        public IUserRepository UserRepository
        {
            get { return _userRepository ?? (_userRepository = new UserRepository(_db)); }

            //Singleton pattern ile de yapabiliriz.Gelen appUser repositorysi null gelirse new'leyip yeni bir repo oluşurulup return edilir,null değilse o repo return ile döndürülür.
            //get
            //{
            //    if (_appUserRepository == null) _appUserRepository = new AppUserRepository(_db);

            //    return _appUserRepository;
            //}
        }

        private IAddressRepository _addressRepository;
        public IAddressRepository AddressRepository { get { return _addressRepository ?? (_addressRepository = new AddressRepository(_db)); } }

        private IInvoiceRepository _invoiceRepository;
        public IInvoiceRepository InvoiceRepository { get { return _invoiceRepository ?? (_invoiceRepository = new InvoiceRepository(_db)); } }

        private IInvoiceLineRepository _invoiceLineRepository;
        public IInvoiceLineRepository InvoiceLineRepository { get { return _invoiceLineRepository ?? (_invoiceLineRepository = new InvoiceLineRepository(_db)); } }

        private IUserPasswordRepository _userPasswordRepository;
        public IUserPasswordRepository UserPasswordRepository { get { return _userPasswordRepository ?? (_userPasswordRepository = new UserPasswordRepository(_db)); } }

        private IUserPermissionRepository _userPermissionRepository;
        public IUserPermissionRepository UserPermissionRepository { get { return _userPermissionRepository ?? (_userPermissionRepository = new UserPermissionRepository(_db)); } }

        public async Task Commit() => await _db.SaveChangesAsync();

        public async Task ExecuteSqlRaw(string sql, params object[] paramters) => await _db.Database.ExecuteSqlRawAsync(sql, paramters);

        private bool isDisposing = false;

        public async ValueTask DisposeAsync() //ValueTask bir struct olduğu için senkron çalışma ve başarılı sonuçlanma durumlarında allocationa neden olmamaktadır.Task sınıf olduğu için GC'da her cağırıldıgında üretildiği için ram'in heap alanında gereksiz yer oluşturur.Bunun önüne geçmek için kullandık.
        {
            if (!isDisposing)
            {
                isDisposing = true;
                await DisposeAsync(true);
                GC.SuppressFinalize(this); //Unit of Work Nesnemizin tamamıyla temizlenmesini sağlayacak. (https://stackoverflow.com/questions/151051/when-should-i-use-gc-suppressfinalize)
            }
        }

        private async Task DisposeAsync(bool disposing)
        {
            if (disposing) await _db.DisposeAsync();
        }
    }
}
